namespace Unity.Collections.LowLevel.Unsafe;

[BurstCompatible]
[NativeContainer]
internal struct UnsafeHashMapDataDispose
{
	[NativeDisableUnsafePtrRestriction]
	internal UnsafeHashMapData* m_Buffer; //Field offset: 0x0
	internal AllocatorHandle m_AllocatorLabel; //Field offset: 0x8

	public void Dispose() { }

}

