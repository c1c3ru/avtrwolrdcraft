namespace Unity.Collections.LowLevel.Unsafe;

[Extension]
public static class HashSetExtensions
{

	[Extension]
	public static void ExceptWith(NativeHashSet<T> container, UnsafeHashSet<T> other) { }

	[Extension]
	public static void ExceptWith(UnsafeHashSet<T> container, NativeList<T> other) { }

	[Extension]
	public static void ExceptWith(UnsafeHashSet<T> container, NativeArray<T> other) { }

	[Extension]
	public static void ExceptWith(UnsafeHashSet<T> container, FixedList64Bytes<T> other) { }

	[Extension]
	public static void ExceptWith(UnsafeHashSet<T> container, FixedList512Bytes<T> other) { }

	[Extension]
	public static void ExceptWith(UnsafeHashSet<T> container, NativeHashSet<T> other) { }

	[Extension]
	public static void ExceptWith(UnsafeHashSet<T> container, UnsafeHashSet<T> other) { }

	[Extension]
	public static void ExceptWith(UnsafeHashSet<T> container, FixedList32Bytes<T> other) { }

	[Extension]
	public static void ExceptWith(UnsafeHashSet<T> container, FixedList4096Bytes<T> other) { }

	[Extension]
	public static void ExceptWith(UnsafeHashSet<T> container, FixedList128Bytes<T> other) { }

	[Extension]
	public static void ExceptWith(UnsafeHashSet<T> container, UnsafeList<T> other) { }

	[Extension]
	public static void ExceptWith(NativeHashSet<T> container, UnsafeList<T> other) { }

	[Extension]
	public static void IntersectWith(UnsafeHashSet<T> container, FixedList128Bytes<T> other) { }

	[Extension]
	public static void IntersectWith(NativeHashSet<T> container, UnsafeHashSet<T> other) { }

	[Extension]
	public static void IntersectWith(UnsafeHashSet<T> container, NativeArray<T> other) { }

	[Extension]
	public static void IntersectWith(UnsafeHashSet<T> container, NativeList<T> other) { }

	[Extension]
	public static void IntersectWith(UnsafeHashSet<T> container, FixedList64Bytes<T> other) { }

	[Extension]
	public static void IntersectWith(UnsafeHashSet<T> container, UnsafeList<T> other) { }

	[Extension]
	public static void IntersectWith(UnsafeHashSet<T> container, FixedList512Bytes<T> other) { }

	[Extension]
	public static void IntersectWith(NativeHashSet<T> container, UnsafeList<T> other) { }

	[Extension]
	public static void IntersectWith(UnsafeHashSet<T> container, FixedList4096Bytes<T> other) { }

	[Extension]
	public static void IntersectWith(UnsafeHashSet<T> container, FixedList32Bytes<T> other) { }

	[Extension]
	public static void IntersectWith(UnsafeHashSet<T> container, UnsafeHashSet<T> other) { }

	[Extension]
	public static void IntersectWith(UnsafeHashSet<T> container, NativeHashSet<T> other) { }

	[Extension]
	public static void UnionWith(UnsafeHashSet<T> container, NativeList<T> other) { }

	[Extension]
	public static void UnionWith(UnsafeHashSet<T> container, UnsafeHashSet<T> other) { }

	[Extension]
	public static void UnionWith(UnsafeHashSet<T> container, FixedList512Bytes<T> other) { }

	[Extension]
	public static void UnionWith(UnsafeHashSet<T> container, NativeArray<T> other) { }

	[Extension]
	public static void UnionWith(UnsafeHashSet<T> container, FixedList64Bytes<T> other) { }

	[Extension]
	public static void UnionWith(UnsafeHashSet<T> container, FixedList4096Bytes<T> other) { }

	[Extension]
	public static void UnionWith(UnsafeHashSet<T> container, FixedList32Bytes<T> other) { }

	[Extension]
	public static void UnionWith(UnsafeHashSet<T> container, FixedList128Bytes<T> other) { }

	[Extension]
	public static void UnionWith(NativeHashSet<T> container, UnsafeList<T> other) { }

	[Extension]
	public static void UnionWith(NativeHashSet<T> container, UnsafeHashSet<T> other) { }

	[Extension]
	public static void UnionWith(UnsafeHashSet<T> container, NativeHashSet<T> other) { }

	[Extension]
	public static void UnionWith(UnsafeHashSet<T> container, UnsafeList<T> other) { }

}

