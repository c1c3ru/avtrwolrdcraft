namespace Unity.Collections.LowLevel.Unsafe;

[DebuggerDisplay("Length = {Length}, Capacity = {Capacity}, IsCreated = {IsCreated}, IsEmpty = {IsEmpty}")]
[DebuggerTypeProxy(typeof(UnsafePtrListDebugView))]
[DefaultMember("Item")]
[Obsolete("Untyped UnsafePtrList is deprecated, please use UnsafePtrList<T> instead. (RemovedAfter 2021-05-18)", False)]
public struct UnsafePtrList : INativeDisposable, IDisposable, INativeList<IntPtr>, IIndexable<IntPtr>, IEnumerable<IntPtr>, IEnumerable
{
	internal struct ParallelReader
	{
		[NativeDisableUnsafePtrRestriction]
		public readonly Void** Ptr; //Field offset: 0x0
		public readonly int Length; //Field offset: 0x8

		internal ParallelReader(Void** ptr, int length) { }

		public bool Contains(Void* value) { }

		public int IndexOf(Void* value) { }

	}

	internal struct ParallelWriter
	{
		[NativeDisableUnsafePtrRestriction]
		public readonly Void* Ptr; //Field offset: 0x0
		[NativeDisableUnsafePtrRestriction]
		public UnsafeList* ListData; //Field offset: 0x8

		internal ParallelWriter(Void* ptr, UnsafeList* listData) { }

		public void AddNoResize(Void* value) { }

		public void AddRangeNoResize(Void** ptr, int length) { }

		public void AddRangeNoResize(UnsafePtrList list) { }

	}

	[NativeDisableUnsafePtrRestriction]
	public readonly Void** Ptr; //Field offset: 0x0
	public readonly int length; //Field offset: 0x8
	public readonly int unused; //Field offset: 0xC
	public readonly int capacity; //Field offset: 0x10
	public readonly AllocatorHandle Allocator; //Field offset: 0x14

	public override int Capacity
	{
		 get { } //Length: 8
		 set { } //Length: 4
	}

	public bool IsCreated
	{
		 get { } //Length: 16
	}

	public override bool IsEmpty
	{
		 get { } //Length: 32
	}

	public override IntPtr Item
	{
		 get { } //Length: 12
		 set { } //Length: 44
	}

	public override int Length
	{
		 get { } //Length: 8
		 set { } //Length: 4
	}

	public UnsafePtrList(Void** ptr, int length) { }

	public UnsafePtrList(int initialCapacity, AllocatorHandle allocator, NativeArrayOptions options = 0) { }

	public UnsafePtrList(int initialCapacity, Allocator allocator, NativeArrayOptions options = 0) { }

	public void Add(Void* value) { }

	public void Add(in IntPtr value) { }

	public void AddNoResize(Void* value) { }

	public void AddRange(UnsafePtrList list) { }

	public void AddRange(Void* ptr, int length) { }

	public void AddRangeNoResize(Void** ptr, int length) { }

	public void AddRangeNoResize(UnsafePtrList list) { }

	public ParallelReader AsParallelReader() { }

	public ParallelWriter AsParallelWriter() { }

	public override void Clear() { }

	public bool Contains(Void* value) { }

	public static UnsafePtrList* Create(Void** ptr, int length) { }

	public static UnsafePtrList* Create(int initialCapacity, Allocator allocator, NativeArrayOptions options = 0) { }

	public static void Destroy(UnsafePtrList* listData) { }

	public override void Dispose() { }

	[NotBurstCompatible]
	public override JobHandle Dispose(JobHandle inputDeps) { }

	public override IntPtr ElementAt(int index) { }

	public override int get_Capacity() { }

	public bool get_IsCreated() { }

	public override bool get_IsEmpty() { }

	public override IntPtr get_Item(int index) { }

	public override int get_Length() { }

	public int IndexOf(Void* value) { }

	public void InsertRangeWithBeginEnd(int begin, int end) { }

	public void RemoveAt(int index) { }

	public void RemoveAtSwapBack(int index) { }

	public void RemoveRangeSwapBackWithBeginEnd(int begin, int end) { }

	public void RemoveRangeWithBeginEnd(int begin, int end) { }

	public void Resize(int length, NativeArrayOptions options = 0) { }

	public override void set_Capacity(int value) { }

	public override void set_Item(int index, IntPtr value) { }

	public override void set_Length(int value) { }

	public void SetCapacity(int capacity) { }

	private override IEnumerator<IntPtr> System.Collections.Generic.IEnumerable<System.IntPtr>.GetEnumerator() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	public void TrimExcess() { }

}

