from pathlib import Path
import json,hashlib,sys
root=Path(__file__).resolve().parents[5];sys.path.insert(0,str(root/'tools'))
from recon_il2cpp import Elf
base=root/'out/recon/il2cpp';elf=Elf((base/'libil2cpp.so').read_bytes())
rows=[json.loads(x) for x in (base/'assembly_csharp_methods.jsonl').read_text().splitlines()]
out=[]
for m in rows:
 if m['name'] not in ['HasWalkingAnimations','HasRunningAnimations']:continue
 va=int(m['vaddr'],16);raw=elf.data[elf.offset(va,8):][:8]
 expected=(bytes.fromhex('e0031f2ac0035fd6') if m['name']=='HasRunningAnimations' or 'LevelTech' in m['declaring_type'] else bytes.fromhex('20008052c0035fd6'))
 assert raw==expected,(m,raw.hex())
 out.append({'type':m['declaring_type'],'method':m['name'],'slot':m['slot'],'va':m['vaddr'],'bytes':raw.hex(),'returns':raw[:4]==bytes.fromhex('20008052')})
assert len(out)==7
(root/'out/recon/tasks/T032/families/capabilities.json').write_text(json.dumps(out,indent=2)+'\n')
print('PASS: 7 capability methods checked against binary bytes; all running capability false, 5 tech walking capabilities false')
