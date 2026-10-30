namespace Unity.Collections;

[NativeContainer]
internal struct NativeReferenceDispose
{
	[NativeDisableUnsafePtrRestriction]
	internal Void* m_Data; //Field offset: 0x0
	internal AllocatorHandle m_AllocatorLabel; //Field offset: 0x8

	public void Dispose() { }

}

