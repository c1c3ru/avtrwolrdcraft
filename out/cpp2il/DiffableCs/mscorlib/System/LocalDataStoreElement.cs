namespace System;

internal sealed class LocalDataStoreElement
{
	private object m_value; //Field offset: 0x10
	private long m_cookie; //Field offset: 0x18

	public long Cookie
	{
		 get { } //Length: 8
	}

	public object Value
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public LocalDataStoreElement(long cookie) { }

	public long get_Cookie() { }

	public object get_Value() { }

	public void set_Value(object value) { }

}

