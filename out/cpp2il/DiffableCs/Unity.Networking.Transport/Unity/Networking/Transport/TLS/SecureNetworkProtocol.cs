namespace Unity.Networking.Transport.TLS;

[BurstCompile]
internal struct SecureNetworkProtocol : INetworkProtocol, IDisposable
{
	public static readonly SecureNetworkProtocolParameter DefaultParameters; //Field offset: 0x0
	public IntPtr UserData; //Field offset: 0x0

	private static SecureNetworkProtocol() { }

	public override int Bind(INetworkInterface networkInterface, ref NetworkInterfaceEndPoint localEndPoint) { }

	private static bool ClientShouldStep(uint currentState) { }

	[BurstCompile(DisableDirectCall = True)]
	[MonoPInvokeCallback(typeof(ComputePacketOverheadDelegate))]
	public static int ComputePacketOverhead(ref Connection connection, out int dataOffset) { }

	[BurstCompile(DisableDirectCall = True)]
	[MonoPInvokeCallback(typeof(ConnectDelegate))]
	public static void Connect(ref Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData) { }

	public override int CreateConnectionAddress(INetworkInterface networkInterface, NetworkEndPoint remoteEndpoint, out NetworkInterfaceEndPoint remoteAddress) { }

	private static bool CreateNewSecureClientState(ref NetworkInterfaceEndPoint endpoint, uint tlsRole, SecureNetworkProtocolData* protocolData, SessionIdToken receiveToken = null) { }

	public override NetworkProtocol CreateProtocolInterface() { }

	private static void CreateSecureClient(uint role, SecureClientState* state) { }

	[BurstCompile(DisableDirectCall = True)]
	[MonoPInvokeCallback(typeof(DisconnectDelegate))]
	public static void Disconnect(ref Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData) { }

	public override void Dispose() { }

	public static void DisposeSecureClient(ref SecureClientState state) { }

	public override NetworkEndPoint GetRemoteEndPoint(INetworkInterface networkInterface, NetworkInterfaceEndPoint address) { }

	private static unitytls_client_config* GetSecureClientConfig(SecureNetworkProtocolData* protocolData) { }

	public override void Initialize(NetworkSettings settings) { }

	public int Listen(INetworkInterface networkInterface) { }

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

	private static void PruneHalfOpenConnections(SecureNetworkProtocolData* protocolData) { }

	internal static uint SecureHandshakeStep(ref SecureClientState clientAgent) { }

	private static void SendConnectionRequest(SessionIdToken token, SecureClientState secureClient, ref NetworkInterfaceEndPoint address, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle) { }

	private static uint SendHeaderOnlyMessage(UdpCProtocol type, SessionIdToken token, SecureClientState secureClient, ref Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle) { }

	public static bool ServerShouldStep(uint currentState) { }

	internal static void SetSecureUserData(IntPtr inStream, int size, ref NetworkInterfaceEndPoint remote, ref NetworkSendInterface networkSendInterface, ref NetworkSendQueueHandle queueHandle, SecureUserData* secureUserData) { }

	private bool TryExtractParameters(out T config, INetworkParameter[] param) { }

	[BurstCompile(DisableDirectCall = True)]
	[MonoPInvokeCallback(typeof(UpdateDelegate))]
	public static void Update(long updateTime, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData) { }

	private static uint UpdateSecureHandshakeState(SecureNetworkProtocolData* protocolData, ref NetworkInterfaceEndPoint endpoint) { }

	[BurstCompile(DisableDirectCall = True)]
	internal static int WriteConnectionAcceptMessage(ref Connection connection, Byte* packet, int capacity) { }

}

