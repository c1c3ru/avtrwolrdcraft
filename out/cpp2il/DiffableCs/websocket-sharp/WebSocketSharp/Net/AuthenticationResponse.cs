namespace WebSocketSharp.Net;

internal class AuthenticationResponse : AuthenticationBase
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<String, Boolean> <>9__24_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <initAsDigest>b__24_0(string qop) { }

	}

	private uint _nonceCount; //Field offset: 0x20

	public string Cnonce
	{
		 get { } //Length: 84
	}

	public string Nc
	{
		 get { } //Length: 84
	}

	internal uint NonceCount
	{
		internal get { } //Length: 16
	}

	public string Password
	{
		 get { } //Length: 84
	}

	public string Response
	{
		 get { } //Length: 84
	}

	public string Uri
	{
		 get { } //Length: 84
	}

	public string UserName
	{
		 get { } //Length: 84
	}

	private AuthenticationResponse(AuthenticationSchemes scheme, NameValueCollection parameters) { }

	internal AuthenticationResponse(NetworkCredential credentials) { }

	internal AuthenticationResponse(AuthenticationChallenge challenge, NetworkCredential credentials, uint nonceCount) { }

	internal AuthenticationResponse(AuthenticationSchemes scheme, NameValueCollection parameters, NetworkCredential credentials, uint nonceCount) { }

	private static string createA1(string username, string password, string realm, string nonce, string cnonce) { }

	private static string createA1(string username, string password, string realm) { }

	private static string createA2(string method, string uri, string entity) { }

	private static string createA2(string method, string uri) { }

	internal static string CreateRequestDigest(NameValueCollection parameters) { }

	public string get_Cnonce() { }

	public string get_Nc() { }

	internal uint get_NonceCount() { }

	public string get_Password() { }

	public string get_Response() { }

	public string get_Uri() { }

	public string get_UserName() { }

	private static string hash(string value) { }

	private void initAsDigest() { }

	internal static AuthenticationResponse Parse(string value) { }

	internal static NameValueCollection ParseBasicCredentials(string value) { }

	internal virtual string ToBasicString() { }

	internal virtual string ToDigestString() { }

	public IIdentity ToIdentity() { }

}

