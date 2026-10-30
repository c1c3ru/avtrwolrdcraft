namespace Unity.Collections.LowLevel.Unsafe;

[DebuggerDisplay("Length = {Length}, Capacity = {Capacity}, IsCreated = {IsCreated}, IsEmpty = {IsEmpty}")]
[Obsolete("Untyped UnsafeList is deprecated, please use UnsafeList<T> instead. (RemovedAfter 2021-05-18)", False)]
public struct UnsafeList : INativeDisposable, IDisposable
{
	internal struct ParallelReader
	{
		[NativeDisableUnsafePtrRestriction]
		public readonly Void* Ptr; //Field offset: 0x0
		public readonly int Length; //Field offset: 0x8

		internal ParallelReader(Void* ptr, int length) { }

		public bool Contains(T value) { }

		public int IndexOf(T value) { }

	}

	internal struct ParallelWriter
	{
		[NativeDisableUnsafePtrRestriction]
		public readonly Void* Ptr; //Field offset: 0x0
		[NativeDisableUnsafePtrRestriction]
		public UnsafeList* ListData; //Field offset: 0x8

		internal ParallelWriter(Void* ptr, UnsafeList* listData) { }

		public void AddNoResize(T value) { }

		private void AddRangeNoResize(int sizeOf, int alignOf, Void* ptr, int length) { }

		public void AddRangeNoResize(Void* ptr, int length) { }

		public void AddRangeNoResize(UnsafeList list) { }

	}

	[NativeDisableUnsafePtrRestriction]
	public Void* Ptr; //Field offset: 0x0
	public int Length; //Field offset: 0x8
	public readonly int unused; //Field offset: 0xC
	public int Capacity; //Field offset: 0x10
	public AllocatorHandle Allocator; //Field offset: 0x14

	public bool IsCreated
	{
		 get { } //Length: 16
	}

	public bool IsEmpty
	{
		 get { } //Length: 32
	}

	public UnsafeList(Allocator allocator) { }

	public UnsafeList(Void* ptr, int length) { }

	public UnsafeList(int sizeOf, int alignOf, int initialCapacity, AllocatorHandle allocator, NativeArrayOptions options = 0) { }

	public UnsafeList(int sizeOf, int alignOf, int initialCapacity, Allocator allocator, NativeArrayOptions options = 0) { }

	public void Add(T value) { }

	public void AddNoResize(T value) { }

	public void AddRange(UnsafeList list) { }

	public void AddRange(Void* ptr, int length) { }

	private void AddRange(int sizeOf, int alignOf, Void* ptr, int length) { }

	private void AddRangeNoResize(int sizeOf, Void* ptr, int length) { }

	public void AddRangeNoResize(Void* ptr, int length) { }

	public void AddRangeNoResize(UnsafeList list) { }

	public ParallelReader AsParallelReader() { }

	public ParallelWriter AsParallelWriter() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void CheckAllocator(Allocator a) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void CheckAllocator(AllocatorHandle a) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckBeginEnd(int begin, int end) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckNoResizeHasEnoughCapacity(int length) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckNoResizeHasEnoughCapacity(int length, int index) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	internal static void CheckNull(Void* listData) { }

	public void Clear() { }

	public bool Contains(T value) { }

	public static UnsafeList* Create(int sizeOf, int alignOf, int initialCapacity, Allocator allocator, NativeArrayOptions options = 0) { }

	internal static UnsafeList* Create(int sizeOf, int alignOf, int initialCapacity, ref U allocator, NativeArrayOptions options = 0) { }

	internal static void Destroy(UnsafeList* listData, ref U allocator, int sizeOf, int alignOf) { }

	public static void Destroy(UnsafeList* listData) { }

	[NotBurstCompatible]
	public override JobHandle Dispose(JobHandle inputDeps) { }

	internal void Dispose(ref U allocator, int sizeOf, int alignOf) { }

	public override void Dispose() { }

	public bool get_IsCreated() { }

	public bool get_IsEmpty() { }

	public int IndexOf(T value) { }

	internal void Initialize(int sizeOf, int alignOf, int initialCapacity, ref U allocator, NativeArrayOptions options = 0) { }

	public void InsertRangeWithBeginEnd(int begin, int end) { }

	private void InsertRangeWithBeginEnd(int sizeOf, int alignOf, int begin, int end) { }

	internal static UnsafeList New(int sizeOf, int alignOf, int initialCapacity, ref U allocator, NativeArrayOptions options = 0) { }

	private void Realloc(ref U allocator, int sizeOf, int alignOf, int capacity) { }

	private void Realloc(int sizeOf, int alignOf, int capacity) { }

	public void RemoveAt(int index) { }

	public void RemoveAtSwapBack(int index) { }

	private void RemoveRangeSwapBackWithBeginEnd(int sizeOf, int begin, int end) { }

	public void RemoveRangeSwapBackWithBeginEnd(int begin, int end) { }

	private void RemoveRangeWithBeginEnd(int sizeOf, int begin, int end) { }

	public void RemoveRangeWithBeginEnd(int begin, int end) { }

	public void Resize(int sizeOf, int alignOf, int length, NativeArrayOptions options = 0) { }

	public void Resize(int length, NativeArrayOptions options = 0) { }

	public void SetCapacity(int capacity) { }

	private void SetCapacity(int sizeOf, int alignOf, int capacity) { }

	private void SetCapacity(ref U allocator, int sizeOf, int alignOf, int capacity) { }

	public void TrimExcess() { }

}

