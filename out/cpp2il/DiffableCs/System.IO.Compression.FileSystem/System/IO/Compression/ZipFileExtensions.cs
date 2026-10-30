namespace System.IO.Compression;

[EditorBrowsable(EditorBrowsableState::Never (1))]
[Extension]
public static class ZipFileExtensions
{

	internal static ZipArchiveEntry DoCreateEntryFromFile(ZipArchive destination, string sourceFileName, string entryName, Nullable<CompressionLevel> compressionLevel) { }

	[Extension]
	public static void ExtractToDirectory(ZipArchive source, string destinationDirectoryName, bool overwrite) { }

	[Extension]
	public static void ExtractToFile(ZipArchiveEntry source, string destinationFileName, bool overwrite) { }

}

