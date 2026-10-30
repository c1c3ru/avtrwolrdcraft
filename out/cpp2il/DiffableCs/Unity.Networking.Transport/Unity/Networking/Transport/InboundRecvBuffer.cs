namespace Unity.Networking.Transport;

public struct InboundRecvBuffer
{
	public Byte* buffer; //Field offset: 0x0
	public int bufferLength; //Field offset: 0x8

	public InboundRecvBuffer Slice(int offset) { }

}

