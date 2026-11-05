"""Recover the ORIGINAL compressed audio (FMOD Vorbis inside FSB5) of every AudioClip as .ogg, with no re-encoding.
Unity stores all 2781 clips as m_CompressionFormat=1 (Vorbis); the WAVs extracted earlier were decoded from it.
Needs: UnityPy (tools/venv) and the `fsb5` package (pip install fsb5) in the Python running this script, plus
resources.resource extracted from apk/split_UnityDataAssetPack.apk (assets/bin/Data/resources.resource).
Clips whose Vorbis setup-header CRC is not in the fsb5 table are reported and left for a fallback."""
from __future__ import annotations
import argparse, collections, glob, json, os, re, sys

for p in glob.glob("/home/deppi/avatarworld-re/tools/venv/lib/python*/site-packages"):
    sys.path.insert(0, p)
import UnityPy  # noqa: E402
import fsb5  # noqa: E402


def safe(name: str) -> str:
    return re.sub(r"[^\w.\-]+", "_", name)


def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("--assets", default="/home/deppi/avatarworld-re/out/scene-extract/resources.assets")
    ap.add_argument("--resource", required=True, help="path to resources.resource")
    ap.add_argument("--outdir", required=True)
    ap.add_argument("--report", required=True)
    a = ap.parse_args()
    os.makedirs(a.outdir, exist_ok=True)
    env = UnityPy.load(a.assets)
    fh = open(a.resource, "rb")
    ok, errors = [], collections.Counter()
    failed = []
    orig_bytes = ogg_bytes = 0
    seen = collections.Counter()
    for o in env.objects:
        if o.type.name != "AudioClip":
            continue
        d = o.read()
        r = d.m_Resource
        fh.seek(r.m_Offset)
        data = fh.read(r.m_Size)
        orig_bytes += len(data)
        base = safe(d.m_Name)
        seen[base] += 1
        fname = base if seen[base] == 1 else f"{base}_{o.path_id}"
        try:
            f = fsb5.load(bytes(data))
            ext = f.get_sample_extension()
            s = f.samples[0]
            raw = f.rebuild_sample(s)
            if ext != "ogg":
                raise ValueError("unexpected extension " + ext)
            with open(os.path.join(a.outdir, fname + ".ogg"), "wb") as w:
                w.write(raw)
            ogg_bytes += len(raw)
            ok.append({"name": d.m_Name, "file": fname + ".ogg", "channels": s.channels, "frequency": s.frequency,
                       "samples": s.samples, "fsb_bytes": len(data), "ogg_bytes": len(raw), "path_id": o.path_id})
        except Exception as e:  # noqa: BLE001
            key = type(e).__name__ + ": " + re.sub(r"\d+", "N", str(e))[:70]
            errors[key] += 1
            failed.append({"name": d.m_Name, "path_id": o.path_id, "fsb_bytes": len(data), "error": str(e)[:120],
                           "channels": getattr(d, "m_Channels", None), "frequency": getattr(d, "m_Frequency", None)})
    report = {"clips": len(ok) + len(failed), "recovered_ogg": len(ok), "failed": len(failed),
              "original_compressed_bytes_all": orig_bytes, "recovered_ogg_bytes": ogg_bytes, "errors": dict(errors),
              "failed_clips": failed, "recovered": ok}
    with open(a.report, "w", encoding="utf-8") as w:
        json.dump(report, w, ensure_ascii=False)
    print("clips", report["clips"], "| recovered", len(ok), "| failed", len(failed), "| errors", dict(errors))
    print("original compressed MB (all)", round(orig_bytes / 1e6, 1), "| recovered ogg MB", round(ogg_bytes / 1e6, 1))


if __name__ == "__main__":
    main()
