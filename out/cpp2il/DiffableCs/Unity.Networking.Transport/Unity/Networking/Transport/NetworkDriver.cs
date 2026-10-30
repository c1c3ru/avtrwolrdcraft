namespace Unity.Networking.Transport;

public struct NetworkDriver : IDisposable
{
	[BurstCompile]
	private struct ClearEventQueue : IJob
	{
		public NativeList<Byte> dataStream; //Field offset: 0x0
		public NativeArray<Int32> dataStreamHead; //Field offset: 0x10
		public NetworkEventQueue eventQueue; //Field offset: 0x20

		public override void Execute() { }

	}

	internal struct Concurrent
	{
		private struct PendingSend
		{
			public NetworkPipeline Pipeline; //Field offset: 0x0
			public NetworkConnection Connection; //Field offset: 0x4
			public NetworkInterfaceSendHandle SendHandle; //Field offset: 0x10
			public int headerSize; //Field offset: 0x28

		}

		internal NetworkSendInterface m_NetworkSendInterface; //Field offset: 0x0
		internal NetworkProtocol m_NetworkProtocolInterface; //Field offset: 0x20
		internal Concurrent m_EventQueue; //Field offset: 0x80
		internal NativeArray<Byte> m_DisconnectReasons; //Field offset: 0x98
		[ReadOnly]
		internal NativeList<Connection> m_ConnectionList; //Field offset: 0xA8
		[ReadOnly]
		internal NativeList<Byte> m_DataStream; //Field offset: 0xB8
		internal Concurrent m_PipelineProcessor; //Field offset: 0xC8
		internal HeaderFlags m_DefaultHeaderFlags; //Field offset: 0x170
		internal ParallelWriter<QueuedSendMessage> m_ConcurrentParallelSendQueue; //Field offset: 0x178
		internal int m_MaxMessageSize; //Field offset: 0x190

		public void AbortSend(DataStreamWriter writer) { }

		internal void AbortSend(NetworkInterfaceSendHandle sendHandle) { }

		public int BeginSend(NetworkConnection id, out DataStreamWriter writer, int requiredPayloadSize = 0) { }

		public int BeginSend(NetworkPipeline pipe, NetworkConnection id, out DataStreamWriter writer, int requiredPayloadSize = 0) { }

		internal int CompleteSend(NetworkConnection sendConnection, NetworkInterfaceSendHandle sendHandle, bool hasPipeline) { }

		public int EndSend(DataStreamWriter writer) { }

		public State GetConnectionState(NetworkConnection id) { }

		public int MaxHeaderSize(NetworkPipeline pipe) { }

		internal int MaxProtocolHeaderSize() { }

		public Type PopEventForConnection(NetworkConnection connectionId, out DataStreamReader reader) { }

		public Type PopEventForConnection(NetworkConnection connectionId, out DataStreamReader reader, out NetworkPipeline pipeline) { }

	}

	public struct Connection
	{
		public NetworkInterfaceEndPoint Address; //Field offset: 0x0
		public long LastNonDataSend; //Field offset: 0x40
		public long LastReceive; //Field offset: 0x48
		public int Id; //Field offset: 0x50
		public int Version; //Field offset: 0x54
		public int ConnectAttempts; //Field offset: 0x58
		public State State; //Field offset: 0x5C
		public SessionIdToken ReceiveToken; //Field offset: 0x60
		public SessionIdToken SendToken; //Field offset: 0x68
		public byte DidReceiveData; //Field offset: 0x70
		public byte IsAccepted; //Field offset: 0x71

		public static Connection Null
		{
			 get { } //Length: 28
		}

		public virtual bool Equals(object compare) { }

		public bool Equals(Connection connection) { }

		public static Connection get_Null() { }

		public virtual int GetHashCode() { }

		public static bool op_Equality(Connection lhs, Connection rhs) { }

		public static bool op_Inequality(Connection lhs, Connection rhs) { }

	}

	private enum ErrorCodeType
	{
		ReceiveError = 0,
		SendError = 1,
		NumErrorCodes = 2,
	}

	private struct Parameters
	{
		public NetworkDataStreamParameter dataStream; //Field offset: 0x0
		public NetworkConfigParameter config; //Field offset: 0x4

