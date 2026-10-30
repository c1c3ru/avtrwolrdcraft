//Type is in global namespace

[DefaultMember("Item")]
internal class ListWithEvents : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
{
	private List<T> m_List; //Field offset: 0x0
	[CompilerGenerated]
	private Action<T> OnElementAdded; //Field offset: 0x0
	[CompilerGenerated]
	private Action<T> OnElementRemoved; //Field offset: 0x0

	public event Action<T> OnElementAdded
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public event Action<T> OnElementRemoved
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public override int Count
	{
		 get { } //Length: 28
	}

	public override bool IsReadOnly
	{
		 get { } //Length: 140
	}

	public override T Item
	{
		 get { } //Length: 36
		 set { } //Length: 180
	}

	public ListWithEvents`1() { }

	public override void Add(T item) { }

	[CompilerGenerated]
	public void add_OnElementAdded(Action<T> value) { }

	[CompilerGenerated]
	public void add_OnElementRemoved(Action<T> value) { }

	public override void Clear() { }

	public override bool Contains(T item) { }

	public override void CopyTo(T[] array, int arrayIndex) { }

	public override int get_Count() { }

	public override bool get_IsReadOnly() { }

	public override T get_Item(int index) { }

	public override IEnumerator<T> GetEnumerator() { }

	public override int IndexOf(T item) { }

	public override void Insert(int index, T item) { }

	private void InvokeAdded(T element) { }

	private void InvokeRemoved(T element) { }

	public override bool Remove(T item) { }

	[CompilerGenerated]
	public void remove_OnElementAdded(Action<T> value) { }

	[CompilerGenerated]
	public void remove_OnElementRemoved(Action<T> value) { }

	public override void RemoveAt(int index) { }

	public override void set_Item(int index, T value) { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

}

