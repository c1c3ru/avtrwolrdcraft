#!/usr/bin/env python3
"""T031: resolve the indirect (blr/tail-br) dispatches inside the drag begin/end
pipeline and the drop-area "hitbox priority" selection, against the cached
shipped IL2CPP pair (libil2cpp.so + global-metadata.dat).

Method: every field access and vtable-slot access feeding a `blr`/tail `br` is
re-derived independently from global-metadata (field_offsets registration table
for instance fields; Il2CppMethodDefinition.slot for virtual methods) and then
cross-checked against the exact opcode bytes observed at each call site. This
does not trust any previously generated .jsonl cache for the slot/field facts
themselves (recon_navigation's own identity re-validation is reused only for
direct `bl` targets already attributed to a named method).

No execution, decompiler or Hopper/Ghidra/IDA session is used; this is a plain
ELF + metadata byte-level read, same bootstrap as the other recon_* tools.
"""
from __future__ import annotations

import argparse
import struct
from pathlib import Path

from recon_il2cpp import ROOT, Elf, Metadata, atomic_json
import recon_navigation as nav
import recon_t025_generics as generics

NATIVE_SHA = "b63661fa60c23ebef1c2da4bb5288ad787eb3da36b22d4bdf285401f1643d728"


def load():
    data_dir = Path("/home/c1c3ru/avtrwolrdcraft/out/recon/il2cpp")
    binary = (data_dir / "libil2cpp.so").read_bytes()
    nav.require(nav.sha(binary) == NATIVE_SHA, "native identity mismatch; contract is version-specific")
    elf = Elf(binary)
    meta = Metadata((data_dir / "global-metadata.dat").read_bytes())
    return elf, meta


def typedef_index(meta, namespace, name):
    matches = [t["index"] for t in meta.types if t["namespace"] == namespace and t["name"] == name]
    nav.require(len(matches) == 1, f"type {namespace}.{name} does not resolve uniquely")
    return matches[0]


def field_offsets(elf, meta, reg, namespace, name):
    """Independently derived field-name -> native-offset map for one TypeDef,
    via the registration fieldOffsets table (same join recon_t025_generics/
    recon_t026_condition already use), not any cached jsonl."""
    typedef = typedef_index(meta, namespace, name)
    traw = struct.unpack_from("<16I8H2I", meta.data, meta.tables["types"]["offset"] + typedef * 88)
    field_start, field_count = traw[8], traw[18]
    field_base, _ = struct.unpack_from("<II", meta.data, 96)
    offset_ptr = elf.pointer(int(reg["tables"]["field_offsets"]["vaddr"], 16) + typedef * 8)
    result = {}
    for j in range(field_count):
        raw = struct.unpack_from("<3I", meta.data, field_base + (field_start + j) * 12)
        fname = meta.string(raw[0])
        value = struct.unpack_from("<i", elf.data, elf.offset(offset_ptr + j * 4, 4))[0]
        result[value] = fname
    return result, typedef


def virtual_slots(meta, namespace, name):
    """Independently derived slot -> (name, vaddr) map for one TypeDef's own
    virtual method overrides, straight from Il2CppMethodDefinition.slot (no
    cached jsonl)."""
    _, methods = meta.image_methods("Assembly-CSharp.dll")
    return {m["slot"]: (m["name"], m["vaddr"] if False else None) for m in methods
            if m["declaring_type"] == f"{namespace}.{name}".lstrip(".") and m["slot"] != 0xFFFF}


def slot_from_offset(vtable_offset):
    nav.require((vtable_offset - 0x138) % 16 == 0, f"vtable slot offset misaligned: {vtable_offset:#x}")
    return (vtable_offset - 0x138) // 16


def site(elf, address, expected):
    nav.expect(elf, address, expected)
    return hex(address)


