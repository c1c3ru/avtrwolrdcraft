#!/usr/bin/env python3
"""Inventaria os NPCs (avatares, pets e personagens de fundo) de cada interior exportado.

Fontes (todas ja extraidas em out/): out/mb/*.jsonl.gz (MonoBehaviours/ScriptableObjects), out/recon/building_scenes.json
(predio -> LevelType -> levelN) e InteriorCatalog.cs (chave -> levelN).
  - PWC.Level.LevelSceneAvatarMap     : por cena "Level_<LevelType>", lista de avatares {id, position, isOnPhone}
  - PWC.Level.LevelAvatarOneTimeSpawner: avatar gerado por script (avatarId, flip, animacao) no levelN
  - PWC.Level.LevelCharacterCallerConfig: papel/animacoes de um avatar id (nome "<LevelType>_<Papel>CallerConfig")
  - Game.Level.LevelAnimalIDHandler / LevelCat: pets da cena; Game.Level.BackgroundCharacterSpineManager: fundo
A aparencia (roupas) de cada avatar id NAO esta nos dados locais. Saida: out/recon/interior_npcs.json e docs/RECON_INTERIOR_NPCS.md.
uso: python3 tools/recon_interior_npcs.py
"""
import collections, gzip, json, re
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
MB = ROOT / 'out/mb'


def rows(name):
    path = MB / f'{name}.jsonl.gz'
    return [json.loads(line) for line in gzip.open(path, 'rt')] if path.exists() else []


def main():
    catalog = (ROOT / 'client/AvatarWorldClient/Assets/Scripts/Core/World/InteriorCatalog.cs').read_text(encoding='utf-8')
    keys = re.findall(r'"(\w+)" \}, // (\S+) -> (level\d+)', catalog)
    scenes = {b['file']: b for b in json.loads((ROOT / 'out/recon/building_scenes.json').read_text())['buildings']}
    avatar_maps = {r['m_Name']: r for r in rows('PWC.Level.LevelSceneAvatarMap')}
    callers = rows('PWC.Level.LevelCharacterCallerConfig')
    by_file = lambda cls: collections.defaultdict(list, {})  # noqa: E731
    spawners, animals, cats, bg = (collections.defaultdict(list) for _ in range(4))
    for r in rows('PWC.Level.LevelAvatarOneTimeSpawner'): spawners[r['_file']].append(r)
    for r in rows('Game.Level.LevelAnimalIDHandler'): animals[r['_file']].append(r)
    for r in rows('Game.Level.LevelCat'): cats[r['_file']].append(r)
    for r in rows('Game.Level.BackgroundCharacterSpineManager'): bg[r['_file']].append(r)

    out, seen_keys = {}, set()
    for key, building, level in keys:
        if key in seen_keys: continue
        seen_keys.add(key)
        level_type = (scenes.get(level) or {}).get('levelType', '')
        amap = avatar_maps.get('Level_' + level_type) if level_type else None
        avatars = []
        for a in (amap['avatars'] if amap else []):
            role = next((c['m_Name'] for c in callers if c['id'] == a['id']), None)
            avatars.append({'id': a['id'], 'x': round(a['position']['x'], 2), 'y': round(a['position']['y'], 2),
                            'onPhone': bool(a['isOnPhone']), 'callerConfig': role})
        out[key] = {
            'building': building, 'level': level, 'levelType': level_type, 'sceneAvatarMap': bool(amap), 'avatars': avatars,
            'scriptSpawns': [{'avatarId': s['_avatarId'], 'flipped': bool(s['_isFlipped']), 'playAnimation': bool(s['_playAnimation'])} for s in spawners[level]],
            'pets': [{'id': p['_id'], 'name': p['_oldSystemName'], 'spineType': p['_spineType']} for p in animals[level]],
            'cats': len(cats[level]), 'backgroundCharacters': [b['_backgroundCharacterID'] for b in bg[level]],
        }
    (ROOT / 'out/recon/interior_npcs.json').write_text(json.dumps(out, indent=1))

    total = sum(len(v['avatars']) for v in out.values())
    lines = ['# NPCs dos interiores (recon estático)', '',
             'Gerado por `tools/recon_interior_npcs.py`. **Avatares**: lista `LevelSceneAvatarMap` da cena (id + posição, mesmo sistema de '
             'coordenadas dos sprites exportados). **Script**: `LevelAvatarOneTimeSpawner`. **Pets**: `LevelAnimalIDHandler`. '
             '**Fundo**: `BackgroundCharacterSpineManager`. A **aparência** de cada id não está nos dados locais (provavelmente '
             'vem do servidor/prefab), então hoje só dá para posicionar um personagem genérico em cada ponto.', '',
             f'Total: **{total}** avatares em {sum(1 for v in out.values() if v["avatars"])} de {len(out)} interiores.', '',
             '| Interior | LevelType | Avatares | isOnPhone | Script | Pets | Fundo |', '|---|---|---:|---:|---:|---:|---:|']
    for key, v in sorted(out.items()):
        lines.append(f"| {key} | {v['levelType']} | {len(v['avatars'])} | {sum(1 for a in v['avatars'] if a['onPhone'])} | "
                     f"{len(v['scriptSpawns'])} | {len(v['pets']) + v['cats']} | {len(v['backgroundCharacters'])} |")
    roles = sorted({(a['id'], a['callerConfig']) for v in out.values() for a in v['avatars'] if a['callerConfig']})
    if roles:
        lines += ['', '## Papéis nomeados (`LevelCharacterCallerConfig`)', ''] + [f'- `{i}` — {n}' for i, n in roles]
    (ROOT / 'docs/RECON_INTERIOR_NPCS.md').write_text('\n'.join(lines) + '\n', encoding='utf-8')
    print(total, 'avatares;', sum(1 for v in out.values() if v['avatars']), '/', len(out), 'interiores com avatares')
    print('sem mapa de cena:', [k for k, v in out.items() if not v['sceneAvatarMap']][:20])


if __name__ == '__main__':
    main()
