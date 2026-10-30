namespace Unity.Networking.Transport;

public struct InboundSendBuffer
{
	public Byte* buffer; //Field offset: 0x0
	public Byte* bufferWithHeaders; //Field offset: 0x8
	public int bufferLength; //Field offset: 0x10
	public int bufferWithHeadersLength; //Field offset: 0x14
	public int headerPadding; //Field offset: 0x18

	public void SetBufferFrombufferWithHeaders() { }

}