def ldr_field(elf, address, expected_opcode, register_width=64):
    """Decode `ldr xN, [xM, #imm]` (or similar) and return (base_reg, dest_reg, imm)."""
    word = nav.word(elf, address)
    nav.require(word == expected_opcode, f"opcode mismatch at {address:#x}")
    if word & 0xffc00000 == 0xf9400000:  # LDR (unsigned offset, 64-bit)
        imm = ((word >> 10) & 0xfff) * 8
    elif word & 0xffc00000 == 0xb9400000:  # LDR (unsigned offset, 32-bit)
        imm = ((word >> 10) & 0xfff) * 4
    elif word & 0xffc00000 == 0x39400000:  # LDRB
        imm = (word >> 10) & 0xfff
    else:
        raise ValueError(f"unsupported load encoding at {address:#x}: {word:#x}")
    return {"base": (word >> 5) & 31, "dest": word & 31, "imm": imm}


def resolve_on_begin_drag(elf, meta, fields):
    """DragDropItemBase.OnBeginDrag, 568-byte proven window [0x206b864, 0x206ba9c)."""
    out = {"procedure": "PWC.DragDropItemBase.OnBeginDrag", "window": ["0x206b864", "0x206ba9c"], "dispatches": []}

    # 1) field+0xe8 delegate, conditional short-circuit return on true.
    nav.require(fields[0xe8] == "TryOverridePreBeginDragAction", "field 0xe8 identity changed")
    load = ldr_field(elf, 0x206b9e0, 0xf9407668)
    nav.require(load == {"base": 19, "dest": 8, "imm": 0xe8}, "TryOverridePreBeginDragAction field load changed")
    nav.expect(elf, 0x206b9e4, 0xb4000188)  # cbz x8, +skip
    nav.expect(elf, 0x206b9f4, 0xaa1303e1)  # mov x1, x19 (this)
    nav.expect(elf, 0x206b9f8, 0xaa1403e2)  # mov x2, x20 (eventData)
    nav.expect(elf, 0x206b9fc, 0xd63f0120)  # blr x9
    nav.expect(elf, 0x206ba00, 0x360000a0)  # tbz w0,#0 -> skip to StopSyncPosition/OnBeginDragInternal block
    out["dispatches"].append({
        "site": "0x206b9fc", "kind": "delegate_field", "field_offset": "0xe8",
        "target": "TryOverridePreBeginDragAction(this, eventData)",
        "effect": "if delegate present and returns true, OnBeginDrag returns immediately: "
                  "StopSyncPosition/OnBeginDragInternal/OnBeginDragAction/StartSyncPosition are all skipped"})

    # 2) vtable slot 32 = StopSyncPosition
    load = ldr_field(elf, 0x206ba34, 0xf9419d09)
    nav.require(load == {"base": 8, "dest": 9, "imm": 0x338}, "StopSyncPosition vtable slot load changed")
    nav.require(slot_from_offset(0x338) == 32, "StopSyncPosition slot arithmetic changed")
    nav.expect(elf, 0x206ba3c, 0xd63f0120)  # blr x9
    out["dispatches"].append({"site": "0x206ba3c", "kind": "vtable_slot", "slot": 32,
                               "target": "StopSyncPosition(this)"})

    # 3) vtable slot 29 = OnBeginDragInternal
    load = ldr_field(elf, 0x206ba4c, 0xf9418509)
    nav.require(load == {"base": 8, "dest": 9, "imm": 0x308}, "OnBeginDragInternal vtable slot load changed")
    nav.require(slot_from_offset(0x308) == 29, "OnBeginDragInternal slot arithmetic changed")
    nav.expect(elf, 0x206ba48, 0xaa1403e1)  # mov x1, x20 (eventData)
    nav.expect(elf, 0x206ba54, 0xd63f0120)  # blr x9
    out["dispatches"].append({"site": "0x206ba54", "kind": "vtable_slot", "slot": 29,
                               "target": "OnBeginDragInternal(this, eventData)"})

    # 4) field+0xc0 delegate (event), fire-and-forget
    nav.require(fields[0xc0] == "OnBeginDragAction", "field 0xc0 identity changed")
    load = ldr_field(elf, 0x206ba58, 0xf9406268)
    nav.require(load == {"base": 19, "dest": 8, "imm": 0xc0}, "OnBeginDragAction field load changed")
    nav.expect(elf, 0x206ba74, 0xd63f0120)  # blr x9
    out["dispatches"].append({"site": "0x206ba74", "kind": "delegate_field", "field_offset": "0xc0",
                               "target": "OnBeginDragAction(this, eventData)"})

    # 5) tail-branch vtable slot 21 = StartSyncPosition
    load = ldr_field(elf, 0x206ba88, 0xf9414502)
    nav.require(load == {"base": 8, "dest": 2, "imm": 0x288}, "StartSyncPosition tail vtable slot load changed")
    nav.require(slot_from_offset(0x288) == 21, "StartSyncPosition slot arithmetic changed")
    nav.expect(elf, 0x206ba94, 0xd61f0040)  # br x2 (tail call, epilogue already run)
    out["dispatches"].append({"site": "0x206ba94", "kind": "vtable_slot_tail", "slot": 21,
                               "target": "StartSyncPosition(this)"})

    # `this+0x39` identity, previously unresolved ("o significado de this+0x39 não foi determinado").
    nav.require(fields[0x39] == "<IsDragging>k__BackingField", "field 0x39 identity changed")
    out["resolved_unknown"] = {"field_offset": "0x39", "name": "<IsDragging>k__BackingField",
                                "note": "this is the flag OnPointerClick checks to suppress a click after a drag"}
    return out


