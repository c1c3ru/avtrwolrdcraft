from pathlib import Path
import json,sys
root=Path(__file__).resolve().parents[5];sys.path.insert(0,str(root/'tools'))
import recon_il2cpp as r
base=root/'out/recon/il2cpp';meta=r.Metadata((base/'global-metadata.dat').read_bytes());elf=r.Elf((base/'libil2cpp.so').read_bytes())
image,methods=meta.image_methods('UnityEngine.CoreModule.dll');module=r.codegen_module(elf,image['name'],len(methods))
wanted={0x3cd1b3c,0x3cc84a8,0x3cd4584};found=[]
for m in methods:
 address=elf.pointer(module['method_pointers_vaddr']+(m['rid']-1)*8)
 if address in wanted:
  m['vaddr']=hex(address);found.append(m)
assert len(found)==3,found
(root/'out/recon/tasks/T032/families/engine_calls.json').write_text(json.dumps(found,indent=2)+'\n')
print([(m['declaring_type'],m['name'],m['vaddr']) for m in found])
