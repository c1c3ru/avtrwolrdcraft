namespace System.IO.Compression;

internal struct Zip64EndOfCentralDirectoryRecord
{
	public ulong SizeOfThisRecord; //Field offset: 0x0
	public ushort VersionMadeBy; //Field offset: 0x8
	public ushort VersionNeededToExtract; //Field offset: 0xA
	public uint NumberOfThisDisk; //Field offset: 0xC
	public uint NumberOfDiskWithStartOfCD; //Field offset: 0x10
	public ulong NumberOfEntriesOnThisDisk; //Field offset: 0x18
	public ulong NumberOfEntriesTotal; //Field offset: 0x20
	public ulong SizeOfCentralDirectory; //Field offset: 0x28
	public ulong OffsetOfCentralDirectory; //Field offset: 0x30

	public static bool TryReadBlock(BinaryReader reader, out Zip64EndOfCentralDirectoryRecord zip64EOCDRecord) { }

	public static void WriteBlock(Stream stream, long numberOfEntries, long startOfCentralDirectory, long sizeOfCentralDirectory) { }

}

