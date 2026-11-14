#!/usr/bin/env python3
"""Check evidence integrity and independently decode crucial BL targets."""
import hashlib,json,struct,sys
from pathlib import Path
OUT=Path(__file__).resolve().parent;ROOT=OUT.parents[4]
sys.path.insert(0,str(ROOT/'tools'))
from recon_il2cpp import Elf
manifest=json.loads((OUT/'manifest.json').read_text());checks=[]
for path,digest in manifest['sources'].items():checks.append({'check':'source_hash:'+path,'passed':hashlib.sha256((ROOT/path).read_bytes()).hexdigest()==digest})
c=json.loads((OUT/'census.json').read_text());avs=[a for r in c['PWC.Level.LevelSceneAvatarMap']['rows'] for a in r['avatars']]
checks.extend([{'check':'229_scene_maps','passed':c['PWC.Level.LevelSceneAvatarMap']['count']==229},{'check':'1170_records_all_on_phone','passed':len(avs)==1170 and all(a['isOnPhone'] for a in avs)},{'check':'1157_distinct_ids','passed':len({a['id'] for a in avs})==1157}])
e=Elf((ROOT/'out/recon/il2cpp/libil2cpp.so').read_bytes())
for pc,target in [(0x22af230,0x3caede0),(0x22af334,0x2331cbc),(0x22af398,0x3cd4624),(0x1e017fc,0x34d7c1c),(0x1e01830,0x34d7f98),(0x1e018bc,0x34d7c1c),(0x1e018f0,0x34d7f98),(0x1e3ca70,0x1c78ab4),(0x1e3ca90,0x1d93d50),(0x2314248,0x22ca3e0),(0x2312a04,0x22ca3e0),(0x2312c2c,0x22ac6e0),(0x2290a34,0x22ca908)]:
 w=struct.unpack_from('<I',e.data,e.offset(pc,4))[0];imm=w&0x3ffffff
 if imm&(1<<25):imm-=1<<26
 checks.append({'check':f'branch_{pc:x}_to_{target:x}','passed':w>>26 in (5,37) and pc+imm*4==target})
from capstone import Cs, CS_ARCH_ARM64, CS_MODE_ARM
cs=Cs(CS_ARCH_ARM64, CS_MODE_ARM)
for pc,mnemonic,operands in [(0x23142ac,'ldrb','w9, [x8, #0x28]'),(0x23142b0,'cbz','w9, #0x2314294'),(0x2312bfc,'ldp','s9, s8, [x25, #0x14]')]:
 ins=next(cs.disasm(e.data[e.offset(pc,4):e.offset(pc,4)+4],pc))
 checks.append({'check':f'field_consumer_{pc:x}','passed':ins.mnemonic==mnemonic and ins.op_str==operands})
r={'passed':all(x['passed'] for x in checks),'checks':checks,'runtime_executed':False}
(OUT/'validation.json').write_text(json.dumps(r,indent=2)+'\n');print(json.dumps(r,indent=2));sys.exit(0 if r['passed'] else 1)
