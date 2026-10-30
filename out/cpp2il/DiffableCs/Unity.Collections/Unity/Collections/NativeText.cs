namespace Unity.Collections;

[BurstCompatible]
[DebuggerDisplay("Length = {Length}")]
[DefaultMember("Item")]
[NativeContainer]
public struct NativeText : INativeList<Byte>, IIndexable<Byte>, INativeDisposable, IDisposable, IUTF8Bytes, IComparable<String>, IEquatable<String>, IComparable<NativeText>, IEquatable<NativeText>, IComparable<FixedString32Bytes>, IEquatable<FixedString32Bytes>, IComparable<FixedString64Bytes>, IEquatable<FixedString64Bytes>, IComparable<FixedString128Bytes>, IEquatable<FixedString128Bytes>, IComparable<FixedString512Bytes>, IEquatable<FixedString512Bytes>, IComparable<FixedString4096Bytes>, IEquatable<FixedString4096Bytes>
{
	internal struct Enumerator : IEnumerator<Rune>, IEnumerator, IDisposable
	{
		private ReadOnly target; //Field offset: 0x0
		private int offset; //Field offset: 0x8
		private Rune current; //Field offset: 0xC

		public override Rune Current
		{
			 get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 92
		}

		public Enumerator(NativeText source) { }

		public Enumerator(ReadOnly source) { }

		public override void Dispose() { }

		public override Rune get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

		private override object System.Collections.IEnumerator.get_Current() { }

	}

	[DefaultMember("Item")]
	[NativeContainer]
	[NativeContainerIsReadOnly]
	internal struct ReadOnly : INativeList<Byte>, IIndexable<Byte>, IUTF8Bytes, IComparable<String>, IEquatable<String>, IComparable<NativeText>, IEquatable<NativeText>, IComparable<FixedString32Bytes>, IEquatable<FixedString32Bytes>, IComparable<FixedString64Bytes>, IEquatable<FixedString64Bytes>, IComparable<FixedString128Bytes>, IEquatable<FixedString128Bytes>, IComparable<FixedString512Bytes>, IEquatable<FixedString512Bytes>, IComparable<FixedString4096Bytes>, IEquatable<FixedString4096Bytes>
	{
		[NativeDisableUnsafePtrRestriction]
		internal UnsafeText* m_Data; //Field offset: 0x0

		public override int Capacity
		{
			 get { } //Length: 12
			 set { } //Length: 4
		}

		public override bool IsEmpty
		{
			 get { } //Length: 24
			 set { } //Length: 4
		}

		public override byte Item
		{
			 get { } //Length: 28
			 set { } //Length: 4
		}

		public override int Length
		{
			 get { } //Length: 12
			 set { } //Length: 4
		}

		[CreateProperty]
		[EditorBrowsable(EditorBrowsableState::Never (1))]
		[NotBurstCompatible]
		public string Value
		{
			 get { } //Length: 4
		}

