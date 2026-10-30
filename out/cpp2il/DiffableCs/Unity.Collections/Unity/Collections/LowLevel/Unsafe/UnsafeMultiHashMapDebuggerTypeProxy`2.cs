namespace Unity.Collections.LowLevel.Unsafe;

internal sealed class UnsafeMultiHashMapDebuggerTypeProxy
{
	private UnsafeMultiHashMap<TKey, TValue> m_Target; //Field offset: 0x0

	public List<ListPair`2<TKey, List`1<TValue>>> Items
	{
		 get { } //Length: 1060
	}

	public UnsafeMultiHashMapDebuggerTypeProxy`2(UnsafeMultiHashMap<TKey, TValue> target) { }

	public List<ListPair`2<TKey, List`1<TValue>>> get_Items() { }

	public static ValueTuple<NativeArray`1<TKey>, Int32> GetUniqueKeyArray(ref UnsafeMultiHashMap<TKey, TValue>& hashMap, AllocatorHandle allocator) { }

}

