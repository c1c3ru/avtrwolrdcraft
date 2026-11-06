"""Exact Spine links per skeleton: SkeletonDataAsset -> skeleton TextAsset, SpineAtlasAsset -> atlas TextAsset and Materials -> Texture2D.
Reads datapack.unity3d one serialized file at a time (the whole bundle does not fit in memory with UnityPy.load);
resources.assets and sharedassets*.assets are nodes of that bundle. Only object HEADERS/names are read; no image data is decoded.
Input rows come from out/mb (SkeletonDataAsset, SpineAtlasAsset). Output: spine-links.json.
Usage: recon_spine_links.py --datapack <datapack.unity3d> --output <json> [--limit N]"""
from __future__ import annotations
import argparse, collections, glob, gzip, json, os, sys

for p in glob.glob("/home/deppi/avatarworld-re/tools/venv/lib/python*/site-packages"):
    sys.path.insert(0, p)
import UnityPy  # noqa: E402
from UnityPy.files import BundleFile  # noqa: E402
from UnityPy.files.SerializedFile import SerializedFile  # noqa: E402
from UnityPy.helpers import ImportHelper  # noqa: E402
from UnityPy.streams import EndianBinaryReader  # noqa: E402

MB = "/home/deppi/avatarworld-re/out/mb/"


class LazyBundle(BundleFile):
    """BundleFile que NAO junta todos os blocos descomprimidos: guarda os blocos comprimidos e descomprime so os necessarios."""

    def read_fs(self, reader):
        from UnityPy.enums.BundleFile import ArchiveFlags
        from UnityPy.files.BundleFile import BlockInfo, DirectoryInfoFS
        reader.read_long()
        compressedSize = reader.read_u_int()
        uncompressedSize = reader.read_u_int()
        dataflagsValue = reader.read_u_int()
        version = self.parse_version()
        self.dataflags = ArchiveFlags(dataflagsValue)
        if self.version >= 7 or (version[0] == 2019 and version >= (2019, 4, 15)):
            reader.align_stream(16)
            self._uses_block_alignment = True
        start = reader.Position
        if self.dataflags & ArchiveFlags.BlocksInfoAtTheEnd:
            reader.Position = reader.Length - compressedSize
            blocksInfoBytes = reader.read_bytes(compressedSize)
            reader.Position = start
        else:
            blocksInfoBytes = reader.read_bytes(compressedSize)
        blocksInfoBytes = self.decompress_data(blocksInfoBytes, uncompressedSize, self.dataflags)
        bi = EndianBinaryReader(blocksInfoBytes, offset=start)
        bi.read_bytes(16)
        count = bi.read_int()
        blocks = [BlockInfo(bi.read_u_int(), bi.read_u_int(), bi.read_u_short()) for _ in range(count)]
        nodes_count = bi.read_int()
        dirs = [DirectoryInfoFS(bi.read_long(), bi.read_long(), bi.read_u_int(), bi.read_string_to_null()) for _ in range(nodes_count)]
        if isinstance(self.dataflags, ArchiveFlags) and self.dataflags & ArchiveFlags.BlockInfoNeedPaddingAtStart:
            reader.align_stream(16)
        # posicoes: bloco i comeca (comprimido) em comp_pos[i] e (descomprimido) em unc_pos[i]
        comp_pos, unc_pos, c, u = [], [], reader.Position, 0
        for b in blocks:
            comp_pos.append(c)
            unc_pos.append(u)
            c += b.compressedSize
            u += b.uncompressedSize
        self._reader, self._blocks, self._comp_pos, self._unc_pos = reader, blocks, comp_pos, unc_pos
        self._base = bi.real_offset()
        return dirs, None

    def read_files(self, reader, files):
        self._nodes = {n.path: n for n in files}

    def _range(self, offset, size):
        import bisect
        out = bytearray()
        i = bisect.bisect_right(self._unc_pos, offset) - 1
        pos = offset
        end = offset + size
        while pos < end:
            b = self._blocks[i]
            self._reader.Position = self._comp_pos[i]
            raw = self._reader.read_bytes(b.compressedSize)
            data = self.decompress_data(raw, b.uncompressedSize, b.flags, i)
            lo = pos - self._unc_pos[i]
            hi = min(len(data), lo + (end - pos))
            out += data[lo:hi]
            pos += hi - lo
            i += 1
        return bytes(out)

    def node_reader(self, name):
        n = self._nodes[name]
        return EndianBinaryReader(self._range(n.offset, n.size), offset=self._base + n.offset)


