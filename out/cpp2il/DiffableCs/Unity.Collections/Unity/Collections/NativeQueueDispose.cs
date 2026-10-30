namespace Unity.Collections;

[BurstCompatible]
[NativeContainer]
internal struct NativeQueueDispose
{
	[NativeDisableUnsafePtrRestriction]
	internal NativeQueueData* m_Buffer; //Field offset: 0x0
	[NativeDisableUnsafePtrRestriction]
	internal NativeQueueBlockPoolData* m_QueuePool; //Field offset: 0x8
	internal AllocatorHandle m_AllocatorLabel; //Field offset: 0x10

	public void Dispose() { }

}

