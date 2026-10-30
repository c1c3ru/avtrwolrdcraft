namespace System.IO.Compression;

public static class ZipFile
{

	public static void CreateFromDirectory(string sourceDirectoryName, string destinationArchiveFileName) { }

	private static void DoCreateFromDirectory(string sourceDirectoryName, string destinationArchiveFileName, Nullable<CompressionLevel> compressionLevel, bool includeBaseDirectory, Encoding entryNameEncoding) { }

	private static void EnsureCapacity(ref Char[] buffer, int min) { }

	private static string EntryFromPath(string entry, int offset, int length, ref Char[] buffer, bool appendPathSeparator = false) { }

	public static void ExtractToDirectory(string sourceArchiveFileName, string destinationDirectoryName, bool overwrite) { }

	public static void ExtractToDirectory(string sourceArchiveFileName, string destinationDirectoryName, Encoding entryNameEncoding, bool overwrite) { }

	private static bool IsDirEmpty(DirectoryInfo possiblyEmptyDir) { }

	public static ZipArchive Open(string archiveFileName, ZipArchiveMode mode, Encoding entryNameEncoding) { }

}

