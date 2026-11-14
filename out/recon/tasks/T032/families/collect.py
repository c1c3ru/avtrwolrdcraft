from pathlib import Path
import subprocess,json,hashlib,sys
root=Path(__file__).resolve().parents[5]
out=Path(__file__).resolve().parent
methods=['LevelAnimal.HasRunningAnimations','LevelAnimal.GetWalkingAnimationName','LevelAnimal.GetRunningAnimationName','LevelAnimal.HasSwimmingAnimations','LevelAnimal.OnMovement','LevelAnimal.OnBeginDragInternal','LevelAnimal.OnSyncPosition','LevelAnimal.OnEndDragInternal','LevelBaby.OnBeginDragInternal','LevelBaby.OnEndDragInternal','LevelBaby.OnEndLand','LevelToddler.OnBeginDragInternal','LevelToddler.OnSyncPosition','LevelToddler.OnEndDragInternal','LevelCharacterAnimator.OnMovement','LevelHorse.HasSwimmingAnimations']
manifest=[]
for method in methods:
 p=subprocess.run([sys.executable,str(root/'tools/recon_disasm.py'),method,'--data',str(root/'out/recon/il2cpp'),'--cap','16384'],capture_output=True,text=True)
 if p.returncode: raise RuntimeError(p.stderr)
 dest=out/(method+'.asm.txt');dest.write_text(p.stdout)
 manifest.append({'method':method,'path':dest.name,'sha256':hashlib.sha256(dest.read_bytes()).hexdigest()})
for f in ['libil2cpp.so','global-metadata.dat','assembly_csharp_methods.jsonl']:
 path=root/'out/recon/il2cpp'/f
 manifest.append({'source':str(path.relative_to(root)),'sha256':hashlib.sha256(path.read_bytes()).hexdigest()})
(out/'manifest.json').write_text(json.dumps(manifest,indent=2)+'\n')
print(f'{len(methods)} methods captured')
