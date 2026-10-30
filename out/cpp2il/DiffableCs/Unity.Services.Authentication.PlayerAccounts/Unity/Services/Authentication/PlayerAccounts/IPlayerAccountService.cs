namespace Unity.Services.Authentication.PlayerAccounts;

public interface IPlayerAccountService
{

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

	public string AccountPortalUrl
	{
		 get { } //Length: 0
	}

	public string IdToken
	{
		 get { } //Length: 0
	}

	public IdToken IdTokenClaims
	{
		 get { } //Length: 0
	}

	public bool IsSignedIn
	{
		 get { } //Length: 0
	}

	[CompilerGenerated]
	public void add_SignedIn(Action value) { }

	[CompilerGenerated]
	public void add_SignedOut(Action value) { }

	[CompilerGenerated]
	public void add_SignInFailed(Action<RequestFailedException> value) { }

	public string get_AccessToken() { }

	public string get_AccountPortalUrl() { }

	public string get_IdToken() { }

	public IdToken get_IdTokenClaims() { }

	public bool get_IsSignedIn() { }

	public Task RefreshTokenAsync() { }

	[CompilerGenerated]
	public void remove_SignedIn(Action value) { }

	[CompilerGenerated]
	public void remove_SignedOut(Action value) { }

	[CompilerGenerated]
	public void remove_SignInFailed(Action<RequestFailedException> value) { }

	public void SignOut() { }

	public Task StartSignInAsync(bool isSigningUp = false) { }

}

