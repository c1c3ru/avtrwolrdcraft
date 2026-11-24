#!/usr/bin/env python3
"""Constroi type trees de MonoBehaviours que o TypeTreeGeneratorAPI nao consegue gerar (NRE em SerializableDictionaryBase<K,V>) a partir do Cpp2IL.

Uso (raiz do repo): python3 -I tools/mb_typetree_builder.py <dir_bytes_crus> <dir_saida> [Classe ...]
 - <dir_bytes_crus>: arquivos `<Classe>__<path_id>__<arquivo>.bin` (get_raw_data de cada objeto; ver tools/mb_retry_errors_lowmem.py).
 - Le `out/cpp2il/DiffableCs/Assembly-CSharp` para a lista de campos serializados (base primeiro), classifica cada tipo e emite nos
   {m_Level, m_Type, m_Name, m_MetaFlag}. O UnityPy so aceita a leitura se consumir EXATAMENTE todos os bytes (byte_size): um palpite errado falha, nao gera lixo.
 - Layout do dicionario (RotaryHeart): `_keyValues` List<K>, `_keys` K[], `_values` V[].
 - Grava `<dir_saida>/<Classe>.jsonl.gz` (campos + `_path_id` + `_file`) so para classes onde TODAS as instancias leem exato; imprime resumo.
Limitacoes: tipos Unity nao mapeados (AnimationCurve, Gradient, LayerMask...) abortam a classe; enums assumidos int32; UnityEvent via molde fixo.
"""
import collections
import gzip
import json
import os
import re
import sys

from UnityPy.helpers.TypeTreeNode import TypeTreeNode
from UnityPy.helpers import TypeTreeHelper
from UnityPy.streams import EndianBinaryReader

C = "out/cpp2il/DiffableCs/Assembly-CSharp/"
PRIM = {"bool": ("UInt8", 0x4000), "byte": ("UInt8", 0x4000), "sbyte": ("SInt8", 0x4000), "short": ("SInt16", 0x4000), "ushort": ("UInt16", 0x4000),
        "char": ("UInt16", 0x4000), "int": ("int", 0), "uint": ("unsigned int", 0), "long": ("SInt64", 0), "ulong": ("UInt64", 0), "float": ("float", 0), "double": ("double", 0)}
NAMED_PRIM = {"Boolean": "bool", "Byte": "byte", "Int32": "int", "Int64": "long", "Single": "float", "Double": "double", "UInt32": "uint", "Int16": "short", "String": "string"}
VEC = {"Vector2": ("Vector2f", ["x", "y"]), "Vector3": ("Vector3f", ["x", "y", "z"]), "Vector4": ("Vector4f", ["x", "y", "z", "w"]),
       "Quaternion": ("Quaternionf", ["x", "y", "z", "w"]), "Color": ("ColorRGBA", ["r", "g", "b", "a"]), "Rect": ("Rectf", ["x", "y", "width", "height"])}
NOT_SER = ("Dictionary<", "HashSet<", "Action", "Func<", "UnityAction", "Predicate<", "Queue<", "Stack<", "Tween", "Coroutine", "Task", "Type", "object", "Object[]")
UNITY_ROOTS = {"MonoBehaviour", "ScriptableObject", "Component", "Behaviour", "Object", "UIBehaviour", "Graphic", "MaskableGraphic"}


DICT_BASE = {"n": None}
BOOL_NAMES = set()  # nomes de campos bool da classe em construcao (um bool so pode valer 0 ou 1)


class Unsupported(Exception):
    pass


_index = None


