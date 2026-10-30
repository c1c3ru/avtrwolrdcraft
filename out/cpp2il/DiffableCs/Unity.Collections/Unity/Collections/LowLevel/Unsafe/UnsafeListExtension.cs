namespace Unity.Collections.LowLevel.Unsafe;

[Extension]
public static class UnsafeListExtension
{

	[Extension]
	public static int BinarySearch(UnsafeList container, T value) { }

	[Extension]
	public static int BinarySearch(UnsafeList container, T value, U comp) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	[Extension]
	internal static UnsafeList ListData(ref UnsafeList<T>& from) { }

	[Extension]
	public static void Sort(UnsafeList list) { }

	[Extension]
	public static void Sort(UnsafeList list, U comp) { }

	[Extension]
	[NotBurstCompatible]
	[Obsolete("Instead call SortJob(this UnsafeList).Schedule(JobHandle). (RemovedAfter 2021-06-20)", False)]
	public static JobHandle Sort(UnsafeList container, JobHandle inputDeps) { }

	[Extension]
	[NotBurstCompatible]
	[Obsolete("Instead call SortJob(this UnsafeList, U).Schedule(JobHandle). (RemovedAfter 2021-06-20)", False)]
	public static JobHandle Sort(UnsafeList container, U comp, JobHandle inputDeps) { }

	[Extension]
	public static SortJob<T, DefaultComparer`1<T>> SortJob(UnsafeList list) { }

	[Extension]
	public static SortJob<T, U> SortJob(UnsafeList list, U comp) { }

}