		public Parameters(NetworkSettings settings) { }

	}

	[BurstCompile]
	private struct UpdateJob : IJob
	{
		public NetworkDriver driver; //Field offset: 0x0

		public override void Execute() { }

	}

	private static List<INetworkInterface> s_NetworkInterfaces; //Field offset: 0x0
	private const int InternalStateListening = 0; //Field offset: 0x0
	private const int InternalStateBound = 1; //Field offset: 0x0
	private static List<INetworkProtocol> s_NetworkProtocols; //Field offset: 0x8
	private int m_NetworkInterfaceIndex; //Field offset: 0x0
	private NetworkSendInterface m_NetworkSendInterface; //Field offset: 0x8
	private int m_NetworkProtocolIndex; //Field offset: 0x28
	private NetworkProtocol m_NetworkProtocolInterface; //Field offset: 0x30
	private NativeQueue<QueuedSendMessage> m_ParallelSendQueue; //Field offset: 0x90
	private NetworkEventQueue m_EventQueue; //Field offset: 0xA8
	private NativeArray<Byte> m_DisconnectReasons; //Field offset: 0xE0
	private NativeQueue<Int32> m_FreeList; //Field offset: 0xF0
	private NativeQueue<Int32> m_NetworkAcceptQueue; //Field offset: 0x108
	private NativeList<Connection> m_ConnectionList; //Field offset: 0x120
	[NativeDisableContainerSafetyRestriction]
	private NativeArray<Int32> m_InternalState; //Field offset: 0x130
	private NativeReference<Int32> m_ProtocolStatus; //Field offset: 0x140
	private NativeQueue<Int32> m_PendingFree; //Field offset: 0x150
	private NativeArray<Int32> m_ErrorCodes; //Field offset: 0x168
	private Parameters m_NetworkParams; //Field offset: 0x178
	private NativeList<Byte> m_DataStream; //Field offset: 0x198
	private NativeArray<Int32> m_DataStreamHead; //Field offset: 0x1A8
	private NetworkPipelineProcessor m_PipelineProcessor; //Field offset: 0x1B8
	private HeaderFlags m_DefaultHeaderFlags; //Field offset: 0x290
	private long m_UpdateTime; //Field offset: 0x298
	private long m_UpdateTimeAdjustment; //Field offset: 0x2A0
	private Random m_Rand; //Field offset: 0x2A8

	public bool Bound
	{
		 get { } //Length: 20
	}

	public bool IsCreated
	{
		 get { } //Length: 68
	}

	public long LastUpdateTime
	{
		 get { } //Length: 8
	}

	public private bool Listening
	{
		 get { } //Length: 20
		private set { } //Length: 16
	}

	internal INetworkInterface NetworkInterface
	{
		internal get { } //Length: 128
	}

	internal INetworkProtocol NetworkProtocol
	{
		internal get { } //Length: 128
	}

	internal int ProtocolStatus
	{
		internal get { } //Length: 72
	}

	public internal int ReceiveErrorCode
	{
		 get { } //Length: 12
		internal set { } //Length: 308
	}

	private static NetworkDriver() { }

	public NetworkDriver(INetworkInterface netIf) { }

	public NetworkDriver(INetworkInterface netIf, NetworkSettings settings) { }

	internal NetworkDriver(INetworkInterface netIf, INetworkProtocol netProtocol, NetworkSettings settings) { }

	[Obsolete("Use NetworkDriver(INetworkInterface, NetworkSettings) instead", False)]
	public NetworkDriver(INetworkInterface netIf, INetworkParameter[] param) { }

	[Obsolete("Use NetworkDriver(INetworkInterface, NetworkSettings) instead", False)]
	internal NetworkDriver(INetworkInterface netIf, INetworkProtocol netProtocol, INetworkParameter[] param) { }

	public void AbortSend(DataStreamWriter writer) { }

	public NetworkConnection Accept() { }

	private void AddConnectEvent(int id) { }

	private void AddDisconnectEvent(int id, DisconnectReason reason = 0) { }

	internal IntPtr AllocateMemory(ref int dataLen) { }

