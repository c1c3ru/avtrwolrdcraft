namespace Unity.Collections;

[BurstCompatible]
[DefaultMember("Item")]
public struct FixedString128Bytes : INativeList<Byte>, IIndexable<Byte>, IUTF8Bytes, IComparable<String>, IEquatable<String>, IComparable<FixedString32Bytes>, IEquatable<FixedString32Bytes>, IComparable<FixedString64Bytes>, IEquatable<FixedString64Bytes>, IComparable<FixedString128Bytes>, IEquatable<FixedString128Bytes>, IComparable<FixedString512Bytes>, IEquatable<FixedString512Bytes>, IComparable<FixedString4096Bytes>, IEquatable<FixedString4096Bytes>
{
	internal struct Enumerator : IEnumerator
	{
		private FixedString128Bytes target; //Field offset: 0x0
		private int offset; //Field offset: 0x80
		private Rune current; //Field offset: 0x84

		public Rune Current
		{
			 get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 92
		}

		public Enumerator(FixedString128Bytes other) { }

		public void Dispose() { }

		public Rune get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

		private override object System.Collections.IEnumerator.get_Current() { }

	}

	internal const ushort utf8MaxLengthInBytes = 125; //Field offset: 0x0
	[SerializeField]
	internal ushort utf8LengthInBytes; //Field offset: 0x0
	[SerializeField]
	internal FixedBytes126 bytes; //Field offset: 0x2

	public override int Capacity
	{
		 get { } //Length: 8
		 set { } //Length: 4
	}

	public override bool IsEmpty
	{
		 get { } //Length: 16
	}

	public override byte Item
	{
		 get { } //Length: 12
		 set { } //Length: 12
	}

	public override int Length
	{
		 get { } //Length: 8
		 set { } //Length: 16
	}

	public static int UTF8MaxLengthInBytes
	{
		 get { } //Length: 8
	}

	[CreateProperty]
	[EditorBrowsable(EditorBrowsableState::Never (1))]
	[NotBurstCompatible]
	public string Value
	{
		 get { } //Length: 4
	}

	public FixedString128Bytes(in FixedString32Bytes other) { }

	public FixedString128Bytes(in FixedString512Bytes other) { }

	public FixedString128Bytes(Rune rune, int count = 1) { }

	[NotBurstCompatible]
	public FixedString128Bytes(string source) { }

	public FixedString128Bytes(in FixedString64Bytes other) { }

	public FixedString128Bytes(in FixedString128Bytes other) { }

	public FixedString128Bytes(in FixedString4096Bytes other) { }

	public void Add(in byte value) { }

	public FixedList128Bytes<Byte>& AsFixedList() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckCapacityInRange(int capacity) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void CheckCopyError(CopyError error, string source) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void CheckFormatError(FormatError error) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckIndexInRange(int index) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckLengthInRange(int length) { }

	public override void Clear() { }

	public override int CompareTo(FixedString4096Bytes other) { }

	[NotBurstCompatible]
	public override int CompareTo(string other) { }

	public override int CompareTo(FixedString64Bytes other) { }

	public override int CompareTo(FixedString512Bytes other) { }

	public override int CompareTo(FixedString128Bytes other) { }

	public override int CompareTo(FixedString32Bytes other) { }

	public override byte ElementAt(int index) { }

	public override bool Equals(FixedString128Bytes other) { }

	public override bool Equals(FixedString32Bytes other) { }

	[NotBurstCompatible]
	public override bool Equals(string other) { }

	public override bool Equals(FixedString4096Bytes other) { }

	[NotBurstCompatible]
	public virtual bool Equals(object obj) { }

	public override bool Equals(FixedString512Bytes other) { }

	public override bool Equals(FixedString64Bytes other) { }

	public override int get_Capacity() { }

	public override bool get_IsEmpty() { }

	public override byte get_Item(int index) { }

	public override int get_Length() { }

	public static int get_UTF8MaxLengthInBytes() { }

	public string get_Value() { }

	public Enumerator GetEnumerator() { }

	public virtual int GetHashCode() { }

	public override Byte* GetUnsafePtr() { }

	internal int Initialize(in FixedString64Bytes other) { }

	internal int Initialize(in FixedString128Bytes other) { }

	internal int Initialize(in FixedString32Bytes other) { }

	internal int Initialize(Rune rune, int count = 1) { }

	internal int Initialize(in FixedString512Bytes other) { }

	internal int Initialize(in FixedString4096Bytes other) { }

	[NotBurstCompatible]
	internal int Initialize(string source) { }

	public static bool op_Equality(in FixedString128Bytes a, in FixedString4096Bytes b) { }

	public static bool op_Equality(in FixedString128Bytes a, in FixedString64Bytes b) { }

	public static bool op_Equality(in FixedString128Bytes a, in FixedString512Bytes b) { }

	public static bool op_Equality(in FixedString128Bytes a, in FixedString32Bytes b) { }

	public static bool op_Equality(in FixedString128Bytes a, in FixedString128Bytes b) { }

	public static FixedString4096Bytes op_Implicit(in FixedString128Bytes fs) { }

	[NotBurstCompatible]
	public static FixedString128Bytes op_Implicit(string b) { }

	public static FixedString512Bytes op_Implicit(in FixedString128Bytes fs) { }

	public static bool op_Inequality(in FixedString128Bytes a, in FixedString512Bytes b) { }

	public static bool op_Inequality(in FixedString128Bytes a, in FixedString64Bytes b) { }

	public static bool op_Inequality(in FixedString128Bytes a, in FixedString4096Bytes b) { }

	public static bool op_Inequality(in FixedString128Bytes a, in FixedString128Bytes b) { }

	public static bool op_Inequality(in FixedString128Bytes a, in FixedString32Bytes b) { }

	public override void set_Capacity(int value) { }

	public override void set_Item(int index, byte value) { }

	public override void set_Length(int value) { }

	[NotBurstCompatible]
	public virtual string ToString() { }

	public override bool TryResize(int newLength, NativeArrayOptions clearOptions = 1) { }

}

