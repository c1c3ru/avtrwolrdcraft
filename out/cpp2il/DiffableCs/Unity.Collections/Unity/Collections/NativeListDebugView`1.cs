namespace Unity.Collections;

internal sealed class NativeListDebugView
{
	private NativeList<T> m_Array; //Field offset: 0x0

	public T[] Items
	{
		 get { } //Length: 80
	}

	public NativeListDebugView`1(NativeList<T> array) { }

	public T[] get_Items() { }

}

