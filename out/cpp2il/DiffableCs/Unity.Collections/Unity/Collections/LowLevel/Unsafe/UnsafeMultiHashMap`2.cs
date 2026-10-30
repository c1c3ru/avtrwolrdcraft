namespace Unity.Collections.LowLevel.Unsafe;

[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
[DebuggerTypeProxy(typeof(UnsafeMultiHashMapDebuggerTypeProxy`2))]
public struct UnsafeMultiHashMap : INativeDisposable, IDisposable, IEnumerable<KeyValue`2<TKey, TValue>>, IEnumerable
{
	internal struct Enumerator : IEnumerator<TValue>, IEnumerator, IDisposable
	{
		internal UnsafeMultiHashMap<TKey, TValue> hashmap; //Field offset: 0x0
		internal TKey key; //Field offset: 0x0
		internal bool isFirst; //Field offset: 0x0
		private TValue value; //Field offset: 0x0
		private NativeMultiHashMapIterator<TKey> iterator; //Field offset: 0x0

		public override TValue Current
		{
			 get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 104
		}

		public override void Dispose() { }

		public override TValue get_Current() { }

		public Enumerator<TKey, TValue> GetEnumerator() { }

		public override bool MoveNext() { }

		public override void Reset() { }

		private override object System.Collections.IEnumerator.get_Current() { }

	}

	internal struct KeyValueEnumerator : IEnumerator<KeyValue`2<TKey, TValue>>, IEnumerator, IDisposable
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
	[NativeContainerIsAtomicWriteOnly]
	internal struct ParallelWriter
	{
		[NativeDisableUnsafePtrRestriction]
		internal UnsafeHashMapData* m_Buffer; //Field offset: 0x0
		[NativeSetThreadIndex]
		internal int m_ThreadIndex; //Field offset: 0x0

		public int Capacity
		{
			 get { } //Length: 28
		}

		public void Add(TKey key, TValue item) { }

		public int get_Capacity() { }

	}

	[NativeDisableUnsafePtrRestriction]
	internal UnsafeHashMapData* m_Buffer; //Field offset: 0x0
	internal AllocatorHandle m_AllocatorLabel; //Field offset: 0x0

	public int Capacity
	{
		 get { } //Length: 28
		 set { } //Length: 112
	}

	public bool IsCreated
	{
		 get { } //Length: 16
	}

	public bool IsEmpty
	{
		 get { } //Length: 60
	}

	public UnsafeMultiHashMap`2(int capacity, AllocatorHandle allocator) { }

	public void Add(TKey key, TValue item) { }

	public ParallelWriter<TKey, TValue> AsParallelWriter() { }

	public void Clear() { }

	public bool ContainsKey(TKey key) { }

	public int Count() { }

	public int CountValuesForKey(TKey key) { }

	[NotBurstCompatible]
	public override JobHandle Dispose(JobHandle inputDeps) { }

	public override void Dispose() { }

	public int get_Capacity() { }

	public bool get_IsCreated() { }

	public bool get_IsEmpty() { }

	public KeyValueEnumerator<TKey, TValue> GetEnumerator() { }

	public NativeArray<TKey> GetKeyArray(AllocatorHandle allocator) { }

	public NativeKeyValueArrays<TKey, TValue> GetKeyValueArrays(AllocatorHandle allocator) { }

	public NativeArray<TValue> GetValueArray(AllocatorHandle allocator) { }

	public Enumerator<TKey, TValue> GetValuesForKey(TKey key) { }

	public void Remove(NativeMultiHashMapIterator<TKey> it) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public void Remove(TKey key, TValueEQ value) { }

	public int Remove(TKey key) { }

	public void set_Capacity(int value) { }

	public bool SetValue(TValue item, NativeMultiHashMapIterator<TKey> it) { }

	private override IEnumerator<KeyValue`2<TKey, TValue>> System.Collections.Generic.IEnumerable<Unity.Collections.LowLevel.Unsafe.KeyValue<TKey,TValue>>.GetEnumerator() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	public bool TryGetFirstValue(TKey key, out TValue item, out NativeMultiHashMapIterator<TKey>& it) { }

	public bool TryGetNextValue(out TValue item, ref NativeMultiHashMapIterator<TKey>& it) { }

}

