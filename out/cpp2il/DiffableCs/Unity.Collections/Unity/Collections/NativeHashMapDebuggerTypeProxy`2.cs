namespace Unity.Collections;

internal sealed class NativeHashMapDebuggerTypeProxy
{
	private UnsafeHashMap<TKey, TValue> m_Target; //Field offset: 0x0

	public List<Pair`2<TKey, TValue>> Items
	{
		 get { } //Length: 784
	}

	public NativeHashMapDebuggerTypeProxy`2(NativeHashMap<TKey, TValue> target) { }

	public List<Pair`2<TKey, TValue>> get_Items() { }

}

