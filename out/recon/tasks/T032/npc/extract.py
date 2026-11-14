#!/usr/bin/env python3
"""Bounded T032 NPC evidence. Run with tools/venv/bin/python from repository root."""
import bisect, collections, gzip, hashlib, json, struct, subprocess, sys
from pathlib import Path
ROOT=Path(__file__).resolve().parents[5]
OUT=Path(__file__).resolve().parent
DATA=ROOT/'out/recon/il2cpp'
sys.path.insert(0,str(ROOT/'tools'))
from recon_il2cpp import Elf, Metadata, codegen_module
methods=[json.loads(l) for l in (DATA/'assembly_csharp_methods.jsonl').read_text().splitlines()]
methods=[m for m in methods if m.get('vaddr')]
byva={int(m['vaddr'],16):m for m in methods}
starts=sorted(byva)
selected=['BackgroundCharacterSpineManager.Start','BackgroundCharacterSpineManager.SetAnimation','BackgroundToddlerSpineManager.Start','BackgroundToddlerSpineManager.SetAnimation','LevelCharacterCaller.CallCharacter','LevelCharacterCaller.<CallCharacter>b__3_0','LevelSceneAvatarMap.LoadDataIfNeeded','LevelSceneAvatarMap.TryGetAvatar','LevelSceneAvatarMap.TryGetAvatars','LevelAirportWalkwayDropAreaHandler.SyncMovement','LevelAirportWalkwayDropAreaHandler.CancelMovement','LevelButlerCaller.OnPointerClick','LevelManager.Init','LevelManager.InitPhone','LevelManager.GetAllLevelDefaultAvatarsID','LevelManager.RestoreMakerExcludedSkinClothingIfNeeded','LevelAvatarExtensionMethods.<AvatarAwake>g__TryOverrideGuidCreation|3_0']
for name in selected:
    result=subprocess.run([sys.executable,str(ROOT/'tools/recon_disasm.py'),name,'--cap','20000','--data',str(DATA)],capture_output=True,text=True,check=True)
    (OUT/(name+'.asm.txt')).write_text(result.stdout)
elf=Elf((DATA/'libil2cpp.so').read_bytes())
targets={int(m['vaddr'],16):m['declaring_type']+'.'+m['name'] for m in methods if m['declaring_type'].endswith(('LevelSceneAvatarMap','BackgroundCharacterSpineManager','BackgroundToddlerSpineManager','LevelCharacterCaller'))}
xrefs=[]
for seg in elf.loads:
    if not seg['flags']&1: continue
    code=elf.data[seg['file_offset']:seg['file_offset']+seg['file_size']]
    for offset in range(0,len(code)-3,4):
        w=struct.unpack_from('<I',code,offset)[0]
        if w>>26 not in (5,37):continue
        imm=w&0x3ffffff
        if imm&(1<<25):imm-=1<<26
        pc=seg['vaddr']+offset
        target=pc+imm*4
        if target not in targets:continue
        i=bisect.bisect_right(starts,pc)-1
        caller=byva[starts[i]] if i>=0 else None
        xrefs.append({'pc':hex(pc),'target':targets[target],'op':'bl' if w>>26==37 else 'b','nearest_preceding_method':caller['declaring_type']+'.'+caller['name'] if caller else None,'attribution':'candidate_next_method_boundary_not_proven'})
(OUT/'direct-callers.json').write_text(json.dumps(xrefs,indent=2)+'\n')
census={}
for cls in ['PWC.Level.LevelSceneAvatarMap','PWC.Level.LevelCharacterCallerConfig','PWC.Level.LevelCharacterCaller','Game.Level.BackgroundCharacterSpineManager','Game.Level.BackgroundToddlerSpineManager','Game.Level.LevelAirportWalkwayDropAreaHandler','Game.Level.LevelButlerCaller']:
    path=ROOT/'out/mb'/f'{cls}.jsonl.gz'
    rows=[json.loads(l) for l in gzip.open(path,'rt')] if path.exists() else []
    census[cls]={'count':len(rows),'files':dict(collections.Counter(r['_file'] for r in rows)),'rows':rows,'source_sha256':hashlib.sha256(path.read_bytes()).hexdigest() if path.exists() else None}
(OUT/'census.json').write_text(json.dumps(census,indent=2)+'\n')
meta=Metadata((DATA/'global-metadata.dat').read_bytes())
external=[]
for image_name in ['spine-unity.dll','spine-csharp.dll','UnityEngine.CoreModule.dll']:
    image,image_methods=meta.image_methods(image_name)
    module=codegen_module(elf,image['name'],len(image_methods))
    for m in image_methods:
        va=elf.pointer(module['method_pointers_vaddr']+(m['rid']-1)*8)
        if va in [0x35189d8,0x351908c,0x34d7c1c,0x34d7f98,0x3caede0,0x3cd4584,0x3cd4624,0x3ccb8d8,0x3ccab90]:
            external.append(dict(m,vaddr=hex(va)))
(OUT/'external-methods.json').write_text(json.dumps(external,indent=2)+'\n')
manifest={'evidence_kind':'local structural metadata + ARM64 + decoded serialized fields; no REA provider or runtime','sources':{str(p.relative_to(ROOT)):hashlib.sha256(p.read_bytes()).hexdigest() for p in [DATA/'libil2cpp.so',DATA/'global-metadata.dat',DATA/'assembly_csharp_methods.jsonl',ROOT/'tools/recon_disasm.py']},'selected':selected,'limitations':['Disassembly ends at next known method; this is not proof of complete body extent.','Direct callers do not cover interface, virtual, delegate or UnityEvent calls.','No live device execution in this evidence.']}
(OUT/'manifest.json').write_text(json.dumps(manifest,indent=2)+'\n')
print('NPC evidence captured:',len(selected),'method windows;',len(xrefs),'direct call sites')
