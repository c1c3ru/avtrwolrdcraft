namespace Unity.Networking.Transport;

public struct NetworkPacketReceiver
{
	[Flags]
	internal enum AppendPacketMode
	{
		None = 0,
		NoCopyNeeded = 1,
	}

	internal NetworkDriver m_Driver; //Field offset: 0x0

	public long LastUpdateTime
	{
		 get { } //Length: 84
	}

	public int ReceiveErrorCode
	{
		 set { } //Length: 100
	}

	public IntPtr AllocateMemory(ref int dataLen) { }

	public bool AppendPacket(IntPtr data, ref NetworkInterfaceEndPoint address, int dataLen, AppendPacketMode mode = 0) { }

	public long get_LastUpdateTime() { }

	public bool IsAddressUsed(NetworkInterfaceEndPoint address) { }

	private void OutOfMemoryError() { }

	public void set_ReceiveErrorCode(int value) { }

}

