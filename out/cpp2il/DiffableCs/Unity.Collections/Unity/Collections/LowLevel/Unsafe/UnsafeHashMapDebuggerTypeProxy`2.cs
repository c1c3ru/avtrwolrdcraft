namespace Unity.Collections.LowLevel.Unsafe;

internal sealed class UnsafeHashMapDebuggerTypeProxy
{
	private UnsafeHashMap<TKey, TValue> m_Target; //Field offset: 0x0

	public List<Pair`2<TKey, TValue>> Items
	{
		 get { } //Length: 784
	}

	public UnsafeHashMapDebuggerTypeProxy`2(UnsafeHashMap<TKey, TValue> target) { }

	public List<Pair`2<TKey, TValue>> get_Items() { }

}

