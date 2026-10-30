namespace Unity.Networking.Transport;

public struct NetworkInterfaceSendHandle
{
	public IntPtr data; //Field offset: 0x0
	public int capacity; //Field offset: 0x8
	public int size; //Field offset: 0xC
	public int id; //Field offset: 0x10
	public SendHandleFlags flags; //Field offset: 0x14

}

