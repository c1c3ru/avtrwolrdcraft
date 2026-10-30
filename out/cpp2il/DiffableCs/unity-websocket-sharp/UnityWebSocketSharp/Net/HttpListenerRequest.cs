namespace UnityWebSocketSharp.Net;

internal sealed class HttpListenerRequest
{
	private static readonly Byte[] _100continue; //Field offset: 0x0
	private static readonly Encoding _defaultEncoding; //Field offset: 0x8
	private String[] _acceptTypes; //Field offset: 0x10
	private bool _chunked; //Field offset: 0x18
	private HttpConnection _connection; //Field offset: 0x20
	private Encoding _contentEncoding; //Field offset: 0x28
	private long _contentLength; //Field offset: 0x30
	private HttpListenerContext _context; //Field offset: 0x38
	private CookieCollection _cookies; //Field offset: 0x40
	private WebHeaderCollection _headers; //Field offset: 0x48
	private string _httpMethod; //Field offset: 0x50
	private Stream _inputStream; //Field offset: 0x58
	private Version _protocolVersion; //Field offset: 0x60
	private NameValueCollection _queryString; //Field offset: 0x68
	private string _rawUrl; //Field offset: 0x70
	private Guid _requestTraceIdentifier; //Field offset: 0x78
	private Uri _url; //Field offset: 0x88
	private Uri _urlReferrer; //Field offset: 0x90
	private bool _urlSet; //Field offset: 0x98
	private string _userHostName; //Field offset: 0xA0
	private String[] _userLanguages; //Field offset: 0xA8

	public String[] AcceptTypes
	{
		 get { } //Length: 304
	}

	public int ClientCertificateError
	{
		 get { } //Length: 56
	}

	public Encoding ContentEncoding
	{
		 get { } //Length: 64
	}

	public long ContentLength64
	{
		 get { } //Length: 8
	}

	public string ContentType
	{
		 get { } //Length: 84
	}

	public CookieCollection Cookies
	{
		 get { } //Length: 132
	}

	public bool HasEntityBody
	{
		 get { } //Length: 36
	}

	public NameValueCollection Headers
	{
		 get { } //Length: 8
	}

	public string HttpMethod
	{
		 get { } //Length: 8
	}

	public Stream InputStream
	{
		 get { } //Length: 164
	}

	public bool IsAuthenticated
	{
		 get { } //Length: 36
	}

	public bool IsLocal
	{
		 get { } //Length: 24
	}

	public bool IsSecureConnection
	{
		 get { } //Length: 28
	}

	public bool IsWebSocketRequest
	{
		 get { } //Length: 172
	}

	public bool KeepAlive
	{
		 get { } //Length: 100
	}

	public IPEndPoint LocalEndPoint
	{
		 get { } //Length: 24
	}

	public Version ProtocolVersion
	{
		 get { } //Length: 8
	}

	public NameValueCollection QueryString
	{
		 get { } //Length: 232
	}

	public string RawUrl
	{
		 get { } //Length: 8
	}

	public IPEndPoint RemoteEndPoint
	{
		 get { } //Length: 24
	}

	public Guid RequestTraceIdentifier
	{
		 get { } //Length: 12
	}

	public Uri Url
	{
		 get { } //Length: 188
	}

	public Uri UrlReferrer
	{
		 get { } //Length: 224
	}

	public string UserAgent
	{
		 get { } //Length: 84
	}

	public string UserHostAddress
	{
		 get { } //Length: 40
	}

	public string UserHostName
	{
		 get { } //Length: 8
	}

	public String[] UserLanguages
	{
		 get { } //Length: 264
	}

	private static HttpListenerRequest() { }

	internal HttpListenerRequest(HttpListenerContext context) { }

	internal void AddHeader(string headerField) { }

	public IAsyncResult BeginGetClientCertificate(AsyncCallback requestCallback, object state) { }

	public X509Certificate2 EndGetClientCertificate(IAsyncResult asyncResult) { }

	internal void FinishInitialization() { }

	internal bool FlushInput() { }

	public String[] get_AcceptTypes() { }

	public int get_ClientCertificateError() { }

	public Encoding get_ContentEncoding() { }

	public long get_ContentLength64() { }

	public string get_ContentType() { }

	public CookieCollection get_Cookies() { }

	public bool get_HasEntityBody() { }

	public NameValueCollection get_Headers() { }

	public string get_HttpMethod() { }

	public Stream get_InputStream() { }

	public bool get_IsAuthenticated() { }

	public bool get_IsLocal() { }

	public bool get_IsSecureConnection() { }

	public bool get_IsWebSocketRequest() { }

	public bool get_KeepAlive() { }

	public IPEndPoint get_LocalEndPoint() { }

	public Version get_ProtocolVersion() { }

	public NameValueCollection get_QueryString() { }

	public string get_RawUrl() { }

	public IPEndPoint get_RemoteEndPoint() { }

	public Guid get_RequestTraceIdentifier() { }

	public Uri get_Url() { }

	public Uri get_UrlReferrer() { }

	public string get_UserAgent() { }

	public string get_UserHostAddress() { }

	public string get_UserHostName() { }

	public String[] get_UserLanguages() { }

	public X509Certificate2 GetClientCertificate() { }

	private Encoding getContentEncoding() { }

	internal bool IsUpgradeRequest(string protocol) { }

	internal void SetRequestLine(string requestLine) { }

	public virtual string ToString() { }

}

