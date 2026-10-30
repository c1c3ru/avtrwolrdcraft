namespace WebSocketSharp.Net;

internal abstract class AuthenticationBase
{
	private AuthenticationSchemes _scheme; //Field offset: 0x10
	internal NameValueCollection Parameters; //Field offset: 0x18

	public string Algorithm
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

	protected AuthenticationBase(AuthenticationSchemes scheme, NameValueCollection parameters) { }

	internal static string CreateNonceValue() { }

	public string get_Algorithm() { }

	public string get_Nonce() { }

	public string get_Opaque() { }

	public string get_Qop() { }

	public string get_Realm() { }

	public AuthenticationSchemes get_Scheme() { }

	internal static NameValueCollection ParseParameters(string value) { }

	internal abstract string ToBasicString() { }

	internal abstract string ToDigestString() { }

	public virtual string ToString() { }

}

