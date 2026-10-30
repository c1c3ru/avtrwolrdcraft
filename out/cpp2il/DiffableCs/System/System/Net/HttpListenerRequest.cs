namespace System.Net;

public sealed class HttpListenerRequest
{
	private static Byte[] _100continue; //Field offset: 0x0
	private static Char[] separators; //Field offset: 0x8
	private String[] accept_types; //Field offset: 0x10
	private long content_length; //Field offset: 0x18
	private bool cl_set; //Field offset: 0x20
	private CookieCollection cookies; //Field offset: 0x28
	private WebHeaderCollection headers; //Field offset: 0x30
	private string method; //Field offset: 0x38
	private Stream input_stream; //Field offset: 0x40
	private Version version; //Field offset: 0x48
	private NameValueCollection query_string; //Field offset: 0x50
	private string raw_url; //Field offset: 0x58
	private Uri url; //Field offset: 0x60
	private Uri referrer; //Field offset: 0x68
	private String[] user_languages; //Field offset: 0x70
	private HttpListenerContext context; //Field offset: 0x78
	private bool is_chunked; //Field offset: 0x80
	private bool ka_set; //Field offset: 0x81
	private bool keep_alive; //Field offset: 0x82

	public bool HasEntityBody
	{
		 get { } //Length: 36
	}

	public NameValueCollection Headers
	{
		 get { } //Length: 8
	}

	public Stream InputStream
	{
		 get { } //Length: 188
	}

	public bool IsSecureConnection
	{
		 get { } //Length: 36
	}

	public bool KeepAlive
	{
		 get { } //Length: 348
	}

	public IPEndPoint LocalEndPoint
	{
		 get { } //Length: 32
	}

	public Version ProtocolVersion
	{
		 get { } //Length: 8
	}

	public Uri Url
	{
		 get { } //Length: 8
	}

	public string UserHostAddress
	{
		 get { } //Length: 32
	}

	public string UserHostName
	{
		 get { } //Length: 84
	}

	private static HttpListenerRequest() { }

	internal HttpListenerRequest(HttpListenerContext context) { }

	internal void AddHeader(string header) { }

	private void CreateQueryString(string query) { }

	internal bool FinishInitialization() { }

	internal bool FlushInput() { }

	public bool get_HasEntityBody() { }

	public NameValueCollection get_Headers() { }

	public Stream get_InputStream() { }

	public bool get_IsSecureConnection() { }

	public bool get_KeepAlive() { }

	public IPEndPoint get_LocalEndPoint() { }

	public Version get_ProtocolVersion() { }

	public Uri get_Url() { }

	public string get_UserHostAddress() { }

	public string get_UserHostName() { }

	private static bool IsPredefinedScheme(string scheme) { }

	private static bool MaybeUri(string s) { }

	internal void SetRequestLine(string req) { }

	internal static string Unquote(string str) { }

}