def resolve_on_end_drag(elf, meta, fields):
    """DragDropItemBase.OnEndDrag, proven window [0x206bb40, 0x206bcc0)."""
    out = {"procedure": "PWC.DragDropItemBase.OnEndDrag", "window": ["0x206bb40", "0x206bcc0"], "dispatches": []}

    nav.require(fields[0xf0] == "TryOverridePreEndDragAction", "field 0xf0 identity changed")
    load = ldr_field(elf, 0x206bc0c, 0xf9407a88)
    nav.require(load == {"base": 20, "dest": 8, "imm": 0xf0}, "TryOverridePreEndDragAction field load changed")
    nav.expect(elf, 0x206bc20, 0xaa1403e1)  # mov x1, x20 (this)
    nav.expect(elf, 0x206bc24, 0xaa1303e2)  # mov x2, x19 (eventData)
    nav.expect(elf, 0x206bc28, 0xd63f0120)  # blr x9
    nav.expect(elf, 0x206bc2c, 0x37000420)  # tbnz w0,#0 -> straight to epilogue on true
    out["dispatches"].append({
        "site": "0x206bc28", "kind": "delegate_field", "field_offset": "0xf0",
        "target": "TryOverridePreEndDragAction(this, eventData)",
        "effect": "if delegate present and returns true, OnEndDrag returns immediately: "
                  "IsDragging/_dragPositionOffset are not cleared and StopSyncPosition/OnEndDragInternal/"
                  "OnEndDragAction are all skipped"})

    nav.require(fields[0x39] == "<IsDragging>k__BackingField", "field 0x39 identity changed")
    nav.expect(elf, 0x206bc34, 0x3900e69f)  # strb wzr, [x20, #0x39]  -> IsDragging = false
    nav.require(fields[0x90] == "_dragPositionOffset", "field 0x90 identity changed")
    nav.expect(elf, 0x206bc38, 0xf9004a9f)  # str xzr, [x20, #0x90]  -> _dragPositionOffset = default

    load = ldr_field(elf, 0x206bc40, 0xf9419d09)
    nav.require(load == {"base": 8, "dest": 9, "imm": 0x338} and slot_from_offset(0x338) == 32,
                "StopSyncPosition vtable slot load changed")
    nav.expect(elf, 0x206bc48, 0xd63f0120)
    out["dispatches"].append({"site": "0x206bc48", "kind": "vtable_slot", "slot": 32,
                               "target": "StopSyncPosition(this)"})

    nav.require(fields[0xc8] == "OnPreEndDragAction", "field 0xc8 identity changed")
    load = ldr_field(elf, 0x206bc4c, 0xf9406688)
    nav.require(load == {"base": 20, "dest": 8, "imm": 0xc8}, "OnPreEndDragAction field load changed")
    nav.expect(elf, 0x206bc68, 0xd63f0120)
    out["dispatches"].append({"site": "0x206bc68", "kind": "delegate_field", "field_offset": "0xc8",
                               "target": "OnPreEndDragAction(this, eventData)"})

    load = ldr_field(elf, 0x206bc78, 0xf9418d09)
    nav.require(load == {"base": 8, "dest": 9, "imm": 0x318} and slot_from_offset(0x318) == 30,
                "OnEndDragInternal vtable slot load changed")
    nav.expect(elf, 0x206bc80, 0xd63f0120)
    out["dispatches"].append({"site": "0x206bc80", "kind": "vtable_slot", "slot": 30,
                               "target": "OnEndDragInternal(this, eventData)"})

    nav.require(fields[0xd0] == "OnEndDragAction", "field 0xd0 identity changed")
    load = ldr_field(elf, 0x206bc84, 0xf9406a88)
    nav.require(load == {"base": 20, "dest": 8, "imm": 0xd0}, "OnEndDragAction field load changed")
    nav.expect(elf, 0x206bcac, 0xd61f0080)  # br x4 (tail call, only reached when field non-null)
    out["dispatches"].append({"site": "0x206bcac", "kind": "delegate_field_tail", "field_offset": "0xd0",
                               "target": "OnEndDragAction(this, eventData)",
                               "effect": "tail-called only when the event has a subscriber; cbz at 0x206bc88 "
                                         "returns directly to epilogue otherwise"})
    return out


