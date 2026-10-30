namespace Unity.Services.Lobbies.Apis.Lobby;

internal class LobbyApiClient : BaseApiClient, ILobbyApiClient
{
	[CompilerGenerated]
	private struct <BulkUpdateLobbyAsync>d__7 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Response`1<Lobby>> <>t__builder; //Field offset: 0x8
		public Configuration operationConfiguration; //Field offset: 0x20
		public LobbyApiClient <>4__this; //Field offset: 0x28
		public BulkUpdateLobbyRequest request; //Field offset: 0x30
		private Dictionary<String, Type> <statusCodeToTypeMap>5__2; //Field offset: 0x38
		private TaskAwaiter<HttpClientResponse> <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <CreateLobbyAsync>d__8 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Response`1<Lobby>> <>t__builder; //Field offset: 0x8
		public Configuration operationConfiguration; //Field offset: 0x20
		public LobbyApiClient <>4__this; //Field offset: 0x28
		public CreateLobbyRequest request; //Field offset: 0x30
		private Dictionary<String, Type> <statusCodeToTypeMap>5__2; //Field offset: 0x38
		private TaskAwaiter<HttpClientResponse> <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <CreateOrJoinLobbyAsync>d__9 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Response`1<Lobby>> <>t__builder; //Field offset: 0x8
		public Configuration operationConfiguration; //Field offset: 0x20
		public LobbyApiClient <>4__this; //Field offset: 0x28
		public CreateOrJoinLobbyRequest request; //Field offset: 0x30
		private Dictionary<String, Type> <statusCodeToTypeMap>5__2; //Field offset: 0x38
		private TaskAwaiter<HttpClientResponse> <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <DeleteLobbyAsync>d__10 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Response> <>t__builder; //Field offset: 0x8
		public Configuration operationConfiguration; //Field offset: 0x20
		public LobbyApiClient <>4__this; //Field offset: 0x28
		public DeleteLobbyRequest request; //Field offset: 0x30
		private Dictionary<String, Type> <statusCodeToTypeMap>5__2; //Field offset: 0x38
		private TaskAwaiter<HttpClientResponse> <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <GetHostedLobbiesAsync>d__11 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Response`1<List`1<String>>> <>t__builder; //Field offset: 0x8
		public Configuration operationConfiguration; //Field offset: 0x20
		public LobbyApiClient <>4__this; //Field offset: 0x28
		public GetHostedLobbiesRequest request; //Field offset: 0x30
		private Dictionary<String, Type> <statusCodeToTypeMap>5__2; //Field offset: 0x38
		private TaskAwaiter<HttpClientResponse> <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <GetJoinedLobbiesAsync>d__12 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Response`1<List`1<String>>> <>t__builder; //Field offset: 0x8
		public Configuration operationConfiguration; //Field offset: 0x20
		public LobbyApiClient <>4__this; //Field offset: 0x28
		public GetJoinedLobbiesRequest request; //Field offset: 0x30
		private Dictionary<String, Type> <statusCodeToTypeMap>5__2; //Field offset: 0x38
		private TaskAwaiter<HttpClientResponse> <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <GetLobbyAsync>d__13 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Response`1<Lobby>> <>t__builder; //Field offset: 0x8
		public Configuration operationConfiguration; //Field offset: 0x20
		public LobbyApiClient <>4__this; //Field offset: 0x28
		public GetLobbyRequest request; //Field offset: 0x30
		private Dictionary<String, Type> <statusCodeToTypeMap>5__2; //Field offset: 0x38
		private TaskAwaiter<HttpClientResponse> <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <HeartbeatAsync>d__14 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Response> <>t__builder; //Field offset: 0x8
		public Configuration operationConfiguration; //Field offset: 0x20
		public LobbyApiClient <>4__this; //Field offset: 0x28
		public HeartbeatRequest request; //Field offset: 0x30
		private Dictionary<String, Type> <statusCodeToTypeMap>5__2; //Field offset: 0x38
		private TaskAwaiter<HttpClientResponse> <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <JoinLobbyByCodeAsync>d__15 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Response`1<Lobby>> <>t__builder; //Field offset: 0x8
		public Configuration operationConfiguration; //Field offset: 0x20
		public LobbyApiClient <>4__this; //Field offset: 0x28
		public JoinLobbyByCodeRequest request; //Field offset: 0x30
		private Dictionary<String, Type> <statusCodeToTypeMap>5__2; //Field offset: 0x38
		private TaskAwaiter<HttpClientResponse> <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <JoinLobbyByIdAsync>d__16 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Response`1<Lobby>> <>t__builder; //Field offset: 0x8
		public Configuration operationConfiguration; //Field offset: 0x20
		public LobbyApiClient <>4__this; //Field offset: 0x28
		public JoinLobbyByIdRequest request; //Field offset: 0x30
		private Dictionary<String, Type> <statusCodeToTypeMap>5__2; //Field offset: 0x38
		private TaskAwaiter<HttpClientResponse> <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <QueryLobbiesAsync>d__17 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Response`1<QueryResponse>> <>t__builder; //Field offset: 0x8
		public Configuration operationConfiguration; //Field offset: 0x20
		public LobbyApiClient <>4__this; //Field offset: 0x28
		public QueryLobbiesRequest request; //Field offset: 0x30
		private Dictionary<String, Type> <statusCodeToTypeMap>5__2; //Field offset: 0x38
		private TaskAwaiter<HttpClientResponse> <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <QuickJoinLobbyAsync>d__18 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Response`1<Lobby>> <>t__builder; //Field offset: 0x8
		public Configuration operationConfiguration; //Field offset: 0x20
		public LobbyApiClient <>4__this; //Field offset: 0x28
		public QuickJoinLobbyRequest request; //Field offset: 0x30
		private Dictionary<String, Type> <statusCodeToTypeMap>5__2; //Field offset: 0x38
		private TaskAwaiter<HttpClientResponse> <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <ReconnectAsync>d__19 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Response`1<Lobby>> <>t__builder; //Field offset: 0x8
		public Configuration operationConfiguration; //Field offset: 0x20
		public LobbyApiClient <>4__this; //Field offset: 0x28
		public ReconnectRequest request; //Field offset: 0x30
		private Dictionary<String, Type> <statusCodeToTypeMap>5__2; //Field offset: 0x38
		private TaskAwaiter<HttpClientResponse> <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <RemovePlayerAsync>d__20 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Response> <>t__builder; //Field offset: 0x8
		public Configuration operationConfiguration; //Field offset: 0x20
		public LobbyApiClient <>4__this; //Field offset: 0x28
		public RemovePlayerRequest request; //Field offset: 0x30
		private Dictionary<String, Type> <statusCodeToTypeMap>5__2; //Field offset: 0x38
		private TaskAwaiter<HttpClientResponse> <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <RequestTokensAsync>d__21 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Response`1<Dictionary`2<String, TokenData>>> <>t__builder; //Field offset: 0x8
		public Configuration operationConfiguration; //Field offset: 0x20
		public LobbyApiClient <>4__this; //Field offset: 0x28
		public RequestTokensRequest request; //Field offset: 0x30
		private Dictionary<String, Type> <statusCodeToTypeMap>5__2; //Field offset: 0x38
		private TaskAwaiter<HttpClientResponse> <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <UpdateLobbyAsync>d__22 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Response`1<Lobby>> <>t__builder; //Field offset: 0x8
		public Configuration operationConfiguration; //Field offset: 0x20
		public LobbyApiClient <>4__this; //Field offset: 0x28
		public UpdateLobbyRequest request; //Field offset: 0x30
		private Dictionary<String, Type> <statusCodeToTypeMap>5__2; //Field offset: 0x38
		private TaskAwaiter<HttpClientResponse> <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <UpdatePlayerAsync>d__23 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Response`1<Lobby>> <>t__builder; //Field offset: 0x8
		public Configuration operationConfiguration; //Field offset: 0x20
		public LobbyApiClient <>4__this; //Field offset: 0x28
		public UpdatePlayerRequest request; //Field offset: 0x30
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
		 get { } //Length: 208
		 set { } //Length: 8
	}

	public LobbyApiClient(IHttpClient httpClient, IAccessToken accessToken, Configuration configuration = null) { }

	[AsyncStateMachine(typeof(<BulkUpdateLobbyAsync>d__7))]
	public override Task<Response`1<Lobby>> BulkUpdateLobbyAsync(BulkUpdateLobbyRequest request, Configuration operationConfiguration = null) { }

