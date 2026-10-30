namespace System.Collections.Generic;

[DefaultMember("Item")]
internal struct ArrayBuilder
{
	private T[] _array; //Field offset: 0x0
	private int _count; //Field offset: 0x0

	public int Capacity
	{
		 get { } //Length: 24
	}

	public int Count
	{
		 get { } //Length: 8
	}

	public T Item
	{
		 get { } //Length: 48
	}

	public void Add(T item) { }

	private void EnsureCapacity(int minimum) { }

	public int get_Capacity() { }

	public int get_Count() { }

	public T get_Item(int index) { }

	public void UncheckedAdd(T item) { }

}

