namespace Unity.Networking.Transport.Utilities.LowLevel.Unsafe;

internal struct UnsafeAtomicFreeList : IDisposable
{
	[NativeDisableUnsafePtrRestriction]
	private Int32* m_Buffer; //Field offset: 0x0
	private int m_Length; //Field offset: 0x8
	private Allocator m_Allocator; //Field offset: 0xC

	public int Capacity
	{
		 get { } //Length: 8
	}

	public int InUse
	{
		 get { } //Length: 16
	}

	public bool IsCreated
	{
		 get { } //Length: 16
	}

	public UnsafeAtomicFreeList(int capacity, Allocator allocator) { }

	public override void Dispose() { }

	public int get_Capacity() { }

	public int get_InUse() { }

	public bool get_IsCreated() { }

	public int Pop() { }

	public void Push(int item) { }

}

