import json
from UnityPy.helpers.TypeTreeGenerator import TypeTreeGenerator
import UnityPy

g = TypeTreeGenerator("2022.3.70f1")
g.load_il2cpp(
    open("/home/c1c3ru/avtrwolrdcraft/il2cpp_in/libil2cpp.so", "rb").read(),
    open("/home/c1c3ru/avtrwolrdcraft/il2cpp_in/global-metadata.dat", "rb").read(),
)
base = UnityPy.load("/home/c1c3ru/avtrwolrdcraft/x/base/assets/bin/Data/data.unity3d")
scripts = {}
for o in base.objects:
    if o.type.name == "MonoScript":
        s = o.read()
        cname = f"{s.m_Namespace}.{s.m_ClassName}".strip(".")
        scripts[cname] = (s.m_AssemblyName.removesuffix(".dll"), s.m_Namespace, s.m_ClassName)

targets = [
    "PazuCore.WindowManager",
    "PWC.LevelPhone.PhoneBackground",
    "PWC.LevelPhone.DeliveryApp.DeliveryContent",
    "PWC.LevelPhone.PhoneContentIcon",
    "PWC.Level.LevelSkinsRandomizer",
    "Game.Level.MovingTraingBackground.LevelStationButton",
    "PazuCore.PazuCoreAddressables.AFC.AFCChangePositionWIthLanguageCode",
    "PWC.EditorApp.EASUTEThumbButtonHandler",
    "PWC.EditorApp.EAEditorDirectoryIndexer",
    "PWC.EditorApp.EAEditorAssetsIndexer",
    "PWC.AvatarMaker.AvatarMakerBabyColorsConfig",
    "PWC.EditorApp.EAHierarchyPanel",
    "PazuCore.PazuCoreAddressables.AFC.AFCTMPTextLineSpaceWIthLanguageCode",
    "PWC.AvatarMaker.AvatarMakerCatColorsConfig",
    "PWC.EditorApp.EASearchPanel",
    "PWC.AvatarMaker.AvatarMakerCatSubcategoriesConfig",
    "PWC.EditorApp.EAResultPool",
    "PWC.EditorApp.EACAInfoManager",
]

for cname in targets:
    asm, ns, cls = scripts[cname]
    full = f"{ns}.{cls}" if ns else cls
    print(f"=== {cname} ===", flush=True)
    try:
        nodes = g.get_nodes_as_json(asm, full)
        print("OK, node json length:", len(nodes), flush=True)
    except Exception as e:
        print("PYEXC:", type(e).__name__, e, flush=True)
