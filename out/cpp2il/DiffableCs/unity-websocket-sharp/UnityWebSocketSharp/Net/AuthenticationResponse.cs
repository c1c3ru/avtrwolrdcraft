namespace UnityWebSocketSharp.Net;

internal class AuthenticationResponse
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<String, Boolean> <>9__40_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <initAsDigest>b__40_0(string qop) { }

	}

	private uint _nonceCount; //Field offset: 0x10
	private NameValueCollection _parameters; //Field offset: 0x18
	private AuthenticationSchemes _scheme; //Field offset: 0x20

	public string Algorithm
	{
		 get { } //Length: 84
	}

	public string Cnonce
	{
		 get { } //Length: 84
	}

	public string Nc
	{
		 get { } //Length: 84
	}

	public string Nonce
	{
		 get { } //Length: 84
	}

	internal uint NonceCount
	{
		internal get { } //Length: 16
	}

	public string Opaque
	{
		 get { } //Length: 84
	}

	internal NameValueCollection Parameters
	{
		internal get { } //Length: 8
	}

	public string Password
	{
		 get { } //Length: 84
	}

	public string Qop
	{
		 get { } //Length: 84
	}

	public string Realm
	{
		 get { } //Length: 84
	}

	public string Response
	{
		 get { } //Length: 84
	}

	public AuthenticationSchemes Scheme
	{
		 get { } //Length: 8
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

	private static string createA1(string username, string password, string realm) { }

	private static string createA1(string username, string password, string realm, string nonce, string cnonce) { }

	private static string createA2(string method, string uri, string entity) { }

	private static string createA2(string method, string uri) { }

	internal static string CreateRequestDigest(NameValueCollection parameters) { }

	public string get_Algorithm() { }

	public string get_Cnonce() { }

	public string get_Nc() { }

	public string get_Nonce() { }

	internal uint get_NonceCount() { }

	public string get_Opaque() { }

	internal NameValueCollection get_Parameters() { }

	public string get_Password() { }

	public string get_Qop() { }

	public string get_Realm() { }

	public string get_Response() { }

	public AuthenticationSchemes get_Scheme() { }

	public string get_Uri() { }

	public string get_UserName() { }

	private static string hash(string value) { }

	private void initAsDigest() { }

	internal static AuthenticationResponse Parse(string value) { }

	internal static NameValueCollection ParseBasicCredentials(string value) { }

	internal string ToBasicString() { }

	internal string ToDigestString() { }

	public IIdentity ToIdentity() { }

	public virtual string ToString() { }

}

