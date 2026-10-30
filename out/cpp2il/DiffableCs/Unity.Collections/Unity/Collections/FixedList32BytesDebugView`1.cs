namespace Unity.Collections;

internal sealed class FixedList32BytesDebugView
{
	private FixedList32Bytes<T> m_List; //Field offset: 0x0

	public T[] Items
	{
		 get { } //Length: 24
	}

	public FixedList32BytesDebugView`1(FixedList32Bytes<T> list) { }

	public T[] get_Items() { }

}

