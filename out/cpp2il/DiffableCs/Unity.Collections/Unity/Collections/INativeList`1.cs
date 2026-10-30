namespace Unity.Collections;

[DefaultMember("Item")]
public interface INativeList : IIndexable<T>
{

	public int Capacity
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public bool IsEmpty
	{
		 get { } //Length: 0
	}

	public T Item
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public void Clear() { }

	public int get_Capacity() { }

	public bool get_IsEmpty() { }

	public T get_Item(int index) { }

	public void set_Capacity(int value) { }

	public void set_Item(int index, T value) { }

}

