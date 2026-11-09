"""Static proof of drop-target priority and eligibility (SortDropAreas, CompareConsumers,
IsDroppableUnderItem, PerformBasicTests). Reads libil2cpp.so and global-metadata.dat only."""
import argparse
from pathlib import Path

import recon_callback_probe as callback
import recon_load_scene_pipeline as pipe
import recon_navigation as nav
import recon_t031_dispatch as dispatch

WINDOWS = {  # name -> (start, exclusive stop = next metadata method)
    'SortDropAreas': (0x227f574, 0x227f638),
    'CompareConsumers': (0x22c3fd4, 0x22c4350),
    'IsDroppableUnderItem': (0x23544e0, 0x235468c),
    'PerformBasicTests': (0x235468c, 0x2354750),
}
COMPARE_TOKEN = '0x06007d66'


def mov_x(dst, src):
    return 0xaa0003e0 | (src << 16) | dst


def mov_w_imm(dst, imm):
    return 0x52800000 | (imm << 5) | dst


def word_is(elf, address, expected):
    actual = nav.word(elf, address)
    nav.require(actual == expected, f'instruction mismatch at {address:#x}: {actual:#x} != {expected:#x}')


def branch_is(elf, address, kind, target):
    control = nav.branch(address, nav.word(elf, address))
    nav.require(control and control['kind'] == kind and control['target'] == target,
                f'branch mismatch at {address:#x}: {control}')


def named_sequence(elf, resolve, window):
    calls = pipe.controls(elf, resolve, *window)
    return [(a, pipe.label(c['rows'][0])) for a, c in sorted(calls.items()) if c['rows']], calls


def prove_sort(elf, meta, resolve, rows):
    nav.require(callback.typedef_name(meta, nav.metadata_usage(
        elf, nav.adrp_ldr(elf, 0x227f580, 0x227f588)['got_vaddr'])) == 'PWC.Level.LevelDropArea', 'sort class mismatch')
    pipe.at(elf, 0x227f5f4, pipe.LDR_X, rt=19, rn=8, imm=0)  # static +0x0 = LevelDropArea.List
    usage = nav.metadata_usage(elf, nav.adrp_ldr(elf, 0x227f5d0, 0x227f5dc)['got_vaddr'])
    target = [r for r in rows if r['token'] == COMPARE_TOKEN]
    nav.require(usage['kind'] == 3 and len(target) == 1 and usage['index'] == target[0]['method_definition_index']
                and target[0]['name'] == 'CompareConsumers', 'sort comparator is not CompareConsumers')
    word_is(elf, 0x227f600, mov_x(1, 31))  # delegate target = null (static method)
    branch_is(elf, 0x227f60c, 'BL', 0x27fb274)
    branch_is(elf, 0x227f630, 'B', 0x2cf2280)
    return {'list': 'LevelDropArea.List (static +0x0)', 'comparator': 'LevelConsumers.CompareConsumers (static delegate)',
            'unresolved': ['Comparison ctor 0x27fb274 and List.Sort 0x2cf2280 are generic instantiations without a name']}


