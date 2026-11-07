"""Audio coverage: which extracted AudioClips are referenced by name from scene data, code literals and Spine events.
Reference sources (all static):
  1. out/mb sound classes: every string (or list of strings) in a field whose name looks like a sound/clip/music/audio name;
  2. string literals in global-metadata.dat that equal a clip base name;
  3. Spine event names (skel-dump.jsonl) that equal a clip base name.
Clip base name = file name without the '_<pathid>.wav' suffix. Data lives in the main checkout's out/ (override --root)."""
from __future__ import annotations
import argparse, collections, gzip, json, os, re, struct, sys
from pathlib import Path

sys.path.insert(0, str(Path(__file__).resolve().parent))
import recon_il2cpp as r  # noqa: E402

ROOT = Path("/home/deppi/avatarworld-re")
CLASS = re.compile(r"Sound|Audio|Music|Sfx|Voice|Speech|Song|Jingle", re.I)
FIELD = re.compile(r"sound|audio|music|clip|sfx|song|voice|jingle", re.I)


def tokens(s):
    """Nome de som -> candidatos: separa '^'/';', tira pasta e extensao."""
    for part in re.split(r"[\^;|]", s):
        part = part.strip().replace("\\", "/").split("/")[-1]
        part = re.sub(r"\.(wav|mp3|ogg)$", "", part, flags=re.I)
        if part:
            yield part


def strings_in(value):
    if isinstance(value, str):
        yield value
    elif isinstance(value, list):
        for v in value:
            yield from strings_in(v)
    elif isinstance(value, dict):
        for v in value.values():
            yield from strings_in(v)


def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("--root", type=Path, default=ROOT)
    ap.add_argument("--output", type=Path, required=True)
    a = ap.parse_args()
    clips = {}
    for f in os.listdir(a.root / "out/assets/AudioClip"):
        m = re.match(r"(.+)_(\d+)\.\w+$", f)
        if m:
            clips.setdefault(m.group(1), []).append(f)
    lower = {k.lower(): k for k in clips}

    # 1) dados de cena
    data_refs = collections.defaultdict(set)         # nome -> {classes}
    by_class = collections.Counter()
    for f in sorted((a.root / "out/mb").glob("*.jsonl.gz")):
        cls = f.name.replace(".jsonl.gz", "")
        if not CLASS.search(cls):
            continue
        for line in gzip.open(f, "rt"):
            row = json.loads(line)
            for k, v in row.items():
                if FIELD.search(k) and not k.startswith(("m_Script", "m_Game")):
                    for s in strings_in(v):
                        if s and not s.isdigit():
                            data_refs[s].add(cls)
                            by_class[cls] += 1
    # 2) literais do codigo
    meta = r.Metadata((a.root / "out/recon/il2cpp/global-metadata.dat").read_bytes())
    lt, lb = struct.unpack_from("<II", meta.data, 8)
    so, _ = struct.unpack_from("<II", meta.data, 16)
    code_lits = set()
    for i in range(lb // 8):
        ln, di = struct.unpack_from("<II", meta.data, lt + i * 8)
        s = meta.data[so + di:so + di + ln].decode("utf-8", "replace")
        if s.lower() in lower:
            code_lits.add(lower[s.lower()])
    # 3) eventos Spine
    events = set()
    for line in (a.root / "out/recon/tasks/T032/skel-dump.jsonl").open():
        for e in json.loads(line).get("events", []):
            events.add(e)
    ev_match = {e for e in events if e.lower() in lower}

    data_match, unresolved = set(), []
    for s in data_refs:
        hit = [lower[t.lower()] for t in tokens(s) if t.lower() in lower]
        if hit:
            data_match.update(hit)
        else:
            unresolved.append(s)
    unresolved.sort()
    # audioPath dos eventos Spine
    audio_paths, audio_hit = set(), set()
    for line in (a.root / "out/recon/tasks/T032/skel-dump.jsonl").open():
        for e in json.loads(line).get("eventDetails", []):
            if e.get("AudioPath"):
                audio_paths.add(e["AudioPath"])
                for t in tokens(e["AudioPath"]):
                    if t.lower() in lower:
                        audio_hit.add(lower[t.lower()])
    # prefixos de nome montados em codigo (literal que termina em '_' e abre >= 2 clipes)
    prefix_hit, prefixes = set(), []
    for i in range(lb // 8):
        ln, di = struct.unpack_from("<II", meta.data, lt + i * 8)
        if ln < 4 or ln > 40:
            continue
        sx = meta.data[so + di:so + di + ln].decode("utf-8", "replace")
        if sx.endswith("_"):
            hit = [k for k in clips if k.startswith(sx)]
            if len(hit) >= 2:
                prefixes.append((sx, len(hit)))
                prefix_hit.update(hit)
    scan_all = set()
    scan_file = a.root / "out/recon/tasks/T032/audio-scan-all.json"
    if scan_file.exists():       # varredura de TODAS as classes (tools/recon_audio_scan_all.py)
        scan_all = set(json.loads(scan_file.read_text())["clips"])
    referenced = data_match | code_lits | {lower[e.lower()] for e in ev_match} | audio_hit | prefix_hit | scan_all
    # categorias pelo registro AudioClipPaths (PazuCore.AudioClipPaths): nome -> pasta
    cat_of = {}
    reg = json.loads(next(gzip.open(a.root / "out/mb/PazuCore.AudioClipPaths.jsonl.gz", "rt")))["paths"]
    for e in reg:
        k = lower.get(e["name"].lower())
        if k:
            cat_of[k] = os.path.dirname(e["path"]).split("/")[-1]
    cats = collections.Counter(cat_of.get(k, "?") for k in clips)
    cats_ref = collections.Counter(cat_of.get(k, "?") for k in referenced)
    exact_only = (data_match | code_lits | scan_all | audio_hit | {lower[e.lower()] for e in ev_match})
    unref = sorted(set(clips) - referenced)
    out = {
        "clips_total": len(clips), "clip_files": sum(len(v) for v in clips.values()),
        "data_reference_names": len(data_refs), "data_names_resolving_to_a_clip": len(data_match),
        "data_names_without_clip": len(unresolved), "sample_unresolved": unresolved[:40],
        "code_literals_matching_clips": len(code_lits),
        "spine_event_audio_paths": len(audio_paths), "spine_audio_paths_matching_clips": len(audio_hit),
        "code_name_prefixes": len(prefixes), "clips_covered_by_code_prefixes": len(prefix_hit), "sample_prefixes": sorted(prefixes, key=lambda x: -x[1])[:20],
        "spine_event_names": len(events), "spine_events_matching_clips": len(ev_match),
        "registry_entries": len(reg), "clips_by_category": dict(cats), "referenced_by_category": dict(cats_ref),
        "clips_referenced_exact_name": len(exact_only), "clips_referenced_only_by_code_prefix": len(referenced - exact_only),
        "clips_referenced_any": len(referenced), "clips_unreferenced": len(unref), "sample_unreferenced": unref[:40],
        "refs_by_class": dict(by_class.most_common(20)),
    }
    a.output.write_text(json.dumps(out, indent=1, ensure_ascii=False) + "\n")
    for k, v in out.items():
        if not k.startswith("sample"):
            print(k, v)


if __name__ == "__main__":
    main()