def load_rows(cls):
    return [json.loads(l) for l in gzip.open(MB + cls + ".jsonl.gz", "rt")]


def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("--datapack", required=True)
    ap.add_argument("--output", required=True)
    ap.add_argument("--limit", type=int, default=0, help="only the first N serialized files (test)")
    a = ap.parse_args()
    skel_rows = load_rows("Spine.Unity.SkeletonDataAsset")
    atlas_rows = load_rows("Spine.Unity.SpineAtlasAsset")
    need_files = {r["_file"] for r in skel_rows} | {r["_file"] for r in atlas_rows}
    atlas_by = {(r["_file"], r["_path_id"]): r for r in atlas_rows}
    mats_needed = collections.defaultdict(set)      # file -> {material path ids}
    for r in atlas_rows:
        for m in r["materials"]:
            mats_needed[r["_file"]].add(m["m_PathID"])
    text_needed = collections.defaultdict(set)
    for r in skel_rows:
        text_needed[r["_file"]].add(r["skeletonJSON"]["m_PathID"])
    for r in atlas_rows:
        text_needed[r["_file"]].add(r["atlasFile"]["m_PathID"])

    info = {}   # (file, kind, pid) -> data

    def scan(f, fname):
        wanted_mat = mats_needed.get(fname, set())
        wanted_txt = text_needed.get(fname, set())
        names = {}
        for pid, o in f.objects.items():
            t = o.type.name
            if t == "Material" and pid in wanted_mat:
                d = o.read()
                tex = None
                for k, v in d.m_SavedProperties.m_TexEnvs:
                    if k == "_MainTex":
                        tex = {"fileID": v.m_Texture.m_FileID, "pathID": v.m_Texture.m_PathID}
                info[(fname, "mat", pid)] = {"name": d.m_Name, "shader_pid": d.m_Shader.m_PathID, "mainTex": tex}
            elif t == "TextAsset" and pid in wanted_txt:
                d = o.read()
                info[(fname, "text", pid)] = {"name": d.m_Name, "bytes": len(d.m_Script if isinstance(d.m_Script, (bytes, bytearray)) else d.m_Script.encode("utf-8", "surrogateescape"))}
            elif t == "Texture2D":
                names[pid] = o
        # nomes de textura locais (so as referenciadas por materiais deste arquivo)
        for (ff, kind, pid), v in list(info.items()):
            if ff == fname and kind == "mat" and v["mainTex"] and v["mainTex"]["fileID"] == 0:
                o = names.get(v["mainTex"]["pathID"])
                if o is not None:
                    v["mainTex"]["name"] = o.read().m_Name
        externals = [e.path for e in getattr(f, "externals", [])]
        info[(fname, "externals", 0)] = externals

    count = 0
    # datapack.unity3d (contem resources.assets, sharedassets*.assets e levelN), um arquivo serializado por vez
    reader = EndianBinaryReader(open(a.datapack, "rb").read())
    bundle = LazyBundle(reader, None, "datapack")
    done = 0
    for name in list(bundle._nodes):
        if name not in need_files:
            continue
        node_reader = bundle.node_reader(name)
        f = ImportHelper.parse_file(node_reader, bundle, name, is_dependency=False)
        if isinstance(f, SerializedFile):
            scan(f, name)
            done += 1
            count += 1
        del f, node_reader
        if a.limit and done >= a.limit:
            break
    out = {"files_scanned": count, "need_files": len(need_files),
           "info": {f"{k[0]}|{k[1]}|{k[2]}": v for k, v in info.items()}}
    with open(a.output, "w") as w:
        json.dump(out, w)
    print("scanned", count, "of", len(need_files), "files | materials", sum(1 for k in info if k[1] == "mat"), "| texts", sum(1 for k in info if k[1] == "text"))


if __name__ == "__main__":
    main()
