namespace System.Collections.Generic;

[IsReadOnly]
public struct KeyValuePair
{
	private readonly TKey key; //Field offset: 0x0
	private readonly TValue value; //Field offset: 0x0

	public TKey Key
	{
		 get { } //Length: 12
	}

	public TValue Value
	{
		 get { } //Length: 12
	}

	public KeyValuePair`2(TKey key, TValue value) { }

	public TKey get_Key() { }

	public TValue get_Value() { }

	public virtual string ToString() { }

}

