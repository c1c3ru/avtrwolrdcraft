namespace Unity.Collections.LowLevel.Unsafe;

[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
[DebuggerDisplay("Length = {Length}, Capacity = {Capacity}, IsCreated = {IsCreated}, IsEmpty = {IsEmpty}")]
[DebuggerTypeProxy(typeof(UnsafeRingQueueDebugView`1))]
public struct UnsafeRingQueue : INativeDisposable, IDisposable
{
	[NativeDisableUnsafePtrRestriction]
	public T* Ptr; //Field offset: 0x0
	public AllocatorHandle Allocator; //Field offset: 0x0
	internal RingControl Control; //Field offset: 0x0

	public int Capacity
	{
		 get { } //Length: 8
	}

	public bool IsCreated
	{
		 get { } //Length: 16
	}

	public bool IsEmpty
	{
		 get { } //Length: 224
	}

	public int Length
	{
		 get { } //Length: 12
	}

	public UnsafeRingQueue`1(T* ptr, int capacity) { }

	public UnsafeRingQueue`1(int capacity, AllocatorHandle allocator, NativeArrayOptions options = 1) { }

	public T Dequeue() { }

	public override void Dispose() { }

	[NotBurstCompatible]
	public override JobHandle Dispose(JobHandle inputDeps) { }

	public void Enqueue(T value) { }

	public int get_Capacity() { }

	public bool get_IsCreated() { }

	public bool get_IsEmpty() { }

	public int get_Length() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void ThrowQueueEmpty() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void ThrowQueueFull() { }

	public bool TryDequeue(out T item) { }

	public bool TryEnqueue(T value) { }

}

