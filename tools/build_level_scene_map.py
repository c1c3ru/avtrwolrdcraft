import UnityPy, zipfile, json, re, os
from pathlib import Path
R = Path('/home/deppi/avatarworld-re')
W = R / '.claude/worktrees/t032-locomotion-contract'
apk = R / 'assets/base.apk'
if not apk.exists():
    apk = W / 'assets/base.apk'
print('apk', apk, apk.exists())
raw = zipfile.ZipFile(apk).read('assets/bin/Data/data.unity3d')
env = UnityPy.load(raw)
bs = [o.read_typetree() for o in env.objects if o.type.name == 'BuildSettings'][0]
scenes = [Path(p).stem for p in bs['scenes']]
print(len(scenes), scenes[:12])
# LevelType enum
txt = (W / 'out/cpp2il/DiffableCs/Assembly-CSharp/PWC/Game/LevelType.cs').read_text()
enum = {int(m.group(2)): m.group(1) for m in re.finditer(r'\t(\w+) = (\d+),', txt)}
world = json.load(open(W / 'client/AvatarWorldClient/Assets/Resources/WorldSlice/world.json'))
have = {p.name for p in (R / 'out/scene-extract').iterdir() if re.fullmatch(r'level\d+', p.name)}
out = []
for lv in sorted({b['defaultLevel'] for b in world['buildings'] if b['defaultLevel']}):
    name = enum.get(lv)
    scene = 'Level_' + str(name)
    idx = scenes.index(scene) if scene in scenes else None
    out.append({'levelType': lv, 'name': name, 'scene': scene, 'buildIndex': idx,
                'extracted': (f'level{idx}' in have) if idx is not None else False})
json.dump(out, open('/home/deppi/.claude/jobs/0979ab8d/tmp/levelmap.json', 'w'), indent=1)
for o in out:
    print(o)
