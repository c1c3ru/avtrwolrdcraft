namespace Unity.Networking.Transport.TLS;

internal struct SecureUserData
{
	public IntPtr StreamData; //Field offset: 0x0
	public NetworkSendInterface Interface; //Field offset: 0x8
	public NetworkInterfaceEndPoint Remote; //Field offset: 0x28
	public NetworkSendQueueHandle QueueHandle; //Field offset: 0x68
	public int Size; //Field offset: 0x70
	public int BytesProcessed; //Field offset: 0x74

}

