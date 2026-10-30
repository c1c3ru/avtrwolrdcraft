namespace System.IO.Compression;

internal struct Zip64EndOfCentralDirectoryLocator
{
	public uint NumberOfDiskWithZip64EOCD; //Field offset: 0x0
	public ulong OffsetOfZip64EOCD; //Field offset: 0x8
	public uint TotalNumberOfDisks; //Field offset: 0x10

	public static bool TryReadBlock(BinaryReader reader, out Zip64EndOfCentralDirectoryLocator zip64EOCDLocator) { }

	public static void WriteBlock(Stream stream, long zip64EOCDRecordStart) { }

}

