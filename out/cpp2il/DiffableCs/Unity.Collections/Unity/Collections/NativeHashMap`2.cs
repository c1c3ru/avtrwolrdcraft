namespace Unity.Collections;

[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
[DebuggerDisplay("Count = {m_HashMapData.Count()}, Capacity = {m_HashMapData.Capacity}, IsCreated = {m_HashMapData.IsCreated}, IsEmpty = {IsEmpty}")]
[DebuggerTypeProxy(typeof(NativeHashMapDebuggerTypeProxy`2))]
[DefaultMember("Item")]
[NativeContainer]
public struct NativeHashMap : INativeDisposable, IDisposable, IEnumerable<KeyValue`2<TKey, TValue>>, IEnumerable
{
	[NativeContainer]
	[NativeContainerIsReadOnly]
	internal struct Enumerator : IEnumerator<KeyValue`2<TKey, TValue>>, IEnumerator, IDisposable
	{
		internal UnsafeHashMapDataEnumerator m_Enumerator; //Field offset: 0x0

		public override KeyValue<TKey, TValue> Current
		{
			 get { } //Length: 52
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 112
		}

		public override void Dispose() { }

		public override KeyValue<TKey, TValue> get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

		private override object System.Collections.IEnumerator.get_Current() { }

	}

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	[DebuggerDisplay("Capacity = {m_Writer.Capacity}")]
	[NativeContainer]
	[NativeContainerIsAtomicWriteOnly]
	internal struct ParallelWriter
	{
		internal ParallelWriter<TKey, TValue> m_Writer; //Field offset: 0x0

		public int Capacity
		{
			 get { } //Length: 52
		}

		public int m_ThreadIndex
		{
			 get { } //Length: 8
		}

		public int get_Capacity() { }

		public int get_m_ThreadIndex() { }

		public bool TryAdd(TKey key, TValue item) { }

	}

	internal UnsafeHashMap<TKey, TValue> m_HashMapData; //Field offset: 0x0

	public int Capacity
	{
		 get { } //Length: 52
		 set { } //Length: 68
	}

	public bool IsCreated
	{
		 get { } //Length: 52
	}

	public bool IsEmpty
	{
		 get { } //Length: 116
	}

	public TValue Item
	{
		 get { } //Length: 160
		 set { } //Length: 148
	}

	public NativeHashMap`2(int capacity, AllocatorHandle allocator) { }

	private NativeHashMap`2(int capacity, AllocatorHandle allocator, int disposeSentinelStackDepth) { }

	public void Add(TKey key, TValue item) { }

	public ParallelWriter<TKey, TValue> AsParallelWriter() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckRead() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckWrite() { }

	public void Clear() { }

	public bool ContainsKey(TKey key) { }

	public int Count() { }

	[NotBurstCompatible]
	public override JobHandle Dispose(JobHandle inputDeps) { }

	public override void Dispose() { }

	public int get_Capacity() { }

	public bool get_IsCreated() { }

	public bool get_IsEmpty() { }

	public TValue get_Item(TKey key) { }

	public Enumerator<TKey, TValue> GetEnumerator() { }

	public NativeArray<TKey> GetKeyArray(AllocatorHandle allocator) { }

	public NativeKeyValueArrays<TKey, TValue> GetKeyValueArrays(AllocatorHandle allocator) { }

	public NativeArray<TValue> GetValueArray(AllocatorHandle allocator) { }

	public bool Remove(TKey key) { }

	public void set_Capacity(int value) { }

	public void set_Item(TKey key, TValue value) { }

	private override IEnumerator<KeyValue`2<TKey, TValue>> System.Collections.Generic.IEnumerable<Unity.Collections.LowLevel.Unsafe.KeyValue<TKey,TValue>>.GetEnumerator() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void ThrowKeyAlreadyAdded(TKey key) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void ThrowKeyNotPresent(TKey key) { }

	public bool TryAdd(TKey key, TValue item) { }

	public bool TryGetValue(TKey key, out TValue item) { }

}

