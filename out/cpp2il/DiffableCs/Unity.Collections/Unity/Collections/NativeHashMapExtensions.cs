namespace Unity.Collections;

[BurstCompatible]
[Extension]
public static class NativeHashMapExtensions
{

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	[Extension]
	[Obsolete("GetBucketData is deprecated, please use GetUnsafeBucketData instead. (RemovedAfter 2021-07-08) (UnityUpgradable) -> GetUnsafeBucketData<TKey,TValue>(*)", False)]
	public static UnsafeHashMapBucketData GetBucketData(NativeHashMap<TKey, TValue> container) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	[Extension]
	public static ValueTuple<NativeArray`1<TKey>, Int32> GetUniqueKeyArray(UnsafeMultiHashMap<TKey, TValue> container, AllocatorHandle allocator) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	[Extension]
	public static ValueTuple<NativeArray`1<TKey>, Int32> GetUniqueKeyArray(NativeMultiHashMap<TKey, TValue> container, AllocatorHandle allocator) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	[Extension]
	public static UnsafeHashMapBucketData GetUnsafeBucketData(NativeHashMap<TKey, TValue> container) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	[Extension]
	public static UnsafeHashMapBucketData GetUnsafeBucketData(NativeMultiHashMap<TKey, TValue> container) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	[Extension]
	public static void Remove(NativeMultiHashMap<TKey, TValue> container, TKey key, TValue value) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	[Extension]
	public static int Unique(NativeArray<T> array) { }

}