	[AsyncStateMachine(typeof(<CreateLobbyAsync>d__8))]
	public override Task<Response`1<Lobby>> CreateLobbyAsync(CreateLobbyRequest request, Configuration operationConfiguration = null) { }

	[AsyncStateMachine(typeof(<CreateOrJoinLobbyAsync>d__9))]
	public override Task<Response`1<Lobby>> CreateOrJoinLobbyAsync(CreateOrJoinLobbyRequest request, Configuration operationConfiguration = null) { }

	[AsyncStateMachine(typeof(<DeleteLobbyAsync>d__10))]
	public override Task<Response> DeleteLobbyAsync(DeleteLobbyRequest request, Configuration operationConfiguration = null) { }

	public Configuration get_Configuration() { }

	[AsyncStateMachine(typeof(<GetHostedLobbiesAsync>d__11))]
	public override Task<Response`1<List`1<String>>> GetHostedLobbiesAsync(GetHostedLobbiesRequest request, Configuration operationConfiguration = null) { }

	[AsyncStateMachine(typeof(<GetJoinedLobbiesAsync>d__12))]
	public override Task<Response`1<List`1<String>>> GetJoinedLobbiesAsync(GetJoinedLobbiesRequest request, Configuration operationConfiguration = null) { }

	[AsyncStateMachine(typeof(<GetLobbyAsync>d__13))]
	public override Task<Response`1<Lobby>> GetLobbyAsync(GetLobbyRequest request, Configuration operationConfiguration = null) { }

	[AsyncStateMachine(typeof(<HeartbeatAsync>d__14))]
	public override Task<Response> HeartbeatAsync(HeartbeatRequest request, Configuration operationConfiguration = null) { }

	[AsyncStateMachine(typeof(<JoinLobbyByCodeAsync>d__15))]
	public override Task<Response`1<Lobby>> JoinLobbyByCodeAsync(JoinLobbyByCodeRequest request, Configuration operationConfiguration = null) { }

