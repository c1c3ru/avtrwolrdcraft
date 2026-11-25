"""Decodificacao estrutural (sem nomes de campo) das classes PWC.EditorApp.* + resolucao de contexto (arquivo, GameObject, referencias).
uso: resolve_ea.py <datapack> <saida.json>   (rodar da raiz do repo principal; usa tools/lowmem_unitypy.py)"""
import sys, os, glob, json, struct, collections, gc
import UnityPy
sys.path.insert(0, '/home/deppi/avtrwolrdcraft/.claude/worktrees/re-capstone-dispatch/tools')
import lowmem_unitypy as L
T = '/home/deppi/.claude/jobs/b6b1dc79/tmp/'
bundle, outp = sys.argv[1], sys.argv[2]
L.install(T, 'base')
base = UnityPy.load('x/base/assets/bin/Data/data.unity3d')
scripts = {o.path_id: o.read() for o in base.objects if o.type.name == 'MonoScript'}
names = {pid: f'{s.m_Namespace}.{s.m_ClassName}'.strip('.') for pid, s in scripts.items()}
del base; gc.collect()
L.TMP['tag'] = 'datapack'
env = UnityPy.load(bundle)
files = {}
def sf_by_name(n):
    if n in files: return files[n]
    for k, v in env.files.items():
        if k == n or k.endswith('/' + n):
            files[n] = v; return v
    # procura em bundles aninhados
    for k, v in env.files.items():
        if hasattr(v, 'files') and n in v.files:
            files[n] = v.files[n]; return files[n]
    files[n] = None; return None
def go_name(sf, pid):
    try:
        o = sf.objects[pid]
        if o.type.name == 'GameObject':
            return o.read(check_read=False).m_Name
    except Exception as e:
        return None
def describe(sf, pid):
    """tipo e nome (GameObject) do objeto referenciado"""
    try:
        o = sf.objects[pid]
    except KeyError:
        return None
    t = o.type.name; d = {'type': t, 'path_id': pid}
    try:
        if t == 'GameObject':
            d['name'] = o.read(check_read=False).m_Name
        elif t == 'MonoBehaviour':
            x = o.read(check_read=False)
            d['script'] = names.get(x.m_Script.m_PathID)
            g = x.m_GameObject.m_PathID
            d['gameobject'] = go_name(sf, g) if g else None
        else:
            x = o.read(check_read=False)
            g = getattr(getattr(x, 'm_GameObject', None), 'm_PathID', 0)
            d['gameobject'] = go_name(sf, g) if g else None
    except Exception as e:
        d['erro'] = str(e)[:50]
    return d
def decode(data, sf):
    """itens estruturais apos o cabecalho: ('pptr', fileID, pathID) | ('str', texto) | ('int', n)"""
    i = 28
    ln = struct.unpack_from('<i', data, i)[0]
    name = ''
    if 0 <= ln < 200 and i + 4 + ln <= len(data):
        name = data[i + 4:i + 4 + ln].decode('utf8', 'replace'); i = (i + 4 + ln + 3) & ~3
    else:
        i += 4
    items = []
    while i + 4 <= len(data):
        if i + 12 <= len(data):
            fid = struct.unpack_from('<i', data, i)[0]; pid = struct.unpack_from('<q', data, i + 4)[0]
            if 0 < pid < 2 ** 32 and (0 <= fid <= 30) and (fid != 0 or (sf and pid in sf.objects)):
                items.append(('pptr', fid, pid)); i += 12; continue
        v = struct.unpack_from('<i', data, i)[0]
        if 0 < v < 200 and i + 4 + v <= len(data) and all(32 <= b < 127 for b in data[i + 4:i + 4 + v]):
            items.append(('str', data[i + 4:i + 4 + v].decode())); i = (i + 4 + v + 3) & ~3; continue
        items.append(('int', v)); i += 4
    return name, items
out = []
for f in sorted(glob.glob(T + 'raw/PWC.EditorApp.*')):
    cls, pid, fil = os.path.basename(f)[:-4].split('__')
    data = open(f, 'rb').read()
    sf = sf_by_name(fil)
    gopid = struct.unpack_from('<q', data, 4)[0]
    rec = {'class': cls, 'path_id': int(pid), 'file': fil, 'size': len(data), 'gameobject': go_name(sf, gopid) if sf else None}
    name, items = decode(data, sf)
    rec['m_Name'] = name
    rec['items'] = []
    for it in items:
        if it[0] == 'pptr' and it[1] == 0 and sf:
            rec['items'].append({'kind': 'pptr', 'ref': describe(sf, it[2])})
        elif it[0] == 'pptr':
            rec['items'].append({'kind': 'pptr_externo', 'fileID': it[1], 'path_id': it[2]})
        else:
            rec['items'].append({'kind': it[0], 'value': it[1]})
    out.append(rec)
    print(rec['class'].split('.')[-1], fil, 'GO=', rec['gameobject'], '| itens', len(items), flush=True)
json.dump(out, open(outp, 'w'), indent=1, ensure_ascii=False)
