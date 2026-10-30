namespace WebSocketSharp;

internal class HttpResponse : HttpBase
{
	private string _code; //Field offset: 0x28
	private string _reason; //Field offset: 0x30

	public CookieCollection Cookies
	{
		 get { } //Length: 96
	}

	public bool HasConnectionClose
	{
		 get { } //Length: 144
	}

	public bool IsProxyAuthenticationRequired
	{
		 get { } //Length: 76
	}

	public bool IsRedirect
	{
		 get { } //Length: 132
	}

	public bool IsUnauthorized
	{
		 get { } //Length: 76
	}

	public bool IsWebSocketResponse
	{
		 get { } //Length: 240
	}

	public string Reason
	{
		 get { } //Length: 8
	}

	public string StatusCode
	{
		 get { } //Length: 8
	}

	private HttpResponse(string code, string reason, Version version, NameValueCollection headers) { }

	internal HttpResponse(HttpStatusCode code) { }

	internal HttpResponse(HttpStatusCode code, string reason) { }

	internal static HttpResponse CreateCloseResponse(HttpStatusCode code) { }

	internal static HttpResponse CreateUnauthorizedResponse(string challenge) { }

	internal static HttpResponse CreateWebSocketResponse() { }

	public CookieCollection get_Cookies() { }

	public bool get_HasConnectionClose() { }

	public bool get_IsProxyAuthenticationRequired() { }

	public bool get_IsRedirect() { }

	public bool get_IsUnauthorized() { }

	public bool get_IsWebSocketResponse() { }

	public string get_Reason() { }

	public string get_StatusCode() { }

	internal static HttpResponse Parse(String[] headerParts) { }

	internal static HttpResponse Read(Stream stream, int millisecondsTimeout) { }

	public void SetCookies(CookieCollection cookies) { }

	public virtual string ToString() { }

}

