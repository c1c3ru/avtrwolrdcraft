namespace Unity.Collections.NotBurstCompatible;

[Extension]
public static class Extensions
{

	[Extension]
	[NotBurstCompatible]
	public static void CopyFromNBC(NativeList<T> list, T[] array) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	[Extension]
	[Obsolete("Burst now supports tuple, please use `GetUniqueKeyArray` method from `Unity.Collections.UnsafeMultiHashMap` instead.", False)]
	public static ValueTuple<NativeArray`1<TKey>, Int32> GetUniqueKeyArrayNBC(UnsafeMultiHashMap<TKey, TValue> hashmap, AllocatorHandle allocator) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	[Extension]
	[Obsolete("Burst now supports tuple, please use `GetUniqueKeyArray` method from `Unity.Collections.NativeMultiHashMap` instead.", False)]
	public static ValueTuple<NativeArray`1<TKey>, Int32> GetUniqueKeyArrayNBC(NativeMultiHashMap<TKey, TValue> hashmap, AllocatorHandle allocator) { }

	[Extension]
	[NotBurstCompatible]
	public static T[] ToArray(NativeHashSet<T> set) { }

	[Extension]
	[NotBurstCompatible]
	public static T[] ToArrayNBC(NativeList<T> list) { }

}

