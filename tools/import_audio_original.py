"""Import ALL game sounds into the client with no quality loss vs the original (T036/T018).
 - 2654 clips: the original FMOD Vorbis stream, rebuilt as .ogg (tools/recon_audio_original.py logic, no re-encoding);
 - the rest (Vorbis setup header not known to python-fsb5): lossless FLAC of the PCM the game decodes (from the extracted WAV).
Files go to <resources>/<original registry path>.<ext> (e.g. Resources/Sound/SFX/Name.ogg), so Resources.Load(path) works as in the original.
Also writes <resources>/Sound/sound-registry.json (name -> resource path, format, channels, frequency, bytes).
Needs: tools/venv (UnityPy), `pip install fsb5 numpy` in the interpreter, ffmpeg, resources.resource from
apk/split_UnityDataAssetPack.apk (assets/bin/Data/resources.resource)."""
from __future__ import annotations
import argparse, collections, glob, gzip, json, os, re, subprocess, sys

for p in glob.glob("/home/deppi/avatarworld-re/tools/venv/lib/python*/site-packages"):
    sys.path.insert(0, p)
import UnityPy  # noqa: E402
import fsb5  # noqa: E402

ROOT = "/home/deppi/avatarworld-re"


def safe(name: str) -> str:
    return re.sub(r"[^\w.\-]+", "_", name)


def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("--resource", required=True)
    ap.add_argument("--resources-dir", required=True, help="client Assets/Resources")
    ap.add_argument("--assets", default=ROOT + "/out/scene-extract/resources.assets")
    ap.add_argument("--wav-dir", default=ROOT + "/out/assets/AudioClip")
    a = ap.parse_args()
    registry = json.loads(next(gzip.open(ROOT + "/out/mb/PazuCore.AudioClipPaths.jsonl.gz", "rt")))["paths"]
    reg_path = {e["name"]: e["path"] for e in registry}
    wavs = {}
    for f in os.listdir(a.wav_dir):
        m = re.match(r".+_(\d+)\.wav$", f)
        if m:
            wavs[int(m.group(1))] = f
    env = UnityPy.load(a.assets)
    fh = open(a.resource, "rb")
    entries, fmt = [], collections.Counter()
    nbytes = 0
    for o in env.objects:
        if o.type.name != "AudioClip":
            continue
        d = o.read()
        path = reg_path.get(d.m_Name)
        if path is None:
            raise SystemExit("clip not in AudioClipPaths: " + d.m_Name)
        r = d.m_Resource
        fh.seek(r.m_Offset)
        data = fh.read(r.m_Size)
        folder, base = os.path.dirname(path), os.path.basename(path)
        rel = folder + "/" + safe(base)
        try:
            f = fsb5.load(bytes(data))
            s = f.samples[0]
            raw = bytes(f.rebuild_sample(s))
            ext, how = "ogg", "original-vorbis"
            if f.get_sample_extension() != "ogg":
                raise ValueError("not ogg")
        except Exception:  # noqa: BLE001 - setup header unknown: lossless FLAC of the decoded PCM
            ext, how, raw = "flac", "flac-of-decoded-pcm", None
        dst = os.path.join(a.resources_dir, rel + "." + ext)
        os.makedirs(os.path.dirname(dst), exist_ok=True)
        if raw is not None:
            with open(dst, "wb") as w:
                w.write(raw)
        else:
            wav = os.path.join(a.wav_dir, wavs[o.path_id])
            subprocess.run(["ffmpeg", "-y", "-loglevel", "error", "-i", wav, "-c:a", "flac", "-compression_level", "8", dst], check=True)
        size = os.path.getsize(dst)
        nbytes += size
        fmt[how] += 1
        entries.append({"name": d.m_Name, "path": path, "resourcePath": rel, "format": how,
                        "channels": d.m_Channels, "frequency": d.m_Frequency, "length": round(float(d.m_Length), 4), "bytes": size})
    entries.sort(key=lambda e: e["name"].lower())
    out = os.path.join(a.resources_dir, "Sound", "sound-registry.json")
    os.makedirs(os.path.dirname(out), exist_ok=True)
    with open(out, "w", encoding="utf-8") as w:
        json.dump({"entries": entries}, w, ensure_ascii=False, separators=(",", ":"))
    print("clips", len(entries), dict(fmt), "| audio MB", round(nbytes / 1e6, 1), "| registry", out)


if __name__ == "__main__":
    main()
