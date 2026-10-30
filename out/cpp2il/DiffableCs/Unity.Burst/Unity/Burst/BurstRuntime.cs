namespace Unity.Burst;

public static class BurstRuntime
{
	private struct HashCode32
	{
		public static readonly int Value; //Field offset: 0x0

		private static HashCode32`1() { }

	}

	private struct HashCode64
	{
		public static readonly long Value; //Field offset: 0x0

		private static HashCode64`1() { }

	}

	public class PreserveAttribute : Attribute
	{

		public PreserveAttribute() { }

	}


	public static int GetHashCode32() { }

	public static int GetHashCode32(Type type) { }

	public static long GetHashCode64() { }

	public static long GetHashCode64(Type type) { }

	public static Byte* GetUTF8LiteralPointer(string str, out int byteCount) { }

	internal static int HashStringWithFNV1A32(string text) { }

	internal static long HashStringWithFNV1A64(string text) { }

	internal static void Initialize() { }

	public static bool LoadAdditionalLibrary(string pathToLibBurstGenerated) { }

	internal static bool LoadAdditionalLibraryInternal(string pathToLibBurstGenerated) { }

	[Preserve]
	internal static void Log(Byte* message, int logType, Byte* fileName, int lineNumber) { }

	[Preserve]
	internal static void PreventRequiredAttributeStrip() { }

	[Preserve]
	internal static void RuntimeLog(Byte* message, int logType, Byte* fileName, int lineNumber) { }

}

