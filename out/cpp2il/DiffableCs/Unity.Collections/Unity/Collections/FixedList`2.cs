namespace Unity.Collections;

[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(FixedBytes30)})]
[DefaultMember("Item")]
internal struct FixedList : INativeList<T>, IIndexable<T>
{
	[SerializeField]
	internal ushort length; //Field offset: 0x0
	[SerializeField]
	internal U buffer; //Field offset: 0x0

	internal Byte* Buffer
	{
		internal get { } //Length: 168
	}

	public override int Capacity
	{
		 get { } //Length: 112
		 set { } //Length: 4
	}

	[CreateProperty]
	private IEnumerable<T> Elements
	{
		private get { } //Length: 120
	}

	public override bool IsEmpty
	{
		 get { } //Length: 124
	}

	public override T Item
	{
		 get { } //Length: 412
		 set { } //Length: 412
	}

	[CreateProperty]
	public override int Length
	{
		 get { } //Length: 64
		 set { } //Length: 72
	}

	internal int LengthInBytes
	{
		internal get { } //Length: 208
	}

	public void Add(in T item) { }

	public void AddNoResize(in T item) { }

	public void AddRange(Void* ptr, int length) { }

	public void AddRangeNoResize(Void* ptr, int length) { }

	public override void Clear() { }

	public override T ElementAt(int index) { }

	internal Byte* get_Buffer() { }

	public override int get_Capacity() { }

	private IEnumerable<T> get_Elements() { }

	public override bool get_IsEmpty() { }

	public override T get_Item(int index) { }

	public override int get_Length() { }

	internal int get_LengthInBytes() { }

	public virtual int GetHashCode() { }

	public void Insert(int index, in T item) { }

	public void InsertRangeWithBeginEnd(int begin, int end) { }

	public void RemoveAt(int index) { }

	public void RemoveAtSwapBack(int index) { }

	public void RemoveRange(int index, int count) { }

	public void RemoveRangeSwapBack(int index, int count) { }

	[Obsolete("RemoveRangeSwapBackWithBeginEnd(begin, end) is deprecated, use RemoveRangeSwapBack(index, count) instead. (RemovedAfter 2021-06-02)", False)]
	public void RemoveRangeSwapBackWithBeginEnd(int begin, int end) { }

	[Obsolete("RemoveRangeWithBeginEnd(begin, end) is deprecated, use RemoveRange(index, count) instead. (RemovedAfter 2021-06-02)", False)]
	public void RemoveRangeWithBeginEnd(int begin, int end) { }

	public override void set_Capacity(int value) { }

	public override void set_Item(int index, T value) { }

	public override void set_Length(int value) { }

	[NotBurstCompatible]
	public T[] ToArray() { }

	public NativeArray<T> ToNativeArray(AllocatorHandle allocator) { }

}

