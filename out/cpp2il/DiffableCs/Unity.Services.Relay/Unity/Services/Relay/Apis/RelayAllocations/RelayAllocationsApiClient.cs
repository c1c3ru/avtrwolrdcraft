namespace Unity.Services.Relay.Apis.RelayAllocations;

internal class RelayAllocationsApiClient : BaseApiClient, IRelayAllocationsApiClient
{
	[CompilerGenerated]
	private struct <CreateAllocationAsync>d__7 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Response`1<AllocateResponseBody>> <>t__builder; //Field offset: 0x8
		public Configuration operationConfiguration; //Field offset: 0x20
		public RelayAllocationsApiClient <>4__this; //Field offset: 0x28
		public CreateAllocationRequest request; //Field offset: 0x30
		private Dictionary<String, Type> <statusCodeToTypeMap>5__2; //Field offset: 0x38
		private TaskAwaiter<HttpClientResponse> <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <CreateJoincodeAsync>d__8 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Response`1<JoinCodeResponseBody>> <>t__builder; //Field offset: 0x8
		public Configuration operationConfiguration; //Field offset: 0x20
		public RelayAllocationsApiClient <>4__this; //Field offset: 0x28
		public CreateJoincodeRequest request; //Field offset: 0x30
		private Dictionary<String, Type> <statusCodeToTypeMap>5__2; //Field offset: 0x38
		private TaskAwaiter<HttpClientResponse> <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <JoinRelayAsync>d__9 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Response`1<JoinResponseBody>> <>t__builder; //Field offset: 0x8
		public Configuration operationConfiguration; //Field offset: 0x20
		public RelayAllocationsApiClient <>4__this; //Field offset: 0x28
		public JoinRelayRequest request; //Field offset: 0x30
		private Dictionary<String, Type> <statusCodeToTypeMap>5__2; //Field offset: 0x38
		private TaskAwaiter<HttpClientResponse> <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <ListRegionsAsync>d__10 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Response`1<RegionsResponseBody>> <>t__builder; //Field offset: 0x8
		public Configuration operationConfiguration; //Field offset: 0x20
		public RelayAllocationsApiClient <>4__this; //Field offset: 0x28
		public ListRegionsRequest request; //Field offset: 0x30
		private Dictionary<String, Type> <statusCodeToTypeMap>5__2; //Field offset: 0x38
		private TaskAwaiter<HttpClientResponse> <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	private const int _baseTimeout = 10; //Field offset: 0x0
	private IAccessToken _accessToken; //Field offset: 0x18
	private Configuration _configuration; //Field offset: 0x20

	public Configuration Configuration
	{
		 get { } //Length: 200
		 set { } //Length: 8
	}

	public RelayAllocationsApiClient(IHttpClient httpClient, IAccessToken accessToken, Configuration configuration = null) { }

	[AsyncStateMachine(typeof(<CreateAllocationAsync>d__7))]
	public override Task<Response`1<AllocateResponseBody>> CreateAllocationAsync(CreateAllocationRequest request, Configuration operationConfiguration = null) { }

	[AsyncStateMachine(typeof(<CreateJoincodeAsync>d__8))]
	public override Task<Response`1<JoinCodeResponseBody>> CreateJoincodeAsync(CreateJoincodeRequest request, Configuration operationConfiguration = null) { }

	public Configuration get_Configuration() { }

	[AsyncStateMachine(typeof(<JoinRelayAsync>d__9))]
	public override Task<Response`1<JoinResponseBody>> JoinRelayAsync(JoinRelayRequest request, Configuration operationConfiguration = null) { }

	[AsyncStateMachine(typeof(<ListRegionsAsync>d__10))]
	public override Task<Response`1<RegionsResponseBody>> ListRegionsAsync(ListRegionsRequest request, Configuration operationConfiguration = null) { }

	public void set_Configuration(Configuration value) { }

}