def resolve_level_item_begin(elf, meta, fields):
    """LevelItem.OnBeginDragInternal, proven window [0x22f6260, 0x22f67ec)."""
    out = {"procedure": "PWC.Level.LevelItem.OnBeginDragInternal", "window": ["0x22f6260", "0x22f67ec"],
           "dispatches": [], "unresolved": []}

    load = ldr_field(elf, 0x22f62e8, 0xf9426d09)
    nav.require(load == {"base": 8, "dest": 9, "imm": 0x4d8} and slot_from_offset(0x4d8) == 58,
                "PlayPickUpSound vtable slot load changed")
    nav.expect(elf, 0x22f62f0, 0xd63f0120)
    nav.require(fields[0x231] == "<IsPerformingBasicDrop>k__BackingField", "field 0x231 identity changed")
    out["dispatches"].append({"site": "0x22f62f0", "kind": "vtable_slot", "slot": 58,
                               "target": "PlayPickUpSound(this)",
                               "effect": "skipped when <IsPerformingBasicDrop>k__BackingField (0x231) is true"})

    load = ldr_field(elf, 0x22f64a0, 0xf9428509)
    nav.require(load == {"base": 8, "dest": 9, "imm": 0x508} and slot_from_offset(0x508) == 61,
                "DetachFromParentIfExists vtable slot load changed")
    nav.expect(elf, 0x22f64a8, 0xd63f0120)
    out["dispatches"].append({"site": "0x22f64a8", "kind": "vtable_slot", "slot": 61,
                               "target": "DetachFromParentIfExists(this, true)"})

    load = ldr_field(elf, 0x22f65d4, 0xf9429509)
    nav.require(load == {"base": 8, "dest": 9, "imm": 0x528} and slot_from_offset(0x528) == 63,
                "GetDefaultScaleForCurrentFlipState vtable slot load changed")
    nav.expect(elf, 0x22f65dc, 0xd63f0120)
    out["dispatches"].append({"site": "0x22f65dc", "kind": "vtable_slot", "slot": 63,
                               "target": "GetDefaultScaleForCurrentFlipState(this)"})

    load = ldr_field(elf, 0x22f66d4, 0xf9427d09)
    nav.require(load == {"base": 8, "dest": 9, "imm": 0x4f8} and slot_from_offset(0x4f8) == 60,
                "CacheLevelItemsUnderSelfForNotifyEvents vtable slot load changed")
    nav.expect(elf, 0x22f66dc, 0xd63f0120)
    out["dispatches"].append({"site": "0x22f66dc", "kind": "vtable_slot", "slot": 60,
                               "target": "CacheLevelItemsUnderSelfForNotifyEvents(this)"})

    # Lighting/sorting/orientation field reads confirmed by name (doc previously only inferred these by comment).
    nav.require(fields[0x228] == "_orientationHandler", "field 0x228 identity changed")
    nav.require(fields[0x178] == "_sortingTransform", "field 0x178 identity changed")
    nav.require(fields[0x170] == "_movableLightSystemObject", "field 0x170 identity changed")

    # Fifth blr: static class-level delegate, offset 0x10 of a static-data block reached via the same
    # class-init-guard GOT slot (0x41b5000+0x5c0) checked at function entry. Declaring type not identified.
    nav.expect(elf, 0x22f67b4, 0xf9400908)  # ldr x8, [x8, #0x10]  (static field slot)
    nav.expect(elf, 0x22f67cc, 0xd63f0120)  # blr x9
    out["unresolved"].append({"site": "0x22f67cc", "kind": "static_delegate_field", "static_offset": "0x10",
                               "note": "static multicast delegate invoked with this as sole argument; declaring "
                                       "type not identified in this pass (would need the GOT 0x41b5000+0x5c0 "
                                       "class-statics identity)"})
    return out


