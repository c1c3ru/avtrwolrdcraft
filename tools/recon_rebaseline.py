#!/usr/bin/env python3
"""Compara dois builds do original (libil2cpp.so + metadata) metodo a metodo: o mesmo metodo tem o mesmo codigo?

Chave do metodo: (tipo, nome, n. de parametros). Impressao digital do corpo = hash da sequencia de instrucoes AArch64 normalizada:
registradores e imediatos pequenos ficam; imediatos grandes (>= 5 digitos hex: enderecos, paginas, alvos de desvio, indices de .got)
viram `#T`, porque mudam de build para build sem mudar o comportamento. Corpo = [vaddr, proximo_inicio) limitado a 0x4000 bytes.
Detecta: metodos novos/removidos, corpos identicos, corpos diferentes (com o numero de instrucoes de cada lado).

uso: tools/venv/bin/python tools/recon_rebaseline.py --old out/recon/il2cpp --new out/recon/il2cpp_1.230 [--key] [--json saida.json]
  --key  so os metodos das series de leitura (Home, feriado, drops, cena); sem --key varre todos (~12 min por build).
"""
import argparse, bisect, hashlib, json, re, sys
from pathlib import Path
from capstone import Cs, CS_ARCH_ARM64, CS_MODE_ARM

HERE = Path(__file__).resolve().parent
sys.path.insert(0, str(HERE))
import recon_il2cpp as r  # noqa: E402

BIG = re.compile(r"#0x[0-9a-f]{5,}")
KEY_TYPES = ("HolidayGameModeButton", "HomePlayButton", "ClothesDropUtils", "ClothesDropDataMap", "TimeToClothesDropData", "GameSceneManager",
             "WorldBuilding", "HomeNewClothesDropBadge", "WeatherManager", "HolidayConfig", "WorldResetManager", "StoreAvatarPassButton",
             "StoreAvatarPassGiftsButton", "StoreNewUserGiftCurrencyButton", "AvatarPassChangeWidget", "MatchActiveStateIfHolidayIsAvaileable")


def load(d):
    elf = r.Elf((d / "libil2cpp.so").read_bytes())
    rows = {}
    allv = []
    for f in d.glob("*_methods.jsonl"):
        for l in f.open():
            x = json.loads(l)
            if x.get("vaddr"):
                allv.append(int(x["vaddr"], 16))
    starts = sorted(set(allv))
    for l in (d / "assembly_csharp_methods.jsonl").open():
        x = json.loads(l)
        if x.get("vaddr"):
            rows[(x["declaring_type"], x["name"], x["parameter_count"])] = int(x["vaddr"], 16)
    return elf, rows, starts


def fingerprint(elf, starts, cs, va):
    i = bisect.bisect_right(starts, va)
    end = min(starts[i] if i < len(starts) else va + 0x400, va + 0x4000)
    code = elf.data[elf.offset(va, end - va):][: end - va]
    ops, pages = [], set()
    for x in cs.disasm(code, va):
        text = BIG.sub("#T", x.op_str)
        # `adrp xN, PAGE` seguido de `ldr/add/str ..., [xN, #off]` / `add xD, xN, #off`: o deslocamento e posicao na .got/.data, muda por build
        if x.mnemonic == "adrp":
            pages.add(x.op_str.split(",")[0].strip())
        elif x.mnemonic in ("ldr", "str", "add", "ldrb", "strb", "ldrh", "ldrsw") and "#" in x.op_str:
            parts = [p.strip(" []!") for p in x.op_str.split(",")]
            base = parts[1] if x.mnemonic == "add" else (parts[1] if len(parts) > 1 else "")
            if base in pages:
                text = re.sub(r"#0x[0-9a-f]+", "#G", text)
            dst = parts[0]
            if dst in pages and x.mnemonic != "str":
                pages.discard(dst)
        ops.append("%s %s" % (x.mnemonic, text))
    return hashlib.sha256("\n".join(ops).encode()).hexdigest()[:16], len(ops)


def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("--old", type=Path, required=True)
    ap.add_argument("--new", type=Path, required=True)
    ap.add_argument("--key", action="store_true")
    ap.add_argument("--json", type=Path)
    a = ap.parse_args()
    cs = Cs(CS_ARCH_ARM64, CS_MODE_ARM)
    eo, ro, so = load(a.old)
    en, rn, sn = load(a.new)
    keys_old, keys_new = set(ro), set(rn)
    common = keys_old & keys_new
    if a.key:
        common = {k for k in common if k[0].split(".")[-1] in KEY_TYPES}
    same = diff = 0
    changed = []
    for k in sorted(common):
        fo, no = fingerprint(eo, so, cs, ro[k])
        fn, nn = fingerprint(en, sn, cs, rn[k])
        if fo == fn:
            same += 1
        else:
            diff += 1
            changed.append({"type": k[0], "method": k[1], "params": k[2], "old_instr": no, "new_instr": nn})
    out = {"old_methods": len(keys_old), "new_methods": len(keys_new), "removed": len(keys_old - keys_new), "added": len(keys_new - keys_old),
           "compared": len(common), "identical": same, "different": diff, "changed": changed,
           "added_types_sample": sorted({k[0] for k in keys_new - keys_old})[:40]}
    print(json.dumps({k: v for k, v in out.items() if k not in ("changed", "added_types_sample")}))
    for c in changed[:40]:
        print("  mudou:", c["type"], c["method"], c["old_instr"], "->", c["new_instr"], "instr")
    if a.json:
        a.json.write_text(json.dumps(out, indent=1))


if __name__ == "__main__":
    main()
