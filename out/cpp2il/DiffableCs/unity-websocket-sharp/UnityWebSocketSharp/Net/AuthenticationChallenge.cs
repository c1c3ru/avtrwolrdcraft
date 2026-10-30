namespace UnityWebSocketSharp.Net;

internal class AuthenticationChallenge
{
	private NameValueCollection _parameters; //Field offset: 0x10
	private AuthenticationSchemes _scheme; //Field offset: 0x18

	public string Algorithm
	{
		 get { } //Length: 84
	}

	public string Domain
	{
		 get { } //Length: 84
	}

	public string Nonce
	{
		 get { } //Length: 84
	}

	public string Opaque
	{
		 get { } //Length: 84
	}

	internal NameValueCollection Parameters
	{
		internal get { } //Length: 8
	}

	public string Qop
	{
		 get { } //Length: 84
	}

	public string Realm
	{
		 get { } //Length: 84
	}

	public AuthenticationSchemes Scheme
	{
		 get { } //Length: 8
	}

	public string Stale
	{
		 get { } //Length: 84
	}

	private AuthenticationChallenge(AuthenticationSchemes scheme, NameValueCollection parameters) { }

	internal AuthenticationChallenge(AuthenticationSchemes scheme, string realm) { }

	internal static AuthenticationChallenge CreateBasicChallenge(string realm) { }

	internal static AuthenticationChallenge CreateDigestChallenge(string realm) { }

	internal static string CreateNonceValue() { }

	public string get_Algorithm() { }

	public string get_Domain() { }

	public string get_Nonce() { }

	public string get_Opaque() { }

	internal NameValueCollection get_Parameters() { }

	public string get_Qop() { }

	public string get_Realm() { }

	public AuthenticationSchemes get_Scheme() { }

	public string get_Stale() { }

	internal static AuthenticationChallenge Parse(string value) { }

	internal static NameValueCollection ParseParameters(string value) { }

	internal string ToBasicString() { }

	internal string ToDigestString() { }

	public virtual string ToString() { }

}