	[AsyncStateMachine(typeof(<JoinLobbyByIdAsync>d__16))]
	public override Task<Response`1<Lobby>> JoinLobbyByIdAsync(JoinLobbyByIdRequest request, Configuration operationConfiguration = null) { }

	[AsyncStateMachine(typeof(<QueryLobbiesAsync>d__17))]
	public override Task<Response`1<QueryResponse>> QueryLobbiesAsync(QueryLobbiesRequest request, Configuration operationConfiguration = null) { }

	[AsyncStateMachine(typeof(<QuickJoinLobbyAsync>d__18))]
	public override Task<Response`1<Lobby>> QuickJoinLobbyAsync(QuickJoinLobbyRequest request, Configuration operationConfiguration = null) { }

	[AsyncStateMachine(typeof(<ReconnectAsync>d__19))]
	public override Task<Response`1<Lobby>> ReconnectAsync(ReconnectRequest request, Configuration operationConfiguration = null) { }

	[AsyncStateMachine(typeof(<RemovePlayerAsync>d__20))]
	public override Task<Response> RemovePlayerAsync(RemovePlayerRequest request, Configuration operationConfiguration = null) { }

	[AsyncStateMachine(typeof(<RequestTokensAsync>d__21))]
	public override Task<Response`1<Dictionary`2<String, TokenData>>> RequestTokensAsync(RequestTokensRequest request, Configuration operationConfiguration = null) { }

	public void set_Configuration(Configuration value) { }

	[AsyncStateMachine(typeof(<UpdateLobbyAsync>d__22))]
	public override Task<Response`1<Lobby>> UpdateLobbyAsync(UpdateLobbyRequest request, Configuration operationConfiguration = null) { }

	[AsyncStateMachine(typeof(<UpdatePlayerAsync>d__23))]
	public override Task<Response`1<Lobby>> UpdatePlayerAsync(UpdatePlayerRequest request, Configuration operationConfiguration = null) { }

}

