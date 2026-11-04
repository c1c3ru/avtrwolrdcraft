"""Assert animator animation names against exact skeleton animation lists (skel_dump.jsonl)."""
import json, sys
from pathlib import Path
ROOT = Path(__file__).resolve().parents[1]
EXPECT = {  # name -> skeletons that MUST contain it as an animation / MUST NOT contain it
    "Idle_Stand_1": ({"Avatar_Spine"}, {"Toddler_Spine", "Baby_Spine"}),
    "Movement_Cycles/Walk": ({"Avatar_Spine"}, {"Toddler_Spine", "Baby_Spine"}),
    "Movement_Cycles/Run": ({"Avatar_Spine"}, {"Toddler_Spine", "Baby_Spine"}),
    "Lift_Idle": ({"Avatar_Spine"}, {"Toddler_Spine", "Baby_Spine"}),
    "CA/Chair_Sitting/Sit_On_Chair_Idle": ({"Avatar_Spine"}, set()),
    "CA/Bed_Laying/Laying_Idle": ({"Avatar_Spine"}, set()),
    "Track_Animations/Forced_To_Walk": ({"Avatar_Spine", "Toddler_Spine", "Pet_Dog_Spine", "Pet_Cat_Spine", "Pet_Horse"}, {"Baby_Spine"}),
    "General/Standing_Idle": ({"Pet_Dog_Spine", "Pet_Cat_Spine", "Pet_Horse"}, {"Avatar_Spine"}),
    "Movement_Cycles/Walking_Loop": ({"Toddler_Spine"}, {"Avatar_Spine", "Baby_Spine"}),
    "Movement_Cycles/Crawling_Loop": ({"Toddler_Spine"}, {"Avatar_Spine", "Baby_Spine"}),
    "General/Stand_Idle": ({"Toddler_Spine"}, {"Avatar_Spine", "Baby_Spine"}),
    "General/Lift_Idle": ({"Toddler_Spine"}, {"Avatar_Spine"}),
    "Track_Animations/Forced_To_Crawl": ({"Toddler_Spine"}, {"Avatar_Spine", "Baby_Spine"}),
    "General/Idle": ({"Baby_Spine"}, set()),
    "Glow_Loop": ({"Star_Pass-Gift_Choice"}, {"Avatar_Spine"}),
}
path = Path(sys.argv[1]) if len(sys.argv) > 1 else ROOT / "out/recon/tasks/T032/skel-dump.jsonl"
rows = {}
for l in path.open():
    r = json.loads(l); rows.setdefault(r["file"].split(".skel")[0], []).append(r)
fails = 0
for name, (must, mustnot) in EXPECT.items():
    has = {k for k, r in rows.items() if any(a["Name"] == name for x in r for a in x.get("animations", []))}
    for k in must - has: print("FAIL missing", name, "in", k); fails += 1
    for k in mustnot & has: print("FAIL unexpected", name, "in", k); fails += 1
print("skeletons", len(rows), "checks", len(EXPECT), "failures", fails)
sys.exit(1 if fails else 0)
