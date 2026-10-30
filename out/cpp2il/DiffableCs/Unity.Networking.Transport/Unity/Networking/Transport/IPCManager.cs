namespace Unity.Networking.Transport;

internal struct IPCManager
{
	public struct IPCData
	{
		[CompilerGenerated]
		[UnsafeValueType]
		internal struct <data>e__FixedBuffer
		{
			public byte FixedElementField; //Field offset: 0x0

		}

		public int from; //Field offset: 0x0
		public int length; //Field offset: 0x4
		[FixedBuffer(typeof(byte), 1472)]
		public <data>e__FixedBuffer data; //Field offset: 0x8

	}

	public static IPCManager Instance; //Field offset: 0x0
	internal static JobHandle ManagerAccessHandle; //Field offset: 0x48
	private NativeMultiQueue<IPCData> m_IPCQueue; //Field offset: 0x0
	private NativeHashMap<UInt16, Int32> m_IPCChannels; //Field offset: 0x30
	private int m_RefCount; //Field offset: 0x40

	public bool IsCreated
	{
		 get { } //Length: 72
	}

	private static IPCManager() { }

	public void AddRef() { }

	public NetworkInterfaceEndPoint CreateEndPoint(ushort port) { }

	public bool get_IsCreated() { }

	private void GetEndPointByHandle(int handle, out NetworkInterfaceEndPoint endpoint) { }

	public bool GetEndPointPort(NetworkInterfaceEndPoint ep, out ushort port) { }

	public int PeekNext(NetworkInterfaceEndPoint local, Void* slice, out int length, out NetworkInterfaceEndPoint from) { }

	public int ReceiveMessageEx(NetworkInterfaceEndPoint local, Void* payloadData, int payloadLen, ref NetworkInterfaceEndPoint remote) { }

	public void Release() { }

	internal void Update(NetworkInterfaceEndPoint local, NativeQueue<QueuedSendMessage> queue) { }

}

