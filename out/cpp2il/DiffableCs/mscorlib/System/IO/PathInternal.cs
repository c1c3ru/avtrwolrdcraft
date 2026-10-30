namespace System.IO;

internal static class PathInternal
{
	private static readonly bool s_isCaseSensitive; //Field offset: 0x0

	internal static bool IsCaseSensitive
	{
		internal get { } //Length: 88
	}

	internal static StringComparison StringComparison
	{
		internal get { } //Length: 100
	}

	private static PathInternal() { }

	internal static bool EndsInDirectorySeparator(ReadOnlySpan<Char> path) { }

	internal static bool get_IsCaseSensitive() { }

	internal static StringComparison get_StringComparison() { }

	private static bool GetIsCaseSensitive() { }

	internal static int GetRootLength(ReadOnlySpan<Char> path) { }

	internal static bool IsDirectorySeparator(char c) { }

	internal static bool IsEffectivelyEmpty(string path) { }

	public static bool IsPartiallyQualified(string path) { }

	internal static bool IsRoot(ReadOnlySpan<Char> path) { }

	internal static bool StartsWithDirectorySeparator(ReadOnlySpan<Char> path) { }

	internal static string TrimEndingDirectorySeparator(string path) { }

	internal static ReadOnlySpan<Char> TrimEndingDirectorySeparator(ReadOnlySpan<Char> path) { }

}

