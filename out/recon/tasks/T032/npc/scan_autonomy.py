#!/usr/bin/env python3
"""Bounded name search, not proof of global absence of AI."""
import json,re,collections,hashlib
from pathlib import Path
OUT=Path(__file__).resolve().parent;ROOT=OUT.parents[4]
path=ROOT/'out/recon/il2cpp/assembly_csharp_methods.jsonl'
rows=[json.loads(l) for l in path.read_text().splitlines()]
patterns={
'explicit_ai_npc':r'NPC|Npc|AI(?=[A-Z_.$]|$)|(?i:Autonom|Wander|Patrol|NavMesh|Pathfind|BehaviourTree|BehaviorTree|DecisionTree)',
'movement_related':r'(?i)Walk|Mov(e|ement)|Follow|RandomPosition|Destination|Waypoint|Steer',
'entity_related':r'(?i)Character|Toddler|Baby|Animal|LevelCat|LevelDog|LevelHorse|Avatar|Pet',
}
result={'universe':{'method_rows':len(rows),'distinct_declaring_types':len({r['declaring_type'] for r in rows}),'source':str(path.relative_to(ROOT)),'sha256':hashlib.sha256(path.read_bytes()).hexdigest()},'patterns':patterns,'explicit_ai_npc':[],'entity_movement':[],'other_movement_types':[],'limits':['Case-sensitive NPC/AI markers and case-insensitive explicit concepts only. Obfuscated/generic names and data-driven event graphs can hide behavior.','Method names establish candidates, not behavior. No negative global AI claim.']}
seen=set()
for r in rows:
 n=r['declaring_type']+'.'+r['name']
 if re.search(patterns['explicit_ai_npc'],n):result['explicit_ai_npc'].append({'method':n,'vaddr':r.get('vaddr')})
 if re.search(patterns['movement_related'],n):
  if re.search(patterns['entity_related'],n):result['entity_movement'].append({'method':n,'vaddr':r.get('vaddr')})
  elif r['declaring_type'] not in seen:seen.add(r['declaring_type']);result['other_movement_types'].append(r['declaring_type'])
(OUT/'autonomy-name-scan.json').write_text(json.dumps(result,indent=2)+'\n')
print(result['universe']);print('explicit',len(result['explicit_ai_npc']),'entity movement',len(result['entity_movement']),'other movement types',len(result['other_movement_types']))
for x in result['explicit_ai_npc']:print(x)
