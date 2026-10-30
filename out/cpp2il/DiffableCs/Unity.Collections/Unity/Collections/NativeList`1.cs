namespace Unity.Collections;

[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
[DebuggerDisplay("Length = {Length}")]
[DebuggerTypeProxy(typeof(NativeListDebugView`1))]
[DefaultMember("Item")]
[NativeContainer]
public struct NativeList : INativeDisposable, IDisposable, INativeList<T>, IIndexable<T>, IEnumerable<T>, IEnumerable
{
	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	[NativeContainer]
	[NativeContainerIsAtomicWriteOnly]
	internal struct ParallelWriter
	{
		[NativeDisableUnsafePtrRestriction]
		public UnsafeList<T>* ListData; //Field offset: 0x0

		public Void* Ptr
		{
			[IsReadOnly]
			 get { } //Length: 28
		}

		internal ParallelWriter(UnsafeList<T>* listData) { }

		public void AddNoResize(T value) { }

		public void AddRangeNoResize(Void* ptr, int count) { }

		public void AddRangeNoResize(UnsafeList<T> list) { }

		public void AddRangeNoResize(NativeList<T> list) { }

		[IsReadOnly]
		public Void* get_Ptr() { }

	}

	[NativeDisableUnsafePtrRestriction]
	internal UnsafeList<T>* m_ListData; //Field offset: 0x0
	internal AllocatorHandle m_DeprecatedAllocator; //Field offset: 0x0

	public override int Capacity
	{
		 get { } //Length: 48
		 set { } //Length: 64
	}

	public bool IsCreated
	{
		 get { } //Length: 16
	}

	public override bool IsEmpty
	{
		 get { } //Length: 104
	}

	public override T Item
	{
		 get { } //Length: 64
		 set { } //Length: 72
	}

	public override int Length
	{
		 get { } //Length: 56
		 set { } //Length: 68
	}

	public NativeList`1(AllocatorHandle allocator) { }

	public NativeList`1(int initialCapacity, AllocatorHandle allocator) { }

	private NativeList`1(int initialCapacity, AllocatorHandle allocator, int disposeSentinelStackDepth) { }

	public void Add(in T value) { }

	public void AddNoResize(T value) { }

	public void AddRange(Void* ptr, int count) { }

	public void AddRange(NativeArray<T> array) { }

	public void AddRangeNoResize(NativeList<T> list) { }

	public void AddRangeNoResize(Void* ptr, int count) { }

	public NativeArray<T> AsArray() { }

	public NativeArray<T> AsDeferredJobArray() { }

	public ReadOnly<T> AsParallelReader() { }

	public ParallelWriter<T> AsParallelWriter() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void CheckArgPositive(int value) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckHandleMatches(AllocatorHandle handle) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void CheckIndexInRange(int value, int length) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void CheckInitialCapacity(int initialCapacity) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void CheckSufficientCapacity(int capacity, int length) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void CheckTotalSize(int initialCapacity, long totalSize) { }

	public override void Clear() { }

	public void CopyFrom(NativeArray<T> array) { }

	[NotBurstCompatible]
	[Obsolete("Please use `CopyFromNBC` from `Unity.Collections.NotBurstCompatible` namespace instead. (RemovedAfter 2021-06-22)", False)]
	public void CopyFrom(T[] array) { }

	[NotBurstCompatible]
	public override JobHandle Dispose(JobHandle inputDeps) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(AllocatorHandle)})]
	internal void Dispose(ref U allocator) { }

	public override void Dispose() { }

	public override T ElementAt(int index) { }

	public override int get_Capacity() { }

	public bool get_IsCreated() { }

	public override bool get_IsEmpty() { }

	public override T get_Item(int index) { }

	public override int get_Length() { }

	public Enumerator<T> GetEnumerator() { }

	public UnsafeList<T>* GetUnsafeList() { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(AllocatorHandle)})]
	internal void Initialize(int initialCapacity, ref U allocator, int disposeSentinelStackDepth) { }

	public void InsertRangeWithBeginEnd(int begin, int end) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(AllocatorHandle)})]
	internal static NativeList<T> New(int initialCapacity, ref U allocator) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(AllocatorHandle)})]
	internal static NativeList<T> New(int initialCapacity, ref U allocator, int disposeSentinelStackDepth) { }

	public static NativeArray<T> op_Implicit(NativeList<T> nativeList) { }

	public void RemoveAt(int index) { }

	public void RemoveAtSwapBack(int index) { }

	public void RemoveRange(int index, int count) { }

	public void RemoveRangeSwapBack(int index, int count) { }

	[Obsolete("RemoveRangeSwapBackWithBeginEnd(begin, end) is deprecated, use RemoveRangeSwapBack(index, count) instead. (RemovedAfter 2021-06-02)", False)]
	public void RemoveRangeSwapBackWithBeginEnd(int begin, int end) { }

	[Obsolete("RemoveRangeWithBeginEnd(begin, end) is deprecated, use RemoveRange(index, count) instead. (RemovedAfter 2021-06-02)", False)]
	public void RemoveRangeWithBeginEnd(int begin, int end) { }

	public void Resize(int length, NativeArrayOptions options) { }

	public void ResizeUninitialized(int length) { }

	public override void set_Capacity(int value) { }

	public override void set_Item(int index, T value) { }

	public override void set_Length(int value) { }

	public void SetCapacity(int capacity) { }

	private override IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	public NativeArray<T> ToArray(AllocatorHandle allocator) { }

	[NotBurstCompatible]
	public T[] ToArray() { }

	public void TrimExcess() { }

}

