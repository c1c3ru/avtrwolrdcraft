from pathlib import Path
import hashlib,json,re,sys,struct
root=Path(__file__).resolve().parents[5];sys.path.insert(0,str(root/'tools'))
from recon_il2cpp import Elf
out=Path(__file__).resolve().parent
matches=[]
for p in (root/'out/cpp2il/DiffableCs/Assembly-CSharp').rglob('*.cs'):
 s=p.read_text()
 if 'public static Action<ICATarget, Boolean> ' in s and 'public static Action<ICATarget, Boolean, Boolean> ' in s:
  matches.append({'path':str(p.relative_to(root)),'sha256':hashlib.sha256(p.read_bytes()).hexdigest(),'text':s})
assert len(matches)==1
elf=Elf((root/'out/recon/il2cpp/libil2cpp.so').read_bytes());got=0x41bd548;usage=elf.pointer(got);encoded=struct.unpack_from('<Q',elf.data,elf.offset(usage,8))[0]
records={'candidate_owner':matches[0],'got':hex(got),'usage':hex(usage),'encoded':hex(encoded),'status':'INFERRED_unique_static_field_layout_plus_shared_CA_extension_consumer_not_direct_type_metadata_join','calls':[{'site':'Baby.OnBeginDragInternal','pc':'0x229b800','field_offset':0,'candidate':'CATargetEvents.OnSelectedAction','arguments':['this',True]},{'site':'Baby.OnEndLand','pc':'0x229b91c','field_offset':8,'candidate':'CATargetEvents.OnUpdateCAListAction','arguments':['this',False,True]},{'site':'CATargetExtensionMethods.AddCAHandlerAndUpdateGame','pc':'0x23aca3c','field_offset':8,'candidate':'CATargetEvents.OnUpdateCAListAction','arguments':['target',True,'handler_virtual_boolean']}], 'limits':['GOT encoded metadata usage is noncanonical, so exact owner attribution remains inferred','Delegate subscribers and side effects are separate; calling field is not a singleton instance','No dynamic execution']}
(out/'delegates.json').write_text(json.dumps(records,indent=2)+'\n');print('PASS: unique matching static field layout and noncanonical usage preserved')
