namespace Unity.Collections;

[BurstCompatible]
[NativeContainer]
internal struct NativeListDispose
{
	[NativeDisableUnsafePtrRestriction]
	public UntypedUnsafeList* m_ListData; //Field offset: 0x0

	public void Dispose() { }

}