		internal ReadOnly(UnsafeText* text) { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		internal static void CheckNull(Void* dataPtr) { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckRead() { }

		public override void Clear() { }

		public override int CompareTo(FixedString128Bytes other) { }

		public override int CompareTo(FixedString32Bytes other) { }

		public override int CompareTo(FixedString4096Bytes other) { }

		public override int CompareTo(NativeText other) { }

		public override int CompareTo(FixedString512Bytes other) { }

		public override int CompareTo(FixedString64Bytes other) { }

		public int CompareTo(ReadOnly other) { }

		[NotBurstCompatible]
		public override int CompareTo(string other) { }

		public override byte ElementAt(int index) { }

		public override bool Equals(FixedString32Bytes other) { }

		public override bool Equals(NativeText other) { }

		public bool Equals(ReadOnly other) { }

		[NotBurstCompatible]
		public override bool Equals(string other) { }

		[NotBurstCompatible]
		public virtual bool Equals(object other) { }

		public override bool Equals(FixedString128Bytes other) { }

		public override bool Equals(FixedString512Bytes other) { }

		public override bool Equals(FixedString4096Bytes other) { }

		public override bool Equals(FixedString64Bytes other) { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void ErrorWrite() { }

		public override int get_Capacity() { }

		public override bool get_IsEmpty() { }

		public override byte get_Item(int index) { }

		public override int get_Length() { }

		public string get_Value() { }

		public Enumerator GetEnumerator() { }

		public virtual int GetHashCode() { }

		public override Byte* GetUnsafePtr() { }

		public static bool op_Equality(in ReadOnly a, in FixedString64Bytes b) { }

		public static bool op_Equality(in ReadOnly a, in FixedString4096Bytes b) { }

		public static bool op_Equality(in ReadOnly a, in FixedString512Bytes b) { }

		public static bool op_Equality(in ReadOnly a, in FixedString32Bytes b) { }

		public static bool op_Equality(in ReadOnly a, in FixedString128Bytes b) { }

		public static bool op_Inequality(in ReadOnly a, in FixedString128Bytes b) { }

		public static bool op_Inequality(in ReadOnly a, in FixedString512Bytes b) { }

		public static bool op_Inequality(in ReadOnly a, in FixedString64Bytes b) { }

		public static bool op_Inequality(in ReadOnly a, in FixedString4096Bytes b) { }

		public static bool op_Inequality(in ReadOnly a, in FixedString32Bytes b) { }

		public override void set_Capacity(int value) { }

		public void set_IsEmpty(bool value) { }

		public override void set_Item(int index, byte value) { }

		public override void set_Length(int value) { }

		[NotBurstCompatible]
		public virtual string ToString() { }

		public override bool TryResize(int newLength, NativeArrayOptions clearOptions = 1) { }

	}

	[NativeDisableUnsafePtrRestriction]
	private UnsafeText* m_Data; //Field offset: 0x0

	public override int Capacity
	{
		 get { } //Length: 12
		 set { } //Length: 12
	}

	public bool IsCreated
	{
		 get { } //Length: 16
	}

	public override bool IsEmpty
	{
		 get { } //Length: 24
	}

	public override byte Item
	{
		 get { } //Length: 28
		 set { } //Length: 32
	}

	public override int Length
	{
		 get { } //Length: 12
		 set { } //Length: 12
	}

	[CreateProperty]
	[EditorBrowsable(EditorBrowsableState::Never (1))]
	[NotBurstCompatible]
	public string Value
	{
		 get { } //Length: 4
	}

	[NotBurstCompatible]
	public NativeText(string source, Allocator allocator) { }

	public NativeText(in FixedString4096Bytes source, AllocatorHandle allocator) { }

	public NativeText(in FixedString512Bytes source, Allocator allocator) { }

	public NativeText(in FixedString512Bytes source, AllocatorHandle allocator) { }

	public NativeText(in FixedString128Bytes source, Allocator allocator) { }

	public NativeText(in FixedString128Bytes source, AllocatorHandle allocator) { }

	public NativeText(in FixedString64Bytes source, Allocator allocator) { }

	public NativeText(in FixedString64Bytes source, AllocatorHandle allocator) { }

	public NativeText(in FixedString32Bytes source, Allocator allocator) { }

	public NativeText(in FixedString32Bytes source, AllocatorHandle allocator) { }

	public NativeText(AllocatorHandle allocator) { }

	public NativeText(Allocator allocator) { }

	public NativeText(int capacity, AllocatorHandle allocator) { }

	public NativeText(int capacity, Allocator allocator) { }

	private NativeText(int capacity, AllocatorHandle allocator, int disposeSentinelStackDepth) { }

	[NotBurstCompatible]
	public NativeText(string source, AllocatorHandle allocator) { }

	public NativeText(in FixedString4096Bytes source, Allocator allocator) { }

	public void Add(in byte value) { }

	public ReadOnly AsReadOnly() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckIndexInRange(int index) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	internal static void CheckNull(Void* dataPtr) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckRead() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckWrite() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckWriteAndBumpSecondaryVersion() { }

	public override void Clear() { }

	public override int CompareTo(FixedString64Bytes other) { }

	public override int CompareTo(FixedString4096Bytes other) { }

	public override int CompareTo(FixedString512Bytes other) { }

	public override int CompareTo(FixedString128Bytes other) { }

	public override int CompareTo(FixedString32Bytes other) { }

	public override int CompareTo(NativeText other) { }

	[NotBurstCompatible]
	public override int CompareTo(string other) { }

	public int CompareTo(ReadOnly other) { }

	[NotBurstCompatible]
	public override JobHandle Dispose(JobHandle inputDeps) { }

	public override void Dispose() { }

	public override byte ElementAt(int index) { }

	public bool Equals(ReadOnly other) { }

	[NotBurstCompatible]
	public virtual bool Equals(object other) { }

	public override bool Equals(FixedString4096Bytes other) { }

	public override bool Equals(NativeText other) { }

	[NotBurstCompatible]
	public override bool Equals(string other) { }

	public override bool Equals(FixedString512Bytes other) { }

	public override bool Equals(FixedString128Bytes other) { }

	public override bool Equals(FixedString32Bytes other) { }

	public override bool Equals(FixedString64Bytes other) { }

	public override int get_Capacity() { }

	public bool get_IsCreated() { }

	public override bool get_IsEmpty() { }

	public override byte get_Item(int index) { }

	public override int get_Length() { }

	public string get_Value() { }

	public Enumerator GetEnumerator() { }

	public virtual int GetHashCode() { }

	public override Byte* GetUnsafePtr() { }

	public static bool op_Equality(in NativeText a, in FixedString4096Bytes b) { }

	public static bool op_Equality(in NativeText a, in FixedString128Bytes b) { }

	public static bool op_Equality(in NativeText a, in FixedString32Bytes b) { }

	public static bool op_Equality(in NativeText a, in FixedString512Bytes b) { }

	public static bool op_Equality(in NativeText a, in FixedString64Bytes b) { }

	public static bool op_Inequality(in NativeText a, in FixedString64Bytes b) { }

	public static bool op_Inequality(in NativeText a, in FixedString512Bytes b) { }

	public static bool op_Inequality(in NativeText a, in FixedString128Bytes b) { }

	public static bool op_Inequality(in NativeText a, in FixedString32Bytes b) { }

	public static bool op_Inequality(in NativeText a, in FixedString4096Bytes b) { }

	public override void set_Capacity(int value) { }

	public override void set_Item(int index, byte value) { }

	public override void set_Length(int value) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void ThrowCopyError(CopyError error, string source) { }

	[NotBurstCompatible]
	public virtual string ToString() { }

	public override bool TryResize(int newLength, NativeArrayOptions clearOptions = 1) { }

}

