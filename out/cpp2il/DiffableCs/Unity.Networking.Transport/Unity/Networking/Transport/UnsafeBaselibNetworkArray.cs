namespace Unity.Networking.Transport;

internal struct UnsafeBaselibNetworkArray : IDisposable
{
	[NativeDisableUnsafePtrRestriction]
	private UnsafePtrList<Baselib_RegisteredNetwork_Buffer> m_BufferPool; //Field offset: 0x0

	public UnsafeBaselibNetworkArray(int capacity, int typeSize) { }

	public Baselib_RegisteredNetwork_BufferSlice AtIndexAsSlice(int index, uint elementSize) { }

	public override void Dispose() { }

}

