namespace Unity.Collections.LowLevel.Unsafe;

[BurstCompatible]
public struct UnsafeAppendBuffer : INativeDisposable, IDisposable
{
	[BurstCompatible]
	internal struct Reader
	{
		public readonly Byte* Ptr; //Field offset: 0x0
		public readonly int Size; //Field offset: 0x8
		public int Offset; //Field offset: 0xC

		public bool EndOfBuffer
		{
			 get { } //Length: 16
		}

		public Reader(ref UnsafeAppendBuffer buffer) { }

		public Reader(Void* ptr, int length) { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckBounds(int structSize) { }

		public bool get_EndOfBuffer() { }

		[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
		public void ReadNext(out T value) { }

		[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
		public T ReadNext() { }

		public Void* ReadNext(int structSize) { }

		[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
		public void ReadNext(out NativeArray<T>& value, AllocatorHandle allocator) { }

		[NotBurstCompatible]
		[Obsolete("Please use `ReadNextNBC` from `Unity.Collections.LowLevel.Unsafe.NotBurstCompatible` namespace instead. (RemovedAfter 2021-06-22)", False)]
		public void ReadNext(out string value) { }

		[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
		public Void* ReadNextArray(out int length) { }

	}

	[NativeDisableUnsafePtrRestriction]
	public Byte* Ptr; //Field offset: 0x0
	public int Length; //Field offset: 0x8
	public int Capacity; //Field offset: 0xC
	public AllocatorHandle Allocator; //Field offset: 0x10
	public readonly int Alignment; //Field offset: 0x14

	public bool IsCreated
	{
		 get { } //Length: 16
	}

	public bool IsEmpty
	{
		 get { } //Length: 16
	}

	public UnsafeAppendBuffer(int initialCapacity, int alignment, AllocatorHandle allocator) { }

	public UnsafeAppendBuffer(Void* ptr, int length) { }

	[NotBurstCompatible]
	[Obsolete("Please use `AddNBC` from `Unity.Collections.LowLevel.Unsafe.NotBurstCompatible` namespace instead. (RemovedAfter 2021-06-22)", False)]
	public void Add(string value) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public void Add(NativeArray<T> value) { }

	public void Add(Void* ptr, int structSize) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public void Add(T value) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public void AddArray(Void* ptr, int length) { }

	public Reader AsReader() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void CheckAlignment(int alignment) { }

	public override void Dispose() { }

	[NotBurstCompatible]
	public override JobHandle Dispose(JobHandle inputDeps) { }

	public bool get_IsCreated() { }

	public bool get_IsEmpty() { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public T Pop() { }

	public void Pop(Void* ptr, int structSize) { }

	public void Reset() { }

	public void ResizeUninitialized(int length) { }

	public void SetCapacity(int capacity) { }

	[NotBurstCompatible]
	[Obsolete("Please use `ToBytesNBC` from `Unity.Collections.LowLevel.Unsafe.NotBurstCompatible` namespace instead. (RemovedAfter 2021-06-22)", False)]
	public Byte[] ToBytes() { }

}

