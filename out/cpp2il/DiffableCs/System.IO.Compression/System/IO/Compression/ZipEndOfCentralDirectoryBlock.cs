namespace System.IO.Compression;

internal struct ZipEndOfCentralDirectoryBlock
{
	public uint Signature; //Field offset: 0x0
	public ushort NumberOfThisDisk; //Field offset: 0x4
	public ushort NumberOfTheDiskWithTheStartOfTheCentralDirectory; //Field offset: 0x6
	public ushort NumberOfEntriesInTheCentralDirectoryOnThisDisk; //Field offset: 0x8
	public ushort NumberOfEntriesInTheCentralDirectory; //Field offset: 0xA
	public uint SizeOfCentralDirectory; //Field offset: 0xC
	public uint OffsetOfStartOfCentralDirectoryWithRespectToTheStartingDiskNumber; //Field offset: 0x10
	public Byte[] ArchiveComment; //Field offset: 0x18

	public static bool TryReadBlock(BinaryReader reader, out ZipEndOfCentralDirectoryBlock eocdBlock) { }

	public static void WriteBlock(Stream stream, long numberOfEntries, long startOfCentralDirectory, long sizeOfCentralDirectory, Byte[] archiveComment) { }

}

