namespace Unity.Services.Authentication;

internal class AuthenticationNetworkClient : IAuthenticationNetworkClient
{
	private const string k_PlayerIdReplacement = "{PlayerId}"; //Field offset: 0x0
	private const string k_AnonymousUrlStem = "/v1/authentication/anonymous"; //Field offset: 0x0
	private const string k_SessionTokenUrlStem = "/v1/authentication/session-token"; //Field offset: 0x0
	private const string k_ExternalTokenUrlStem = "/v1/authentication/external-token"; //Field offset: 0x0
	private const string k_LinkExternalTokenUrlStem = "/v1/authentication/link"; //Field offset: 0x0
	private const string k_UnlinkExternalTokenUrlStem = "/v1/authentication/unlink"; //Field offset: 0x0
	private const string k_UsersUrlStem = "/v1/users"; //Field offset: 0x0
	private const string k_UsernamePasswordSignInUrlStem = "/v1/authentication/usernamepassword/sign-in"; //Field offset: 0x0
	private const string k_UsernamePasswordSignUpUrlStem = "/v1/authentication/usernamepassword/sign-up"; //Field offset: 0x0
	private const string k_UpdatePasswordUrlStem = "/v1/authentication/usernamepassword/update-password"; //Field offset: 0x0
	private const string k_GenerateSignInCodeUrlStem = "/v1/authentication/code-link/generate"; //Field offset: 0x0
	private const string k_ConfirmSignInCodeUrlStem = "/v1/authentication/code-link/confirm"; //Field offset: 0x0
	private const string k_GetCodeIdentifierUrlStem = "/v1/authentication/code-link/info"; //Field offset: 0x0
	private const string k_CodeSignInUrlStem = "/v1/authentication/code-link/sign-in"; //Field offset: 0x0
	private const string k_GetNotificationsStem = "/v1/users/{PlayerId}/notifications"; //Field offset: 0x0
	[CompilerGenerated]
	private readonly AccessTokenComponent <AccessTokenComponent>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly ICloudProjectId <CloudProjectIdComponent>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private readonly IEnvironments <EnvironmentComponent>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private readonly INetworkHandler <NetworkHandler>k__BackingField; //Field offset: 0x28
	private readonly string m_AnonymousUrl; //Field offset: 0x30
	private readonly string m_SessionTokenUrl; //Field offset: 0x38
	private readonly string m_ExternalTokenUrl; //Field offset: 0x40
	private readonly string m_LinkExternalTokenUrl; //Field offset: 0x48
	private readonly string m_UnlinkExternalTokenUrl; //Field offset: 0x50
	private readonly string m_UsersUrl; //Field offset: 0x58
	private readonly string m_UsernamePasswordSignInUrl; //Field offset: 0x60
	private readonly string m_UsernamePasswordSignUpUrl; //Field offset: 0x68
	private readonly string m_UpdatePasswordUrl; //Field offset: 0x70
	private readonly string m_GenerateSignInCodeUrl; //Field offset: 0x78
	private readonly string m_ConfirmSignInCodeUrl; //Field offset: 0x80
	private readonly string m_CodeSignInUrl; //Field offset: 0x88
	private readonly string m_GetCodeIdentifierUrl; //Field offset: 0x90
	private readonly string m_GetNotificationsUrl; //Field offset: 0x98
	private readonly Dictionary<String, String> m_CommonHeaders; //Field offset: 0xA0

	private string AccessToken
	{
		private get { } //Length: 28
	}

	internal AccessTokenComponent AccessTokenComponent
	{
		[CompilerGenerated]
		internal get { } //Length: 8
	}

	internal ICloudProjectId CloudProjectIdComponent
	{
		[CompilerGenerated]
		internal get { } //Length: 8
	}

	internal IEnvironments EnvironmentComponent
	{
		[CompilerGenerated]
		internal get { } //Length: 8
	}

	private string EnvironmentName
	{
		private get { } //Length: 160
	}

	internal INetworkHandler NetworkHandler
	{
		[CompilerGenerated]
		internal get { } //Length: 8
	}

	internal AuthenticationNetworkClient(string host, ICloudProjectId cloudProjectId, IEnvironments environment, INetworkHandler networkHandler, AccessTokenComponent accessToken) { }

	public override Task<SignInResponse> AddUsernamePasswordAsync(UsernamePasswordRequest credentials) { }

	public override Task<CodeLinkConfirmResponse> ConfirmCodeAsync(ConfirmSignInCodeRequest request) { }

	private string CreateUserRequestUrl(string user) { }

	public override Task DeleteAccountAsync(string playerId) { }

	public override Task<GenerateCodeResponse> GenerateSignInCodeAsync(GenerateSignInCodeRequest request) { }

	private string get_AccessToken() { }

	[CompilerGenerated]
	internal AccessTokenComponent get_AccessTokenComponent() { }

	[CompilerGenerated]
	internal ICloudProjectId get_CloudProjectIdComponent() { }

	[CompilerGenerated]
	internal IEnvironments get_EnvironmentComponent() { }

	private string get_EnvironmentName() { }

	[CompilerGenerated]
	internal INetworkHandler get_NetworkHandler() { }

	public override Task<CodeLinkInfoResponse> GetCodeIdentifierAsync(CodeLinkInfoRequest request) { }

	private Dictionary<String, String> GetCommonHeaders() { }

	public override Task<GetNotificationsResponse> GetNotificationsAsync(string playerId) { }

	public override Task<PlayerInfoResponse> GetPlayerInfoAsync(string playerId) { }

	public override Task<LinkResponse> LinkWithExternalTokenAsync(string idProvider, LinkWithExternalTokenRequest externalToken) { }

	public override Task<SignInResponse> SignInAnonymouslyAsync() { }

	public override Task<SignInResponse> SignInWithCodeAsync(SignInWithCodeRequest request) { }

	public override Task<SignInResponse> SignInWithExternalTokenAsync(string idProvider, SignInWithExternalTokenRequest externalToken) { }

	public override Task<SignInResponse> SignInWithSessionTokenAsync(string token) { }

	public override Task<SignInResponse> SignInWithUsernamePasswordAsync(UsernamePasswordRequest credentials) { }

	public override Task<SignInResponse> SignUpWithUsernamePasswordAsync(UsernamePasswordRequest credentials) { }

	public override Task<UnlinkResponse> UnlinkExternalTokenAsync(string idProvider, UnlinkRequest request) { }

	public override Task<SignInResponse> UpdatePasswordAsync(UpdatePasswordRequest credentials) { }

	private Dictionary<String, String> WithAccessToken(Dictionary<String, String> headers) { }

	private Dictionary<String, String> WithEnvironment(Dictionary<String, String> headers) { }

}

