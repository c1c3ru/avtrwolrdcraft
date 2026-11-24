"""Patches de baixa memoria para UnityPy.BundleFile: descomprime os blocos em streaming para um arquivo
temporario (em vez de b''.join de tudo) e, em read_files, so instancia SerializedFile (pula .resS/.resource).
Uso: import lowmem_unitypy; lowmem_unitypy.install(tmpdir); env = UnityPy.load(bundle)"""
import os
from UnityPy.files import BundleFile as BF, File as F
from UnityPy.files.BundleFile import BlockInfo, DirectoryInfoFS, ArchiveFlags, ArchiveFlagsOld
from UnityPy.streams import EndianBinaryReader
from UnityPy.helpers import ImportHelper

KEEP = []
TMP = {"dir": None, "tag": "bundle"}
SKIP_SUFFIX = (".resS", ".resource")


def read_fs(self, reader):
    size = reader.read_long()
    compressedSize = reader.read_u_int()
    uncompressedSize = reader.read_u_int()
    dataflagsValue = reader.read_u_int()
    if self.signature != "UnityFS":
        reader.read_byte()
    version = self.parse_version()
    if (version < (2020,) or (version[0] == 2020 and version < (2020, 3, 34)) or (version[0] == 2021 and version < (2021, 3, 2)) or (version[0] == 2022 and version < (2022, 1, 1))):
        self.dataflags = ArchiveFlagsOld(dataflagsValue)
    else:
        self.dataflags = ArchiveFlags(dataflagsValue)
    if self.dataflags & self.dataflags.UsesAssetBundleEncryption:
        raise NotImplementedError("bundle criptografado")
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
    br = EndianBinaryReader(blocksInfoBytes, offset=start)
    br.read_bytes(16)
    n = br.read_int()
    blocks = [BlockInfo(br.read_u_int(), br.read_u_int(), br.read_u_short()) for _ in range(n)]
    nodes = br.read_int()
    directory = [DirectoryInfoFS(br.read_long(), br.read_long(), br.read_u_int(), br.read_string_to_null()) for _ in range(nodes)]
    if blocks:
        self._block_info_flags = blocks[0].flags
    if isinstance(self.dataflags, ArchiveFlags) and self.dataflags & ArchiveFlags.BlockInfoNeedPaddingAtStart:
        reader.align_stream(16)
    path = os.path.join(TMP["dir"], TMP["tag"] + ".blocks")
    total = 0
    with open(path, "wb") as out:
        for i, b in enumerate(blocks):
            data = self.decompress_data(reader.read_bytes(b.compressedSize), b.uncompressedSize, b.flags, i)
            out.write(data)
            total += len(data)
    print(f"[lowmem] {len(blocks)} blocos, {total/1e6:.0f} MB descomprimidos -> {path}; {len(directory)} nos", flush=True)
    import mmap
    fh = open(path, "rb")
    mm = mmap.mmap(fh.fileno(), 0, access=mmap.ACCESS_READ)
    KEEP.extend([fh, mm])
    return directory, EndianBinaryReader(memoryview(mm), offset=br.real_offset())


def read_files(self, reader, files):
    for node in files:
        if node.path.endswith(SKIP_SUFFIX):
            print(f"[lowmem] pula {node.path} ({node.size/1e6:.0f} MB)", flush=True)
            continue
        reader.Position = node.offset
        node_reader = EndianBinaryReader(reader.read(node.size), offset=(reader.BaseOffset + node.offset))
        f = ImportHelper.parse_file(node_reader, self, node.path, is_dependency=self.is_dependency)
        if self.environment:
            try:
                self.environment.register_cab(node.path, f)
            except Exception:
                pass
        f.flags = getattr(node, "flags", 0)
        self.files[node.path] = f
        print(f"[lowmem] carregado {node.path} ({node.size/1e6:.0f} MB)", flush=True)


def install(tmpdir, tag="bundle"):
    TMP["dir"], TMP["tag"] = tmpdir, tag
    BF.read_fs = read_fs
    BF.read_files = read_files
