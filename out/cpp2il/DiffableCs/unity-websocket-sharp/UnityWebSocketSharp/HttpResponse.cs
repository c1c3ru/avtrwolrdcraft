namespace UnityWebSocketSharp;

internal class HttpResponse : HttpBase
{
	private int _code; //Field offset: 0x30
	private string _reason; //Field offset: 0x38

	public bool CloseConnection
	{
		 get { } //Length: 140
	}

	public CookieCollection Cookies
	{
		 get { } //Length: 92
	}

	public bool IsProxyAuthenticationRequired
	{
		 get { } //Length: 16
	}

	public bool IsRedirect
	{
		 get { } //Length: 20
	}

	public bool IsSuccess
	{
		 get { } //Length: 20
	}

	public bool IsUnauthorized
	{
		 get { } //Length: 16
	}

	public bool IsWebSocketResponse
	{
		 get { } //Length: 208
	}

	public virtual string MessageHeader
	{
		 get { } //Length: 52
	}

	public string Reason
	{
		 get { } //Length: 8
	}

	public int StatusCode
	{
		 get { } //Length: 8
	}

	internal string StatusLine
	{
		internal get { } //Length: 572
	}

	private HttpResponse(int code, string reason, Version version, NameValueCollection headers) { }

	internal HttpResponse(int code) { }

	internal HttpResponse(HttpStatusCode code) { }

	internal HttpResponse(int code, string reason) { }

	internal HttpResponse(HttpStatusCode code, string reason) { }

	internal static HttpResponse CreateCloseResponse(HttpStatusCode code) { }

	internal static HttpResponse CreateUnauthorizedResponse(string challenge) { }

	internal static HttpResponse CreateWebSocketHandshakeResponse() { }

	public bool get_CloseConnection() { }

	public CookieCollection get_Cookies() { }

	public bool get_IsProxyAuthenticationRequired() { }

	public bool get_IsRedirect() { }

	public bool get_IsSuccess() { }

	public bool get_IsUnauthorized() { }

	public bool get_IsWebSocketResponse() { }

	public virtual string get_MessageHeader() { }

	public string get_Reason() { }

	public int get_StatusCode() { }

	internal string get_StatusLine() { }

	internal static HttpResponse Parse(String[] messageHeader) { }

	internal static HttpResponse ReadResponse(Stream stream, int millisecondsTimeout) { }

	public void SetCookies(CookieCollection cookies) { }

}

