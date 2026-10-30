namespace WebSocketSharp;

internal class HttpRequest : HttpBase
{
	private CookieCollection _cookies; //Field offset: 0x28
	private string _method; //Field offset: 0x30
	private string _uri; //Field offset: 0x38

	public AuthenticationResponse AuthenticationResponse
	{
		 get { } //Length: 124
	}

	public CookieCollection Cookies
	{
		 get { } //Length: 132
	}

	public string HttpMethod
	{
		 get { } //Length: 8
	}

	public bool IsWebSocketRequest
	{
		 get { } //Length: 240
	}

	public string RequestUri
	{
		 get { } //Length: 8
	}

	private HttpRequest(string method, string uri, Version version, NameValueCollection headers) { }

	internal HttpRequest(string method, string uri) { }

	internal static HttpRequest CreateConnectRequest(Uri uri) { }

	internal static HttpRequest CreateWebSocketRequest(Uri uri) { }

	public AuthenticationResponse get_AuthenticationResponse() { }

	public CookieCollection get_Cookies() { }

	public string get_HttpMethod() { }

	public bool get_IsWebSocketRequest() { }

	public string get_RequestUri() { }

	internal HttpResponse GetResponse(Stream stream, int millisecondsTimeout) { }

	internal static HttpRequest Parse(String[] headerParts) { }

	internal static HttpRequest Read(Stream stream, int millisecondsTimeout) { }

	public void SetCookies(CookieCollection cookies) { }

	public virtual string ToString() { }

}

