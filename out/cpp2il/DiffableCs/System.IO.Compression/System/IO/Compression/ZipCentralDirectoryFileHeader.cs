namespace System.IO.Compression;

internal struct ZipCentralDirectoryFileHeader
{
	public byte VersionMadeByCompatibility; //Field offset: 0x0
	public byte VersionMadeBySpecification; //Field offset: 0x1
	public ushort VersionNeededToExtract; //Field offset: 0x2
	public ushort GeneralPurposeBitFlag; //Field offset: 0x4
	public ushort CompressionMethod; //Field offset: 0x6
	public uint LastModified; //Field offset: 0x8
	public uint Crc32; //Field offset: 0xC
	public long CompressedSize; //Field offset: 0x10
	public long UncompressedSize; //Field offset: 0x18
	public ushort FilenameLength; //Field offset: 0x20
	public ushort ExtraFieldLength; //Field offset: 0x22
	public ushort FileCommentLength; //Field offset: 0x24
	public int DiskNumberStart; //Field offset: 0x28
	public ushort InternalFileAttributes; //Field offset: 0x2C
	public uint ExternalFileAttributes; //Field offset: 0x30
	public long RelativeOffsetOfLocalHeader; //Field offset: 0x38
	public Byte[] Filename; //Field offset: 0x40
	public Byte[] FileComment; //Field offset: 0x48
	public List<ZipGenericExtraField> ExtraFields; //Field offset: 0x50

	public static bool TryReadBlock(BinaryReader reader, bool saveExtraFieldsAndComments, out ZipCentralDirectoryFileHeader header) { }

}

