namespace WebSocketSharp.Net;

internal class AuthenticationChallenge : AuthenticationBase
{

	public string Domain
	{
		 get { } //Length: 84
	}

	public string Stale
	{
		 get { } //Length: 84
	}

	private AuthenticationChallenge(AuthenticationSchemes scheme, NameValueCollection parameters) { }

	internal AuthenticationChallenge(AuthenticationSchemes scheme, string realm) { }

	internal static AuthenticationChallenge CreateBasicChallenge(string realm) { }

	internal static AuthenticationChallenge CreateDigestChallenge(string realm) { }

	public string get_Domain() { }

	public string get_Stale() { }

	internal static AuthenticationChallenge Parse(string value) { }

	internal virtual string ToBasicString() { }

	internal virtual string ToDigestString() { }

}

