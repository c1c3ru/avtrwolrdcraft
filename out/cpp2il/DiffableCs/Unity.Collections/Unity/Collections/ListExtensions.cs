namespace Unity.Collections;

[Extension]
public static class ListExtensions
{

	[Extension]
	public static void RemoveAtSwapBack(List<T> list, int index) { }

	[Extension]
	public static bool RemoveSwapBack(List<T> list, T value) { }

	[Extension]
	public static bool RemoveSwapBack(List<T> list, Predicate<T> matcher) { }

	[Extension]
	public static NativeArray<T> ToNativeArray(List<T> list, AllocatorHandle allocator) { }

	[Extension]
	public static NativeList<T> ToNativeList(List<T> list, AllocatorHandle allocator) { }

}