def index():
    global _index
    if _index is not None:
        return _index
    idx = collections.defaultdict(list)
    for root, _, files in os.walk(C):
        for f in files:
            if not f.endswith(".cs"):
                continue
            p = os.path.join(root, f)
            lines = open(p, errors="ignore").read().split("\n")
            for i, l in enumerate(lines):
                m = re.match(r"^(?:public |internal )?(?:abstract |sealed |static |partial )*(class|enum|struct|interface) ([\w`]+)(?:\s*:\s*(.+))?$", l.strip("\r"))
                if m:
                    attrs = []
                    j = i - 1
                    while j >= 0 and lines[j].startswith("["):
                        attrs.append(lines[j]); j -= 1
                    base = None
                    if m.group(3):
                        first = split_top(m.group(3).strip().rstrip("{").strip())[0]
                        if not re.match(r"^I[A-Z]", first):
                            base = first
                    name = re.sub(r"`\d+$", "", m.group(2))
                    idx[name].append(dict(kind=m.group(1), base=base, attrs=" ".join(attrs), path=p, lines=lines))
                    break
    _index = idx
    return idx


def split_top(s):
    out, depth, cur = [], 0, ""
    for ch in s:
        if ch == "<":
            depth += 1
        elif ch == ">":
            depth -= 1
        if ch == "," and depth == 0:
            out.append(cur.strip()); cur = ""
        else:
            cur += ch
    if cur.strip():
        out.append(cur.strip())
    return out


def generic_args(t):
    m = re.match(r"^[\w.`]+<(.*)>$", t)
    return split_top(m.group(1)) if m else []


def simple(t):
    t = t.replace("System.", "").strip()
    t = re.sub(r"`\d+", "", t)
    return t.split("<")[0].split(".")[-1]


def info(name):
    lst = index().get(simple(name))
    return lst[0] if lst else None


def is_unity_object(name):
    seen = set()
    n = simple(name)
    while n and n not in seen:
        if n in UNITY_ROOTS:
            return True
        seen.add(n)
        i = info(n)
        if not i:
            return n not in VEC and n not in PRIM and n != "string"  # tipo Unity desconhecido: tratar como referencia
        n = simple(i["base"]) if i["base"] else None
    return False


def class_fields(cname):
    """Campos serializados de cname (base primeiro): lista de (tipo, nome)."""
    i = info(cname)
    if not i:
        raise Unsupported(f"classe sem fonte: {cname}")
    out = []
    if i["base"] and simple(i["base"]) not in UNITY_ROOTS and info(i["base"]):
        out += class_fields(i["base"])
    lines = i["lines"]
    for k, l in enumerate(lines):
        m = re.match(r"^\t(public|private|protected|internal)((?: static| const| readonly)*) (.+?) (\w+);\s*(?://.*)?$", l.rstrip("\r"))
        if not m:
            continue
        vis, mods, typ, name = m.groups()
        if " static" in mods or " const" in mods or " readonly" in mods or "<" in name:
            continue
        attrs = " ".join(x.strip() for x in lines[max(0, k - 4):k] if x.strip().startswith("["))
        if "NonSerialized" in attrs or (vis != "public" and "SerializeField" not in attrs):
            continue
        out.append((typ.strip(), name))
    return out


def node(level, typ, name, flag=0):
    return dict(m_Level=level, m_Type=typ, m_Name=name, m_MetaFlag=flag)