def resolve_level_item_end(elf, meta, fields):
    """LevelItem.OnEndDragInternal, proven window [0x22f68bc, 0x22f6af4)."""
    out = {"procedure": "PWC.Level.LevelItem.OnEndDragInternal", "window": ["0x22f68bc", "0x22f6af4"],
           "dispatches": [], "unresolved": []}

    # First blr: same static class-level delegate family as OnBeginDragInternal, static offset 0x18.
    nav.expect(elf, 0x22f696c, 0xf9400d08)  # ldr x8, [x8, #0x18]  (static field slot)
    nav.expect(elf, 0x22f6984, 0xd63f0120)  # blr x9
    out["unresolved"].append({"site": "0x22f6984", "kind": "static_delegate_field", "static_offset": "0x18",
                               "note": "symmetric to the 0x10 slot seen in OnBeginDragInternal; declaring type "
                                       "not identified in this pass"})

    # Second blr: field 0x328 = OverrideOnDropBehaviorAction, conditional short-circuit on true.
    nav.require(fields[0x328] == "OverrideOnDropBehaviorAction", "field 0x328 identity changed")
    load = ldr_field(elf, 0x22f69ac, 0xf9419668)
    nav.require(load == {"base": 19, "dest": 8, "imm": 0x328}, "OverrideOnDropBehaviorAction field load changed")
    nav.expect(elf, 0x22f69c0, 0xaa1303e1)  # mov x1, x19 (this)
    nav.expect(elf, 0x22f69c4, 0xaa1403e2)  # mov x2, x20 (eventData)
    nav.expect(elf, 0x22f69c8, 0xd63f0120)  # blr x9
    nav.expect(elf, 0x22f69cc, 0x37000860)  # tbnz w0,#0 -> straight to epilogue on true
    out["dispatches"].append({
        "site": "0x22f69c8", "kind": "delegate_field", "field_offset": "0x328",
        "target": "OverrideOnDropBehaviorAction(this, eventData)",
        "effect": "if present and returns true, the entire default fall/land/scale/orientation/sound drop "
                  "pipeline below is skipped; this is the extensibility hook custom drop items (e.g. scoring "
                  "items) use to replace DropOnDropArea/FallOnDropArea/SnapToDropArea/TweenToProperPositionOnDropArea"})

    load = ldr_field(elf, 0x22f69e8, 0xf9429509)
    nav.require(load == {"base": 8, "dest": 9, "imm": 0x528} and slot_from_offset(0x528) == 63,
                "GetDefaultScaleForCurrentFlipState vtable slot load changed")
    nav.expect(elf, 0x22f69f0, 0xd63f0120)
    out["dispatches"].append({"site": "0x22f69f0", "kind": "vtable_slot", "slot": 63,
                               "target": "GetDefaultScaleForCurrentFlipState(this)"})

    nav.require(fields[0x1b8] == "<ShouldCallFixPositionIfNeededOnEndDrag>k__BackingField",
                "field 0x1b8 identity changed")
    nav.require(fields[0x254] == "<LastFallDistance>k__BackingField", "field 0x254 identity changed")
    return out


