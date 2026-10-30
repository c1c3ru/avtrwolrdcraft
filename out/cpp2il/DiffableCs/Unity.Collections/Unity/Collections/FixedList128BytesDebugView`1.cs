namespace Unity.Collections;

internal sealed class FixedList128BytesDebugView
{
	private FixedList128Bytes<T> m_List; //Field offset: 0x0

	public T[] Items
	{
		 get { } //Length: 24
	}

	public FixedList128BytesDebugView`1(FixedList128Bytes<T> list) { }

	public T[] get_Items() { }

}

