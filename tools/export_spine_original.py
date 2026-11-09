"""Export every Spine skeleton of the game with its EXACT atlas and page textures (T018).
For each SkeletonDataAsset: skeleton bytes (.skel.bytes), atlas text (.atlas.txt) and the PNG of the texture that each
Material of its SpineAtlasAsset points to (_MainTex), named after the atlas page. Reads datapack.unity3d one serialized
file at a time (tools/recon_spine_links.py explains why). Texture2D stream data (.resS) is read from the same bundle.
Output: <outdir>/<Name>/{<Name>.skel.bytes, <Name>.atlas.txt, <page>.png} and <outdir>/spine-manifest.json.
Names: SkeletonDataAsset name without the '_SkeletonData' suffix; for repeated names the variant with most scene instances keeps
the plain name, the others get '__<sourcefile>_<pathid>'. 'sceneInstances' counts SkeletonAnimation/SkeletonGraphic users (by path id).
Usage: export_spine_original.py --datapack <datapack.unity3d> --outdir <dir> [--skip Avatar_Spine] [--limit-files N]"""
from __future__ import annotations
import argparse, collections, gzip, json, os, re, sys

sys.path.insert(0, os.path.dirname(os.path.abspath(__file__)))
from recon_spine_links import LazyBundle, load_rows  # noqa: E402
from UnityPy.files.SerializedFile import SerializedFile  # noqa: E402
from UnityPy.helpers import ImportHelper  # noqa: E402
from UnityPy.streams import EndianBinaryReader  # noqa: E402


def safe(name: str) -> str:
    return re.sub(r"[^\w.\-]+", "_", name)


def page_names(atlas_text: str):
    return [l.strip()[:-4] for l in atlas_text.replace("\r", "").split("\n") if l.strip().lower().endswith(".png")]


