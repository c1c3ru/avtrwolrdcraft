namespace System.Collections.Generic;

[DebuggerDisplay("Count = {Count}")]
[DefaultMember("Item")]
internal class LowLevelList
{
	private const int _defaultCapacity = 4; //Field offset: 0x0
	private static readonly T[] s_emptyArray; //Field offset: 0x0
	protected T[] _items; //Field offset: 0x0
	protected int _size; //Field offset: 0x0
	protected int _version; //Field offset: 0x0

	public int Capacity
	{
		 get { } //Length: 28
		 set { } //Length: 316
	}

	public override int Count
	{
		 get { } //Length: 8
	}

	public override T Item
	{
		 get { } //Length: 112
		 set { } //Length: 136
	}

	private static LowLevelList`1() { }

	public LowLevelList`1() { }

	public LowLevelList`1(int capacity) { }

	public override void Add(T item) { }

	public void AddRange(IEnumerable<T> collection) { }

	public override void Clear() { }

	public override bool Contains(T item) { }

	public override void CopyTo(T[] array, int arrayIndex) { }

	private void EnsureCapacity(int min) { }

	public int get_Capacity() { }

	public override int get_Count() { }

	public override T get_Item(int index) { }

	public override int IndexOf(T item) { }

	public override void Insert(int index, T item) { }

	public void InsertRange(int index, IEnumerable<T> collection) { }

	public override bool Remove(T item) { }

	public int RemoveAll(Predicate<T> match) { }

	public override void RemoveAt(int index) { }

	public void set_Capacity(int value) { }

	public override void set_Item(int index, T value) { }

	public T[] ToArray() { }

}

