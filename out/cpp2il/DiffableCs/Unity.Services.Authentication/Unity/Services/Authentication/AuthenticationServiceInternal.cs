namespace Unity.Services.Authentication;

internal class AuthenticationServiceInternal : IAuthenticationService
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<String, Boolean> <>9__5_0; //Field offset: 0x8
		public static Func<String, Boolean> <>9__130_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal bool <CompleteSignIn>b__130_0(string s) { }

		internal bool <ValidateAccessToken>b__5_0(string s) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass120_0
	{
		public AuthenticationServiceInternal <>4__this; //Field offset: 0x10
		public string sessionToken; //Field offset: 0x18

		public <>c__DisplayClass120_0() { }

		internal Task<SignInResponse> <SignInAnonymouslyAsync>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass16_0
	{
		public SignInResponse signInResponse; //Field offset: 0x10

		public <>c__DisplayClass16_0() { }

		internal Task<SignInResponse> <SignInWithCodeAsync>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass172_0
	{
		public AuthenticationServiceInternal <>4__this; //Field offset: 0x10
		public string idProvider; //Field offset: 0x18
		public SignInWithExternalTokenRequest request; //Field offset: 0x20

		public <>c__DisplayClass172_0() { }

		internal Task<SignInResponse> <SignInWithExternalTokenAsync>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass173_0
	{
		public LinkWithExternalTokenRequest request; //Field offset: 0x10

		public <>c__DisplayClass173_0() { }

		internal bool <LinkWithExternalTokenAsync>b__0(ExternalIdentity x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass18_0
	{
		public TaskCompletionSource<Boolean> tcs; //Field offset: 0x10

		public <>c__DisplayClass18_0() { }

		internal void <DelayWithScheduler>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass187_0
	{
		public AuthenticationServiceInternal <>4__this; //Field offset: 0x10
		public UsernamePasswordRequest request; //Field offset: 0x18

		public <>c__DisplayClass187_0() { }

		internal Task<SignInResponse> <SignInWithUsernamePasswordRequestAsync>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass188_0
	{
		public AuthenticationServiceInternal <>4__this; //Field offset: 0x10
		public UsernamePasswordRequest request; //Field offset: 0x18

		public <>c__DisplayClass188_0() { }

		internal Task<SignInResponse> <SignUpWithUsernamePasswordRequestAsync>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass190_0
	{
		public AuthenticationServiceInternal <>4__this; //Field offset: 0x10
		public UpdatePasswordRequest request; //Field offset: 0x18

		public <>c__DisplayClass190_0() { }

		internal Task<SignInResponse> <UpdatePasswordRequestAsync>b__0() { }

	}

	[CompilerGenerated]
	private struct <AddUsernamePasswordRequestAsync>d__189 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public AuthenticationServiceInternal <>4__this; //Field offset: 0x20
		public UsernamePasswordRequest request; //Field offset: 0x28
		private TaskAwaiter<SignInResponse> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <ConfirmCodeAsync>d__20 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public string code; //Field offset: 0x20
		public AuthenticationServiceInternal <>4__this; //Field offset: 0x28
		public string idProvider; //Field offset: 0x30
		public string externalToken; //Field offset: 0x38
		private TaskAwaiter<CodeLinkConfirmResponse> <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <DeleteAccountAsync>d__121 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public AuthenticationServiceInternal <>4__this; //Field offset: 0x20
		private TaskAwaiter <>u__1; //Field offset: 0x28

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <GenerateSignInCodeAsync>d__15 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<SignInCodeInfo> <>t__builder; //Field offset: 0x8
		public AuthenticationServiceInternal <>4__this; //Field offset: 0x20
		public string identifier; //Field offset: 0x28
		private string <codeVerifier>5__2; //Field offset: 0x30
		private TaskAwaiter<GenerateCodeResponse> <>u__1; //Field offset: 0x38

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <GetNotificationsAsync>d__178 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<List`1<Notification>> <>t__builder; //Field offset: 0x8
		public AuthenticationServiceInternal <>4__this; //Field offset: 0x20
		private TaskAwaiter<GetNotificationsResponse> <>u__1; //Field offset: 0x28

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <GetPlayerInfoAsync>d__125 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<PlayerInfo> <>t__builder; //Field offset: 0x8
		public AuthenticationServiceInternal <>4__this; //Field offset: 0x20
		private TaskAwaiter<PlayerInfoResponse> <>u__1; //Field offset: 0x28

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <GetPlayerNameAsync>d__181 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<String> <>t__builder; //Field offset: 0x8
		public AuthenticationServiceInternal <>4__this; //Field offset: 0x20
		public bool autoGenerate; //Field offset: 0x28
		private TaskAwaiter<ApiResponse`1<Player>> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <GetSignInCodeInfoAsync>d__19 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<SignInCodeInfo> <>t__builder; //Field offset: 0x8
		public AuthenticationServiceInternal <>4__this; //Field offset: 0x20
		public string code; //Field offset: 0x28
		private TaskAwaiter<CodeLinkInfoResponse> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <HandleSignInRequestAsync>d__127 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public AuthenticationServiceInternal <>4__this; //Field offset: 0x20
		public Func<Task`1<SignInResponse>> signInRequest; //Field offset: 0x28
		public bool enableRefresh; //Field offset: 0x30
		private TaskAwaiter<SignInResponse> <>u__1; //Field offset: 0x38

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <HandleUpdatePasswordRequestAsync>d__191 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public Func<Task`1<SignInResponse>> updatePasswordRequest; //Field offset: 0x20
		public AuthenticationServiceInternal <>4__this; //Field offset: 0x28
		public bool enableRefresh; //Field offset: 0x30
		private TaskAwaiter<SignInResponse> <>u__1; //Field offset: 0x38

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <LinkWithExternalTokenAsync>d__173 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public LinkWithExternalTokenRequest request; //Field offset: 0x20
		public AuthenticationServiceInternal <>4__this; //Field offset: 0x28
		public string idProvider; //Field offset: 0x30
		private <>c__DisplayClass173_0 <>8__1; //Field offset: 0x38
		private TaskAwaiter<LinkResponse> <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <PollForCodeConfirmationAsync>d__17 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<SignInResponse> <>t__builder; //Field offset: 0x8
		public AuthenticationServiceInternal <>4__this; //Field offset: 0x20
		public SignInWithCodeRequest request; //Field offset: 0x28
		public CancellationToken cancellationToken; //Field offset: 0x30
		private TaskAwaiter <>u__1; //Field offset: 0x38
		private TaskAwaiter<SignInResponse> <>u__2; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <SignInWithCodeAsync>d__16 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public AuthenticationServiceInternal <>4__this; //Field offset: 0x20
		public bool usePolling; //Field offset: 0x28
		public CancellationToken cancellationToken; //Field offset: 0x30
		private <>c__DisplayClass16_0 <>8__1; //Field offset: 0x38
		private TaskAwaiter<SignInResponse> <>u__1; //Field offset: 0x40
		private TaskAwaiter <>u__2; //Field offset: 0x48

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <StartRefreshAsync>d__128 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public AuthenticationServiceInternal <>4__this; //Field offset: 0x20
		public string sessionToken; //Field offset: 0x28
		private TaskAwaiter<SignInResponse> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <UnlinkExternalTokenAsync>d__174 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public AuthenticationServiceInternal <>4__this; //Field offset: 0x20
		public string idProvider; //Field offset: 0x28
		private TaskAwaiter<UnlinkResponse> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <UpdatePlayerNameAsync>d__182 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<String> <>t__builder; //Field offset: 0x8
		public AuthenticationServiceInternal <>4__this; //Field offset: 0x20
		public string playerName; //Field offset: 0x28
		private TaskAwaiter<ApiResponse`1<Player>> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	private const string k_IdProviderNameRegex = "^oidc-[a-z0-9-_\.]{1,15}$"; //Field offset: 0x0
	private const string k_ProfileRegex = "^[a-zA-Z0-9_-]{1,30}$"; //Field offset: 0x0
	private const string k_SteamIdentityRegex = "^[a-zA-Z0-9]{5,30}$"; //Field offset: 0x0
	[CompilerGenerated]
	private string <CodeLinkSessionId>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private string <CodeVerifier>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private Action<RequestFailedException> SignInFailed; //Field offset: 0x20
	[CompilerGenerated]
	private Action SignedIn; //Field offset: 0x28
	[CompilerGenerated]
	private Action SignedOut; //Field offset: 0x30
	[CompilerGenerated]
	private Action Expired; //Field offset: 0x38
	[CompilerGenerated]
	private Action<SignInCodeInfo> SignInCodeReceived; //Field offset: 0x40
	[CompilerGenerated]
	private Action SignInCodeExpired; //Field offset: 0x48
	[CompilerGenerated]
	private Action<RequestFailedException> UpdatePasswordFailed; //Field offset: 0x50
	[CompilerGenerated]
	private PlayerInfo <PlayerInfo>k__BackingField; //Field offset: 0x58
	[CompilerGenerated]
	private string <LastNotificationDate>k__BackingField; //Field offset: 0x60
	[CompilerGenerated]
	private Nullable<Int64> <ExpirationActionId>k__BackingField; //Field offset: 0x68
	[CompilerGenerated]
	private Nullable<Int64> <RefreshActionId>k__BackingField; //Field offset: 0x78
	[CompilerGenerated]
	private readonly AccessTokenComponent <AccessTokenComponent>k__BackingField; //Field offset: 0x88
	[CompilerGenerated]
	private readonly EnvironmentIdComponent <EnvironmentIdComponent>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private readonly PlayerIdComponent <PlayerIdComponent>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private readonly PlayerNameComponent <PlayerNameComponent>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private readonly SessionTokenComponent <SessionTokenComponent>k__BackingField; //Field offset: 0xA8
	[CompilerGenerated]
	private readonly IEnvironments <EnvironmentComponent>k__BackingField; //Field offset: 0xB0
	[CompilerGenerated]
	private AuthenticationState <State>k__BackingField; //Field offset: 0xB8
	[CompilerGenerated]
	private readonly IAuthenticationSettings <Settings>k__BackingField; //Field offset: 0xC0
	[CompilerGenerated]
	private IAuthenticationNetworkClient <NetworkClient>k__BackingField; //Field offset: 0xC8
	[CompilerGenerated]
	private IPlayerNamesApi <PlayerNamesApi>k__BackingField; //Field offset: 0xD0
	[CompilerGenerated]
	private IAuthenticationExceptionHandler <ExceptionHandler>k__BackingField; //Field offset: 0xD8
	private readonly IProfile m_Profile; //Field offset: 0xE0
	private readonly IJwtDecoder m_JwtDecoder; //Field offset: 0xE8
	private readonly IAuthenticationCache m_Cache; //Field offset: 0xF0
	private readonly IActionScheduler m_Scheduler; //Field offset: 0xF8
	private readonly IAuthenticationMetrics m_Metrics; //Field offset: 0x100
	[CompilerGenerated]
	private Action<AuthenticationState, AuthenticationState> StateChanged; //Field offset: 0x108
	private List<Notification> m_Notifications; //Field offset: 0x110

	public override event Action Expired
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public override event Action SignedIn
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public override event Action SignedOut
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public override event Action SignInCodeExpired
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public override event Action<SignInCodeInfo> SignInCodeReceived
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public override event Action<RequestFailedException> SignInFailed
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	internal event Action<AuthenticationState, AuthenticationState> StateChanged
	{
		[CompilerGenerated]
		internal add { } //Length: 180
		[CompilerGenerated]
		internal remove { } //Length: 180
	}

	public event Action<RequestFailedException> UpdatePasswordFailed
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public override string AccessToken
	{
		 get { } //Length: 28
	}

	internal AccessTokenComponent AccessTokenComponent
	{
		[CompilerGenerated]
		internal get { } //Length: 8
	}

	internal string CodeLinkSessionId
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	internal string CodeVerifier
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	internal IEnvironments EnvironmentComponent
	{
		[CompilerGenerated]
		internal get { } //Length: 8
	}

	internal EnvironmentIdComponent EnvironmentIdComponent
	{
		[CompilerGenerated]
		internal get { } //Length: 8
	}

	internal IAuthenticationExceptionHandler ExceptionHandler
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	internal Nullable<Int64> ExpirationActionId
	{
		[CompilerGenerated]
		internal get { } //Length: 12
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	public override bool IsAuthorized
	{
		 get { } //Length: 20
	}

	public override bool IsExpired
	{
		 get { } //Length: 16
	}

	public override bool IsSignedIn
	{
		 get { } //Length: 20
	}

	[CanBeNull]
	public private override string LastNotificationDate
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	internal IAuthenticationNetworkClient NetworkClient
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	public override List<Notification> Notifications
	{
		 get { } //Length: 8
	}

	public override string PlayerId
	{
		 get { } //Length: 28
	}

	internal PlayerIdComponent PlayerIdComponent
	{
		[CompilerGenerated]
		internal get { } //Length: 8
	}

	public internal override PlayerInfo PlayerInfo
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	public override string PlayerName
	{
		 get { } //Length: 28
	}

	internal PlayerNameComponent PlayerNameComponent
	{
		[CompilerGenerated]
		internal get { } //Length: 8
	}

	internal IPlayerNamesApi PlayerNamesApi
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	public override string Profile
	{
		 get { } //Length: 164
	}

	internal Nullable<Int64> RefreshActionId
	{
		[CompilerGenerated]
		internal get { } //Length: 12
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	internal SessionTokenComponent SessionTokenComponent
	{
		[CompilerGenerated]
		internal get { } //Length: 8
	}

	public override bool SessionTokenExists
	{
		 get { } //Length: 44
	}

	internal IAuthenticationSettings Settings
	{
		[CompilerGenerated]
		internal get { } //Length: 8
	}

	internal AuthenticationState State
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	internal AuthenticationServiceInternal(IAuthenticationSettings settings, IAuthenticationNetworkClient networkClient, IPlayerNamesApi playerNamesApi, IProfile profile, IJwtDecoder jwtDecoder, IAuthenticationCache cache, IActionScheduler scheduler, IAuthenticationMetrics metrics, AccessTokenComponent accessToken, EnvironmentIdComponent environmentId, PlayerIdComponent playerId, PlayerNameComponent playerName, SessionTokenComponent sessionToken, IEnvironments environment) { }

	[CompilerGenerated]
	private void <.ctor>b__118_0() { }

	[CompilerGenerated]
	public override void add_Expired(Action value) { }

	[CompilerGenerated]
	public override void add_SignedIn(Action value) { }

	[CompilerGenerated]
	public override void add_SignedOut(Action value) { }

	[CompilerGenerated]
	public override void add_SignInCodeExpired(Action value) { }

	[CompilerGenerated]
	public override void add_SignInCodeReceived(Action<SignInCodeInfo> value) { }

	[CompilerGenerated]
	public override void add_SignInFailed(Action<RequestFailedException> value) { }

	[CompilerGenerated]
	internal void add_StateChanged(Action<AuthenticationState, AuthenticationState> value) { }

	[CompilerGenerated]
	public void add_UpdatePasswordFailed(Action<RequestFailedException> value) { }

	public override Task AddUsernamePasswordAsync(string username, string password) { }

	[AsyncStateMachine(typeof(<AddUsernamePasswordRequestAsync>d__189))]
	internal Task AddUsernamePasswordRequestAsync(UsernamePasswordRequest request) { }

	private UsernamePasswordRequest BuildUsernamePasswordRequest(string username, string password) { }

	internal void CancelScheduledExpiration() { }

	internal void CancelScheduledRefresh() { }

	private void ChangeState(AuthenticationState newState) { }

	public override void ClearSessionToken() { }

	private void CompleteSignIn(string accessToken, string sessionToken, bool enableRefresh = true, User user = null, string lastNotificationDate = null) { }

	internal void CompleteSignIn(SignInResponse response, bool enableRefresh = true) { }

	[AsyncStateMachine(typeof(<ConfirmCodeAsync>d__20))]
	public override Task ConfirmCodeAsync(string code, string idProvider = null, string externalToken = null) { }

	private Task DelayWithScheduler(double delaySeconds) { }

	[AsyncStateMachine(typeof(<DeleteAccountAsync>d__121))]
	public override Task DeleteAccountAsync() { }

	internal void ExecuteScheduledExpiration() { }

	internal void ExecuteScheduledRefresh() { }

	internal void Expire() { }

	[AsyncStateMachine(typeof(<GenerateSignInCodeAsync>d__15))]
	public override Task<SignInCodeInfo> GenerateSignInCodeAsync(string identifier = null) { }

	public override string get_AccessToken() { }

	[CompilerGenerated]
	internal AccessTokenComponent get_AccessTokenComponent() { }

	[CompilerGenerated]
	internal string get_CodeLinkSessionId() { }

	[CompilerGenerated]
	internal string get_CodeVerifier() { }

	[CompilerGenerated]
	internal IEnvironments get_EnvironmentComponent() { }

	[CompilerGenerated]
	internal EnvironmentIdComponent get_EnvironmentIdComponent() { }

	[CompilerGenerated]
	internal IAuthenticationExceptionHandler get_ExceptionHandler() { }

	[CompilerGenerated]
	internal Nullable<Int64> get_ExpirationActionId() { }

	public override bool get_IsAuthorized() { }

	public override bool get_IsExpired() { }

	public override bool get_IsSignedIn() { }

	[CompilerGenerated]
	public override string get_LastNotificationDate() { }

	[CompilerGenerated]
	internal IAuthenticationNetworkClient get_NetworkClient() { }

	public override List<Notification> get_Notifications() { }

	public override string get_PlayerId() { }

	[CompilerGenerated]
	internal PlayerIdComponent get_PlayerIdComponent() { }

	[CompilerGenerated]
	public override PlayerInfo get_PlayerInfo() { }

	public override string get_PlayerName() { }

	[CompilerGenerated]
	internal PlayerNameComponent get_PlayerNameComponent() { }

	[CompilerGenerated]
	internal IPlayerNamesApi get_PlayerNamesApi() { }

	public override string get_Profile() { }

	[CompilerGenerated]
	internal Nullable<Int64> get_RefreshActionId() { }

	[CompilerGenerated]
	internal SessionTokenComponent get_SessionTokenComponent() { }

	public override bool get_SessionTokenExists() { }

	[CompilerGenerated]
	internal IAuthenticationSettings get_Settings() { }

	[CompilerGenerated]
	internal AuthenticationState get_State() { }

	[AsyncStateMachine(typeof(<GetNotificationsAsync>d__178))]
	public override Task<List`1<Notification>> GetNotificationsAsync() { }

	[AsyncStateMachine(typeof(<GetPlayerInfoAsync>d__125))]
	public override Task<PlayerInfo> GetPlayerInfoAsync() { }

	[AsyncStateMachine(typeof(<GetPlayerNameAsync>d__181))]
	public override Task<String> GetPlayerNameAsync(bool autoGenerate = true) { }

	[AsyncStateMachine(typeof(<GetSignInCodeInfoAsync>d__19))]
	public override Task<SignInCodeInfo> GetSignInCodeInfoAsync(string code) { }

	[AsyncStateMachine(typeof(<HandleSignInRequestAsync>d__127))]
	internal Task HandleSignInRequestAsync(Func<Task`1<SignInResponse>> signInRequest, bool enableRefresh = true) { }

	private void HandleStateChanged(AuthenticationState oldState, AuthenticationState newState) { }

	[AsyncStateMachine(typeof(<HandleUpdatePasswordRequestAsync>d__191))]
	internal Task HandleUpdatePasswordRequestAsync(Func<Task`1<SignInResponse>> updatePasswordRequest, bool enableRefresh = true) { }

	public override Task LinkWithAppleAsync(string idToken, LinkOptions options = null) { }

	public override Task LinkWithAppleGameCenterAsync(string signature, string teamPlayerId, string publicKeyURL, string salt, ulong timestamp, LinkOptions options = null) { }

	[AsyncStateMachine(typeof(<LinkWithExternalTokenAsync>d__173))]
	internal Task LinkWithExternalTokenAsync(string idProvider, LinkWithExternalTokenRequest request) { }

	public override Task LinkWithFacebookAsync(string accessToken, LinkOptions options = null) { }

	public override Task LinkWithGoogleAsync(string idToken, LinkOptions options = null) { }

	public override Task LinkWithGooglePlayGamesAsync(string authCode, LinkOptions options = null) { }

	public override Task LinkWithOculusAsync(string nonce, string userId, LinkOptions options = null) { }

	public override Task LinkWithOpenIdConnectAsync(string idProviderName, string idToken, LinkOptions options = null) { }

	public override Task LinkWithSteamAsync(string sessionTicket, string identity, string appId, LinkOptions options = null) { }

	public override Task LinkWithSteamAsync(string sessionTicket, string identity, LinkOptions options = null) { }

	[Obsolete("This method is deprecated as of version 2.7.1. Please use the LinkWithSteamAsync method with the 'identity' parameter for better security.")]
	public override Task LinkWithSteamAsync(string sessionTicket, LinkOptions options = null) { }

	public override Task LinkWithUnityAsync(string token, LinkOptions options = null) { }

	internal void MigrateCache() { }

	private void OnPlayerIdChanged(string playerId) { }

	[AsyncStateMachine(typeof(<PollForCodeConfirmationAsync>d__17))]
	private Task<SignInResponse> PollForCodeConfirmationAsync(SignInWithCodeRequest request, CancellationToken cancellationToken) { }

	public override void ProcessAuthenticationTokens(string accessToken, string sessionToken = null) { }

	internal Task RefreshAccessTokenAsync() { }

	[CompilerGenerated]
	public override void remove_Expired(Action value) { }

	[CompilerGenerated]
	public override void remove_SignedIn(Action value) { }

	[CompilerGenerated]
	public override void remove_SignedOut(Action value) { }

	[CompilerGenerated]
	public override void remove_SignInCodeExpired(Action value) { }

	[CompilerGenerated]
	public override void remove_SignInCodeReceived(Action<SignInCodeInfo> value) { }

	[CompilerGenerated]
	public override void remove_SignInFailed(Action<RequestFailedException> value) { }

	[CompilerGenerated]
	internal void remove_StateChanged(Action<AuthenticationState, AuthenticationState> value) { }

	[CompilerGenerated]
	public void remove_UpdatePasswordFailed(Action<RequestFailedException> value) { }

	internal void ScheduleExpiration(double delay) { }

	internal void ScheduleRefresh(double delay) { }

	private void SendSignInFailedEvent(RequestFailedException exception, bool forceSignOut) { }

	private void SendUpdatePasswordFailedEvent(RequestFailedException exception, bool forceSignOut) { }

	[CompilerGenerated]
	internal void set_CodeLinkSessionId(string value) { }

	[CompilerGenerated]
	internal void set_CodeVerifier(string value) { }

	[CompilerGenerated]
	internal void set_ExceptionHandler(IAuthenticationExceptionHandler value) { }

	[CompilerGenerated]
	internal void set_ExpirationActionId(Nullable<Int64> value) { }

	[CompilerGenerated]
	private void set_LastNotificationDate(string value) { }

	[CompilerGenerated]
	internal void set_NetworkClient(IAuthenticationNetworkClient value) { }

	[CompilerGenerated]
	internal void set_PlayerInfo(PlayerInfo value) { }

	[CompilerGenerated]
	internal void set_PlayerNamesApi(IPlayerNamesApi value) { }

	[CompilerGenerated]
	internal void set_RefreshActionId(Nullable<Int64> value) { }

	[CompilerGenerated]
	internal void set_State(AuthenticationState value) { }

	public override Task SignInAnonymouslyAsync(SignInOptions options = null) { }

	public override Task SignInWithAppleAsync(string idToken, SignInOptions options = null) { }

	public override Task SignInWithAppleGameCenterAsync(string signature, string teamPlayerId, string publicKeyURL, string salt, ulong timestamp, SignInOptions options = null) { }

	[AsyncStateMachine(typeof(<SignInWithCodeAsync>d__16))]
	public override Task SignInWithCodeAsync(bool usePolling = false, CancellationToken cancellationToken = null) { }

	internal Task SignInWithExternalTokenAsync(string idProvider, SignInWithExternalTokenRequest request, bool enableRefresh = true) { }

	public override Task SignInWithFacebookAsync(string accessToken, SignInOptions options = null) { }

	public override Task SignInWithGoogleAsync(string idToken, SignInOptions options = null) { }

	public override Task SignInWithGooglePlayGamesAsync(string authCode, SignInOptions options = null) { }

	public override Task SignInWithOculusAsync(string nonce, string userId, SignInOptions options = null) { }

	public override Task SignInWithOpenIdConnectAsync(string idProviderName, string idToken, SignInOptions options = null) { }

	public override Task SignInWithSteamAsync(string sessionTicket, string identity, string appId, SignInOptions options = null) { }

	[Obsolete("This method is deprecated as of version 2.7.1. Please use the SignInWithSteamAsync method with the 'identity' parameter for better security.")]
	public override Task SignInWithSteamAsync(string sessionTicket, SignInOptions options = null) { }

	public override Task SignInWithSteamAsync(string sessionTicket, string identity, SignInOptions options = null) { }

	public override Task SignInWithUnityAsync(string token, SignInOptions options = null) { }

	public override Task SignInWithUsernamePasswordAsync(string username, string password) { }

	internal Task SignInWithUsernamePasswordRequestAsync(UsernamePasswordRequest request, bool enableRefresh = true) { }

	public override void SignOut(bool clearCredentials = false) { }

	public override Task SignUpWithUsernamePasswordAsync(string username, string password) { }

	internal Task SignUpWithUsernamePasswordRequestAsync(UsernamePasswordRequest request, bool enableRefresh = true) { }

	[AsyncStateMachine(typeof(<StartRefreshAsync>d__128))]
	internal Task StartRefreshAsync(string sessionToken) { }

	public override void SwitchProfile(string profile) { }

	public override Task UnlinkAppleAsync() { }

	public override Task UnlinkAppleGameCenterAsync() { }

	[AsyncStateMachine(typeof(<UnlinkExternalTokenAsync>d__174))]
	internal Task UnlinkExternalTokenAsync(string idProvider) { }

	public override Task UnlinkFacebookAsync() { }

	public override Task UnlinkGoogleAsync() { }

	public override Task UnlinkGooglePlayGamesAsync() { }

	public override Task UnlinkOculusAsync() { }

	public override Task UnlinkOpenIdConnectAsync(string idProviderName) { }

	public override Task UnlinkSteamAsync() { }

	public override Task UnlinkUnityAsync() { }

	public override Task UpdatePasswordAsync(string currentPassword, string newPassword) { }

	internal Task UpdatePasswordRequestAsync(UpdatePasswordRequest request, bool enableRefresh = true) { }

	[AsyncStateMachine(typeof(<UpdatePlayerNameAsync>d__182))]
	public override Task<String> UpdatePlayerNameAsync(string playerName) { }

	private void ValidateAccessToken(string accessToken) { }

	private bool ValidateCredentials(string username, string password) { }

	private bool ValidateOpenIdConnectIdProviderName(string idProviderName) { }

	private void ValidateSteamIdentity(string identity) { }

}

