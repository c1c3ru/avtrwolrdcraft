namespace System.IO.Enumeration;

internal static class FileSystemEnumerableFactory
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static FindTransform<String> <>9__3_0; //Field offset: 0x8
		public static FindTransform<String> <>9__4_0; //Field offset: 0x10
		public static FindTransform<String> <>9__5_0; //Field offset: 0x18
		public static FindTransform<FileInfo> <>9__6_0; //Field offset: 0x20
		public static FindTransform<DirectoryInfo> <>9__7_0; //Field offset: 0x28
		public static FindTransform<FileSystemInfo> <>9__8_0; //Field offset: 0x30

		private static <>c() { }

		public <>c() { }

		internal DirectoryInfo <DirectoryInfos>b__7_0(ref FileSystemEntry entry) { }

		internal FileInfo <FileInfos>b__6_0(ref FileSystemEntry entry) { }

		internal FileSystemInfo <FileSystemInfos>b__8_0(ref FileSystemEntry entry) { }

		internal string <UserDirectories>b__4_0(ref FileSystemEntry entry) { }

		internal string <UserEntries>b__5_0(ref FileSystemEntry entry) { }

		internal string <UserFiles>b__3_0(ref FileSystemEntry entry) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_0
	{
		public string expression; //Field offset: 0x10
		public EnumerationOptions options; //Field offset: 0x18

		public <>c__DisplayClass3_0() { }

		internal bool <UserFiles>b__1(ref FileSystemEntry entry) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		public string expression; //Field offset: 0x10
		public EnumerationOptions options; //Field offset: 0x18

		public <>c__DisplayClass4_0() { }

		internal bool <UserDirectories>b__1(ref FileSystemEntry entry) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public string expression; //Field offset: 0x10
		public EnumerationOptions options; //Field offset: 0x18

		public <>c__DisplayClass5_0() { }

		internal bool <UserEntries>b__1(ref FileSystemEntry entry) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public string expression; //Field offset: 0x10
		public EnumerationOptions options; //Field offset: 0x18

		public <>c__DisplayClass6_0() { }

		internal bool <FileInfos>b__1(ref FileSystemEntry entry) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		public string expression; //Field offset: 0x10
		public EnumerationOptions options; //Field offset: 0x18

		public <>c__DisplayClass7_0() { }

		internal bool <DirectoryInfos>b__1(ref FileSystemEntry entry) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public string expression; //Field offset: 0x10
		public EnumerationOptions options; //Field offset: 0x18

		public <>c__DisplayClass8_0() { }

		internal bool <FileSystemInfos>b__1(ref FileSystemEntry entry) { }

	}

	private static readonly Char[] s_unixEscapeChars; //Field offset: 0x0

	private static FileSystemEnumerableFactory() { }

	internal static IEnumerable<DirectoryInfo> DirectoryInfos(string directory, string expression, EnumerationOptions options) { }

	internal static IEnumerable<FileInfo> FileInfos(string directory, string expression, EnumerationOptions options) { }

	internal static IEnumerable<FileSystemInfo> FileSystemInfos(string directory, string expression, EnumerationOptions options) { }

	private static bool MatchesPattern(string expression, ReadOnlySpan<Char> name, EnumerationOptions options) { }

	internal static void NormalizeInputs(ref string directory, ref string expression, EnumerationOptions options) { }

	internal static IEnumerable<String> UserDirectories(string directory, string expression, EnumerationOptions options) { }

	internal static IEnumerable<String> UserEntries(string directory, string expression, EnumerationOptions options) { }

	internal static IEnumerable<String> UserFiles(string directory, string expression, EnumerationOptions options) { }

}

