"""Loop registry: renders prompts, tracks a graded ledger and decides convergence.

Does not run agents or touch the game; it only reads docs/loops/loops.json, an
optional class tree and out/recon/loops/<ID>/ledger.jsonl.
"""
import argparse
import json
import os
import string
import sys
from datetime import datetime, timezone
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent
REGISTRY = ROOT / 'docs/loops/loops.json'
TEMPLATE = ROOT / 'docs/loops/PROMPT_TEMPLATE.md'
LEDGER_DIR = ROOT / 'out/recon/loops'
RANK = {'U': 0, 'C': 1, 'B': 2, 'A': 3}
DEFAULT_MAX_ITERATIONS = 25
STALL_WINDOW = 3


class LoopError(Exception):
    pass


def load_registry(path=REGISTRY):
    data = json.loads(Path(path).read_text(encoding='utf-8'))
    ids = [loop['id'] for loop in data['loops']]
    if len(ids) != len(set(ids)):
        raise LoopError('duplicate loop ids')
    for loop in data['loops']:
        if not loop.get('units') and 'unit_source' not in loop:
            raise LoopError(f"{loop['id']}: needs units or unit_source")
        for key in ('title', 'goal', 'stop', 'task_ref'):
            if not loop.get(key):
                raise LoopError(f"{loop['id']}: missing {key}")
    return data


def get_loop(registry, loop_id):
    for loop in registry['loops']:
        if loop['id'] == loop_id:
            return loop
    raise LoopError(f'unknown loop {loop_id}')


def ledger_path(loop_id, ledger_dir=LEDGER_DIR):
    return Path(ledger_dir) / loop_id / 'ledger.jsonl'


def read_ledger(loop_id, ledger_dir=LEDGER_DIR):
    path = ledger_path(loop_id, ledger_dir)
    if not path.exists():
        return []
    rows = []
    for number, line in enumerate(path.read_text(encoding='utf-8').splitlines(), 1):
        if line.strip():
            try:
                rows.append(json.loads(line))
            except json.JSONDecodeError as error:
                raise LoopError(f'{path}:{number}: {error}') from error
    return rows


def dump_root(loop):
    source = loop['unit_source']
    return Path(os.environ.get(source['root_env']) or ROOT / source['default_root'])


def list_units(loop):
    """Return ordered unit ids. Static loops use 1..N; class loops scan the dump."""
    if 'unit_source' not in loop:
        return [str(i) for i in range(1, len(loop['units']) + 1)]
    root = dump_root(loop)
    if not root.is_dir():
        raise LoopError(f'class root not found: {root} (set {loop["unit_source"]["root_env"]})')
    files = sorted(root.glob(loop['unit_source']['glob']))
    return [f.relative_to(root).with_suffix('').as_posix() for f in files]


def latest_by_unit(rows):
    latest = {}
    for row in rows:
        latest[row['unit']] = row
    return latest


def validate_row(row, units=None):
    if row.get('grade') not in RANK:
        raise LoopError('grade must be one of A, B, C, U')
    if not isinstance(row.get('iteration'), int) or row['iteration'] < 1:
        raise LoopError('iteration must be an integer >= 1')
    if not row.get('evidence'):
        raise LoopError('evidence is required')
    if row['grade'] in ('C', 'U') and not row.get('reason'):
        raise LoopError('reason is required for grade C or U')
    if units is not None and row['unit'] not in units:
        raise LoopError(f"unknown unit {row['unit']}")


def progress_by_iteration(rows):
    """Count, per iteration, units newly seen or whose grade improved."""
    best = {}
    gains = {}
    for row in sorted(rows, key=lambda r: r['iteration']):
        rank = RANK[row['grade']]
        previous = best.get(row['unit'])
        if previous is None or rank > previous:
            gains[row['iteration']] = gains.get(row['iteration'], 0) + 1
        best[row['unit']] = max(rank, previous if previous is not None else rank)
        gains.setdefault(row['iteration'], 0)
    return gains


def evaluate(loop, rows, units):
    latest = latest_by_unit(rows)
    graded = [u for u in units if u in latest]
    counts = {g: sum(1 for u in graded if latest[u]['grade'] == g) for g in RANK}
    missing = len(units) - len(graded)
    is_sweep = 'unit_source' in loop
    unresolved = counts['C'] if not is_sweep else 0
    last_iteration = max((r['iteration'] for r in rows), default=0)
    gains = progress_by_iteration(rows)
    quiet = 0
    for iteration in range(last_iteration, 0, -1):
        if gains.get(iteration, 0) == 0:
            quiet += 1
        else:
            break
    limit = loop.get('max_iterations', DEFAULT_MAX_ITERATIONS)
    if missing == 0 and unresolved == 0:
        verdict = 'converged'
    elif last_iteration >= limit:
        verdict = 'max_iterations'
    elif quiet >= STALL_WINDOW:
        verdict = 'stalled'
    else:
        verdict = 'open'
    return {
        'id': loop['id'], 'verdict': verdict, 'total': len(units), 'graded': len(graded),
        'missing': missing, 'grades': counts, 'unresolved_C': unresolved,
        'last_iteration': last_iteration, 'quiet_iterations': quiet, 'max_iterations': limit,
    }


