"""Method -> VA map for any managed image of libil2cpp.so (same structural join used for Assembly-CSharp).
Output: out/recon/il2cpp/<image>_methods.jsonl. Data lives in the main checkout's out/ (override with --data)."""
from __future__ import annotations
import argparse, json, sys
from pathlib import Path

sys.path.insert(0, str(Path(__file__).resolve().parent))
import recon_il2cpp as r  # noqa: E402

DEFAULT_DATA = Path("/home/deppi/avatarworld-re/out/recon/il2cpp")


def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("image", help="e.g. UnityEngine.CoreModule.dll")
    ap.add_argument("--data", type=Path, default=DEFAULT_DATA)
    a = ap.parse_args()
    meta = r.Metadata((a.data / "global-metadata.dat").read_bytes())
    elf = r.Elf((a.data / "libil2cpp.so").read_bytes())
    image, methods = meta.image_methods(a.image)
    module = r.codegen_module(elf, image["name"], len(methods))
    n = 0
    out = a.data / (a.image.replace(".dll", "") + "_methods.jsonl")
    with out.open("w", encoding="utf-8") as f:
        for m in sorted(methods, key=lambda x: x["rid"]):
            slot = module["method_pointers_vaddr"] + (m["rid"] - 1) * 8
            address = elf.pointer(slot)
            m["vaddr"] = hex(address) if address else None
            m["image"] = image["name"]
            n += bool(address)
            f.write(json.dumps(m, ensure_ascii=False) + "\n")
    print(f"{a.image}: {len(methods)} methods, {n} with code -> {out}")


if __name__ == "__main__":
    main()
