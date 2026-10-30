namespace WebSocketSharp.Net;

public class HttpDigestIdentity : GenericIdentity
{
	private NameValueCollection _parameters; //Field offset: 0x88

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

	public string Response
	{
		 get { } //Length: 84
	}

	public string Uri
	{
		 get { } //Length: 84
	}

	internal HttpDigestIdentity(NameValueCollection parameters) { }

	public string get_Algorithm() { }

	public string get_Cnonce() { }

	public string get_Nc() { }

	public string get_Nonce() { }

	public string get_Opaque() { }

	public string get_Qop() { }

	public string get_Realm() { }

	public string get_Response() { }

	public string get_Uri() { }

	internal bool IsValid(string password, string realm, string method, string entity) { }

}

