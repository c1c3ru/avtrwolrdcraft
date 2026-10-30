namespace Unity.Networking.Transport.Relay;

[BurstCompile]
internal struct RelayNetworkProtocol : INetworkProtocol, IDisposable
{
	private enum RelayConnectionState
	{
		Unbound = 0,
		Handshake = 1,
		Binding = 2,
		Bound = 3,
		Connected = 4,
	}

	private struct RelayProtocolData
	{
		public RelayConnectionState ConnectionState; //Field offset: 0x0
		public SecuredRelayConnectionState SecureState; //Field offset: 0x1
		public SessionIdToken ConnectionReceiveToken; //Field offset: 0x2
		public long LastConnectAttempt; //Field offset: 0x10
		public long LastUpdateTime; //Field offset: 0x18
		public long LastReceiveTime; //Field offset: 0x20
		public long LastSentTime; //Field offset: 0x28
		public int ConnectTimeoutMS; //Field offset: 0x30
		public int RelayConnectionTimeMS; //Field offset: 0x34
		public RelayAllocationId HostAllocationId; //Field offset: 0x38
		public NetworkInterfaceEndPoint ServerEndpoint; //Field offset: 0x48
		public RelayServerData ServerData; //Field offset: 0x84
		public SecureClientState SecureClientState; //Field offset: 0x310
		public bool ConnectOnBind; //Field offset: 0x330

	}

	private enum SecuredRelayConnectionState
	{
		Unsecure = 0,
		Secured = 1,
	}

	public IntPtr UserData; //Field offset: 0x0

	public override int Bind(INetworkInterface networkInterface, ref NetworkInterfaceEndPoint localEndPoint) { }

	[BurstCompile(DisableDirectCall = True)]
	[MonoPInvokeCallback(typeof(ComputePacketOverheadDelegate))]
	public static int ComputePacketOverhead(ref Connection connection, out int dataOffset) { }

	[BurstCompile(DisableDirectCall = True)]
	[MonoPInvokeCallback(typeof(ConnectDelegate))]
	public static void Connect(ref Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData) { }

	public override int CreateConnectionAddress(INetworkInterface networkInterface, NetworkEndPoint endPoint, out NetworkInterfaceEndPoint address) { }

	public override NetworkProtocol CreateProtocolInterface() { }

	[BurstCompile(DisableDirectCall = True)]
	[MonoPInvokeCallback(typeof(DisconnectDelegate))]
	public static void Disconnect(ref Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData) { }

	public override void Dispose() { }

	public override NetworkEndPoint GetRemoteEndPoint(INetworkInterface networkInterface, NetworkInterfaceEndPoint address) { }

	public override void Initialize(NetworkSettings settings) { }

	[BurstCompile(DisableDirectCall = True)]
	[MonoPInvokeCallback(typeof(ProcessReceiveDelegate))]
	public static void ProcessReceive(IntPtr stream, ref NetworkInterfaceEndPoint endpoint, int size, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData, ref ProcessPacketCommand command) { }

	private static bool ProcessRelayData(IntPtr stream, ref NetworkInterfaceEndPoint endpoint, int size, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, ref ProcessPacketCommand command, RelayProtocolData* protocolData) { }

	private static void ProcessRelayError(Byte* data, int size, ref ProcessPacketCommand command) { }

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
	[MonoPInvokeCallback(typeof(ProcessSendPingDelegate))]
	public static void ProcessSendPong(ref Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData) { }

	private static void SendConnectionRequestToRelay(RelayProtocolData* relayProtocolData, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle) { }

	private static int SendHeaderOnlyHostMessage(UdpCProtocol type, SessionIdToken token, RelayProtocolData* relayProtocolData, ref RelayAllocationId hostAllocationId, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle) { }

	private static int SendMessage(RelayProtocolData* protocolData, ref NetworkSendInterface sendInterface, ref NetworkInterfaceSendHandle sendHandle, ref NetworkSendQueueHandle queueHandle) { }

	private static void SendRelayDisconnect(RelayProtocolData* protocolData, ref RelayAllocationId hostAllocationId, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle) { }

	public static ushort SwitchEndianness(ushort value) { }

	private bool TryExtractParameters(out T config, INetworkParameter[] param) { }

	[BurstCompile(DisableDirectCall = True)]
	[MonoPInvokeCallback(typeof(UpdateDelegate))]
	public static void Update(long updateTime, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData) { }

	[BurstCompatible]
	private static bool WriteBindMessage(ref NetworkInterfaceEndPoint serverEndpoint, ref NetworkInterfaceSendHandle sendHandle, ref NetworkSendQueueHandle queueHandle, IntPtr userData) { }

	[BurstCompatible]
	private static bool WriteRelayPingMessage(ref NetworkInterfaceEndPoint serverEndpoint, ref NetworkInterfaceSendHandle sendHandle, ref NetworkSendQueueHandle queueHandle, IntPtr userData) { }

	private static DataStreamWriter WriterForSendBuffer(int requestSize, ref NetworkInterfaceSendHandle sendHandle) { }

}

