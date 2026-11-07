"""Copy the output of tools/export_spine_original.py into the client: Assets/Resources/Spine/<folder>/ and spine-index.json.
Index fields: name, folder, renderable, scale, defaultMix (from the original SkeletonDataAsset), pages, sceneInstances, sourceFile,
animations, bones (from tools/skel_dump, an independent parse used later to cross-check Unity's parser), notes.
Atlas page textures keep the EXACT page name of the atlas (some contain spaces). DOG_A_BROWS has no skeleton data in the shipped
game (dangling reference) and is not imported.
Usage: import_spine_original.py --export-dir <spine_out> --resources-dir <client Assets/Resources>"""
from __future__ import annotations
import argparse, json, os, re, shutil, gzip

ROOT = "/home/deppi/avatarworld-re"


def safe(name: str) -> str:
    return re.sub(r"[^\w.\-]+", "_", name)


def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("--export-dir", required=True)
    ap.add_argument("--resources-dir", required=True)
    a = ap.parse_args()
    manifest = json.load(open(os.path.join(a.export_dir, "spine-manifest.json"), encoding="utf-8"))["skeletons"]
    rows = {}
    for line in gzip.open(ROOT + "/out/mb/Spine.Unity.SkeletonDataAsset.jsonl.gz", "rt"):
        r = json.loads(line)
        rows[(r["_file"], r["_path_id"])] = r
    dump = {}
    ta = ROOT + "/out/assets/TextAsset/"
    sizes = {f: os.path.getsize(ta + f) for f in os.listdir(ta) if ".skel_" in f}
    for line in open(ROOT + "/out/recon/tasks/T032/skel-dump.jsonl", encoding="utf-8"):
        d = json.loads(line)
        if "error" in d:
            continue
        dump[(d["file"], )] = d
    by_size = {}
    for f, sz in sizes.items():
        d = dump.get((f,))
        if d:
            by_size[(safe(f.split(".skel")[0]), sz)] = d
    out_root = os.path.join(a.resources_dir, "Spine")
    os.makedirs(out_root, exist_ok=True)
    index, skipped = [], []
    for e in manifest:
        if not e["skeleton"]:
            skipped.append(e["name"])
            continue
        folder = safe(e["name"])
        src = os.path.join(a.export_dir, folder)
        dst = os.path.join(out_root, folder)
        os.makedirs(dst, exist_ok=True)
        shutil.copyfile(os.path.join(src, e["skeleton"]["file"]), os.path.join(dst, e["skeleton"]["file"]))
        if e["atlas"]:
            shutil.copyfile(os.path.join(src, e["atlas"]["file"]), os.path.join(dst, e["atlas"]["file"]))
        for p in e["pages"]:
            shutil.copyfile(os.path.join(src, p["file"]), os.path.join(dst, p["page"] + ".png"))
        r = rows[(e["sourceFile"], e["sourcePathId"])]
        d = by_size.get((folder.split("__")[0] if False else folder, e["skeleton"]["bytes"])) or by_size.get((safe(re.sub(r"__.*$", "", e["name"])), e["skeleton"]["bytes"]))
        index.append({"name": e["name"], "folder": folder, "renderable": bool(e["atlas"]) and bool(e["pages"]),
                      "scale": round(float(r["scale"]), 6), "defaultMix": round(float(r["defaultMix"]), 6),
                      "pages": len(e["pages"]), "sceneInstances": e["sceneInstances"], "sourceFile": e["sourceFile"],
                      "animations": len(d["animations"]) if d else -1, "bones": d["bones"] if d else -1,
                      "notes": e["notes"]})
    index.sort(key=lambda x: x["name"].lower())
    with open(os.path.join(out_root, "spine-index.json"), "w", encoding="utf-8") as w:
        json.dump({"skeletons": index}, w, ensure_ascii=False, separators=(",", ":"))
    print("imported", len(index), "| renderable", sum(1 for i in index if i["renderable"]), "| pages", sum(i["pages"] for i in index),
          "| skipped (no skeleton data)", skipped, "| animations known", sum(1 for i in index if i["animations"] >= 0), "of", len(index))


if __name__ == "__main__":
    main()
