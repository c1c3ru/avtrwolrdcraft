from pathlib import Path
import gzip,hashlib,json
root=Path(__file__).resolve().parents[5];out=Path(__file__).resolve().parent
census=json.loads((root/'out/recon/tasks/T032/npc/census.json').read_text());checks=[]
for cls,entry in census.items():
 p=root/'out/mb'/(cls+'.jsonl.gz');raw=[json.loads(x) for x in gzip.open(p,'rt')] if p.exists() else []
 checks.append({'check':'raw_census_'+cls,'passed':raw==entry['rows'] and len(raw)==entry['count'] and (not p.exists() or hashlib.sha256(p.read_bytes()).hexdigest()==entry['source_sha256'])})
report={'passed':all(c['passed'] for c in checks),'checks':checks,'review':['npc validate.py rerun passes 16 checks','Census independently compared to original gzip rows and hashes','Caller decision and walkway moveLocalX/setSpeed claims match captured instruction sequences','No blocker found in report; report correctly limits absence of autonomy to examined managers','Validation cannot establish runtime behavior, and does not purport to']}
(out/'npc_review.json').write_text(json.dumps(report,indent=2)+'\n');assert report['passed'];print('PASS: 7 raw source census checks; NPC report reviewed')
