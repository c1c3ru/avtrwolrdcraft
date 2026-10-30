namespace Unity.Collections;

[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
[DebuggerTypeProxy(typeof(NativeHashSetDebuggerTypeProxy`1))]
public struct NativeHashSet : INativeDisposable, IDisposable, IEnumerable<T>, IEnumerable
{
	[NativeContainer]
	[NativeContainerIsReadOnly]
	internal struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
	{
		internal UnsafeHashMapDataEnumerator m_Enumerator; //Field offset: 0x0

		public override T Current
		{
			 get { } //Length: 280
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 292
		}

		public override void Dispose() { }

		public override T get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

		private override object System.Collections.IEnumerator.get_Current() { }

	}

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	[NativeContainerIsAtomicWriteOnly]
	internal struct ParallelWriter
	{
		internal ParallelWriter<T, Boolean> m_Data; //Field offset: 0x0

		public int Capacity
		{
			 get { } //Length: 120
		}

		public bool Add(T item) { }

		public int get_Capacity() { }

	}

	internal NativeHashMap<T, Boolean> m_Data; //Field offset: 0x0

	public int Capacity
	{
		 get { } //Length: 120
		 set { } //Length: 136
	}

	public bool IsCreated
	{
		 get { } //Length: 120
	}

	public bool IsEmpty
	{
		 get { } //Length: 120
	}

	public NativeHashSet`1(int capacity, AllocatorHandle allocator) { }

	public bool Add(T item) { }

	public ParallelWriter<T> AsParallelWriter() { }

	public void Clear() { }

	public bool Contains(T item) { }

	public int Count() { }

	public override void Dispose() { }

	[NotBurstCompatible]
	public override JobHandle Dispose(JobHandle inputDeps) { }

	public int get_Capacity() { }

	public bool get_IsCreated() { }

	public bool get_IsEmpty() { }

	public Enumerator<T> GetEnumerator() { }

	public bool Remove(T item) { }

	public void set_Capacity(int value) { }

	private override IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	public NativeArray<T> ToNativeArray(AllocatorHandle allocator) { }

}

