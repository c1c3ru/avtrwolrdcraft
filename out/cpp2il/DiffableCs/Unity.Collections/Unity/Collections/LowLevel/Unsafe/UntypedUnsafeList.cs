namespace Unity.Collections.LowLevel.Unsafe;

internal struct UntypedUnsafeList
{
	[NativeDisableUnsafePtrRestriction]
	public Void* Ptr; //Field offset: 0x0
	public int m_length; //Field offset: 0x8
	public int m_capacity; //Field offset: 0xC
	public AllocatorHandle Allocator; //Field offset: 0x10
	internal int obsolete_length; //Field offset: 0x14
	internal int obsolete_capacity; //Field offset: 0x18

}

