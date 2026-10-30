namespace Unity.Collections.LowLevel.Unsafe;

[BurstCompatible]
public struct UnsafeStream : INativeDisposable, IDisposable
{
	[BurstCompile]
	private struct ConstructJob : IJob
	{
		public UnsafeStream Container; //Field offset: 0x0
		[ReadOnly]
		public NativeArray<Int32> Length; //Field offset: 0x10

		public override void Execute() { }

	}

	[BurstCompile]
	private struct ConstructJobList : IJob
	{
		public UnsafeStream Container; //Field offset: 0x0
		[NativeDisableUnsafePtrRestriction]
		[ReadOnly]
		public UntypedUnsafeList* List; //Field offset: 0x10

		public override void Execute() { }

	}

	[BurstCompile]
	private struct DisposeJob : IJob
	{
		public UnsafeStream Container; //Field offset: 0x0

		public override void Execute() { }

	}

	[BurstCompatible]
	internal struct Reader
	{
		[NativeDisableUnsafePtrRestriction]
		internal UnsafeStreamBlockData* m_BlockStream; //Field offset: 0x0
		[NativeDisableUnsafePtrRestriction]
		internal UnsafeStreamBlock* m_CurrentBlock; //Field offset: 0x8
		[NativeDisableUnsafePtrRestriction]
		internal Byte* m_CurrentPtr; //Field offset: 0x10
		[NativeDisableUnsafePtrRestriction]
		internal Byte* m_CurrentBlockEnd; //Field offset: 0x18
		internal int m_RemainingItemCount; //Field offset: 0x20
		internal int m_LastBlockSize; //Field offset: 0x24

		public int ForEachCount
		{
			 get { } //Length: 28
		}

		public int RemainingItemCount
		{
			 get { } //Length: 8
		}

		internal Reader(ref UnsafeStream stream) { }

		public int BeginForEachIndex(int foreachIndex) { }

		public int Count() { }

		public void EndForEachIndex() { }

		public int get_ForEachCount() { }

		public int get_RemainingItemCount() { }

		[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
		public T Peek() { }

		[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
		public T Read() { }

		public Byte* ReadUnsafePtr(int size) { }

	}

	[BurstCompatible]
	internal struct Writer
	{
		[NativeDisableUnsafePtrRestriction]
		internal UnsafeStreamBlockData* m_BlockStream; //Field offset: 0x0
		[NativeDisableUnsafePtrRestriction]
		private UnsafeStreamBlock* m_CurrentBlock; //Field offset: 0x8
		[NativeDisableUnsafePtrRestriction]
		private Byte* m_CurrentPtr; //Field offset: 0x10
		[NativeDisableUnsafePtrRestriction]
		private Byte* m_CurrentBlockEnd; //Field offset: 0x18
		internal int m_ForeachIndex; //Field offset: 0x20
		private int m_ElementCount; //Field offset: 0x24
		[NativeDisableUnsafePtrRestriction]
		private UnsafeStreamBlock* m_FirstBlock; //Field offset: 0x28
		private int m_FirstOffset; //Field offset: 0x30
		private int m_NumberOfBlocks; //Field offset: 0x34
		[NativeSetThreadIndex]
		private int m_ThreadIndex; //Field offset: 0x38

		public int ForEachCount
		{
			 get { } //Length: 28
		}

		internal Writer(ref UnsafeStream stream) { }

		[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
		public T Allocate() { }

		public Byte* Allocate(int size) { }

		public void BeginForEachIndex(int foreachIndex) { }

		public void EndForEachIndex() { }

		public int get_ForEachCount() { }

		[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
		public void Write(T value) { }

	}

	[NativeDisableUnsafePtrRestriction]
	internal UnsafeStreamBlockData* m_Block; //Field offset: 0x0
	internal AllocatorHandle m_Allocator; //Field offset: 0x8

	public int ForEachCount
	{
		 get { } //Length: 28
	}

	public bool IsCreated
	{
		 get { } //Length: 16
	}

	public UnsafeStream(int bufferCount, AllocatorHandle allocator) { }

	internal static void AllocateBlock(out UnsafeStream stream, AllocatorHandle allocator) { }

	internal void AllocateForEach(int forEachCount) { }

	public Reader AsReader() { }

	public Writer AsWriter() { }

	public int Count() { }

	private void Deallocate() { }

	public override void Dispose() { }

	[NotBurstCompatible]
	public override JobHandle Dispose(JobHandle inputDeps) { }

	public int get_ForEachCount() { }

	public bool get_IsCreated() { }

	public bool IsEmpty() { }

	[NotBurstCompatible]
	public static JobHandle ScheduleConstruct(out UnsafeStream stream, NativeList<T> bufferCount, JobHandle dependency, AllocatorHandle allocator) { }

	[NotBurstCompatible]
	public static JobHandle ScheduleConstruct(out UnsafeStream stream, NativeArray<Int32> bufferCount, JobHandle dependency, AllocatorHandle allocator) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public NativeArray<T> ToNativeArray(AllocatorHandle allocator) { }

}

