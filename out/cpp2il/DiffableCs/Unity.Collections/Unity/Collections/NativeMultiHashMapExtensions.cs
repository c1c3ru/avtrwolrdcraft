namespace Unity.Collections;

[BurstCompatible]
[Extension]
public static class NativeMultiHashMapExtensions
{

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int), typeof(AllocatorHandle)})]
	[Extension]
	internal static void Initialize(ref NativeMultiHashMap<TKey, TValue>& nativeMultiHashMap, int capacity, ref U allocator, int disposeSentinelStackDepth = 2) { }

}

