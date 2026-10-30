namespace Unity.Services.Authentication;

public interface IAuthenticationService
{

	public event Action Expired
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	public event Action SignedIn
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	public event Action SignedOut
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	public event Action SignInCodeExpired
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	public event Action<SignInCodeInfo> SignInCodeReceived
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	public event Action<RequestFailedException> SignInFailed
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	public string AccessToken
	{
		 get { } //Length: 0
	}

	public bool IsAuthorized
	{
		 get { } //Length: 0
	}

	public bool IsExpired
	{
		 get { } //Length: 0
	}

	public bool IsSignedIn
	{
		 get { } //Length: 0
	}

	public string LastNotificationDate
	{
		 get { } //Length: 0
	}

	public List<Notification> Notifications
	{
		 get { } //Length: 0
	}

	public string PlayerId
	{
		 get { } //Length: 0
	}

	public PlayerInfo PlayerInfo
	{
		 get { } //Length: 0
	}

	public string PlayerName
	{
		 get { } //Length: 0
	}

	public string Profile
	{
		 get { } //Length: 0
	}

	public bool SessionTokenExists
	{
		 get { } //Length: 0
	}

	[CompilerGenerated]
	public void add_Expired(Action value) { }

	[CompilerGenerated]
	public void add_SignedIn(Action value) { }

	[CompilerGenerated]
	public void add_SignedOut(Action value) { }

	[CompilerGenerated]
	public void add_SignInCodeExpired(Action value) { }

	[CompilerGenerated]
	public void add_SignInCodeReceived(Action<SignInCodeInfo> value) { }

	[CompilerGenerated]
	public void add_SignInFailed(Action<RequestFailedException> value) { }

	public Task AddUsernamePasswordAsync(string username, string password) { }

	public void ClearSessionToken() { }

	public Task ConfirmCodeAsync(string code, string idProvider = null, string externalToken = null) { }

	public Task DeleteAccountAsync() { }

	public Task<SignInCodeInfo> GenerateSignInCodeAsync(string identifier = null) { }

	public string get_AccessToken() { }

	public bool get_IsAuthorized() { }

	public bool get_IsExpired() { }

	public bool get_IsSignedIn() { }

	public string get_LastNotificationDate() { }

	public List<Notification> get_Notifications() { }

	public string get_PlayerId() { }

	public PlayerInfo get_PlayerInfo() { }

	public string get_PlayerName() { }

	public string get_Profile() { }

	public bool get_SessionTokenExists() { }

	public Task<List`1<Notification>> GetNotificationsAsync() { }

	public Task<PlayerInfo> GetPlayerInfoAsync() { }

	public Task<String> GetPlayerNameAsync(bool autoGenerate = true) { }

	public Task<SignInCodeInfo> GetSignInCodeInfoAsync(string code) { }

	public Task LinkWithAppleAsync(string idToken, LinkOptions options = null) { }

	public Task LinkWithAppleGameCenterAsync(string signature, string teamPlayerId, string publicKeyURL, string salt, ulong timestamp, LinkOptions options = null) { }

	public Task LinkWithFacebookAsync(string accessToken, LinkOptions options = null) { }

	public Task LinkWithGoogleAsync(string idToken, LinkOptions options = null) { }

	public Task LinkWithGooglePlayGamesAsync(string authCode, LinkOptions options = null) { }

	public Task LinkWithOculusAsync(string nonce, string userId, LinkOptions options = null) { }

	public Task LinkWithOpenIdConnectAsync(string idProviderName, string idToken, LinkOptions options = null) { }

	public Task LinkWithSteamAsync(string sessionTicket, string identity, LinkOptions options = null) { }

	public Task LinkWithSteamAsync(string sessionTicket, string identity, string appId, LinkOptions options = null) { }

	[Obsolete("This method is deprecated as of version 2.7.1. Please use the LinkWithSteamAsync method with the 'identity' parameter for better security.")]
	public Task LinkWithSteamAsync(string sessionTicket, LinkOptions options = null) { }

	public Task LinkWithUnityAsync(string token, LinkOptions options = null) { }

	public void ProcessAuthenticationTokens(string accessToken, string sessionToken = null) { }

	[CompilerGenerated]
	public void remove_Expired(Action value) { }

	[CompilerGenerated]
	public void remove_SignedIn(Action value) { }

	[CompilerGenerated]
	public void remove_SignedOut(Action value) { }

	[CompilerGenerated]
	public void remove_SignInCodeExpired(Action value) { }

	[CompilerGenerated]
	public void remove_SignInCodeReceived(Action<SignInCodeInfo> value) { }

	[CompilerGenerated]
	public void remove_SignInFailed(Action<RequestFailedException> value) { }

	public Task SignInAnonymouslyAsync(SignInOptions options = null) { }

	public Task SignInWithAppleAsync(string idToken, SignInOptions options = null) { }

	public Task SignInWithAppleGameCenterAsync(string signature, string teamPlayerId, string publicKeyURL, string salt, ulong timestamp, SignInOptions options = null) { }

	public Task SignInWithCodeAsync(bool usePolling = false, CancellationToken cancellationToken = null) { }

	public Task SignInWithFacebookAsync(string accessToken, SignInOptions options = null) { }

	public Task SignInWithGoogleAsync(string idToken, SignInOptions options = null) { }

	public Task SignInWithGooglePlayGamesAsync(string authCode, SignInOptions options = null) { }

	public Task SignInWithOculusAsync(string nonce, string userId, SignInOptions options = null) { }

	public Task SignInWithOpenIdConnectAsync(string idProviderName, string idToken, SignInOptions options = null) { }

	[Obsolete("This method is deprecated as of version 2.7.1. Please use the SignInWithSteamAsync method with the 'identity' parameter for better security.")]
	public Task SignInWithSteamAsync(string sessionTicket, SignInOptions options = null) { }

	public Task SignInWithSteamAsync(string sessionTicket, string identity, SignInOptions options = null) { }

	public Task SignInWithSteamAsync(string sessionTicket, string identity, string appId, SignInOptions options = null) { }

	public Task SignInWithUnityAsync(string token, SignInOptions options = null) { }

	public Task SignInWithUsernamePasswordAsync(string username, string password) { }

	public void SignOut(bool clearCredentials = false) { }

	public Task SignUpWithUsernamePasswordAsync(string username, string password) { }

	public void SwitchProfile(string profile) { }

	public Task UnlinkAppleAsync() { }

	public Task UnlinkAppleGameCenterAsync() { }

	public Task UnlinkFacebookAsync() { }

	public Task UnlinkGoogleAsync() { }

	public Task UnlinkGooglePlayGamesAsync() { }

	public Task UnlinkOculusAsync() { }

	public Task UnlinkOpenIdConnectAsync(string idProviderName) { }

	public Task UnlinkSteamAsync() { }

	public Task UnlinkUnityAsync() { }

	public Task UpdatePasswordAsync(string currentPassword, string newPassword) { }

	public Task<String> UpdatePlayerNameAsync(string name) { }

}

