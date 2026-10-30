namespace Unity.Collections;

internal sealed class NativeMultiHashMapDebuggerTypeProxy
{
	private NativeMultiHashMap<TKey, TValue> m_Target; //Field offset: 0x0

	public List<ListPair`2<TKey, List`1<TValue>>> Items
	{
		 get { } //Length: 1080
	}

	public NativeMultiHashMapDebuggerTypeProxy`2(NativeMultiHashMap<TKey, TValue> target) { }

	public List<ListPair`2<TKey, List`1<TValue>>> get_Items() { }

}

