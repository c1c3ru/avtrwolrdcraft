namespace Unity.Collections.LowLevel.Unsafe;

public struct UntypedUnsafeHashMap
{
	[NativeDisableUnsafePtrRestriction]
	private UnsafeHashMapData* m_Buffer; //Field offset: 0x0
	private AllocatorHandle m_AllocatorLabel; //Field offset: 0x8

}

