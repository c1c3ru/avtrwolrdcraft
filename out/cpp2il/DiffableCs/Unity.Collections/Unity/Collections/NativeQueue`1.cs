namespace Unity.Collections;

[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
[NativeContainer]
public struct NativeQueue : INativeDisposable, IDisposable
{
	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	[NativeContainer]
	[NativeContainerIsAtomicWriteOnly]
	internal struct ParallelWriter
	{
		[NativeDisableUnsafePtrRestriction]
		internal NativeQueueData* m_Buffer; //Field offset: 0x0
		[NativeDisableUnsafePtrRestriction]
		internal NativeQueueBlockPoolData* m_QueuePool; //Field offset: 0x0
		[NativeSetThreadIndex]
		internal int m_ThreadIndex; //Field offset: 0x0

		public void Enqueue(T value) { }

	}

	[NativeDisableUnsafePtrRestriction]
	private NativeQueueData* m_Buffer; //Field offset: 0x0
	[NativeDisableUnsafePtrRestriction]
	private NativeQueueBlockPoolData* m_QueuePool; //Field offset: 0x0
	private AllocatorHandle m_AllocatorLabel; //Field offset: 0x0

	public int Count
	{
		 get { } //Length: 80
	}

	public bool IsCreated
	{
		 get { } //Length: 16
	}

	internal static int MemoryBlockSize
	{
		internal get { } //Length: 8
	}

	internal static int PersistentMemoryBlockCount
	{
		internal get { } //Length: 96
		internal set { } //Length: 108
	}

	public NativeQueue`1(AllocatorHandle allocator) { }

	public ParallelWriter<T> AsParallelWriter() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckRead() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckReadNotEmpty() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckWrite() { }

	public void Clear() { }

	public T Dequeue() { }

	public override void Dispose() { }

	[NotBurstCompatible]
	public override JobHandle Dispose(JobHandle inputDeps) { }

	public void Enqueue(T value) { }

	public int get_Count() { }

	public bool get_IsCreated() { }

	internal static int get_MemoryBlockSize() { }

	internal static int get_PersistentMemoryBlockCount() { }

	public bool IsEmpty() { }

	public T Peek() { }

	internal static void set_PersistentMemoryBlockCount(int value) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void ThrowEmpty() { }

	public NativeArray<T> ToArray(AllocatorHandle allocator) { }

	public bool TryDequeue(out T item) { }

}

