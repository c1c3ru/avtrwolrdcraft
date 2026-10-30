namespace Unity.Collections;

[Extension]
public static class HashSetExtensions
{

	[Extension]
	public static void ExceptWith(NativeHashSet<T> container, FixedList128Bytes<T> other) { }

	[Extension]
	public static void ExceptWith(NativeHashSet<T> container, NativeHashSet<T> other) { }

	[Extension]
	public static void ExceptWith(NativeHashSet<T> container, NativeList<T> other) { }

	[Extension]
	public static void ExceptWith(NativeHashSet<T> container, FixedList32Bytes<T> other) { }

	[Extension]
	public static void ExceptWith(NativeHashSet<T> container, FixedList64Bytes<T> other) { }

	[Extension]
	public static void ExceptWith(NativeHashSet<T> container, FixedList4096Bytes<T> other) { }

	[Extension]
	public static void ExceptWith(NativeHashSet<T> container, NativeArray<T> other) { }

	[Extension]
	public static void ExceptWith(NativeHashSet<T> container, FixedList512Bytes<T> other) { }

	[Extension]
	public static void IntersectWith(NativeHashSet<T> container, FixedList64Bytes<T> other) { }

	[Extension]
	public static void IntersectWith(NativeHashSet<T> container, NativeList<T> other) { }

	[Extension]
	public static void IntersectWith(NativeHashSet<T> container, NativeHashSet<T> other) { }

	[Extension]
	public static void IntersectWith(NativeHashSet<T> container, FixedList4096Bytes<T> other) { }

	[Extension]
	public static void IntersectWith(NativeHashSet<T> container, FixedList32Bytes<T> other) { }

	[Extension]
	public static void IntersectWith(NativeHashSet<T> container, FixedList128Bytes<T> other) { }

	[Extension]
	public static void IntersectWith(NativeHashSet<T> container, FixedList512Bytes<T> other) { }

	[Extension]
	public static void IntersectWith(NativeHashSet<T> container, NativeArray<T> other) { }

	[Extension]
	public static void UnionWith(NativeHashSet<T> container, NativeHashSet<T> other) { }

	[Extension]
	public static void UnionWith(NativeHashSet<T> container, FixedList512Bytes<T> other) { }

	[Extension]
	public static void UnionWith(NativeHashSet<T> container, FixedList64Bytes<T> other) { }

	[Extension]
	public static void UnionWith(NativeHashSet<T> container, FixedList4096Bytes<T> other) { }

	[Extension]
	public static void UnionWith(NativeHashSet<T> container, FixedList32Bytes<T> other) { }

	[Extension]
	public static void UnionWith(NativeHashSet<T> container, FixedList128Bytes<T> other) { }

	[Extension]
	public static void UnionWith(NativeHashSet<T> container, NativeArray<T> other) { }

	[Extension]
	public static void UnionWith(NativeHashSet<T> container, NativeList<T> other) { }

}

