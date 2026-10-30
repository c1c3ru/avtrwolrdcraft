namespace Unity.Collections;

[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
[DebuggerTypeProxy(typeof(FixedList512BytesDebugView`1))]
[DefaultMember("Item")]
public struct FixedList512Bytes : INativeList<T>, IIndexable<T>, IEnumerable<T>, IEnumerable, IEquatable<FixedList32Bytes`1<T>>, IComparable<FixedList32Bytes`1<T>>, IEquatable<FixedList64Bytes`1<T>>, IComparable<FixedList64Bytes`1<T>>, IEquatable<FixedList128Bytes`1<T>>, IComparable<FixedList128Bytes`1<T>>, IEquatable<FixedList512Bytes`1<T>>, IComparable<FixedList512Bytes`1<T>>, IEquatable<FixedList4096Bytes`1<T>>, IComparable<FixedList4096Bytes`1<T>>
{
	internal struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
	{
		private FixedList512Bytes<T> m_List; //Field offset: 0x0
		private int m_Index; //Field offset: 0x0

		public override T Current
		{
			 get { } //Length: 60
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 104
		}

		public Enumerator(ref FixedList512Bytes<T>& list) { }

		public override void Dispose() { }

		public override T get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

		private override object System.Collections.IEnumerator.get_Current() { }

	}

	[SerializeField]
	internal ushort length; //Field offset: 0x0
	[SerializeField]
	internal FixedBytes510 buffer; //Field offset: 0x0

	internal Byte* Buffer
	{
		internal get { } //Length: 60
	}

	public override int Capacity
	{
		 get { } //Length: 36
		 set { } //Length: 4
	}

	[CreateProperty]
	private IEnumerable<T> Elements
	{
		private get { } //Length: 52
	}

	public override bool IsEmpty
	{
		 get { } //Length: 48
	}

	public override T Item
	{
		 get { } //Length: 116
		 set { } //Length: 128
	}

	[CreateProperty]
	public override int Length
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	internal int LengthInBytes
	{
		internal get { } //Length: 84
	}

	public FixedList512Bytes`1(in FixedList32Bytes<T>& other) { }

	public FixedList512Bytes`1(in FixedList64Bytes<T>& other) { }

	public FixedList512Bytes`1(in FixedList128Bytes<T>& other) { }

	public FixedList512Bytes`1(in FixedList4096Bytes<T>& other) { }

	public void Add(in T item) { }

	public void AddNoResize(in T item) { }

	public void AddRange(Void* ptr, int length) { }

	public void AddRangeNoResize(Void* ptr, int length) { }

	public override void Clear() { }

	public override int CompareTo(FixedList64Bytes<T> other) { }

	public override int CompareTo(FixedList128Bytes<T> other) { }

	public override int CompareTo(FixedList512Bytes<T> other) { }

	public override int CompareTo(FixedList32Bytes<T> other) { }

	public override int CompareTo(FixedList4096Bytes<T> other) { }

	public override T ElementAt(int index) { }

	public override bool Equals(FixedList512Bytes<T> other) { }

	public override bool Equals(FixedList128Bytes<T> other) { }

	public override bool Equals(FixedList4096Bytes<T> other) { }

	[NotBurstCompatible]
	public virtual bool Equals(object obj) { }

	public override bool Equals(FixedList64Bytes<T> other) { }

	public override bool Equals(FixedList32Bytes<T> other) { }

	internal Byte* get_Buffer() { }

	public override int get_Capacity() { }

	private IEnumerable<T> get_Elements() { }

	public override bool get_IsEmpty() { }

	public override T get_Item(int index) { }

	public override int get_Length() { }

	internal int get_LengthInBytes() { }

	public Enumerator<T> GetEnumerator() { }

	public virtual int GetHashCode() { }

	internal int Initialize(in FixedList128Bytes<T>& other) { }

	internal int Initialize(in FixedList4096Bytes<T>& other) { }

	internal int Initialize(in FixedList32Bytes<T>& other) { }

	internal int Initialize(in FixedList64Bytes<T>& other) { }

	public void Insert(int index, in T item) { }

	public void InsertRangeWithBeginEnd(int begin, int end) { }

	public static bool op_Equality(in FixedList512Bytes<T>& a, in FixedList512Bytes<T>& b) { }

	public static bool op_Equality(in FixedList512Bytes<T>& a, in FixedList4096Bytes<T>& b) { }

	public static bool op_Equality(in FixedList512Bytes<T>& a, in FixedList128Bytes<T>& b) { }

	public static bool op_Equality(in FixedList512Bytes<T>& a, in FixedList32Bytes<T>& b) { }

	public static bool op_Equality(in FixedList512Bytes<T>& a, in FixedList64Bytes<T>& b) { }

	public static FixedList512Bytes<T> op_Implicit(in FixedList64Bytes<T>& other) { }

	public static FixedList512Bytes<T> op_Implicit(in FixedList32Bytes<T>& other) { }

	public static FixedList512Bytes<T> op_Implicit(in FixedList4096Bytes<T>& other) { }

	public static FixedList512Bytes<T> op_Implicit(in FixedList128Bytes<T>& other) { }

	public static bool op_Inequality(in FixedList512Bytes<T>& a, in FixedList128Bytes<T>& b) { }

	public static bool op_Inequality(in FixedList512Bytes<T>& a, in FixedList64Bytes<T>& b) { }

	public static bool op_Inequality(in FixedList512Bytes<T>& a, in FixedList32Bytes<T>& b) { }

	public static bool op_Inequality(in FixedList512Bytes<T>& a, in FixedList512Bytes<T>& b) { }

	public static bool op_Inequality(in FixedList512Bytes<T>& a, in FixedList4096Bytes<T>& b) { }

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

	private override IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	[NotBurstCompatible]
	public T[] ToArray() { }

	public NativeArray<T> ToNativeArray(AllocatorHandle allocator) { }

}

