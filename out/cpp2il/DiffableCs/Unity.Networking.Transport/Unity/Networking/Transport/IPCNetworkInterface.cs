namespace Unity.Networking.Transport;

[BurstCompile]
public struct IPCNetworkInterface : INetworkInterface, IDisposable
{
	[BurstCompile]
	private struct ReceiveJob : IJob
	{
		public NetworkPacketReceiver receiver; //Field offset: 0x0
		public IPCManager ipcManager; //Field offset: 0x2B0
		public NetworkInterfaceEndPoint localEndPoint; //Field offset: 0x2F8

		public override void Execute() { }

		private int NativeReceive(Void* data, int length, ref NetworkInterfaceEndPoint address) { }

	}

	[BurstCompile]
	private struct SendUpdate : IJob
	{
		public IPCManager ipcManager; //Field offset: 0x0
		public NativeQueue<QueuedSendMessage> ipcQueue; //Field offset: 0x48
		[ReadOnly]
		public NativeArray<NetworkInterfaceEndPoint> localEndPoint; //Field offset: 0x60

		public override void Execute() { }

	}

	private static TransportFunctionPointer<BeginSendMessageDelegate> BeginSendMessageFunctionPointer; //Field offset: 0x0
	private static TransportFunctionPointer<EndSendMessageDelegate> EndSendMessageFunctionPointer; //Field offset: 0x8
	private static TransportFunctionPointer<AbortSendMessageDelegate> AbortSendMessageFunctionPointer; //Field offset: 0x10
	[ReadOnly]
	private NativeArray<NetworkInterfaceEndPoint> m_LocalEndPoint; //Field offset: 0x0

	public override NetworkInterfaceEndPoint LocalEndPoint
	{
		 get { } //Length: 32
	}

	private static IPCNetworkInterface() { }

	[BurstCompile(DisableDirectCall = True)]
	[MonoPInvokeCallback(typeof(AbortSendMessageDelegate))]
	private static void AbortSendMessage(ref NetworkInterfaceSendHandle handle, IntPtr userData) { }

	[BurstCompile(DisableDirectCall = True)]
	[MonoPInvokeCallback(typeof(BeginSendMessageDelegate))]
	private static int BeginSendMessage(out NetworkInterfaceSendHandle handle, IntPtr userData, int requiredPayloadSize) { }

	public override int Bind(NetworkInterfaceEndPoint endpoint) { }

	public override int CreateInterfaceEndPoint(NetworkEndPoint address, out NetworkInterfaceEndPoint endpoint) { }

	public override NetworkSendInterface CreateSendInterface() { }

	public override void Dispose() { }

	[BurstCompile(DisableDirectCall = True)]
	[MonoPInvokeCallback(typeof(EndSendMessageDelegate))]
	private static int EndSendMessage(ref NetworkInterfaceSendHandle handle, ref NetworkInterfaceEndPoint address, IntPtr userData, ref NetworkSendQueueHandle sendQueueHandle) { }

	public override NetworkInterfaceEndPoint get_LocalEndPoint() { }

	public override NetworkEndPoint GetGenericEndPoint(NetworkInterfaceEndPoint endpoint) { }

	public override int Initialize(NetworkSettings settings) { }

	public override int Listen() { }

	public override JobHandle ScheduleReceive(NetworkPacketReceiver receiver, JobHandle dep) { }

	public override JobHandle ScheduleSend(NativeQueue<QueuedSendMessage> sendQueue, JobHandle dep) { }

}

