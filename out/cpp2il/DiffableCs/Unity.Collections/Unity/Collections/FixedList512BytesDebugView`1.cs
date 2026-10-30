namespace Unity.Collections;

internal sealed class FixedList512BytesDebugView
{
	private FixedList512Bytes<T> m_List; //Field offset: 0x0

	public T[] Items
	{
		 get { } //Length: 24
	}

	public FixedList512BytesDebugView`1(FixedList512Bytes<T> list) { }

	public T[] get_Items() { }

}

