namespace Unity.Collections.LowLevel.Unsafe.NotBurstCompatible;

[Extension]
public static class Extensions
{

	[Extension]
	[NotBurstCompatible]
	public static void AddNBC(ref UnsafeAppendBuffer buffer, string value) { }

	[Extension]
	[NotBurstCompatible]
	public static void ReadNextNBC(ref Reader reader, out string value) { }

	[Extension]
	public static T[] ToArray(UnsafeHashSet<T> set) { }

	[Extension]
	[NotBurstCompatible]
	public static Byte[] ToBytesNBC(ref UnsafeAppendBuffer buffer) { }

}