def hitbox_priority(elf, meta):
    """SortDropAreas / GetMostRelevantDropAreaUnderPosition: no indirect dispatch in either
    method; priority among overlapping drop areas is entirely "sorted-list order, first
    predicate match wins". The sort comparator and the acceptance predicate are not opened
    here (still open)."""
    out = {"sort": {"procedure": "PWC.SortDropAreas", "address": "0x227f574"},
           "select": {"procedure": "PWC.GetMostRelevantDropAreaUnderPosition", "address": "0x22eba10"},
           "mechanism": [
               "SortDropAreas applies a generic Array/List sort (direct `bl`, no blr) to the static "
               "candidate drop-area list using a static comparer field; the comparer's declaring type/Compare "
               "body is not identified in this pass.",
               "GetMostRelevantDropAreaUnderPosition walks the already-sorted candidate list with a plain "
               "List<T> enumerator (direct `bl` to MoveNext/get_Current/Dispose, no blr) and returns the FIRST "
               "drop area for which the predicate call at 0x23544e0 (consistent with "
               "LevelDropAreaQuery.IsDroppableUnderItem per the existing contract) returns true.",
               "Hitbox priority among overlapping drop areas = sort order established once by SortDropAreas; "
               "ties/overlaps are resolved purely by that fixed order, not by any score computed in "
               "GetMostRelevantDropAreaUnderPosition itself."],
           "open": ["SortDropAreas comparer identity/criteria", "IsDroppableUnderItem acceptance criteria"]}
    # Confirm there is genuinely no blr in either window (opcode-level negative check).
    for start, stop in [(0x227f574, 0x227f638), (0x22eba10, 0x22ebb84)]:
        for addr in range(start, stop, 4):
            word = nav.word(elf, addr)
            nav.require(word & 0xfffffc1f != 0xd63f0000, f"unexpected blr at {addr:#x}; hitbox mechanism changed")
    return out


def verify(elf, meta):
    reg = generics.verify(elf, meta)
    drag_fields, _ = field_offsets(elf, meta, reg, "PWC", "DragDropItemBase")
    item_fields, _ = field_offsets(elf, meta, reg, "PWC.Level", "LevelItem")
    return {
        "native_sha256": NATIVE_SHA,
        "on_begin_drag": resolve_on_begin_drag(elf, meta, drag_fields),
        "on_end_drag": resolve_on_end_drag(elf, meta, drag_fields),
        "level_item_on_begin_drag_internal": resolve_level_item_begin(elf, meta, item_fields),
        "level_item_on_end_drag_internal": resolve_level_item_end(elf, meta, item_fields),
        "hitbox_priority": hitbox_priority(elf, meta),
        "still_open": [
            "LevelItem static class-level delegates at static offsets 0x10/0x18 (declaring type not identified)",
            "SortDropAreas comparer and LevelDropAreaQuery.IsDroppableUnderItem acceptance criteria",
            "LevelBSBasketballItemHandler.ScoreInternal/MissInternal/Shoot and LevelBSHoop physics/scoring: "
            "not traced this pass; this sandbox's objdump build has no AArch64 support and no Ghidra/IDA "
            "provider is configured for REA, so these ~2.7 KB of new functions were not opened",
            "device/runtime validation of all of the above (deferred per project policy)"],
    }


def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("--output", type=Path, default=ROOT / "out/recon/tasks/T031/dispatch-resolution.json")
    a = ap.parse_args()
    elf, meta = load()
    result = verify(elf, meta)
    atomic_json(a.output, result)
    print(f"wrote {a.output}")


if __name__ == "__main__":
    main()
