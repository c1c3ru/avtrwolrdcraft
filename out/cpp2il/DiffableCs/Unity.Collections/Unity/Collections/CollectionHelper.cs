namespace Unity.Collections;

[BurstCompatible]
public static class CollectionHelper
{
	public struct LongDoubleUnion
	{
		internal long longValue; //Field offset: 0x0
		internal double doubleValue; //Field offset: 0x0

	}

	public const int CacheLineSize = 64; //Field offset: 0x0

	public static ulong Align(ulong size, ulong alignmentPowerOfTwo) { }

	public static int Align(int size, int alignmentPowerOfTwo) { }

	internal static int AssumePositive(int value) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	internal static void CheckAllocator(AllocatorHandle allocator) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	internal static void CheckCapacityInRange(int capacity, int length) { }

	[Conditional("UNITY_DOTS_DEBUG")]
	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	internal static void CheckIndexInRange(int index, int length) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	internal static void CheckIntPositivePowerOfTwo(int value) { }

	[BurstDiscard]
	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[NotBurstCompatible]
	internal static void CheckIsUnmanaged() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	internal static void CheckUlongPositivePowerOfTwo(ulong value) { }

	[NotBurstCompatible]
	public static NativeArray<T> CreateNativeArray(T[] array, AllocatorHandle allocator) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public static NativeArray<T> CreateNativeArray(NativeArray<T> array, AllocatorHandle allocator) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public static NativeArray<T> CreateNativeArray(int length, AllocatorHandle allocator, NativeArrayOptions options = 1) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(AllocatorHandle)})]
	public static NativeArray<T> CreateNativeArray(int length, ref U allocator, NativeArrayOptions options = 1) { }

	[NotBurstCompatible]
	public static NativeArray<T> CreateNativeArray(T[] array, ref U allocator) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int), typeof(AllocatorHandle)})]
	public static NativeMultiHashMap<TKey, TValue> CreateNativeMultiHashMap(int length, ref U allocator) { }

	public static uint Hash(Void* ptr, int bytes) { }

	public static bool IsAligned(ulong offset, int alignmentPowerOfTwo) { }

	public static bool IsAligned(Void* p, int alignmentPowerOfTwo) { }

	public static bool IsPowerOfTwo(int value) { }

	public static int Log2Ceil(int value) { }

	public static int Log2Floor(int value) { }

	internal static bool ShouldDeallocate(AllocatorHandle allocator) { }

	[NotBurstCompatible]
	internal static void WriteLayout(Type type) { }

}

