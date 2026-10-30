namespace Unity.Networking.QoS;

internal struct QosJob : IQosJob, IJob
{
	private struct InternalQosServer
	{
		public readonly NetworkEndPoint RemoteEndpoint; //Field offset: 0x0
		public readonly DateTime BackoffUntilUtc; //Field offset: 0x18
		public readonly int Idx; //Field offset: 0x20
		private int m_FirstIdx; //Field offset: 0x24
		private ushort m_RequestIdentifier; //Field offset: 0x28

		public string Address
		{
			 get { } //Length: 76
		}

		public bool Duplicate
		{
			 get { } //Length: 16
		}

		public int FirstIdx
		{
			 get { } //Length: 8
			 set { } //Length: 8
		}

		public ushort RequestIdentifier
		{
			 get { } //Length: 8
			 set { } //Length: 8
		}

		public InternalQosServer(NetworkEndPoint remote, DateTime backoffUntilUtc, int idx) { }

		public string get_Address() { }

		public bool get_Duplicate() { }

		public int get_FirstIdx() { }

		public ushort get_RequestIdentifier() { }

		public void set_FirstIdx(int value) { }

		public void set_RequestIdentifier(ushort value) { }

	}

	private uint RequestsPerEndpoint; //Field offset: 0x0
	private ulong TimeoutMs; //Field offset: 0x8
	private ulong MaxWaitMs; //Field offset: 0x10
	private uint RequestsBetweenPause; //Field offset: 0x18
	private uint RequestPauseMs; //Field offset: 0x1C
	private uint ReceiveWaitMs; //Field offset: 0x20
	private NativeArray<InternalQosResult> _qosResults; //Field offset: 0x28
	[DeallocateOnJobCompletion]
	private NativeArray<InternalQosServer> m_QosServers; //Field offset: 0x38
	[DeallocateOnJobCompletion]
	private NativeArray<Byte> m_TitleBytesUtf8; //Field offset: 0x48
	private NativeHashMap<FixedString64Bytes, Int32> m_AddressIndexes; //Field offset: 0x58
	private DateTime m_JobExpireTimeUtc; //Field offset: 0x68
	private int m_Requests; //Field offset: 0x70
	private int m_Responses; //Field offset: 0x74

	public override NativeArray<InternalQosResult> QosResults
	{
		 get { } //Length: 12
	}

	internal QosJob(IList<UcgQosServer> qosServers, string title, uint requestsPerEndpoint = 5, ulong timeoutMs = 10000, ulong maxWaitMs = 500, uint requestsBetweenPause = 10, uint requestPauseMs = 1, uint receiveWaitMs = 10) { }

	private static ValueTuple<Baselib_Socket_Handle, Baselib_ErrorCode> CreateAndBindSocket() { }

	public override void Dispose() { }

	private string EnableReceiveWait() { }

	public override void Execute() { }

	public override NativeArray<InternalQosResult> get_QosResults() { }

	private int LookupResult(NetworkEndPoint endPoint, QosResponse response, ref InternalQosResult result) { }

	private void ProcessServer(InternalQosServer server, Baselib_Socket_Handle socketHandle) { }

	private void ProcessServers(Baselib_Socket_Handle socketHandle) { }

	private void RecvQosResponses(NetworkEndPoint addr, DateTime deadline, Baselib_Socket_Handle socketHandle, bool wait) { }

	private void RecvQosResponsesTimed(NetworkEndPoint addr, DateTime deadline, Baselib_Socket_Handle socketHandle, bool wait) { }

	public override JobHandle Schedule(JobHandle dependsOn = null) { }

	private Baselib_ErrorCode SendQosRequests(InternalQosServer server, Baselib_Socket_Handle socketHandle, ref InternalQosResult result) { }

	private void StoreResult(int idx, InternalQosResult result) { }

	private void StoreServer(InternalQosServer server) { }

}

