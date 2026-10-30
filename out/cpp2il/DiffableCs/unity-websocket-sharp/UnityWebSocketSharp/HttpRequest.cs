namespace UnityWebSocketSharp;

internal class HttpRequest : HttpBase
{
	private CookieCollection _cookies; //Field offset: 0x30
	private string _method; //Field offset: 0x38
	private string _target; //Field offset: 0x40

	public AuthenticationResponse AuthenticationResponse
	{
		 get { } //Length: 124
	}

	public CookieCollection Cookies
	{
		 get { } //Length: 128
	}

	public string HttpMethod
	{
		 get { } //Length: 8
	}

	public bool IsWebSocketRequest
	{
		 get { } //Length: 236
	}

	public virtual string MessageHeader
	{
		 get { } //Length: 52
	}

	internal string RequestLine
	{
		internal get { } //Length: 400
	}

	public string RequestTarget
	{
		 get { } //Length: 8
	}

	private HttpRequest(string method, string target, Version version, NameValueCollection headers) { }

	internal HttpRequest(string method, string target) { }

	internal static HttpRequest CreateConnectRequest(Uri targetUri) { }

	internal static HttpRequest CreateWebSocketHandshakeRequest(Uri targetUri) { }

	public AuthenticationResponse get_AuthenticationResponse() { }

	public CookieCollection get_Cookies() { }

	public string get_HttpMethod() { }

	public bool get_IsWebSocketRequest() { }

	public virtual string get_MessageHeader() { }

	internal string get_RequestLine() { }

	public string get_RequestTarget() { }

	internal HttpResponse GetResponse(Stream stream, int millisecondsTimeout) { }

	internal static HttpRequest Parse(String[] messageHeader) { }

	internal static HttpRequest ReadRequest(Stream stream, int millisecondsTimeout) { }

	public void SetCookies(CookieCollection cookies) { }

}