def emit(t, name, level, out):
    t = t.replace("System.", "").strip()
    s = simple(t)
    if t.endswith("[]") or (s == "List" and generic_args(t)):
        el = t[:-2] if t.endswith("[]") else generic_args(t)[0]
        out.append(node(level, "vector", name, 0x4000))
        out.append(node(level + 1, "Array", "Array", 0x4000))
        out.append(node(level + 2, "int", "size"))
        emit(el, "data", level + 2, out)
        return
    if any(t.startswith(p) for p in NOT_SER):
        raise Unsupported(f"nao serializavel: {t}")
    if s in NAMED_PRIM:
        t, s = NAMED_PRIM[s], NAMED_PRIM[s]
    if s == "string":
        out.append(node(level, "string", name, 0x4000)); return
    if s == "bool":
        BOOL_NAMES.add(name)
    if s in PRIM:
        out.append(node(level, PRIM[s][0], name, PRIM[s][1])); return
    if s in VEC:
        out.append(node(level, VEC[s][0], name))
        for f in VEC[s][1]:
            out.append(node(level + 1, "float", f))
        return
    i = info(s)
    if i and i["kind"] == "enum":
        out.append(node(level, "int", name)); return
    if s == "SerializableDictionaryBase" or (i and i["base"] and simple(i["base"]) == "SerializableDictionaryBase"):
        args = generic_args(t) if s == "SerializableDictionaryBase" else generic_args(i["base"])
        if len(args) != 2:
            raise Unsupported(f"dicionario sem args: {t}")
        out.append(node(level, s, name))
        if DICT_BASE["n"] is None:
            for bt, bn in class_fields("DrawableDictionary"):  # base editor: reorderableList (sem campos) + reqReferences (PPtr)
                emit(bt, bn, level + 1, out)
        else:  # variante: n inteiros de 4 bytes no lugar da base (objetos em cenas serializam menos)
            for k in range(DICT_BASE["n"]):
                out.append(node(level + 1, "int", f"_base{k}"))
        emit(f"List<{args[0]}>", "_keyValues", level + 1, out)
        emit(f"{args[0]}[]", "_keys", level + 1, out)
        emit(f"{args[1]}[]", "_values", level + 1, out)
        return
    if s == "UnityEvent":
        out.append(node(level, "UnityEvent", name))
        out.append(node(level + 1, "PersistentCallGroup", "m_PersistentCalls"))
        out.append(node(level + 2, "PersistentCall", "m_Calls"))
        out.append(node(level + 3, "Array", "Array", 0x4000))
        out.append(node(level + 4, "int", "size"))
        out.append(node(level + 4, "PersistentCall", "data"))
        for lv, ty, nm in ((5, "PPtr<$Object>", "m_Target"), (5, "string", "m_TargetAssemblyTypeName"), (5, "string", "m_MethodName"), (5, "int", "m_Mode"), (5, "ArgumentCache", "m_Arguments"), (5, "int", "m_CallState")):
            out.append(node(level + lv, ty, nm))
            if ty.startswith("PPtr"):
                out.append(node(level + lv + 1, "int", "m_FileID")); out.append(node(level + lv + 1, "SInt64", "m_PathID"))
            if nm == "m_Arguments":
                for a, (ty2, nm2) in enumerate((("PPtr<$Object>", "m_ObjectArgument"), ("string", "m_ObjectArgumentAssemblyTypeName"), ("int", "m_IntArgument"), ("float", "m_FloatArgument"), ("string", "m_StringArgument"), ("UInt8", "m_BoolArgument"))):
                    out.append(node(level + lv + 1, ty2, nm2, 0x4000 if ty2 == "UInt8" else 0))
                    if ty2.startswith("PPtr"):
                        out.append(node(level + lv + 2, "int", "m_FileID")); out.append(node(level + lv + 2, "SInt64", "m_PathID"))
        return
    if i and i["kind"] in ("class", "struct") and not is_unity_object(s):
        # o Cpp2IL nao imprime [Serializable]; a leitura exata (byte_size) valida o palpite
        out.append(node(level, s, name))
        for ft, fn in class_fields(s):
            emit(ft, fn, level + 1, out)
        return
    # referencia a objeto Unity
    out.append(node(level, f"PPtr<{s}>", name))
    out.append(node(level + 1, "int", "m_FileID")); out.append(node(level + 1, "SInt64", "m_PathID"))


def sane(v, path=""):
    """Plausibilidade dos valores lidos: a leitura exata de byte_size e necessaria mas NAO suficiente (um parse deslocado pode consumir os mesmos bytes).
    Rejeita PPtr com fileID fora de 0..30 ou pathID >= 2**36, float nao finito/enorme, int fora de 32 bits e strings com lixo."""
    if isinstance(v, dict):
        if set(v) == {"m_FileID", "m_PathID"}:
            return 0 <= v["m_FileID"] <= 30 and 0 <= v["m_PathID"] < 2 ** 36
        for k, x in v.items():
            if k in BOOL_NAMES and isinstance(x, int) and x not in (0, 1):
                return False
        return all(sane(x, path + "/" + k) for k, x in v.items() if not k.startswith("_path") and k != "_file")
    if isinstance(v, list):
        return all(sane(x) for x in v)
    if isinstance(v, float):
        return v == v and abs(v) <= 1e7
    if isinstance(v, bool):
        return True
    if isinstance(v, int):
        return abs(v) <= 2 ** 31 - 1
    if isinstance(v, str):
        return "\ufffd" not in v and not any(ord(ch) < 32 and ch not in "\n\r\t" for ch in v)
    return True