	internal void AppendPacket(IntPtr dataStream, ref NetworkInterfaceEndPoint endpoint, int dataLen) { }

	public int BeginSend(NetworkConnection id, out DataStreamWriter writer, int requiredPayloadSize = 0) { }

	public int BeginSend(NetworkPipeline pipe, NetworkConnection id, out DataStreamWriter writer, int requiredPayloadSize = 0) { }

	public int Bind(NetworkEndPoint endpoint) { }

	private void CheckTimeouts() { }

	public NetworkConnection Connect(NetworkEndPoint endpoint) { }

	public static NetworkDriver Create(N networkInterface) { }

	public static NetworkDriver Create(N networkInterface, NetworkSettings settings) { }

	public static NetworkDriver Create() { }

	public static NetworkDriver Create(NetworkSettings settings) { }

	[Obsolete("Use Create(NetworkSettings) instead", False)]
	public static NetworkDriver Create(INetworkParameter[] param) { }

	public NetworkPipeline CreatePipeline(Type[] stages) { }

	public int Disconnect(NetworkConnection id) { }

	public override void Dispose() { }

	public int EndSend(DataStreamWriter writer) { }

	private SessionIdToken GenerateRandomSessionIdToken(ref SessionIdToken token) { }

	public bool get_Bound() { }

	public bool get_IsCreated() { }

	public long get_LastUpdateTime() { }

	public bool get_Listening() { }

	internal INetworkInterface get_NetworkInterface() { }

	internal INetworkProtocol get_NetworkProtocol() { }

	internal int get_ProtocolStatus() { }

	public int get_ReceiveErrorCode() { }

	private Connection GetConnection(NetworkConnection id) { }

	private Connection GetConnection(NetworkInterfaceEndPoint address, SessionIdToken sessionId) { }

	public State GetConnectionState(NetworkConnection con) { }

	public int GetEventQueueSizeForConnection(NetworkConnection connectionId) { }

	private Connection GetNewConnection(NetworkInterfaceEndPoint address, SessionIdToken sessionId) { }

	public void GetPipelineBuffers(NetworkPipeline pipeline, NetworkPipelineStageId stageId, NetworkConnection connection, out NativeArray<Byte>& readProcessingBuffer, out NativeArray<Byte>& writeProcessingBuffer, out NativeArray<Byte>& sharedBuffer) { }

	private static INetworkProtocol GetProtocolForParameters(NetworkSettings settings) { }

	private static int InsertInAvailableIndex(List<T> list, T element) { }

	private void InternalUpdate() { }

	internal bool IsAddressUsed(NetworkInterfaceEndPoint address) { }

	private bool IsPointerInsideDataStream(Byte* dataPtr, int dataLength, out int sliceOffset) { }

	public int Listen() { }

	public NetworkEndPoint LocalEndPoint() { }

	public int MaxHeaderSize(NetworkPipeline pipe) { }

	internal int MaxProtocolHeaderSize() { }

	internal int PinMemoryTillUpdate(int length) { }

	public Type PopEvent(out NetworkConnection con, out DataStreamReader reader, out NetworkPipeline pipeline) { }

	public Type PopEvent(out NetworkConnection con, out DataStreamReader reader) { }

	public Type PopEventForConnection(NetworkConnection connectionId, out DataStreamReader reader) { }

	public Type PopEventForConnection(NetworkConnection connectionId, out DataStreamReader reader, out NetworkPipeline pipeline) { }

	internal void PushDataEvent(NetworkConnection con, int pipelineId, Byte* dataPtr, int dataLength) { }

	public NetworkEndPoint RemoteEndPoint(NetworkConnection id) { }

	private bool RemoveConnection(Connection connection) { }

	public JobHandle ScheduleFlushSend(JobHandle dep) { }

	public JobHandle ScheduleUpdate(JobHandle dep = null) { }

	private void set_Listening(bool value) { }

	internal void set_ReceiveErrorCode(int value) { }

	private void SetConnection(Connection connection) { }

	public Concurrent ToConcurrent() { }

	private Concurrent ToConcurrentSendOnly() { }

	private void UpdateConnection(Connection connection) { }

	private void UpdateLastUpdateTime() { }

}

