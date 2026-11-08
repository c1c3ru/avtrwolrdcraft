"""Independent opcode/metadata checks for the families findings."""
from pathlib import Path
import json
import struct
import sys

ROOT=Path(__file__).resolve().parents[5]
sys.path.insert(0,str(ROOT/'tools'))
import recon_navigation as n

b=(ROOT/'out/recon/il2cpp/libil2cpp.so').read_bytes()
m=(ROOT/'out/recon/il2cpp/global-metadata.dat').read_bytes()
n.verify_pair(b,m)
elf,meta=n.Elf(b),n.Metadata(m)
rows,resolve=n.load_index(ROOT/'out/recon/il2cpp/metadata_methods.jsonl',elf,meta)
checks=[]
def check(label,site,word):
    n.expect(elf,site,word)
    checks.append(dict(label=label,site=hex(site),word=hex(word)))

check('animal running false',0x2265b28,0x2a1f03e0)
check('animal running ret',0x2265b2c,0xd65f03c0)
running=[r for r in rows if r['image']=='Assembly-CSharp.dll' and r['name']=='HasRunningAnimations']
n.require(len(running)==1 and running[0]['declaring_type']=='PWC.Level.LevelAnimal','running override census')
vt,_=struct.unpack_from('<II',m,144)
vtable=[]
for t in meta.types:
    if t['name'] not in ['LevelCat','LevelDog','LevelHorse']:continue
    raw=struct.unpack_from('<16I8H2I',m,meta.tables['types']['offset']+t['index']*88)
    enc=struct.unpack_from('<I',m,vt+(raw[14]+147)*4)[0]
    n.require(enc>>29==3 and enc&1 and (enc&0x1fffffff)>>1==30127,'concrete running slot')
    vtable.append(dict(type=t['name'],slot=147,encoded=hex(enc),target=30127))

usage=n.metadata_usage(elf,0x41c1908)
walk=n.literal(meta,usage)
n.require(walk['literal']=='Track_Animations/Forced_To_Walk','walking literal')
check('getter loads walking usage',0x2266e1c,0xf9448694)
check('getter returns literal slot',0x2266e38,0xf9400280)
# Unlocked Walk selects virtual slot158; main SetAddAnimationInternal receives trackIndex0.
check('unlocked walk selects slot158',0x2265764,0xf9458d09)
check('main animation trackIndex0',0x2265894,0x2a1f03e3)
n.require(n.branch(0x226589c,n.word(elf,0x226589c))['target']==0x2266814,'main animation call')
check('locked gate',0x22658a0,0x394dea68)
check('locked branch uses slot158',0x22658b8,0xf9458d09)
check('overlay trackIndex1',0x22658e0,0x52800021)
check('overlay loop true',0x22658e4,0x52800023)
n.require(resolve(0x34d7c1c)[0]['name']=='SetAnimation','overlay SetAnimation target')
n.require(n.branch(0x22658f0,n.word(elf,0x22658f0))['target']==0x34d7c1c,'overlay animation call')
check('empty overlay trackIndex1',0x2265918,0x52800021)
n.require(resolve(0x34d8294)[0]['name']=='SetEmptyAnimation','empty overlay target')
n.require(n.branch(0x2265920,n.word(elf,0x2265920))['target']==0x34d8294,'empty overlay call')

# Baby sync uses the concrete metadata vtable; absence by method name is not the sole proof.
t=next(t for t in meta.types if t['name']=='LevelBaby')
raw=struct.unpack_from('<16I8H2I',m,meta.tables['types']['offset']+t['index']*88)
enc=struct.unpack_from('<I',m,vt+(raw[14]+27)*4)[0]
idx=(enc&0x1fffffff)>>1
baby_sync=[r for r in rows if r['method_definition_index']==idx][0]
n.require(baby_sync['declaring_type']=='PWC.Level.LevelItem' and baby_sync['name']=='OnSyncPosition','Baby sync inheritance')
check('Baby begin base LevelItem',0x229b7cc,0x94016aa5)
check('Baby begin delegate true',0x229b7f8,0x52800022)
check('Baby land delegate false',0x229b918,0x2a1f03e2)
check('Baby land delegate flag true',0x229b910,0x52800023)

skeletons=[json.loads(x) for x in (ROOT/'out/recon/tasks/T032/skel-dump.jsonl').read_text().splitlines()]
found=[]
for prefix in ['Pet_Cat_Spine.skel','Pet_Dog_Spine.skel','Pet_Horse.skel']:
    s=[r for r in skeletons if r['file'].startswith(prefix)]
    n.require(len(s)==1,'pet skeleton ambiguous')
    n.require(walk['literal'] in [x['Name'] for x in s[0]['animations']],'pet missing forced walk')
    found.append(s[0]['file'])

result=dict(schema_version=1,status='pass',native_sha256=n.sha(b),metadata_sha256=n.sha(m),
    checks=checks,running_definitions=running,concrete_running_vtables=vtable,walking_literal=walk,
    baby_sync=baby_sync,pet_skeletons_with_forced_walk=found,
    conclusions=[
      'Forced_To_Walk is correct on track0 for unlocked default movement; track1 is required only for locked movement composition.',
      'Locked mode keeps locked animation on track0 and applies looping forced walk on track1; stand branch empties track1.',
      'Animal running capability false is proven for the shipped base and Cat/Dog/Horse concrete vtables.',
      'Baby inherits LevelItem.OnSyncPosition; it should retain physical drag without Character/Toddler/Animal locomotion cycles.'
    ],minimal_safe_integration=[
      'Change the unlocked animal walking name to Forced_To_Walk and keep its main track0.',
      'Disable artifact animal run capability; keep generic hysteresis only if explicitly distinguished from artifact capabilities.',
      'Route Baby and five tech types to base physical movement; do not default to Character skeleton or walking animations.',
      'Treat locked animation as a separate composition path with track1 and cleanup; do not claim lock parity from the name-only fix.'
    ],limits=[
      'No client or game execution in this review.',
      'Baby static delegate names not inferred from noncanonical metadata usage.',
      'Current client has no complete locked locomotion contract; report does not approve inferred CA/drag arbitration.'
    ])
n.atomic_json(Path(__file__).with_name('review-families.json'),result)
print('PASS: independent family review,',len(checks),'native opcode checks')
