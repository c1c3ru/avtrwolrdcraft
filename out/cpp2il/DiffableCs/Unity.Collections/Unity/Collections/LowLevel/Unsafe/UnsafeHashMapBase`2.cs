namespace Unity.Collections.LowLevel.Unsafe;

[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
internal struct UnsafeHashMapBase
{

	internal static void AddAtomicMulti(UnsafeHashMapData* data, TKey key, TValue item, int threadIndex) { }

	internal static int AllocEntry(UnsafeHashMapData* data, int threadIndex) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void CheckIndexOutOfBounds(UnsafeHashMapData* data, int idx) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void CheckOutOfCapacity(int idx, int keyCapacity) { }

	internal static void Clear(UnsafeHashMapData* data) { }

	internal static void FreeEntry(UnsafeHashMapData* data, int idx, int threadIndex) { }

	internal static int Remove(UnsafeHashMapData* data, TKey key, bool isMultiHashMap) { }

	internal static void Remove(UnsafeHashMapData* data, NativeMultiHashMapIterator<TKey> it) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	internal static void RemoveKeyValue(UnsafeHashMapData* data, TKey key, TValueEQ value) { }

	internal static bool SetValue(UnsafeHashMapData* data, ref NativeMultiHashMapIterator<TKey>& it, ref TValue item) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void ThrowFull() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void ThrowInvalidIterator() { }

	internal static bool TryAdd(UnsafeHashMapData* data, TKey key, TValue item, bool isMultiHashMap, AllocatorHandle allocation) { }

	internal static bool TryAddAtomic(UnsafeHashMapData* data, TKey key, TValue item, int threadIndex) { }

	internal static bool TryGetFirstValueAtomic(UnsafeHashMapData* data, TKey key, out TValue item, out NativeMultiHashMapIterator<TKey>& it) { }

	internal static bool TryGetNextValueAtomic(UnsafeHashMapData* data, out TValue item, ref NativeMultiHashMapIterator<TKey>& it) { }

}