def build(cname, with_name=True):
    out = [node(0, simple(cname), "Base"),
           node(1, "PPtr<GameObject>", "m_GameObject", 0x4000), node(2, "int", "m_FileID"), node(2, "SInt64", "m_PathID"),
           node(1, "UInt8", "m_Enabled", 0x4000),
           node(1, "PPtr<MonoScript>", "m_Script", 0x4000), node(2, "int", "m_FileID"), node(2, "SInt64", "m_PathID")]
    if with_name:
        out.append(node(1, "string", "m_Name", 0x4000))
    for ft, fn in class_fields(cname):
        emit(ft, fn, 1, out)
    return out


def main():
    raw_dir, out_dir = sys.argv[1], sys.argv[2]
    only = set(sys.argv[3:])
    os.makedirs(out_dir, exist_ok=True)
    byclass = collections.defaultdict(list)
    for f in sorted(os.listdir(raw_dir)):
        c, pid, fil = f[:-4].split("__")
        if not only or c in only:
            byclass[c].append((int(pid), fil, os.path.join(raw_dir, f)))
    summary = {}
    for c, objs in sorted(byclass.items()):
        variants = [(True, None), (False, None)] + [(wn, n) for wn in (True, False) for n in (0, 1, 2, 3, 4)]
        rows, errs, chosen = [], ["nenhuma variante leu exato"], None
        built_any = False
        for with_name, dbase in variants:
            DICT_BASE["n"] = dbase
            BOOL_NAMES.clear()
            try:
                root = TypeTreeNode.from_list(build(c, with_name))
                built_any = True
            except Unsupported as e:
                summary[c] = ("nao suportada", str(e)[:90]); break
            except Exception as e:
                summary[c] = ("erro ao montar", f"{type(e).__name__}: {str(e)[:80]}"); break
            r, e_ = [], []
            for pid, fil, p in objs:
                data = open(p, "rb").read()
                try:
                    d = TypeTreeHelper.read_typetree(root, EndianBinaryReader(data, endian="<"), as_dict=True, byte_size=len(data), check_read=True)
                    if not sane(d):
                        raise ValueError("valores implausiveis (parse deslocado?)")
                    d["_path_id"], d["_file"] = pid, fil
                    r.append(d)
                except Exception as ex:
                    e_.append(f"{type(ex).__name__}: {str(ex)[:70]}")
            if r and not e_:
                rows, errs, chosen = r, [], (with_name, dbase)
                break
            if len(r) > len(rows):
                rows, errs = r, e_
        DICT_BASE["n"] = None
        if c in summary:
            continue
        if rows and not errs:
            with gzip.open(os.path.join(out_dir, re.sub(r"[^\w.\-]+", "_", c) + ".jsonl.gz"), "wt") as fh:
                for d in rows:
                    fh.write(json.dumps(d, default=str) + "\n")
        var = "" if chosen is None else f" | variante: m_Name={'sim' if chosen[0] else 'NAO'}, base_dict={'Cpp2IL' if chosen[1] is None else str(chosen[1]) + ' ints'}"
        summary[c] = ("ok" if not errs else "parcial/falha", f"{len(rows)} ok, {len(errs)} err" + (f" | {errs[0]}" if errs else "") + var)
    for c, (st, msg) in summary.items():
        print(f"{st:15} {c} | {msg}")
    print(collections.Counter(s for s, _ in summary.values()))


if __name__ == "__main__":
    main()
