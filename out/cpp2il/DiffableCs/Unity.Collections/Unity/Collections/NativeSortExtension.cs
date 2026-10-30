namespace Unity.Collections;

[BurstCompatible]
[Extension]
public static class NativeSortExtension
{
	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	internal struct DefaultComparer : IComparer<T>
	{

		public override int Compare(T x, T y) { }

	}

	[BurstCompile]
	private struct SegmentSort : IJobParallelFor
	{
		[NativeDisableUnsafePtrRestriction]
		public T* Data; //Field offset: 0x0
		public U Comp; //Field offset: 0x0
		public int Length; //Field offset: 0x0
		public int SegmentWidth; //Field offset: 0x0

		public override void Execute(int index) { }

	}

	[BurstCompile]
	private struct SegmentSortMerge : IJob
	{
		[NativeDisableUnsafePtrRestriction]
		public T* Data; //Field offset: 0x0
		public U Comp; //Field offset: 0x0
		public int Length; //Field offset: 0x0
		public int SegmentWidth; //Field offset: 0x0

		public override void Execute() { }

	}

	private const int k_IntrosortSizeThreshold = 16; //Field offset: 0x0

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	[Extension]
	public static int BinarySearch(UnsafeList<T> list, T value) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(Unity.Collections.NativeSortExtension+DefaultComparer`1<System.Int32>)})]
	[Extension]
	public static int BinarySearch(NativeList<T> list, T value, U comp) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	[Extension]
	public static int BinarySearch(NativeList<T> list, T value) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	[Extension]
	public static int BinarySearch(NativeSlice<T> slice, T value) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(Unity.Collections.NativeSortExtension+DefaultComparer`1<System.Int32>)})]
	[Extension]
	public static int BinarySearch(NativeSlice<T> slice, T value, U comp) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(Unity.Collections.NativeSortExtension+DefaultComparer`1<System.Int32>)})]
	[Extension]
	public static int BinarySearch(NativeArray<T> array, T value, U comp) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public static int BinarySearch(T* ptr, int length, T value) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(Unity.Collections.NativeSortExtension+DefaultComparer`1<System.Int32>)})]
	public static int BinarySearch(T* ptr, int length, T value, U comp) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	[Extension]
	public static int BinarySearch(NativeArray<T> array, T value) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(Unity.Collections.NativeSortExtension+DefaultComparer`1<System.Int32>)})]
	[Extension]
	public static int BinarySearch(UnsafeList<T> list, T value, U comp) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void CheckStrideMatchesSize(int stride) { }

	private static void Heapify(Void* array, int i, int n, int lo, U comp) { }

	private static void HeapifyStruct(Void* array, int i, int n, int lo, U comp) { }

	private static void HeapSort(Void* array, int lo, int hi, U comp) { }

	private static void HeapSortStruct(Void* array, int lo, int hi, U comp) { }

	private static void InsertionSort(Void* array, int lo, int hi, U comp) { }

	private static void InsertionSortStruct(Void* array, int lo, int hi, U comp) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(Unity.Collections.NativeSortExtension+DefaultComparer`1<System.Int32>)})]
	internal static void IntroSort(Void* array, int length, U comp) { }

	private static void IntroSort(Void* array, int lo, int hi, int depth, U comp) { }

	private static void IntroSortStruct(Void* array, int length, U comp) { }

	private static void IntroSortStruct(Void* array, int lo, int hi, int depth, U comp) { }

	private static int Partition(Void* array, int lo, int hi, U comp) { }

	private static int PartitionStruct(Void* array, int lo, int hi, U comp) { }

	[Extension]
	[NotBurstCompatible]
	[Obsolete("Instead call SortJob(this NativeSlice<T>, U).Schedule(JobHandle). (RemovedAfter 2021-06-20)", False)]
	public static JobHandle Sort(NativeSlice<T> slice, U comp, JobHandle inputDeps) { }

	[Extension]
	[NotBurstCompatible]
	[Obsolete("Instead call SortJob(this NativeSlice<T>).Schedule(JobHandle). (RemovedAfter 2021-06-20)", False)]
	public static JobHandle Sort(NativeSlice<T> slice, JobHandle inputDeps) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(Unity.Collections.NativeSortExtension+DefaultComparer`1<System.Int32>)})]
	[Extension]
	public static void Sort(NativeSlice<T> slice, U comp) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	[Extension]
	public static void Sort(NativeSlice<T> slice) { }

	[Extension]
	[NotBurstCompatible]
	[Obsolete("Instead call SortJob(this UnsafeList<T>, U).Schedule(JobHandle). (RemovedAfter 2021-06-20)", False)]
	public static JobHandle Sort(UnsafeList<T> list, U comp, JobHandle inputDeps) { }

	[Extension]
	[NotBurstCompatible]
	[Obsolete("Instead call SortJob(this NativeArray<T>, U).Schedule(JobHandle). (RemovedAfter 2021-06-20)", False)]
	public static JobHandle Sort(NativeArray<T> array, U comp, JobHandle inputDeps) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(Unity.Collections.NativeSortExtension+DefaultComparer`1<System.Int32>)})]
	public static void Sort(T* array, int length, U comp) { }

	[NotBurstCompatible]
	[Obsolete("Instead call SortJob(T*, int).Schedule(JobHandle). (RemovedAfter 2021-06-20)", False)]
	public static JobHandle Sort(T* array, int length, JobHandle inputDeps) { }

	[NotBurstCompatible]
	[Obsolete("Instead call SortJob(T*, int, U).Schedule(JobHandle). (RemovedAfter 2021-06-20)", False)]
	public static JobHandle Sort(T* array, int length, U comp, JobHandle inputDeps) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	[Extension]
	public static void Sort(NativeArray<T> array) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(Unity.Collections.NativeSortExtension+DefaultComparer`1<System.Int32>)})]
	[Extension]
	public static void Sort(NativeArray<T> array, U comp) { }

	[Extension]
	[NotBurstCompatible]
	[Obsolete("Instead call SortJob(this NativeArray<T>).Schedule(JobHandle). (RemovedAfter 2021-06-20)", False)]
	public static JobHandle Sort(NativeArray<T> array, JobHandle inputDeps) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	[Extension]
	public static void Sort(NativeList<T> list) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(Unity.Collections.NativeSortExtension+DefaultComparer`1<System.Int32>)})]
	[Extension]
	public static void Sort(NativeList<T> list, U comp) { }

	[Extension]
	[NotBurstCompatible]
	[Obsolete("Instead call SortJob(this NativeList<T>).Schedule(JobHandle). (RemovedAfter 2021-06-20)", False)]
	public static JobHandle Sort(NativeList<T> array, JobHandle inputDeps) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public static void Sort(T* array, int length) { }

	[Extension]
	[NotBurstCompatible]
	[Obsolete("Instead call SortJob(this NativeList<T>, U).Schedule(JobHandle). (RemovedAfter 2021-06-20)", False)]
	public static JobHandle Sort(NativeList<T> list, U comp, JobHandle inputDeps) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	[Extension]
	public static void Sort(UnsafeList<T> list) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(Unity.Collections.NativeSortExtension+DefaultComparer`1<System.Int32>)})]
	[Extension]
	public static void Sort(UnsafeList<T> list, U comp) { }

	[Extension]
	[NotBurstCompatible]
	[Obsolete("Instead call SortJob(this UnsafeList<T>).Schedule(JobHandle). (RemovedAfter 2021-06-20)", False)]
	public static JobHandle Sort(UnsafeList<T> list, JobHandle inputDeps) { }

	[BurstCompatible(RequiredUnityDefine = "UNITY_2020_2_OR_NEWER", GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	[Extension]
	public static SortJob<T, DefaultComparer`1<T>> SortJob(NativeList<T> list) { }

	[BurstCompatible(RequiredUnityDefine = "UNITY_2020_2_OR_NEWER", GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	[Extension]
	public static SortJob<T, DefaultComparer`1<T>> SortJob(NativeSlice<T> slice) { }

	[BurstCompatible(RequiredUnityDefine = "UNITY_2020_2_OR_NEWER", GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(Unity.Collections.NativeSortExtension+DefaultComparer`1<System.Int32>)})]
	[Extension]
	public static SortJob<T, U> SortJob(NativeArray<T> array, U comp) { }

	[BurstCompatible(RequiredUnityDefine = "UNITY_2020_2_OR_NEWER", GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	[Extension]
	public static SortJob<T, DefaultComparer`1<T>> SortJob(UnsafeList<T> list) { }

	[BurstCompatible(RequiredUnityDefine = "UNITY_2020_2_OR_NEWER", GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	[Extension]
	public static SortJob<T, DefaultComparer`1<T>> SortJob(NativeArray<T> array) { }

	[BurstCompatible(RequiredUnityDefine = "UNITY_2020_2_OR_NEWER", GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(Unity.Collections.NativeSortExtension+DefaultComparer`1<System.Int32>)})]
	[Extension]
	public static SortJob<T, U> SortJob(NativeList<T> list, U comp) { }

	[BurstCompatible(RequiredUnityDefine = "UNITY_2020_2_OR_NEWER", GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(Unity.Collections.NativeSortExtension+DefaultComparer`1<System.Int32>)})]
	[Extension]
	public static SortJob<T, U> SortJob(NativeSlice<T> slice, U comp) { }

	[BurstCompatible(RequiredUnityDefine = "UNITY_2020_2_OR_NEWER", GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(Unity.Collections.NativeSortExtension+DefaultComparer`1<System.Int32>)})]
	public static SortJob<T, U> SortJob(T* array, int length, U comp) { }

	[BurstCompatible(RequiredUnityDefine = "UNITY_2020_2_OR_NEWER", GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public static SortJob<T, DefaultComparer`1<T>> SortJob(T* array, int length) { }

	[BurstCompatible(RequiredUnityDefine = "UNITY_2020_2_OR_NEWER", GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(Unity.Collections.NativeSortExtension+DefaultComparer`1<System.Int32>)})]
	[Extension]
	public static SortJob<T, U> SortJob(UnsafeList<T> list, U comp) { }

	private static void Swap(Void* array, int lhs, int rhs) { }

	private static void SwapIfGreaterWithItems(Void* array, int lhs, int rhs, U comp) { }

	private static void SwapIfGreaterWithItemsStruct(Void* array, int lhs, int rhs, U comp) { }

	private static void SwapStruct(Void* array, int lhs, int rhs) { }

}

