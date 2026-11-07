"""Inventory of compiler-generated coroutine/async state machines in Assembly-CSharp (static, read-only).
Owner type comes from Il2CppTypeDefinition.declaringTypeIndex (offset +12). Calls are direct bl targets inside the
MoveNext window (until the next method start, capped), so they are evidence of callees, not of execution order.
Data lives in the main checkout's out/ (override with --data)."""
from __future__ import annotations
import argparse, bisect, collections, json, re, struct, sys
from pathlib import Path

sys.path.insert(0, str(Path(__file__).resolve().parent))
import recon_il2cpp as r  # noqa: E402

DEFAULT_DATA = Path("/home/deppi/avatarworld-re/out/recon/il2cpp")
NESTED = re.compile(r"^<(.+)>d__(\d+)$")
WAIT_HINTS = ("WaitForSeconds", "WaitForEndOfFrame", "WaitUntil", "WaitWhile", "WaitForFixedUpdate", "WaitForSecondsRealtime",
              "StartCoroutine", "StopCoroutine", "Task.Delay", "UniTask", "DOTween", "Tween")


def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("--data", type=Path, default=DEFAULT_DATA)
    ap.add_argument("--output", type=Path, required=True)
    ap.add_argument("--cap", type=int, default=0x3000)
    a = ap.parse_args()
    meta = r.Metadata((a.data / "global-metadata.dat").read_bytes())
    elf = r.Elf((a.data / "libil2cpp.so").read_bytes())
    table = meta.tables["types"]
    owner_of, qualified, by_byval = {}, {}, {}
    raw_declaring = {}
    for idx, t in enumerate(meta.types):
        byval = struct.unpack_from("<I", meta.data, table["offset"] + idx * 88 + 8)[0]
        by_byval.setdefault(byval, idx)
        raw_declaring[idx] = struct.unpack_from("<i", meta.data, table["offset"] + idx * 88 + 12)[0]
        qualified[idx] = (t["namespace"] + "." if t["namespace"] else "") + t["name"]
    for idx, d in raw_declaring.items():          # declaringTypeIndex e indice de Il2CppType -> definicao de tipo
        owner_of[idx] = by_byval.get(d, -1) if d >= 0 else -1

    def owner_name(idx):
        while owner_of.get(idx, -1) >= 0:
            idx = owner_of[idx]
        return qualified[idx]

    rows = [json.loads(l) for l in (a.data / "assembly_csharp_methods.jsonl").open()]
    rows = [x for x in rows if x.get("vaddr")]
    names = {int(x["vaddr"], 16): x["declaring_type"].split(".")[-1] + "." + x["name"] for x in rows}
    starts = sorted(names)
    out, kinds = [], collections.Counter()
    for x in rows:
        m = NESTED.match(x["declaring_type"].split(".")[-1])
        if not m or x["name"] != "MoveNext":
            continue
        va = int(x["vaddr"], 16)
        i = bisect.bisect_right(starts, va)
        end = min(starts[i] if i < len(starts) else va + a.cap, va + a.cap)
        code = elf.data[elf.offset(va, end - va):][: end - va]
        callees = []
        for k in range(0, len(code) - 3, 4):
            w = struct.unpack_from("<I", code, k)[0]
            if (w & 0xFC000000) in (0x94000000,):
                imm = w & 0x3FFFFFF
                imm = imm - (1 << 26) if imm >= 1 << 25 else imm
                t = va + k + imm * 4
                if t in names and names[t] not in callees:
                    callees.append(names[t])
        owner = owner_name(x["declaring_type_index"])
        waits = [c for c in callees if any(h in c for h in WAIT_HINTS)]
        kinds["async" if any("AsyncTaskMethodBuilder" in c or "AsyncVoidMethodBuilder" in c for c in callees) else "enumerator"] += 1
        out.append({"owner": owner, "method": m.group(1), "state_machine": x["declaring_type"], "vaddr": x["vaddr"],
                    "bytes": end - va, "wait_calls": waits[:6], "callee_count": len(callees)})
    out.sort(key=lambda e: (e["owner"], e["method"]))
    a.output.write_text("\n".join(json.dumps(e, ensure_ascii=False) for e in out) + "\n")
    by_owner = collections.Counter(e["owner"] for e in out)
    print("state machines:", len(out), "| owners:", len(by_owner), "| kinds:", dict(kinds))
    print("top owners:", by_owner.most_common(8))
    print("with wait calls:", sum(1 for e in out if e["wait_calls"]))


if __name__ == "__main__":
    main()
