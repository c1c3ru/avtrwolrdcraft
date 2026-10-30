namespace Unity.Services.Lobbies.Internal;

internal class WrappedLobbyService : ILobbyService, ILobbyServiceSDK, ILobbyServiceSDKConfiguration, ILobbyServiceInternal
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Detail, String> <>9__29_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal string <ResolveErrorWrapping>b__29_0(Detail d) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass31_0
	{
		public Player player; //Field offset: 0x10

		public <>c__DisplayClass31_0() { }

		internal bool <LobbyConflictResolver>b__0(Player x) { }

	}

	[CompilerGenerated]
	private struct <CreateLobbyAsync>d__9 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Lobby> <>t__builder; //Field offset: 0x8
		public string lobbyName; //Field offset: 0x20
		public int maxPlayers; //Field offset: 0x28
		public WrappedLobbyService <>4__this; //Field offset: 0x30
		public CreateLobbyOptions options; //Field offset: 0x38
		private TaskAwaiter<Response`1<Lobby>> <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <CreateOrJoinLobbyAsync>d__10 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Lobby> <>t__builder; //Field offset: 0x8
		public string lobbyId; //Field offset: 0x20
		public string lobbyName; //Field offset: 0x28
		public int maxPlayers; //Field offset: 0x30
		public WrappedLobbyService <>4__this; //Field offset: 0x38
		public CreateLobbyOptions createOptions; //Field offset: 0x40
		private TaskAwaiter<Response`1<Lobby>> <>u__1; //Field offset: 0x48

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <DeleteLobbyAsync>d__12 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public string lobbyId; //Field offset: 0x20
		public WrappedLobbyService <>4__this; //Field offset: 0x28
		private TaskAwaiter<Response> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <GetJoinedLobbiesAsync>d__13 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<List`1<String>> <>t__builder; //Field offset: 0x8
		public WrappedLobbyService <>4__this; //Field offset: 0x20
		private TaskAwaiter<Response`1<List`1<String>>> <>u__1; //Field offset: 0x28

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <GetLobbyAsync>d__14 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Lobby> <>t__builder; //Field offset: 0x8
		public string lobbyId; //Field offset: 0x20
		public WrappedLobbyService <>4__this; //Field offset: 0x28
		private TaskAwaiter<Response`1<Lobby>> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <JoinLobbyByCodeAsync>d__16 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Lobby> <>t__builder; //Field offset: 0x8
		public string lobbyCode; //Field offset: 0x20
		public JoinLobbyByCodeOptions options; //Field offset: 0x28
		public WrappedLobbyService <>4__this; //Field offset: 0x30
		private object <>7__wrap1; //Field offset: 0x38
		private TaskAwaiter<Response`1<Lobby>> <>u__1; //Field offset: 0x40
		private TaskAwaiter<Lobby> <>u__2; //Field offset: 0x48

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <JoinLobbyByIdAsync>d__17 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Lobby> <>t__builder; //Field offset: 0x8
		public string lobbyId; //Field offset: 0x20
		public JoinLobbyByIdOptions options; //Field offset: 0x28
		public WrappedLobbyService <>4__this; //Field offset: 0x30
		private object <>7__wrap1; //Field offset: 0x38
		private TaskAwaiter<Response`1<Lobby>> <>u__1; //Field offset: 0x40
		private TaskAwaiter<Lobby> <>u__2; //Field offset: 0x48

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <LobbyConflictResolver>d__31 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Lobby> <>t__builder; //Field offset: 0x8
		public Player player; //Field offset: 0x20
		public string lobbyId; //Field offset: 0x28
		public WrappedLobbyService <>4__this; //Field offset: 0x30
		private <>c__DisplayClass31_0 <>8__1; //Field offset: 0x38
		public LobbyServiceException e; //Field offset: 0x40
		private TaskAwaiter<List`1<String>> <>u__1; //Field offset: 0x48
		private TaskAwaiter<Lobby> <>u__2; //Field offset: 0x50

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <QueryLobbiesAsync>d__18 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<QueryResponse> <>t__builder; //Field offset: 0x8
		public QueryLobbiesOptions options; //Field offset: 0x20
		public WrappedLobbyService <>4__this; //Field offset: 0x28
		private TaskAwaiter<Response`1<QueryResponse>> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <QuickJoinLobbyAsync>d__19 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Lobby> <>t__builder; //Field offset: 0x8
		public QuickJoinLobbyOptions options; //Field offset: 0x20
		public WrappedLobbyService <>4__this; //Field offset: 0x28
		private object <>7__wrap1; //Field offset: 0x30
		private TaskAwaiter<Response`1<Lobby>> <>u__1; //Field offset: 0x38
		private TaskAwaiter<Lobby> <>u__2; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <ReconnectToLobbyAsync>d__23 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Lobby> <>t__builder; //Field offset: 0x8
		public string lobbyId; //Field offset: 0x20
		public WrappedLobbyService <>4__this; //Field offset: 0x28
		private TaskAwaiter<Response`1<Lobby>> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <RemovePlayerAsync>d__20 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public string lobbyId; //Field offset: 0x20
		public string playerId; //Field offset: 0x28
		public WrappedLobbyService <>4__this; //Field offset: 0x30
		private TaskAwaiter<Response> <>u__1; //Field offset: 0x38

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <RequestTokensAsync>d__24 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Dictionary`2<String, TokenData>> <>t__builder; //Field offset: 0x8
		public TokenTypeOptions[] tokenOptions; //Field offset: 0x20
		public string lobbyId; //Field offset: 0x28
		public WrappedLobbyService <>4__this; //Field offset: 0x30
		private TaskAwaiter<Response`1<Dictionary`2<String, TokenData>>> <>u__1; //Field offset: 0x38

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <SendHeartbeatPingAsync>d__15 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public string lobbyId; //Field offset: 0x20
		public WrappedLobbyService <>4__this; //Field offset: 0x28
		private TaskAwaiter<Response> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <SubscribeToLobbyEventsAsync>d__11 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<ILobbyEvents> <>t__builder; //Field offset: 0x8
		public WrappedLobbyService <>4__this; //Field offset: 0x20
		public string lobbyId; //Field offset: 0x28
		public LobbyEventCallbacks lobbyEventCallbacks; //Field offset: 0x30
		private LobbyChannel <lobbyChannel>5__2; //Field offset: 0x38
		private TaskAwaiter <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <TryCatchRequest>d__27 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Response> <>t__builder; //Field offset: 0x0
		public WrappedLobbyService <>4__this; //Field offset: 0x0
		public string api; //Field offset: 0x0
		public Func<TRequest, Configuration, Task`1<Response>> func; //Field offset: 0x0
		public TRequest request; //Field offset: 0x0
		private Response <response>5__2; //Field offset: 0x0
		private ApiTelemetryScope <>7__wrap2; //Field offset: 0x0
		private TaskAwaiter<Response> <>u__1; //Field offset: 0x0

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <TryCatchRequest>d__28 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Response`1<TReturn>> <>t__builder; //Field offset: 0x0
		public WrappedLobbyService <>4__this; //Field offset: 0x0
		public string api; //Field offset: 0x0
		public Func<TRequest, Configuration, Task`1<Response`1<TReturn>>> func; //Field offset: 0x0
		public TRequest request; //Field offset: 0x0
		private Response<TReturn> <response>5__2; //Field offset: 0x0
		private ApiTelemetryScope <>7__wrap2; //Field offset: 0x0
		private TaskAwaiter<Response`1<TReturn>> <>u__1; //Field offset: 0x0

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <UpdateLobbyAsync>d__21 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Lobby> <>t__builder; //Field offset: 0x8
		public string lobbyId; //Field offset: 0x20
		public UpdateLobbyOptions options; //Field offset: 0x28
		public WrappedLobbyService <>4__this; //Field offset: 0x30
		private TaskAwaiter<Response`1<Lobby>> <>u__1; //Field offset: 0x38

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <UpdatePlayerAsync>d__22 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Lobby> <>t__builder; //Field offset: 0x8
		public string lobbyId; //Field offset: 0x20
		public string playerId; //Field offset: 0x28
		public UpdatePlayerOptions options; //Field offset: 0x30
		public WrappedLobbyService <>4__this; //Field offset: 0x38
		private TaskAwaiter<Response`1<Lobby>> <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	private const int k_CommonErrorCodeRange = 100; //Field offset: 0x0
	internal const int LOBBY_ERROR_MIN_RANGE = 16000; //Field offset: 0x0
	internal ILobbyServiceSdk m_LobbyService; //Field offset: 0x10
	private readonly ApiTelemetryScopeFactory m_TelemetryScopeFactory; //Field offset: 0x18
	private bool m_LocalPlayerLobbyEventsEnabled; //Field offset: 0x20
	[CompilerGenerated]
	private readonly Dictionary<String, Lobby> <JoinedLobbyCache>k__BackingField; //Field offset: 0x28

	internal Dictionary<String, Lobby> JoinedLobbyCache
	{
		[CompilerGenerated]
		internal get { } //Length: 8
	}

	internal WrappedLobbyService(ILobbyServiceSdk lobbyService) { }

	private void AddOrUpdateLobbyCache(Lobby newLobby) { }

	internal static Lobby CloneLobbyHelper(Lobby otherLobby) { }

	private CreateRequest ConvertCreateOptionsToRequest(string lobbyName, int maxPlayers, CreateLobbyOptions options) { }

	[AsyncStateMachine(typeof(<CreateLobbyAsync>d__9))]
	public override Task<Lobby> CreateLobbyAsync(string lobbyName, int maxPlayers, CreateLobbyOptions options = null) { }

	[AsyncStateMachine(typeof(<CreateOrJoinLobbyAsync>d__10))]
	public override Task<Lobby> CreateOrJoinLobbyAsync(string lobbyId, string lobbyName, int maxPlayers, CreateLobbyOptions createOptions = null) { }

	[AsyncStateMachine(typeof(<DeleteLobbyAsync>d__12))]
	public override Task DeleteLobbyAsync(string lobbyId) { }

	public override void EnableLocalPlayerLobbyEvents(bool enabled) { }

	[CompilerGenerated]
	internal Dictionary<String, Lobby> get_JoinedLobbyCache() { }

	[AsyncStateMachine(typeof(<GetJoinedLobbiesAsync>d__13))]
	public override Task<List`1<String>> GetJoinedLobbiesAsync() { }

	[AsyncStateMachine(typeof(<GetLobbyAsync>d__14))]
	public override Task<Lobby> GetLobbyAsync(string lobbyId) { }

	public override Dictionary<String, Lobby> GetLobbyCache() { }

	private bool IsPlayerDataEqual(Player a, Player b) { }

	[AsyncStateMachine(typeof(<JoinLobbyByCodeAsync>d__16))]
	public override Task<Lobby> JoinLobbyByCodeAsync(string lobbyCode, JoinLobbyByCodeOptions options = null) { }

	[AsyncStateMachine(typeof(<JoinLobbyByIdAsync>d__17))]
	public override Task<Lobby> JoinLobbyByIdAsync(string lobbyId, JoinLobbyByIdOptions options = null) { }

	[AsyncStateMachine(typeof(<LobbyConflictResolver>d__31))]
	private Task<Lobby> LobbyConflictResolver(Player player, string lobbyId = null, LobbyServiceException e = null) { }

	[AsyncStateMachine(typeof(<QueryLobbiesAsync>d__18))]
	public override Task<QueryResponse> QueryLobbiesAsync(QueryLobbiesOptions options = null) { }

	[AsyncStateMachine(typeof(<QuickJoinLobbyAsync>d__19))]
	public override Task<Lobby> QuickJoinLobbyAsync(QuickJoinLobbyOptions options = null) { }

	[AsyncStateMachine(typeof(<ReconnectToLobbyAsync>d__23))]
	public override Task<Lobby> ReconnectToLobbyAsync(string lobbyId) { }

	[AsyncStateMachine(typeof(<RemovePlayerAsync>d__20))]
	public override Task RemovePlayerAsync(string lobbyId, string playerId) { }

	[AsyncStateMachine(typeof(<RequestTokensAsync>d__24))]
	public override Task<Dictionary`2<String, TokenData>> RequestTokensAsync(string lobbyId, TokenTypeOptions[] tokenOptions) { }

	private void ResolveErrorWrapping(LobbyExceptionReason reason, Exception exception = null) { }

	[AsyncStateMachine(typeof(<SendHeartbeatPingAsync>d__15))]
	public override Task SendHeartbeatPingAsync(string lobbyId) { }

	public override void SetBasePath(string basePath) { }

	[AsyncStateMachine(typeof(<SubscribeToLobbyEventsAsync>d__11))]
	public override Task<ILobbyEvents> SubscribeToLobbyEventsAsync(string lobbyId, LobbyEventCallbacks lobbyEventCallbacks) { }

	[AsyncStateMachine(typeof(<TryCatchRequest>d__27`1))]
	private Task<Response> TryCatchRequest(string api, Func<TRequest, Configuration, Task`1<Response>> func, TRequest request) { }

	[AsyncStateMachine(typeof(<TryCatchRequest>d__28`2))]
	private Task<Response`1<TReturn>> TryCatchRequest(string api, Func<TRequest, Configuration, Task`1<Response`1<TReturn>>> func, TRequest request) { }

	private bool TryMapCommonErrorCodeToLobbyExceptionReason(int code, out LobbyExceptionReason reason) { }

	[AsyncStateMachine(typeof(<UpdateLobbyAsync>d__21))]
	public override Task<Lobby> UpdateLobbyAsync(string lobbyId, UpdateLobbyOptions options) { }

	[AsyncStateMachine(typeof(<UpdatePlayerAsync>d__22))]
	public override Task<Lobby> UpdatePlayerAsync(string lobbyId, string playerId, UpdatePlayerOptions options) { }

}

