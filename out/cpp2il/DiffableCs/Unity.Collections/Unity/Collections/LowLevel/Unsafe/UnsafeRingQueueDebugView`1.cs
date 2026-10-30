namespace Unity.Collections.LowLevel.Unsafe;

internal sealed class UnsafeRingQueueDebugView
{
	private UnsafeRingQueue<T> Data; //Field offset: 0x0

	public T[] Items
	{
		 get { } //Length: 424
	}

	public UnsafeRingQueueDebugView`1(UnsafeRingQueue<T> data) { }

	public T[] get_Items() { }

}

