namespace Unity.Collections;

[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(AllocatorHandle)})]
public struct AllocatorHelper : IDisposable
{
	private readonly T* m_allocator; //Field offset: 0x0
	private AllocatorHandle m_backingAllocator; //Field offset: 0x0

	public T Allocator
	{
		 get { } //Length: 120
	}

	[NotBurstCompatible]
	public AllocatorHelper`1(AllocatorHandle backingAllocator) { }

	[NotBurstCompatible]
	public override void Dispose() { }

	public T get_Allocator() { }

}