def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("--datapack", required=True)
    ap.add_argument("--outdir", required=True)
    ap.add_argument("--skip", nargs="*", default=["Avatar_Spine"], help="skeletons already in the client")
    ap.add_argument("--limit-files", type=int, default=0)
    a = ap.parse_args()
    skel_rows = load_rows("Spine.Unity.SkeletonDataAsset")
    atlas_rows = {(r["_file"], r["_path_id"]): r for r in load_rows("Spine.Unity.SpineAtlasAsset")}
    # uso por instancias de cena: a variante MAIS USADA fica com o nome simples (duplicatas ganham sufixo)
    use = collections.Counter()
    for cls in ("Spine.Unity.SkeletonAnimation", "Spine.Unity.SkeletonGraphic"):
        for inst in load_rows(cls):
            use[inst["skeletonDataAsset"]["m_PathID"]] += 1
    by_name = collections.defaultdict(list)
    for r in skel_rows:
        by_name[re.sub(r"_SkeletonData$", "", r["m_Name"])].append(r)
    final = {}
    for name, rows in by_name.items():
        rows.sort(key=lambda r: (-use[r["_path_id"]], r["_file"], r["_path_id"]))
        for i, r in enumerate(rows):
            final[(r["_file"], r["_path_id"])] = name if i == 0 else f"{name}__{safe(r['_file'])}_{r['_path_id']}"
    by_file = collections.defaultdict(list)
    for r in skel_rows:
        by_file[r["_file"]].append(r)
    os.makedirs(a.outdir, exist_ok=True)
    reader = EndianBinaryReader(open(a.datapack, "rb").read())
    bundle = LazyBundle(reader, None, "datapack")
    manifest, problems = [], collections.Counter()
    done_files = 0
    ext_cache = {}
    for fname in sorted(by_file):
        if fname not in bundle._nodes:
            problems["file_not_in_bundle"] += 1
            continue
        f = ImportHelper.parse_file(bundle.node_reader(fname), bundle, fname, is_dependency=False)
        if not isinstance(f, SerializedFile):
            continue
        objs = f.objects
        for r in by_file[fname]:
            name = final[(fname, r["_path_id"])]
            if name.split("__")[0] in a.skip:
                continue
            entry = {"name": name, "sourceFile": fname, "sourcePathId": r["_path_id"], "sceneInstances": use[r["_path_id"]], "skeleton": None, "atlas": None, "pages": [], "renderable": bool(r["atlasAssets"]),
                     "notes": []}
            d = os.path.join(a.outdir, safe(name))
            os.makedirs(d, exist_ok=True)
            so = objs.get(r["skeletonJSON"]["m_PathID"])
            if so is None:
                entry["notes"].append("skeleton TextAsset not in this file"); problems["skeleton_missing"] += 1
            else:
                raw = so.read().m_Script
                raw = raw if isinstance(raw, (bytes, bytearray)) else raw.encode("utf-8", "surrogateescape")
                p = os.path.join(d, safe(name) + ".skel.bytes")
                open(p, "wb").write(raw)
                entry["skeleton"] = {"file": os.path.basename(p), "bytes": len(raw)}
            for ar in r["atlasAssets"]:
                tfile, tobjs = fname, objs
                if ar["m_FileID"] != 0:
                    exts = [e.path for e in f.externals]
                    tfile = exts[ar["m_FileID"] - 1] if 0 < ar["m_FileID"] <= len(exts) else None
                    if tfile is None or tfile not in bundle._nodes:
                        entry["notes"].append("atlas is external (fileID %d) and unresolved" % ar["m_FileID"]); problems["atlas_external_unresolved"] += 1
                        continue
                    if tfile not in ext_cache:
                        ext_cache.clear()
                        ext_cache[tfile] = ImportHelper.parse_file(bundle.node_reader(tfile), bundle, tfile, is_dependency=False).objects
                    tobjs = ext_cache[tfile]
                    entry["notes"].append("atlas resolved in external file %s" % tfile)
                    problems["atlas_external_resolved"] += 1
                at = atlas_rows.get((tfile, ar["m_PathID"]))
                ao = tobjs.get(at["atlasFile"]["m_PathID"]) if at else None
                if ao is None:
                    entry["notes"].append("atlas TextAsset missing"); problems["atlas_missing"] += 1
                    continue
                text = ao.read().m_Script
                text = text if isinstance(text, str) else bytes(text).decode("utf-8", "replace")
                p = os.path.join(d, safe(name) + ".atlas.txt")
                open(p, "w", encoding="utf-8", newline="").write(text)
                entry["atlas"] = {"file": os.path.basename(p), "bytes": len(text.encode("utf-8"))}
                wanted = set(page_names(text))
                for m in at["materials"]:
                    mo = tobjs.get(m["m_PathID"])
                    if mo is None:
                        problems["material_missing"] += 1; continue
                    md = mo.read()
                    tex = None
                    for k, v in md.m_SavedProperties.m_TexEnvs:
                        if k == "_MainTex":
                            tex = v.m_Texture
                    if tex is None or tex.m_FileID != 0 or tex.m_PathID not in tobjs:
                        problems["texture_unresolved"] += 1; entry["notes"].append("material %s has no local texture" % md.m_Name); continue
                    to = tobjs[tex.m_PathID]
                    td = to.read()
                    page = td.m_Name
                    if page not in wanted:
                        problems["page_name_mismatch"] += 1
                        entry["notes"].append("texture '%s' not an atlas page" % page)
                    sd = td.m_StreamData
                    if sd is not None and getattr(sd, "size", 0):
                        node = os.path.basename(sd.path)
                        if node not in bundle._nodes:
                            problems["resS_missing"] += 1; continue
                        n = bundle._nodes[node]
                        td.image_data = bundle._range(n.offset + sd.offset, sd.size)
                    try:
                        img = td.image
                        png = os.path.join(d, safe(page) + ".png")
                        img.save(png)
                        entry["pages"].append({"page": page, "file": os.path.basename(png), "width": img.width, "height": img.height,
                                               "textureFormat": int(td.m_TextureFormat), "bytes": os.path.getsize(png)})
                    except Exception as e:  # noqa: BLE001
                        problems["texture_decode_error"] += 1
                        entry["notes"].append("decode error %s: %s" % (page, str(e)[:60]))
                missing_pages = sorted(wanted - {p["page"] for p in entry["pages"]})
                if missing_pages:
                    entry["notes"].append("atlas pages without exported texture: %d" % len(missing_pages))
                    problems["atlas_pages_without_texture"] += len(missing_pages)
            manifest.append(entry)
        done_files += 1
        del f, objs
        if done_files % 10 == 0:
            print("files", done_files, "skeletons", len(manifest), dict(problems), flush=True)
        if a.limit_files and done_files >= a.limit_files:
            break
    with open(os.path.join(a.outdir, "spine-manifest.json"), "w", encoding="utf-8") as w:
        json.dump({"skeletons": manifest, "problems": dict(problems)}, w, ensure_ascii=False)
    print("skeletons", len(manifest), "| pages", sum(len(e["pages"]) for e in manifest), "| problems", dict(problems))


if __name__ == "__main__":
    main()
