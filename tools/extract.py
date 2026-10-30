import sys, os, re, UnityPy
src, outdir, kinds, limit = sys.argv[1], sys.argv[2], sys.argv[3].split(","), int(sys.argv[4])
env = UnityPy.load(src)
n = {k: 0 for k in kinds}; err = {k: 0 for k in kinds}
safe = lambda s: re.sub(r'[^\w.\-]+', '_', s)[:120] or "unnamed"
for o in env.objects:
    t = o.type.name
    if t not in n or (limit and n[t] >= limit): continue
    try:
        d = o.read(); name = f"{safe(getattr(d,'m_Name',''))}_{o.path_id}"
        base = os.path.join(outdir, t); os.makedirs(base, exist_ok=True)
        if t == "AudioClip":
            r = d.m_Resource
            if r and r.m_Size:
                with open(os.path.join(os.path.dirname(src), r.m_Source), "rb") as f:
                    f.seek(r.m_Offset); d.m_AudioData = f.read(r.m_Size)
            for k, v in d.samples.items(): open(os.path.join(base, name + ".wav" if len(d.samples) == 1 else name + "_" + safe(k)), "wb").write(v)
        elif t == "TextAsset":
            raw = d.m_Script if isinstance(d.m_Script, (bytes, bytearray)) else d.m_Script.encode("utf-8", "surrogateescape")
            open(os.path.join(base, name + ".txt"), "wb").write(raw)
        elif t == "Texture2D":
            d.image.save(os.path.join(base, name + ".png"))
        n[t] += 1
    except Exception as e:
        err[t] += 1
print("ok", n, "erros", err)
