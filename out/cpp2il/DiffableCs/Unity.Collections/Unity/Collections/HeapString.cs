namespace Unity.Collections;

[BurstCompatible]
[DefaultMember("Item")]
[Obsolete("HeapString has been removed and replaced with NativeText (RemovedAfter 2021-07-21) (UnityUpgradable) -> NativeText", False)]
public struct HeapString : INativeList<Byte>, IIndexable<Byte>, IDisposable, IUTF8Bytes, IComparable<String>, IEquatable<String>, IComparable<HeapString>, IEquatable<HeapString>, IComparable<FixedString32Bytes>, IEquatable<FixedString32Bytes>, IComparable<FixedString64Bytes>, IEquatable<FixedString64Bytes>, IComparable<FixedString128Bytes>, IEquatable<FixedString128Bytes>, IComparable<FixedString512Bytes>, IEquatable<FixedString512Bytes>, IComparable<FixedString4096Bytes>, IEquatable<FixedString4096Bytes>
{
	internal struct Enumerator : IEnumerator<Rune>, IEnumerator, IDisposable
	{
		private HeapString target; //Field offset: 0x0
		private int offset; //Field offset: 0x10
		private Rune current; //Field offset: 0x14

		public override Rune Current
		{
			 get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 92
		}

		public Enumerator(HeapString source) { }

		public override void Dispose() { }

		public override Rune get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

		private override object System.Collections.IEnumerator.get_Current() { }

	}

	private NativeList<Byte> m_Data; //Field offset: 0x0

	public override int Capacity
	{
		 get { } //Length: 80
		 set { } //Length: 88
	}

	public bool IsCreated
	{
		 get { } //Length: 72
	}

	public override bool IsEmpty
	{
		 get { } //Length: 84
	}

	public override byte Item
	{
		 get { } //Length: 88
		 set { } //Length: 96
	}

	public override int Length
	{
		 get { } //Length: 80
		 set { } //Length: 132
	}

	[CreateProperty]
	[EditorBrowsable(EditorBrowsableState::Never (1))]
	[NotBurstCompatible]
	public string Value
	{
		 get { } //Length: 4
	}

	public HeapString(int capacity, Allocator allocator) { }

	[NotBurstCompatible]
	public HeapString(string source, Allocator allocator) { }

	public HeapString(in FixedString32Bytes source, Allocator allocator) { }

	public HeapString(in FixedString64Bytes source, Allocator allocator) { }

	public HeapString(in FixedString128Bytes source, Allocator allocator) { }

	public HeapString(Allocator allocator) { }

	public HeapString(in FixedString512Bytes source, Allocator allocator) { }

	public HeapString(in FixedString4096Bytes source, Allocator allocator) { }

	public void Add(in byte value) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckIndexInRange(int index) { }

	public override void Clear() { }

	public override int CompareTo(FixedString32Bytes other) { }

	[NotBurstCompatible]
	public override int CompareTo(string other) { }

	public override int CompareTo(FixedString512Bytes other) { }

	public override int CompareTo(FixedString128Bytes other) { }

	public override int CompareTo(FixedString4096Bytes other) { }

	public override int CompareTo(FixedString64Bytes other) { }

	public override int CompareTo(HeapString other) { }

	public override void Dispose() { }

	public override byte ElementAt(int index) { }

	public override bool Equals(FixedString128Bytes other) { }

	public override bool Equals(FixedString64Bytes other) { }

	public override bool Equals(FixedString32Bytes other) { }

	public override bool Equals(FixedString512Bytes other) { }

	[NotBurstCompatible]
	public virtual bool Equals(object other) { }

	public override bool Equals(HeapString other) { }

	public override bool Equals(FixedString4096Bytes other) { }

	[NotBurstCompatible]
	public override bool Equals(string other) { }

	public override int get_Capacity() { }

	public bool get_IsCreated() { }

	public override bool get_IsEmpty() { }

	public override byte get_Item(int index) { }

	public override int get_Length() { }

	public string get_Value() { }

	public Enumerator GetEnumerator() { }

	public virtual int GetHashCode() { }

	public override Byte* GetUnsafePtr() { }

	public static bool op_Equality(in HeapString a, in FixedString4096Bytes b) { }

	public static bool op_Equality(in HeapString a, in FixedString64Bytes b) { }

	public static bool op_Equality(in HeapString a, in FixedString128Bytes b) { }

	public static bool op_Equality(in HeapString a, in FixedString32Bytes b) { }

	public static bool op_Equality(in HeapString a, in FixedString512Bytes b) { }

	public static bool op_Inequality(in HeapString a, in FixedString4096Bytes b) { }

	public static bool op_Inequality(in HeapString a, in FixedString32Bytes b) { }

	public static bool op_Inequality(in HeapString a, in FixedString128Bytes b) { }

	public static bool op_Inequality(in HeapString a, in FixedString64Bytes b) { }

	public static bool op_Inequality(in HeapString a, in FixedString512Bytes b) { }

	public override void set_Capacity(int value) { }

	public override void set_Item(int index, byte value) { }

	public override void set_Length(int value) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void ThrowCopyError(CopyError error, string source) { }

	[NotBurstCompatible]
	public virtual string ToString() { }

	public override bool TryResize(int newLength, NativeArrayOptions clearOptions = 1) { }

}

