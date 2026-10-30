namespace Unity.Networking.Transport.Utilities;

internal struct NativeMultiQueue : IDisposable
{
	private NativeList<T> m_Queue; //Field offset: 0x0
	private NativeList<Int32> m_QueueHeadTail; //Field offset: 0x0
	private NativeArray<Int32> m_MaxItems; //Field offset: 0x0

	public bool IsCreated
	{
		 get { } //Length: 120
	}

	public NativeMultiQueue`1(int initialMessageCapacity) { }

	public void Clear(int bucket) { }

	public bool Dequeue(int bucket, out T value) { }

	public override void Dispose() { }

	public void Enqueue(int bucket, T value) { }

	public bool get_IsCreated() { }

	public bool Peek(int bucket, out T value) { }

}

