namespace System.IO;

public static class File
{

	public static void AppendAllText(string path, string contents) { }

	public static void Copy(string sourceFileName, string destFileName) { }

	public static void Copy(string sourceFileName, string destFileName, bool overwrite) { }

	public static FileStream Create(string path) { }

	public static FileStream Create(string path, int bufferSize) { }

	public static void Delete(string path) { }

	public static bool Exists(string path) { }

	public static FileAttributes GetAttributes(string path) { }

	public static DateTime GetLastWriteTime(string path) { }

	private static String[] InternalReadAllLines(string path, Encoding encoding) { }

	private static string InternalReadAllText(string path, Encoding encoding) { }

	private static void InternalWriteAllBytes(string path, Byte[] bytes) { }

	private static void InternalWriteAllLines(TextWriter writer, IEnumerable<String> contents) { }

	public static FileStream Open(string path, FileMode mode) { }

	public static FileStream Open(string path, FileMode mode, FileAccess access, FileShare share) { }

	public static FileStream OpenRead(string path) { }

	public static StreamReader OpenText(string path) { }

	public static Byte[] ReadAllBytes(string path) { }

	private static Byte[] ReadAllBytesUnknownLength(FileStream fs) { }

	public static String[] ReadAllLines(string path) { }

	public static string ReadAllText(string path) { }

	public static void SetLastWriteTime(string path, DateTime lastWriteTime) { }

	public static void WriteAllBytes(string path, Byte[] bytes) { }

	public static void WriteAllLines(string path, String[] contents) { }

	public static void WriteAllLines(string path, IEnumerable<String> contents) { }

	public static void WriteAllText(string path, string contents) { }

}

