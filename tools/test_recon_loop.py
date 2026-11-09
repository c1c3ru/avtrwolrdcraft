"""Convergence, ledger validation and prompt rendering for recon_loop."""
import os
import tempfile
import unittest
from pathlib import Path

import recon_loop as loops


def rows(*items):
    return [{'unit': u, 'grade': g, 'iteration': i, 'evidence': 'x', **({'reason': 'r'} if g in 'CU' else {})}
            for u, g, i in items]


class LoopTests(unittest.TestCase):
    registry = loops.load_registry()
    static = loops.get_loop(registry, 'L01')

    def test_registry_has_eight_loops_and_all_render(self):
        self.assertEqual(len(self.registry['loops']), 8)
        for loop in self.registry['loops']:
            text = loops.render(self.registry, loop)
            self.assertIn(loop['id'], text)
            self.assertNotIn('${', text)

    def test_converges_only_when_every_unit_is_a_b_or_justified_u(self):
        units = loops.list_units(self.static)
        done = rows(*[(u, 'A', 1) for u in units[:-1]])
        self.assertEqual(loops.evaluate(self.static, done, units)['verdict'], 'open')
        done += rows((units[-1], 'U', 2))
        self.assertEqual(loops.evaluate(self.static, done, units)['verdict'], 'converged')

    def test_grade_c_blocks_convergence_in_static_loops(self):
        units = loops.list_units(self.static)
        result = loops.evaluate(self.static, rows(*[(u, 'C', 1) for u in units]), units)
        self.assertEqual(result['verdict'], 'open')
        self.assertEqual(result['unresolved_C'], len(units))

    def test_stall_after_three_quiet_iterations(self):
        units = loops.list_units(self.static)
        history = rows((units[0], 'B', 1), (units[0], 'B', 2), (units[0], 'B', 3), (units[0], 'B', 4))
        result = loops.evaluate(self.static, history, units)
        self.assertEqual(result['verdict'], 'stalled')
        self.assertEqual(result['quiet_iterations'], 3)

    def test_upgrade_counts_as_progress(self):
        units = loops.list_units(self.static)
        history = rows((units[0], 'C', 1), (units[0], 'C', 2), (units[0], 'B', 3), (units[0], 'B', 4))
        self.assertEqual(loops.evaluate(self.static, history, units)['verdict'], 'open')

    def test_max_iterations(self):
        units = loops.list_units(self.static)
        history = rows((units[0], 'B', 1), (units[1], 'B', 25))
        self.assertEqual(loops.evaluate(self.static, history, units)['verdict'], 'max_iterations')

    def test_row_validation(self):
        good = {'unit': '1', 'grade': 'C', 'iteration': 1, 'evidence': 'e', 'reason': 'r'}
        loops.validate_row(good, {'1'})
        for bad in ({**good, 'grade': 'Z'}, {**good, 'reason': ''}, {**good, 'evidence': ''},
                    {**good, 'iteration': 0}, {**good, 'unit': '99'}):
            with self.assertRaises(loops.LoopError):
                loops.validate_row(bad, {'1'})

    def test_record_roundtrip_and_latest_wins(self):
        with tempfile.TemporaryDirectory() as tmp:
            loops.record('L01', '1', 'C', 1, 'e', 'r', ledger_dir=tmp, registry=self.registry)
            loops.record('L01', '1', 'A', 2, 'e2', ledger_dir=tmp, registry=self.registry)
            latest = loops.latest_by_unit(loops.read_ledger('L01', tmp))
            self.assertEqual(latest['1']['grade'], 'A')

    def test_sweep_units_come_from_dump_and_next_skips_graded(self):
        sweep = loops.get_loop(self.registry, 'L08')
        with tempfile.TemporaryDirectory() as tmp:
            level = Path(tmp) / 'Game/Level/Sub'
            level.mkdir(parents=True)
            for name in ('LevelA', 'LevelB'):
                (level.parent / f'{name}.cs').write_text('class X{}')
            (level / 'Inner.cs').write_text('class Y{}')
            os.environ['RECON_DUMP_ROOT'] = tmp
            try:
                units = loops.list_units(sweep)
                self.assertEqual(sorted(units), ['Game/Level/LevelA', 'Game/Level/LevelB', 'Game/Level/Sub/Inner'])
                graded = rows((units[0], 'C', 1))
                self.assertNotIn(units[0], loops.next_units(sweep, graded, units, 5)[:2])
                full = rows(*[(u, 'C', 1) for u in units])
                self.assertEqual(loops.evaluate(sweep, full, units)['verdict'], 'converged')
            finally:
                del os.environ['RECON_DUMP_ROOT']


if __name__ == '__main__':
    unittest.main()
