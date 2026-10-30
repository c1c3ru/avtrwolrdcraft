namespace Unity.Collections.LowLevel.Unsafe;

[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
[DebuggerDisplay("Length = {Length}, Capacity = {Capacity}, IsCreated = {IsCreated}, IsEmpty = {IsEmpty}")]
[DebuggerTypeProxy(typeof(UnsafePtrListTDebugView`1))]
[DefaultMember("Item")]
public struct UnsafePtrList : INativeDisposable, IDisposable, IEnumerable<IntPtr>, IEnumerable
{
	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	internal struct ParallelReader
	{
		[NativeDisableUnsafePtrRestriction]
		public readonly T** Ptr; //Field offset: 0x0
		public readonly int Length; //Field offset: 0x0

		internal ParallelReader(T** ptr, int length) { }

		public bool Contains(Void* ptr) { }

		public int IndexOf(Void* ptr) { }

	}

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	internal struct ParallelWriter
	{
		[NativeDisableUnsafePtrRestriction]
		public readonly T** Ptr; //Field offset: 0x0
		[NativeDisableUnsafePtrRestriction]
		public UnsafeList<IntPtr>* ListData; //Field offset: 0x0

		internal ParallelWriter(T** ptr, UnsafeList<IntPtr>* listData) { }

		public void AddNoResize(T* value) { }

		public void AddRangeNoResize(T** ptr, int count) { }

		public void AddRangeNoResize(UnsafePtrList<T> list) { }

	}

	[NativeDisableUnsafePtrRestriction]
	public readonly T** Ptr; //Field offset: 0x0
	public readonly int m_length; //Field offset: 0x0
	public readonly int m_capacity; //Field offset: 0x0
	public readonly AllocatorHandle Allocator; //Field offset: 0x0
	[Obsolete("Use Length property (UnityUpgradable) -> Length", True)]
	public int length; //Field offset: 0x0
	[Obsolete("Use Capacity property (UnityUpgradable) -> Capacity", True)]
	public int capacity; //Field offset: 0x0

	public int Capacity
	{
		 get { } //Length: 160
		 set { } //Length: 176
	}

	public bool IsCreated
	{
		 get { } //Length: 16
	}

	public bool IsEmpty
	{
		 get { } //Length: 224
	}

	public T* Item
	{
		 get { } //Length: 32
		 set { } //Length: 44
	}

	public int Length
	{
		 get { } //Length: 160
		 set { } //Length: 176
	}

	public UnsafePtrList`1(T** ptr, int length) { }

	public UnsafePtrList`1(int initialCapacity, AllocatorHandle allocator, NativeArrayOptions options = 0) { }

	public void Add(Void* value) { }

	public void Add(in IntPtr value) { }

	public void AddNoResize(Void* value) { }

	public void AddRange(UnsafePtrList<T> list) { }

	public void AddRange(Void* ptr, int length) { }

	public void AddRangeNoResize(Void** ptr, int count) { }

	public void AddRangeNoResize(UnsafePtrList<T> list) { }

	public ParallelReader<T> AsParallelReader() { }

	public ParallelWriter<T> AsParallelWriter() { }

	public void Clear() { }

	public bool Contains(Void* ptr) { }

	public static UnsafePtrList<T>* Create(T** ptr, int length) { }

	public static UnsafePtrList<T>* Create(int initialCapacity, AllocatorHandle allocator, NativeArrayOptions options = 0) { }

	public static void Destroy(UnsafePtrList<T>* listData) { }

	public override void Dispose() { }

	[NotBurstCompatible]
	public override JobHandle Dispose(JobHandle inputDeps) { }

	public T* ElementAt(int index) { }

	public int get_Capacity() { }

	public bool get_IsCreated() { }

	public bool get_IsEmpty() { }

	public T* get_Item(int index) { }

	public int get_Length() { }

	public int IndexOf(Void* ptr) { }

	public void InsertRangeWithBeginEnd(int begin, int end) { }

	public void RemoveAt(int index) { }

	public void RemoveAtSwapBack(int index) { }

	public void RemoveRange(int index, int count) { }

	public void RemoveRangeSwapBack(int index, int count) { }

	[Obsolete("RemoveRangeSwapBackWithBeginEnd(begin, end) is deprecated, use RemoveRangeSwapBack(index, count) instead. (RemovedAfter 2021-06-02)", False)]
	public void RemoveRangeSwapBackWithBeginEnd(int begin, int end) { }

	[Obsolete("RemoveRangeWithBeginEnd(begin, end) is deprecated, use RemoveRange(index, count) instead. (RemovedAfter 2021-06-02)", False)]
	public void RemoveRangeWithBeginEnd(int begin, int end) { }

	public void Resize(int length, NativeArrayOptions options = 0) { }

	public void set_Capacity(int value) { }

	public void set_Item(int index, T* value) { }

	public void set_Length(int value) { }

	public void SetCapacity(int capacity) { }

	private override IEnumerator<IntPtr> System.Collections.Generic.IEnumerable<System.IntPtr>.GetEnumerator() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	public void TrimExcess() { }

}

