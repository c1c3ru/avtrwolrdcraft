import json
import struct
import unittest
from pathlib import Path
import sys

ROOT = Path(__file__).resolve().parents[1]
sys.path.insert(0, str(ROOT / "tools"))
import recon_navigation as nav
import recon_stage_handler_effects as rsh


class StageHandlerEffectsTest(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.binary = (rsh.SOURCE / "libil2cpp.so").read_bytes()
        cls.metadata = (rsh.SOURCE / "global-metadata.dat").read_bytes()
        nav.verify_pair(cls.binary, cls.metadata)
        cls.elf = nav.Elf(cls.binary)
        cls.meta = nav.Metadata(cls.metadata)
        rows, resolve = nav.load_index(rsh.INDEX, cls.elf, cls.meta)
        cls.rows = rows
        cls.resolve = staticmethod(resolve)

    def mutate(self, address, new_word):
        altered = bytearray(self.binary)
        struct.pack_into("<I", altered, self.elf.offset(address, 4), new_word)
        return nav.Elf(bytes(altered))

    def test_background_planet_sound_guard_detected(self):
        mutated = self.mutate(0x206947c, 0x14000000)  # replace b.lt with plain B
        with self.assertRaises(ValueError):
            rsh.analyze_background_planet_sound(mutated, self.meta, self.resolve, [], 0x2069448, 0x20694d4)

    def test_persistent_data_thunk_detected(self):
        mutated = self.mutate(0x21e09b0, 0xd503201f)  # replace tail-jump with NOP
        with self.assertRaises(ValueError):
            rsh.analyze_persistent_data_save(mutated, self.meta, self.resolve, 0x21e09b0, 0x21e0a48)

    def test_level_manager_stage2_field_write_detected(self):
        mutated = self.mutate(0x2313e68, 0xd65f03c0)  # replace strb with RET
        with self.assertRaises(ValueError):
            rsh.analyze_level_manager_stage2(mutated)

    def test_level_manager_stage3_write_barrier_detected(self):
        mutated = self.mutate(0x2313edc, 0x14000000)  # branch elsewhere instead of write-barrier helper
        with self.assertRaises(ValueError):
            rsh.analyze_level_manager_stage3(mutated, self.meta)

    def test_on_active_scene_changed_flag_write_detected(self):
        mutated = self.mutate(0x20726c0, 0x39000000)  # strb to a different (zero) base register
        with self.assertRaises(ValueError):
            rsh.analyze_on_active_scene_changed(mutated, self.meta)

    def test_real_pair_analyzers_succeed(self):
        self.assertTrue(rsh.analyze_background_planet_sound(
            self.elf, self.meta, self.resolve, [], 0x2069448, 0x20694d4)["effects"])
        self.assertTrue(rsh.analyze_persistent_data_save(
            self.elf, self.meta, self.resolve, 0x21e09b0, 0x21e0a48)["effects"])
        self.assertTrue(rsh.analyze_level_manager_stage2(self.elf)["effects"])
        self.assertTrue(rsh.analyze_level_manager_stage3(self.elf, self.meta)["effects"])
        self.assertTrue(rsh.analyze_on_active_scene_changed(self.elf, self.meta)["effects"])

    def test_outputs_match_known_field_identities(self):
        report_path = ROOT / "reports/recon/stage_handler_effects_2026-11-08.json"
        report = json.loads(report_path.read_text(encoding="utf-8"))
        ids = {h["id"] for h in report["handlers"]}
        self.assertEqual(ids, {
            "BackgroundPlanetSoundHandler.OnBeforeSceneLoadStage1",
            "PersistentDataManager.OnBeforeSceneLoadStage2",
            "LevelManager.OnBeforeSceneLoadStage2",
            "LevelManager.OnBeforeSceneLoadStage3",
            "GameSceneManager.OnActiveSceneChanged",
        })
        for task_dir in ["T025/HANDLER/00005600", "T025/HANDLER/00006e43", "T025/HANDLER/0000849b",
                          "T025/HANDLER/0000849c", "T025/HANDLER/000056fb"]:
            for name in ["method-contract.json", "control-flow.json", "unknowns.jsonl", "result.json"]:
                self.assertTrue((ROOT / "out/recon/tasks" / task_dir / name).is_file(), f"missing {task_dir}/{name}")


if __name__ == "__main__":
    unittest.main()
