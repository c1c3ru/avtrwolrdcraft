namespace System.IO.Compression;

[IsReadOnly]
internal struct ZipLocalFileHeader
{

	public static List<ZipGenericExtraField> GetExtraFields(BinaryReader reader) { }

	public static bool TrySkipBlock(BinaryReader reader) { }

}

