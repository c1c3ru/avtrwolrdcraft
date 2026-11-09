"""Resolve IL2CPP class vtable slots to method names for T031 drag/input indirect dispatches.

Each IL2CPP vtable slot is a 16-byte VirtualInvokeData {methodPtr; MethodInfo*}, so a
`ldr x9,[x8,#off]` load of a method pointer maps to slot = (off - 0x138) // 16, where
0x138 is the fixed VTable base offset inside Il2CppClass on this ABI (validated earlier
in docs/RECON_INPUT_CONTRACT.md against DragDropItemBase.OnEndDrag loading 0x318 = slot 30).

Slot numbers are assigned per class hierarchy: a virtual method declared in a base type
keeps the same slot number in every override. This reads global-metadata.dat directly
(Il2CppMethodDefinition.slot, field row[9] in recon_il2cpp.Metadata.image_methods), so it
covers every image (engine assemblies like UnityEngine.UI.dll included), not just
Assembly-CSharp.dll.

Data lives in the main checkout's out/ (override with --data).
"""
from __future__ import annotations
import argparse
import sys
from pathlib import Path

DEFAULT_DATA = Path("/home/deppi/avatarworld-re/out/recon/il2cpp")

HERE = Path(__file__).resolve().parent
sys.path.insert(0, str(HERE))
import recon_il2cpp as r  # noqa: E402


def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("types", nargs="+", help="Declaring type names (suffix match, e.g. DragDropItemBase)")
    ap.add_argument("--data", type=Path, default=DEFAULT_DATA)
    ap.add_argument("--images", nargs="*", default=["Assembly-CSharp.dll", "UnityEngine.UI.dll"],
                     help="Metadata images to scan (default: Assembly-CSharp.dll and UnityEngine.UI.dll)")
    ap.add_argument("--slot", type=int, default=None, help="Only show this slot number across all matched types")
    ap.add_argument("--offset", type=lambda s: int(s, 0), default=None,
                     help="Compute slot from a vtable byte offset (off-0x138)//16 and filter to it")
    a = ap.parse_args()

    wanted_slot = a.slot
    if a.offset is not None:
        computed = (a.offset - 0x138) // 16
        rem = (a.offset - 0x138) % 16
        print(f"offset {hex(a.offset)} -> slot {computed} (remainder {rem}; 0 selects methodPtr, 8 selects MethodInfo*)")
        wanted_slot = computed

    meta = r.Metadata((a.data / "global-metadata.dat").read_bytes())
    found = False
    for image_name in a.images:
        try:
            _, methods = meta.image_methods(image_name)
        except ValueError as exc:
            print(f"-- skipping image {image_name}: {exc}", file=sys.stderr)
            continue
        by_type = {}
        for m in methods:
            short = m["declaring_type"].split(".")[-1]
            for want in a.types:
                if short == want or m["declaring_type"] == want:
                    by_type.setdefault(m["declaring_type"], []).append(m)
                    break
        for dt, ms in by_type.items():
            found = True
            virt = sorted((m for m in ms if m["slot"] != 65535), key=lambda m: m["slot"])
            print(f"== {dt}  [{image_name}]  ({len(ms)} methods, {len(virt)} virtual/slot-assigned) ==")
            for m in virt:
                if wanted_slot is not None and m["slot"] != wanted_slot:
                    continue
                print(f"  slot {m['slot']:3d}  {m['name']}({m['parameter_count']} params)  token={m['token']}  rid={m['rid']}")

    if not found:
        raise SystemExit("no declaring type matched " + ", ".join(a.types) + " in images " + ", ".join(a.images))


if __name__ == "__main__":
    main()
