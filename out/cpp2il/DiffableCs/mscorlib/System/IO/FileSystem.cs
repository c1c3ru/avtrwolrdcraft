namespace System.IO;

internal static class FileSystem
{

	private static bool CopyDanglingSymlink(string sourceFullPath, string destFullPath) { }

	public static void CopyFile(string sourceFullPath, string destFullPath, bool overwrite) { }

	public static void CreateDirectory(string fullPath) { }

	public static void DeleteFile(string fullPath) { }

	public static bool DirectoryExists(ReadOnlySpan<Char> fullPath) { }

	private static bool DirectoryExists(ReadOnlySpan<Char> fullPath, out ErrorInfo errorInfo) { }

	public static bool FileExists(ReadOnlySpan<Char> fullPath) { }

	private static bool FileExists(ReadOnlySpan<Char> fullPath, int fileType, out ErrorInfo errorInfo) { }

	public static FileAttributes GetAttributes(string fullPath) { }

	public static DateTimeOffset GetLastWriteTime(string fullPath) { }

	public static void RemoveDirectory(string fullPath, bool recursive) { }

	private static void RemoveDirectoryInternal(DirectoryInfo directory, bool recursive, bool throwOnTopLevelDirectoryNotFound) { }

	public static void SetLastWriteTime(string fullPath, DateTimeOffset time, bool asDirectory) { }

	private static bool ShouldIgnoreDirectory(string name) { }

}

