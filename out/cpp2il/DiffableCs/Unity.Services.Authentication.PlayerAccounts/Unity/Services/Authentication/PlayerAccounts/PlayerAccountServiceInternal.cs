namespace Unity.Services.Authentication.PlayerAccounts;

internal class PlayerAccountServiceInternal : IPlayerAccountService
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass54_0
	{
		public PlayerAccountServiceInternal <>4__this; //Field offset: 0x10
		public string refreshRequest; //Field offset: 0x18

		public <>c__DisplayClass54_0() { }

		internal Task<SignInResponse> <RefreshTokenAsync>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass59_0
	{
		public PlayerAccountServiceInternal <>4__this; //Field offset: 0x10
		public string signInRequestBody; //Field offset: 0x18

		public <>c__DisplayClass59_0() { }

		internal Task<SignInResponse> <SignInRequestAsync>b__0() { }

	}

	[CompilerGenerated]
	private struct <HandleSignInRequestAsync>d__60 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public PlayerAccountServiceInternal <>4__this; //Field offset: 0x20
		public Func<Task`1<SignInResponse>> signInRequest; //Field offset: 0x28
		private TaskAwaiter<SignInResponse> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <StartSignInAsync>d__53 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public PlayerAccountServiceInternal <>4__this; //Field offset: 0x20
		public bool isSigningUp; //Field offset: 0x28
		private TaskAwaiter <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	private const string k_AccountPortalUrl = "https://player-account.unity.com"; //Field offset: 0x0
	private const string k_AuthUrl = "https://player-login.unity.com/v1/oauth2/auth"; //Field offset: 0x0
	private const string k_TokenUrl = "https://player-login.unity.com/v1/oauth2/token"; //Field offset: 0x0
	private const string k_CodeChallengeMethod = "S256"; //Field offset: 0x0
	[CompilerGenerated]
	private Action SignedIn; //Field offset: 0x10
	[CompilerGenerated]
	private Action SignedOut; //Field offset: 0x18
	[CompilerGenerated]
	private Action<RequestFailedException> SignInFailed; //Field offset: 0x20
	[CompilerGenerated]
	private string <AccessToken>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private string <IdToken>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private string <RefreshToken>k__BackingField; //Field offset: 0x38
	[CompilerGenerated]
	private IdToken <IdTokenClaims>k__BackingField; //Field offset: 0x40
	[CompilerGenerated]
	private PlayerAccountState <SignInState>k__BackingField; //Field offset: 0x48
	[CompilerGenerated]
	private string <RedirectUri>k__BackingField; //Field offset: 0x50
	[CompilerGenerated]
	private string <CodeVerifier>k__BackingField; //Field offset: 0x58
	private readonly ICloudProjectId m_CloudProjectId; //Field offset: 0x60
	private readonly IBrowserUtils m_BrowserUtils; //Field offset: 0x68
	private readonly IJwtDecoder m_JwtDecoder; //Field offset: 0x70
	private readonly INetworkHandler m_NetworkingClient; //Field offset: 0x78
	private readonly UnityPlayerAccountSettings m_Settings; //Field offset: 0x80

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

	public override event Action<RequestFailedException> SignInFailed
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public internal override string AccessToken
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	public override string AccountPortalUrl
	{
		 get { } //Length: 64
	}

	internal string ClientId
	{
		internal get { } //Length: 16
	}

	internal string CodeVerifier
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	public internal override string IdToken
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	public internal override IdToken IdTokenClaims
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	public override bool IsSignedIn
	{
		 get { } //Length: 20
	}

	internal string RedirectUri
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	public internal string RefreshToken
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	internal PlayerAccountState SignInState
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	internal PlayerAccountServiceInternal(UnityPlayerAccountSettings settings, ICloudProjectId cloudProjectId, IJwtDecoder jwtDecoder, INetworkHandler networkingClient) { }

	[CompilerGenerated]
	public override void add_SignedIn(Action value) { }

	[CompilerGenerated]
	public override void add_SignedOut(Action value) { }

	[CompilerGenerated]
	public override void add_SignInFailed(Action<RequestFailedException> value) { }

	private string BuildAuthorizationRequestUrl(bool isSigningUp) { }

	internal void CompleteSignIn(SignInResponse signInResponse) { }

	[CompilerGenerated]
	public override string get_AccessToken() { }

	public override string get_AccountPortalUrl() { }

	internal string get_ClientId() { }

	[CompilerGenerated]
	internal string get_CodeVerifier() { }

	[CompilerGenerated]
	public override string get_IdToken() { }

	[CompilerGenerated]
	public override IdToken get_IdTokenClaims() { }

	public override bool get_IsSignedIn() { }

	[CompilerGenerated]
	internal string get_RedirectUri() { }

	[CompilerGenerated]
	public string get_RefreshToken() { }

	[CompilerGenerated]
	internal PlayerAccountState get_SignInState() { }

	[AsyncStateMachine(typeof(<HandleSignInRequestAsync>d__60))]
	private Task HandleSignInRequestAsync(Func<Task`1<SignInResponse>> signInRequest) { }

	private void OnAuthCodeReceived(string code) { }

	private void OnDeepLinkActivated(string url) { }

	public override Task RefreshTokenAsync() { }

	[CompilerGenerated]
	public override void remove_SignedIn(Action value) { }

	[CompilerGenerated]
	public override void remove_SignedOut(Action value) { }

	[CompilerGenerated]
	public override void remove_SignInFailed(Action<RequestFailedException> value) { }

	private void SendSignInFailedEvent(RequestFailedException exception, bool forceSignOut) { }

	[CompilerGenerated]
	internal void set_AccessToken(string value) { }

	[CompilerGenerated]
	internal void set_CodeVerifier(string value) { }

	[CompilerGenerated]
	internal void set_IdToken(string value) { }

	[CompilerGenerated]
	internal void set_IdTokenClaims(IdToken value) { }

	[CompilerGenerated]
	internal void set_RedirectUri(string value) { }

	[CompilerGenerated]
	internal void set_RefreshToken(string value) { }

	[CompilerGenerated]
	internal void set_SignInState(PlayerAccountState value) { }

	private Task SignInRequestAsync(string code, string codeVerifier, string redirectUri) { }

	public override void SignOut() { }

	[AsyncStateMachine(typeof(<StartSignInAsync>d__53))]
	public override Task StartSignInAsync(bool isSigningUp = false) { }

}