def prove_compare(elf, meta, resolve, rows):
    iface = sorted((r for r in rows if r['declaring_type'] == 'PWC.Level.ILevelConsumer'), key=lambda r: r['token'])
    order = [r['name'] for r in iface]
    nav.require(order[0] == 'GetEntity' and order[2] == 'GetSortPriority' and order[4] == 'GetSortingElement',
                'ILevelConsumer slot order changed')
    # (site of the slot-index move, slot, site of `mov x0,receiver`, receiver: 21=lhs / 19=rhs)
    expected = [(0x22c405c, 2, 0x22c4060, 21), (0x22c40c0, 2, 0x22c40c4, 19), (0x22c4124, 0, 0x22c4120, 21),
                (0x22c4180, 0, 0x22c417c, 19), (0x22c4220, 4, 0x22c4224, 21), (0x22c4280, 4, 0x22c4284, 19)]
    for site, slot, receiver_site, receiver in expected:
        word_is(elf, site, 0x2a1f03e2 if slot == 0 else mov_w_imm(2, slot))
        word_is(elf, receiver_site, mov_x(0, receiver))
    for site in (0x22c4084, 0x22c40e8, 0x22c4144, 0x22c41a0, 0x22c4248, 0x22c42a8):
        nav.require(nav.branch(site, nav.word(elf, site))['kind'] == 'BLR', f'interface invoke not BLR at {site:#x}')
    names, _ = named_sequence(elf, resolve, WINDOWS['CompareConsumers'])
    nav.require([n for _, n in names] == ['Int32.CompareTo', 'Object.op_Equality', 'Object.op_Equality',
                                          'SortingElement.GetSortingOrderForY', 'SortingElement.GetSortingOrderForY',
                                          'Int64.CompareTo'], 'comparator call sequence changed')
    # Null-entity stage: lhs entity (x22) / rhs entity (x0); -1 when only lhs exists, +1 when only rhs exists.
    for site, kind, target in [(0x22c41a8, 'CBNZ', 0x22c41c0), (0x22c41c0, 'CBZ', 0x22c41d0), (0x22c41c4, 'CBNZ', 0x22c41d0),
                               (0x22c41d0, 'CBZ', 0x22c41f0), (0x22c41d4, 'CBNZ', 0x22c41f0),
                               (0x22c42f4, 'TBNZ', 0x22c41ac), (0x22c42fc, 'TBZ', 0x22c41c8), (0x22c4304, 'TBZ', 0x22c41d8),
                               (0x22c4334, 'B.cond', 0x22c41ac)]:
        branch_is(elf, site, kind, target)
    word_is(elf, 0x22c41c8, 0x12800000)          # mov w0,#-1
    word_is(elf, 0x22c41d8, mov_w_imm(0, 1))     # mov w0,#1
    # Ties fall back to rhsPriority.CompareTo(lhsPriority): this=&rhs (sp+0xc), argument=lhs (w20).
    word_is(elf, 0x22c40ec, 0xb9000fe0)          # str w0,[sp,#0xc]  (rhs priority)
    word_is(elf, 0x22c4094, 0x2a0003f4)          # mov w20,w0        (lhs priority)
    word_is(elf, 0x22c41ac, 0x910033e0)          # add x0,sp,#0xc
    word_is(elf, 0x22c41b0, 0x2a1403e1)          # mov w1,w20
    # Sorting-order stage: rhsOrder.CompareTo(lhsOrder).
    word_is(elf, 0x22c431c, mov_x(21, 0))        # lhs order kept in x21
    word_is(elf, 0x22c4330, 0xf90003e0)          # str x0,[sp] (rhs order)
    word_is(elf, 0x22c433c, mov_x(1, 21))
    return {
        'consumer_interface_slots': {'0': order[0], '2': order[2], '4': order[4]},
        'order': [
            '1. if both GetEntity() are null: higher GetSortPriority() first',
            '2. entity present before entity absent',
            '3. both entities present: SortingElement present before absent (UnityEngine.Object null check)',
            '4. both present: higher SortingElement.GetSortingOrderForY() first; equal -> higher GetSortPriority() first',
        ],
        'direction': 'descending: rhs.CompareTo(lhs) for both priority and sorting order',
    }


def prove_droppable(elf, meta, resolve, rows):
    names, calls = named_sequence(elf, resolve, WINDOWS['IsDroppableUnderItem'])
    expected = ['Object.op_Equality', 'LevelAreaBase.GetWorldXBounds', 'LevelDropAreaQuery.PerformBasicTests',
                'CShape.UpdateTransformDataIfNeeded', 'CShape.IsPointInsideShape', 'LevelItem.HasTouchShapeOverride',
                'LevelAreaBase.GetWorldBounds', 'CShapeModel.IsTouching', 'Component.get_transform',
                'LevelUtils.IsTouchingGameShapeAreaVisibleToUser']
    nav.require([n for _, n in names] == expected, 'IsDroppableUnderItem call sequence changed')
    pipe.at(elf, 0x2354548, pipe.STRB, rt=31, rn=19, imm=0)      # isTouchingOnly = false on entry
    pipe.at(elf, 0x23545cc, pipe.STRB, rt=31, rn=19, imm=0)      # ... and when the pointer is inside the shape
    pipe.at(elf, 0x235465c, pipe.STRB, rt=0, rn=19, imm=0)       # = true only after the touch tests
    word_is(elf, 0x2354658, mov_w_imm(0, 1))
    pipe.at(elf, 0x235459c, pipe.LDR_X, rt=0, rn=22, imm=0x20)   # consumer._cShape (LevelAreaBase +0x20)
    pipe.at(elf, 0x235461c, pipe.LDR_X, rt=0, rn=8, imm=0x38)    # CShape.cShapeModel (+0x38)
    pipe.at(elf, 0x2354624, pipe.LDR_X, rt=1, rn=20, imm=0x58)   # touchGameShape._cShapeModel (+0x58)
    word_is(elf, 0x2354604, 0x1e212800)                          # fadd s0,s0,s1  (center.y + extents.y)
    branch_is(elf, 0x235460c, 'B.cond', 0x2354664)               # b.mi -> return false
    branch_is(elf, 0x23545e8, 'TBNZ', 0x2354610)                 # HasTouchShapeOverride skips the height test
    branch_is(elf, 0x2354598, 'TBZ', 0x2354664)                  # PerformBasicTests false -> false
    word_is(elf, 0x2354570, 0x9a9612f6)                          # csel x22,x23,x22,ne (consumer selection)
    branch_is(elf, 0x2354574, 'CBZ', 0x2354688)                  # null consumer raises
    return {
        'consumer': 'overrideConsumerAreaForTest == null ? dropArea : override',
        'steps': [
            'PerformBasicTests(dropArea, levelItem, consumer.GetWorldXBounds(), itemXBounds) else false',
            'consumer._cShape.IsPointInsideShape(position) -> true, isTouchingOnly=false',
            'unless levelItem.HasTouchShapeOverride(): position.y > consumer.GetWorldBounds() top (center.y+extents.y) -> false',
            'consumer cShapeModel.IsTouching(touchGameShape._cShapeModel) and LevelUtils.IsTouchingGameShapeAreaVisibleToUser(levelItem.transform, touchGameShape, consumer) -> true, isTouchingOnly=true',
        ],
        'inference': 'Bounds layout (center.y at +4, extents.y at +16) is Unity\'s; top-edge reading follows from it',
    }