def next_units(loop, rows, units, count):
    latest = latest_by_unit(rows)
    pending = [u for u in units if u not in latest]
    weak = sorted((u for u in units if u in latest and RANK[latest[u]['grade']] < RANK['B']),
                  key=lambda u: RANK[latest[u]['grade']])
    return (pending + weak)[:count]


def bullet(items, numbered=False):
    return '\n'.join(f'{i}. {t}' if numbered else f'- {t}' for i, t in enumerate(items, 1)) or '- (nenhum)'


def render(registry, loop, template=TEMPLATE):
    if 'unit_source' in loop:
        units = ('Cada classe de `{glob}` sob `{root}` é uma unidade (id = caminho relativo sem `.cs`). '
                 'Trabalhe em lotes por família (prefixo/herança) com `next {id} --n 25`; uma sonda por família, '
                 'um registro por classe. A contagem real vem do disco, não do número citado no pedido.'
                 ).format(glob=loop['unit_source']['glob'], root=loop['unit_source']['default_root'], id=loop['id'])
    else:
        units = bullet(loop['units'], numbered=True) + '\n(ids de unidade: 1..%d)' % len(loop['units'])
    grades = '\n'.join(f'- **{g}** — {t}' for g, t in registry['grades'].items())
    values = {
        'id': loop['id'], 'title': loop['title'], 'task_ref': loop['task_ref'],
        'premise': registry['premise'], 'goal': loop['goal'],
        'known_facts': bullet(loop.get('known_facts', [])),
        'seed_docs': ', '.join(f'`{d}`' for d in loop.get('seed_docs', [])) or '(nenhum)',
        'seed_tools': ', '.join(f'`{d}`' for d in loop.get('seed_tools', [])) or '(nenhum)',
        'ledger': f'out/recon/loops/{loop["id"]}/ledger.jsonl',
        'units': units, 'grades': grades, 'stop': loop['stop'],
        'max_iterations': loop.get('max_iterations', DEFAULT_MAX_ITERATIONS),
    }
    return string.Template(Path(template).read_text(encoding='utf-8')).substitute(values)


def record(loop_id, unit, grade, iteration, evidence, reason=None, ledger_dir=LEDGER_DIR, registry=None):
    registry = registry or load_registry()
    loop = get_loop(registry, loop_id)
    row = {'unit': unit, 'grade': grade, 'iteration': iteration, 'evidence': evidence,
           'ts': datetime.now(timezone.utc).isoformat(timespec='seconds')}
    if reason:
        row['reason'] = reason
    validate_row(row, set(list_units(loop)))
    path = ledger_path(loop_id, ledger_dir)
    path.parent.mkdir(parents=True, exist_ok=True)
    with path.open('a', encoding='utf-8') as handle:
        handle.write(json.dumps(row, ensure_ascii=False) + '\n')
        handle.flush()
        os.fsync(handle.fileno())
    return row


def main(argv=None):
    parser = argparse.ArgumentParser(description=__doc__)
    sub = parser.add_subparsers(dest='cmd', required=True)
    sub.add_parser('list')
    p = sub.add_parser('render')
    p.add_argument('id', nargs='?')
    p.add_argument('--all', action='store_true')
    p.add_argument('--out')
    p = sub.add_parser('status')
    p.add_argument('id', nargs='?')
    p = sub.add_parser('next')
    p.add_argument('id')
    p.add_argument('--n', type=int, default=10)
    p = sub.add_parser('record')
    p.add_argument('id')
    p.add_argument('--unit', required=True)
    p.add_argument('--grade', required=True)
    p.add_argument('--iteration', type=int, required=True)
    p.add_argument('--evidence', required=True)
    p.add_argument('--reason')
    args = parser.parse_args(argv)
    try:
        registry = load_registry()
        if args.cmd == 'list':
            for loop in registry['loops']:
                print(f"{loop['id']}  {loop['task_ref']}  {loop['title']}")
        elif args.cmd == 'render':
            loops = registry['loops'] if args.all else [get_loop(registry, args.id)]
            for loop in loops:
                text = render(registry, loop)
                if args.out:
                    target = Path(args.out)
                    target.mkdir(parents=True, exist_ok=True)
                    (target / f"{loop['id']}.md").write_text(text, encoding='utf-8')
                else:
                    print(text)
        elif args.cmd == 'status':
            loops = [get_loop(registry, args.id)] if args.id else registry['loops']
            for loop in loops:
                try:
                    units = list_units(loop)
                except LoopError as error:
                    print(json.dumps({'id': loop['id'], 'verdict': 'blocked', 'error': str(error)}, ensure_ascii=False))
                    continue
                print(json.dumps(evaluate(loop, read_ledger(loop['id']), units), ensure_ascii=False))
        elif args.cmd == 'next':
            loop = get_loop(registry, args.id)
            for unit in next_units(loop, read_ledger(args.id), list_units(loop), args.n):
                print(unit)
        elif args.cmd == 'record':
            print(json.dumps(record(args.id, args.unit, args.grade, args.iteration, args.evidence,
                                    args.reason, registry=registry), ensure_ascii=False))
    except LoopError as error:
        print(f'error: {error}', file=sys.stderr)
        return 2
    return 0


if __name__ == '__main__':
    sys.exit(main())
