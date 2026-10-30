namespace Unity.Collections.LowLevel.Unsafe;

[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
[DebuggerDisplay("Length = {Length}, Capacity = {Capacity}, IsCreated = {IsCreated}, IsEmpty = {IsEmpty}")]
[DebuggerTypeProxy(typeof(UnsafeListTDebugView`1))]
[DefaultMember("Item")]
public struct UnsafeList : INativeDisposable, IDisposable, INativeList<T>, IIndexable<T>, IEnumerable<T>, IEnumerable
{
	internal struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
	{
		internal T* m_Ptr; //Field offset: 0x0
		internal int m_Length; //Field offset: 0x0
		internal int m_Index; //Field offset: 0x0

		public override T Current
		{
			 get { } //Length: 16
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 112
		}

		public override void Dispose() { }

		public override T get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

		private override object System.Collections.IEnumerator.get_Current() { }

	}

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	internal struct ParallelReader
	{
		[NativeDisableUnsafePtrRestriction]
		public readonly T* Ptr; //Field offset: 0x0
		public readonly int Length; //Field offset: 0x0

		internal ParallelReader(T* ptr, int length) { }

	}

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
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

		[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
		public void AddNoResize(T value) { }

		[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
		public void AddRangeNoResize(Void* ptr, int count) { }

		[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
		public void AddRangeNoResize(UnsafeList<T> list) { }

		[IsReadOnly]
		public Void* get_Ptr() { }

	}

	[NativeDisableUnsafePtrRestriction]
	public T* Ptr; //Field offset: 0x0
	public int m_length; //Field offset: 0x0
	public int m_capacity; //Field offset: 0x0
	public AllocatorHandle Allocator; //Field offset: 0x0
	[Obsolete("Use Length property (UnityUpgradable) -> Length", True)]
	public int length; //Field offset: 0x0
	[Obsolete("Use Capacity property (UnityUpgradable) -> Capacity", True)]
	public int capacity; //Field offset: 0x0

	public override int Capacity
	{
		 get { } //Length: 12
		 set { } //Length: 68
	}

	public bool IsCreated
	{
		 get { } //Length: 16
	}

	public override bool IsEmpty
	{
		 get { } //Length: 64
	}

	public override T Item
	{
		 get { } //Length: 32
		 set { } //Length: 44
	}

	public override int Length
	{
		 get { } //Length: 12
		 set { } //Length: 124
	}

	public UnsafeList`1(T* ptr, int length) { }

	public UnsafeList`1(int initialCapacity, AllocatorHandle allocator, NativeArrayOptions options = 0) { }

	public void Add(in T value) { }

	public void AddNoResize(T value) { }

	public void AddRange(Void* ptr, int count) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public void AddRange(UnsafeList<T> list) { }

	public void AddRangeNoResize(Void* ptr, int count) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public void AddRangeNoResize(UnsafeList<T> list) { }

	public ParallelReader<T> AsParallelReader() { }

	public ParallelWriter<T> AsParallelWriter() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckBeginEnd(int begin, int end) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckIndexCount(int index, int count) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckNoResizeHasEnoughCapacity(int length) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckNoResizeHasEnoughCapacity(int length, int index) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	internal static void CheckNull(Void* listData) { }

	public override void Clear() { }

	public void CopyFrom(UnsafeList<T> array) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(AllocatorHandle)})]
	internal static UnsafeList<T>* Create(int initialCapacity, ref U allocator, NativeArrayOptions options = 0) { }

	public static UnsafeList<T>* Create(int initialCapacity, AllocatorHandle allocator, NativeArrayOptions options = 0) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(AllocatorHandle)})]
	internal static void Destroy(UnsafeList<T>* listData, ref U allocator) { }

	public static void Destroy(UnsafeList<T>* listData) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(AllocatorHandle)})]
	internal void Dispose(ref U allocator) { }

	public override void Dispose() { }

	[NotBurstCompatible]
	public override JobHandle Dispose(JobHandle inputDeps) { }

	public override T ElementAt(int index) { }

	public override int get_Capacity() { }

	public bool get_IsCreated() { }

	public override bool get_IsEmpty() { }

	public override T get_Item(int index) { }

	public override int get_Length() { }

	public Enumerator<T> GetEnumerator() { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(AllocatorHandle)})]
	internal void Initialize(int initialCapacity, ref U allocator, NativeArrayOptions options = 0) { }

	public void InsertRangeWithBeginEnd(int begin, int end) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(AllocatorHandle)})]
	internal static UnsafeList<T> New(int initialCapacity, ref U allocator, NativeArrayOptions options = 0) { }

	private void Realloc(int capacity) { }

	private void Realloc(ref U allocator, int newCapacity) { }

	public void RemoveAt(int index) { }

	public void RemoveAtSwapBack(int index) { }

	public void RemoveRange(int index, int count) { }

	public void RemoveRangeSwapBack(int index, int count) { }

	[Obsolete("RemoveRangeSwapBackWithBeginEnd(begin, end) is deprecated, use RemoveRangeSwapBack(index, count) instead. (RemovedAfter 2021-06-02)", False)]
	public void RemoveRangeSwapBackWithBeginEnd(int begin, int end) { }

	[Obsolete("RemoveRangeWithBeginEnd(begin, end) is deprecated, use RemoveRange(index, count) instead. (RemovedAfter 2021-06-02)", False)]
	public void RemoveRangeWithBeginEnd(int begin, int end) { }

	public void Resize(int length, NativeArrayOptions options = 0) { }

	public override void set_Capacity(int value) { }

	public override void set_Item(int index, T value) { }

	public override void set_Length(int value) { }

	private void SetCapacity(ref U allocator, int capacity) { }

	public void SetCapacity(int capacity) { }

	private override IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	public void TrimExcess() { }

}

