namespace Unity.Collections;

[BurstCompatible]
[NativeContainer]
public struct NativeStream : IDisposable
{
	[BurstCompile]
	private struct ConstructJob : IJob
	{
		public NativeStream Container; //Field offset: 0x0
		[ReadOnly]
		public NativeArray<Int32> Length; //Field offset: 0x10

		public override void Execute() { }

	}

	[BurstCompile]
	private struct ConstructJobList : IJob
	{
		public NativeStream Container; //Field offset: 0x0
		[NativeDisableUnsafePtrRestriction]
		[ReadOnly]
		public UntypedUnsafeList* List; //Field offset: 0x10

		public override void Execute() { }

	}

	[BurstCompatible]
	[NativeContainer]
	[NativeContainerIsReadOnly]
	internal struct Reader
	{
		private Reader m_Reader; //Field offset: 0x0

		public int ForEachCount
		{
			 get { } //Length: 28
		}

		public int RemainingItemCount
		{
			 get { } //Length: 8
		}

		internal Reader(ref NativeStream stream) { }

		public int BeginForEachIndex(int foreachIndex) { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckBeginForEachIndex(int forEachIndex) { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckEndForEachIndex() { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckNotReadingOutOfBounds(int size) { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckRead() { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckReadSize(int size) { }

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
	[NativeContainer]
	[NativeContainerSupportsMinMaxWriteRestriction]
	internal struct Writer
	{
		private Writer m_Writer; //Field offset: 0x0

		public int ForEachCount
		{
			 get { } //Length: 28
		}

		internal Writer(ref NativeStream stream) { }

		[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
		public T Allocate() { }

		public Byte* Allocate(int size) { }

		public void BeginForEachIndex(int foreachIndex) { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckAllocateSize(int size) { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckBeginForEachIndex(int foreachIndex) { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckEndForEachIndex() { }

		public void EndForEachIndex() { }

		public int get_ForEachCount() { }

		public void PatchMinMaxRange(int foreEachIndex) { }

		[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
		public void Write(T value) { }

	}

	private UnsafeStream m_Stream; //Field offset: 0x0

	public int ForEachCount
	{
		 get { } //Length: 28
	}

	public bool IsCreated
	{
		 get { } //Length: 16
	}

	public NativeStream(int bufferCount, AllocatorHandle allocator) { }

	private static void AllocateBlock(out NativeStream stream, AllocatorHandle allocator) { }

	private void AllocateForEach(int forEachCount) { }

	public Reader AsReader() { }

	public Writer AsWriter() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void CheckForEachCountGreaterThanZero(int forEachCount) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckReadAccess() { }

	public int Count() { }

	public override void Dispose() { }

	[NotBurstCompatible]
	public JobHandle Dispose(JobHandle inputDeps) { }

	public int get_ForEachCount() { }

	public bool get_IsCreated() { }

	public bool IsEmpty() { }

	[NotBurstCompatible]
	public static JobHandle ScheduleConstruct(out NativeStream stream, NativeList<T> bufferCount, JobHandle dependency, AllocatorHandle allocator) { }

	[NotBurstCompatible]
	public static JobHandle ScheduleConstruct(out NativeStream stream, NativeArray<Int32> bufferCount, JobHandle dependency, AllocatorHandle allocator) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public NativeArray<T> ToNativeArray(AllocatorHandle allocator) { }

}

