namespace Unity.Networking.Transport;

[BurstCompile]
internal struct UnityTransportProtocol : INetworkProtocol, IDisposable
{

	public override int Bind(INetworkInterface networkInterface, ref NetworkInterfaceEndPoint localEndPoint) { }

	[BurstCompile(DisableDirectCall = True)]
	[MonoPInvokeCallback(typeof(ComputePacketOverheadDelegate))]
	public static int ComputePacketOverhead(ref Connection connection, out int dataOffset) { }

	[BurstCompile(DisableDirectCall = True)]
	[MonoPInvokeCallback(typeof(ConnectDelegate))]
	public static void Connect(ref Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData) { }

	public override int CreateConnectionAddress(INetworkInterface networkInterface, NetworkEndPoint remoteEndpoint, out NetworkInterfaceEndPoint remoteAddress) { }

	public override NetworkProtocol CreateProtocolInterface() { }

	[BurstCompile(DisableDirectCall = True)]
	[MonoPInvokeCallback(typeof(DisconnectDelegate))]
	public static void Disconnect(ref Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData) { }

	public override void Dispose() { }

	internal static int GetConnectionAcceptMessageMaxLength() { }

	public override NetworkEndPoint GetRemoteEndPoint(INetworkInterface networkInterface, NetworkInterfaceEndPoint address) { }

	public override void Initialize(NetworkSettings settings) { }

	[BurstCompile(DisableDirectCall = True)]
	[MonoPInvokeCallback(typeof(ProcessReceiveDelegate))]
	public static void ProcessReceive(IntPtr stream, ref NetworkInterfaceEndPoint endpoint, int size, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData, ref ProcessPacketCommand command) { }

	[BurstCompile(DisableDirectCall = True)]
	[MonoPInvokeCallback(typeof(ProcessSendDelegate))]
	public static int ProcessSend(ref Connection connection, bool hasPipeline, ref NetworkSendInterface sendInterface, ref NetworkInterfaceSendHandle sendHandle, ref NetworkSendQueueHandle queueHandle, IntPtr userData) { }

	[BurstCompile(DisableDirectCall = True)]
	[MonoPInvokeCallback(typeof(ProcessSendConnectionAcceptDelegate))]
	public static void ProcessSendConnectionAccept(ref Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData) { }

	[BurstCompile(DisableDirectCall = True)]
	[MonoPInvokeCallback(typeof(ProcessSendPingDelegate))]
	public static void ProcessSendPing(ref Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData) { }

	[BurstCompile(DisableDirectCall = True)]
	[MonoPInvokeCallback(typeof(ProcessSendPongDelegate))]
	public static void ProcessSendPong(ref Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData) { }

	private static int SendHeaderOnlyMessage(UdpCProtocol type, SessionIdToken token, ref Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle) { }

	[BurstCompile(DisableDirectCall = True)]
	[MonoPInvokeCallback(typeof(UpdateDelegate))]
	public static void Update(long updateTime, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData) { }

	internal static int WriteConnectionAcceptMessage(ref Connection connection, Byte* packet, int capacity) { }

	internal static int WriteSendMessageHeader(ref Connection connection, bool hasPipeline, ref NetworkInterfaceSendHandle sendHandle, int offset) { }

}

