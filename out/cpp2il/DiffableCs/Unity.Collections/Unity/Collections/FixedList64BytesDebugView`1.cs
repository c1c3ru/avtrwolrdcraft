namespace Unity.Collections;

internal sealed class FixedList64BytesDebugView
{
	private FixedList64Bytes<T> m_List; //Field offset: 0x0

	public T[] Items
	{
		 get { } //Length: 24
	}

	public FixedList64BytesDebugView`1(FixedList64Bytes<T> list) { }

	public T[] get_Items() { }

}

