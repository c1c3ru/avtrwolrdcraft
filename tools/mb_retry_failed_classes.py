"""Reextrai, do datapack.unity3d, SO as classes de MonoBehaviour que ainda falham em out/mb/_stats.json
(fica mais leve que rodar mb_dump.py inteiro de novo, que reprocessaria as ~2180 classes ja ok).

Usa o mesmo fix de tools/mb_dump.py (fix_mislabeled_vectors) para o bug do TypeTreeGeneratorAPI que rotula
List<String> como m_Type="string" em vez de "vector" (EOFError: read_str out of bounds / ValueError de
contagem de bytes). Ver docs/RECON_STORE_HOUSE_BUNDLES_2026-11-07.md para o diagnostico completo.

REQUISITO DE MEMORIA (confirmado por journalctl -k, 2026-11-21): o processo passa de 5,8 GB de RSS so pra
carregar x/base/assets/bin/Data/datapack.unity3d (1,3 GB comprimido; Unity usa LZMA/LZ4HC, descomprime bem
maior). NAO roda de forma confiavel numa maquina de 7,1 GB de RAM mesmo com o resto do sistema enxuto -
precisa de algo como 8-10 GB livres (RAM + swap rapido) so para este processo. Rodar numa maquina com mais
RAM disponivel.

Preparo (extrair o jogo do APK, se ainda nao tiver `il2cpp_in/` e `x/` na raiz do repo - ambos gitignored,
nao versionados):
    mkdir -p il2cpp_in x/base/assets/bin/Data
    unzip -p assets/split_config.arm64_v8a.apk lib/arm64-v8a/libil2cpp.so > il2cpp_in/libil2cpp.so
    unzip -p assets/base.apk assets/bin/Data/Managed/Metadata/global-metadata.dat > il2cpp_in/global-metadata.dat
    unzip -p assets/base.apk assets/bin/Data/data.unity3d > x/base/assets/bin/Data/data.unity3d
    unzip -p assets/split_UnityDataAssetPack.apk assets/bin/Data/datapack.unity3d > x/base/assets/bin/Data/datapack.unity3d
    pip install UnityPy TypeTreeGeneratorAPI   # TypeTreeGeneratorAPI nao vem com UnityPy por padrao

uso: python3 tools/mb_retry_failed_classes.py
saida: out/mb/<Classe>.jsonl.gz (uma por classe que passou a funcionar) + out/mb/_stats.json atualizado
       (mescla os resultados novos aos ja existentes, sem apagar o historico das classes que ja estavam ok).
"""
import json, gzip, os, re, collections, UnityPy
from pathlib import Path
from UnityPy.helpers.TypeTreeGenerator import TypeTreeGenerator

ROOT = Path(__file__).resolve().parents[1]
OUT = ROOT / 'out/mb'


def fix_mislabeled_vectors(nodes):
    n = len(nodes)
    fixed = 0
    for i, node in enumerate(nodes):
        if node["m_Type"] != "string":
            continue
        lvl = node["m_Level"]
        j = i + 1
        children = []
        while j < n and nodes[j]["m_Level"] > lvl:
            if nodes[j]["m_Level"] == lvl + 1:
                children.append(nodes[j])
            j += 1
        if not children or children[0]["m_Name"] != "Array":
            continue
        arr_lvl = children[0]["m_Level"]
        k = i + 2
        arr_children = []
        while k < n and nodes[k]["m_Level"] > arr_lvl:
            if nodes[k]["m_Level"] == arr_lvl + 1:
                arr_children.append(nodes[k])
            k += 1
        data_child = next((c for c in arr_children if c["m_Name"] == "data"), None)
        if data_child is not None and data_child["m_Type"] != "char":
            node["m_Type"] = "vector"
            fixed += 1
    return fixed


def main():
    stats_path = OUT / '_stats.json'
    stats = json.loads(stats_path.read_text(encoding='utf-8'))
    targets = set(stats['erros'].keys())
    print('targets:', len(targets), flush=True)
    if not targets:
        print('nada para reextrair - out/mb/_stats.json nao tem classes com erro.')
        return

    g = TypeTreeGenerator("2022.3.70f1")
    g.load_il2cpp((ROOT / 'il2cpp_in/libil2cpp.so').read_bytes(),
                  (ROOT / 'il2cpp_in/global-metadata.dat').read_bytes())

    base = UnityPy.load(str(ROOT / 'x/base/assets/bin/Data/data.unity3d'))
    scripts = {o.path_id: o.read() for o in base.objects if o.type.name == 'MonoScript'}
    print('base scripts loaded:', len(scripts), flush=True)

    env = UnityPy.load(str(ROOT / 'x/base/assets/bin/Data/datapack.unity3d'))
    print('datapack loaded', flush=True)

    nodes_cache = {}

    def nodes_for(s):
        k = (s.m_AssemblyName, s.m_Namespace, s.m_ClassName)
        if k not in nodes_cache:
            asm = s.m_AssemblyName.removesuffix('.dll')
            try:
                ns = json.loads(g.get_nodes_as_json(asm, f'{s.m_Namespace}.{s.m_ClassName}' if s.m_Namespace else s.m_ClassName))
                for n in ns:
                    if n['m_Name'] == 'm_Enabled' and n['m_Level'] == 1:
                        n['m_MetaFlag'] = 16384
                fix_mislabeled_vectors(ns)
                nodes_cache[k] = ns
            except Exception:
                nodes_cache[k] = None
        return nodes_cache[k]

    safe = lambda s: re.sub(r'[^\w.\-]+', '_', s)
    files = {}
    new_stat = collections.defaultdict(lambda: collections.Counter())
    new_errs = {}
    seen = 0
    written = 0
    for o in env.objects:
        if o.type.name != 'MonoBehaviour':
            continue
        raw = o.read(check_read=False)
        pid = raw.m_Script.m_PathID
        s = scripts.get(pid)
        if s is None:
            continue
        cname = f'{s.m_Namespace}.{s.m_ClassName}'.strip('.')
        if cname not in targets:
            continue
        seen += 1
        st = new_stat[cname]
        nodes = nodes_for(s)
        try:
            d = o.read_typetree(nodes, check_read=True) if nodes else o.read_typetree(check_read=True)
            if d['m_Script']['m_PathID'] != pid:
                st['bad'] += 1
                continue
            st['ok'] += 1
            if cname not in files:
                files[cname] = gzip.open(OUT / f'{safe(cname)}.jsonl.gz', 'wt')
            d['_path_id'] = o.path_id
            d['_file'] = o.assets_file.name
            files[cname].write(json.dumps(d, default=str) + '\n')
            written += 1
        except BaseException as e:
            if not isinstance(e, Exception):
                raise
            st['err'] += 1
            new_errs.setdefault(cname, f'{type(e).__name__}: {str(e)[:160]}')
        if seen % 200 == 0:
            print('progress', seen, 'written', written, flush=True)

    for f in files.values():
        f.close()

    # mescla no _stats.json existente: classes que passaram a ler saem de 'erros' e viram 'ok' em 'stats'.
    for cname, counts in new_stat.items():
        stats['stats'][cname] = dict(counts)
        if counts.get('ok') and cname in stats['erros']:
            del stats['erros'][cname]
    for cname, msg in new_errs.items():
        stats['erros'][cname] = msg
    stats_path.write_text(json.dumps(stats, indent=1), encoding='utf-8')

    tot = collections.Counter()
    for c in new_stat.values():
        tot.update(c)
    print('DONE classes_touched', len(new_stat), dict(tot), 'written', written,
          'ainda com erro', len(stats['erros']))


if __name__ == '__main__':
    main()