def prove_basic(elf, meta, resolve):
    names, _ = named_sequence(elf, resolve, WINDOWS['PerformBasicTests'])
    nav.require([n for _, n in names] == ['Bounds1D.Intersects', 'Component.get_transform', 'Component.get_transform',
                                          'Transform.IsChildOf', 'LevelDropAreaQuery.CanItemHeightFitInsideDropArea',
                                          'LevelDropAreaQuery.CanItemWidthFitInsideDropArea'], 'basic-test sequence changed')
    word_is(elf, 0x23546c0, mov_x(0, 19))  # dropArea.transform ...
    word_is(elf, 0x23546e8, mov_x(0, 21))  # ... .IsChildOf(levelItem.transform)
    word_is(elf, 0x23546e4, mov_x(1, 0))
    branch_is(elf, 0x23546f4, 'TBNZ', 0x2354738)                  # area is a child of the item -> false
    pipe.at(elf, 0x2354704, pipe.LDR_X, rt=9, rn=8, imm=0x218)
    slots = dispatch.virtual_slots(meta, 'PWC.Level', 'LevelConsumerAreaBase')
    nav.require(dispatch.slot_from_offset(0x218) == 14 and slots.get(14, ('',))[0] == 'CanConsumeItem',
                'virtual slot 14 is not CanConsumeItem')
    return {'steps': ['areaX.Intersects(itemX)', 'dropArea.transform is not a child of levelItem.transform',
                      'dropArea.CanConsumeItem(levelItem) (virtual slot 14)', 'CanItemHeightFitInsideDropArea',
                      'CanItemWidthFitInsideDropArea']}


def probe(source):
    binary = (source / 'libil2cpp.so').read_bytes()
    metadata = (source / 'global-metadata.dat').read_bytes()
    nav.verify_pair(binary, metadata)
    elf, meta = nav.Elf(binary), nav.Metadata(metadata)
    rows, resolve = nav.load_index(source / 'metadata_methods.jsonl', elf, meta)
    for name, (start, stop) in WINDOWS.items():
        owner = resolve(start)
        nav.require(len(owner) == 1 and owner[0]['name'] == name, f'{name} identity mismatch at {start:#x}')
        following = min(int(r['vaddr'], 16) for r in rows if r['vaddr'] and int(r['vaddr'], 16) > start)
        nav.require(following == stop, f'{name} next-method boundary mismatch')
    return {'schema_version': 1, 'scope': 'bounded static proof; no execution',
            'native_sha256': nav.sha(binary), 'metadata_sha256': nav.sha(metadata),
            'SortDropAreas': prove_sort(elf, meta, resolve, rows),
            'CompareConsumers': prove_compare(elf, meta, resolve, rows),
            'IsDroppableUnderItem': prove_droppable(elf, meta, resolve, rows),
            'PerformBasicTests': prove_basic(elf, meta, resolve)}


if __name__ == '__main__':
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--source', type=Path, default=nav.ROOT / 'out/recon/il2cpp')
    parser.add_argument('--report', type=Path, default=nav.ROOT / 'out/recon/drop_priority.json')
    args = parser.parse_args()
    nav.atomic_json(args.report, probe(args.source))
    print(f'Drop priority proof written to {args.report}')
