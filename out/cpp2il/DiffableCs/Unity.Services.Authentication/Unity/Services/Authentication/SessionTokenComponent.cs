namespace Unity.Services.Authentication;

internal class SessionTokenComponent
{
	private const string k_CacheKey = "session_token"; //Field offset: 0x0
	private string m_SessionToken; //Field offset: 0x10
	private readonly IAuthenticationCache m_Cache; //Field offset: 0x18

	internal string SessionToken
	{
		internal get { } //Length: 8
		internal set { } //Length: 4
	}

	internal SessionTokenComponent(IAuthenticationCache cache) { }

	internal void Clear() { }

	internal string get_SessionToken() { }

	private string GetSessionToken() { }

	internal void Migrate() { }

	internal void Refresh() { }

	internal void set_SessionToken(string value) { }

	private void SetSessionToken(string sessionToken) { }

}

