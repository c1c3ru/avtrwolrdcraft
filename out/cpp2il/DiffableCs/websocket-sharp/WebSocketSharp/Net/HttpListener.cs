namespace WebSocketSharp.Net;

public sealed class HttpListener : IDisposable
{
	private static readonly string _defaultRealm; //Field offset: 0x0
	private AuthenticationSchemes _authSchemes; //Field offset: 0x10
	private Func<HttpListenerRequest, AuthenticationSchemes> _authSchemeSelector; //Field offset: 0x18
	private string _certFolderPath; //Field offset: 0x20
	private Queue<HttpListenerContext> _contextQueue; //Field offset: 0x28
	private LinkedList<HttpListenerContext> _contextRegistry; //Field offset: 0x30
	private object _contextRegistrySync; //Field offset: 0x38
	private bool _disposed; //Field offset: 0x40
	private bool _ignoreWriteExceptions; //Field offset: 0x41
	private bool _listening; //Field offset: 0x42
	private Logger _log; //Field offset: 0x48
	private string _objectName; //Field offset: 0x50
	private HttpListenerPrefixCollection _prefixes; //Field offset: 0x58
	private string _realm; //Field offset: 0x60
	private bool _reuseAddress; //Field offset: 0x68
	private ServerSslConfiguration _sslConfig; //Field offset: 0x70
	private Func<IIdentity, NetworkCredential> _userCredFinder; //Field offset: 0x78
	private Queue<HttpListenerAsyncResult> _waitQueue; //Field offset: 0x80

	public AuthenticationSchemes AuthenticationSchemes
	{
		 get { } //Length: 92
		 set { } //Length: 92
	}

	public Func<HttpListenerRequest, AuthenticationSchemes> AuthenticationSchemeSelector
	{
		 get { } //Length: 92
		 set { } //Length: 92
	}

	public string CertificateFolderPath
	{
		 get { } //Length: 92
		 set { } //Length: 92
	}

	public bool IgnoreWriteExceptions
	{
		 get { } //Length: 92
		 set { } //Length: 96
	}

	public bool IsListening
	{
		 get { } //Length: 24
	}

	public static bool IsSupported
	{
		 get { } //Length: 8
	}

	public Logger Log
	{
		 get { } //Length: 8
	}

	public HttpListenerPrefixCollection Prefixes
	{
		 get { } //Length: 92
	}

	public string Realm
	{
		 get { } //Length: 92
		 set { } //Length: 92
	}

	internal bool ReuseAddress
	{
		internal get { } //Length: 8
		internal set { } //Length: 12
	}

	public ServerSslConfiguration SslConfiguration
	{
		 get { } //Length: 180
	}

	public bool UnsafeConnectionNtlmAuthentication
	{
		 get { } //Length: 56
		 set { } //Length: 56
	}

	public Func<IIdentity, NetworkCredential> UserCredentialsFinder
	{
		 get { } //Length: 92
		 set { } //Length: 92
	}

	private static HttpListener() { }

	public HttpListener() { }

	public void Abort() { }

	internal bool AuthenticateContext(HttpListenerContext context) { }

	private HttpListenerAsyncResult beginGetContext(AsyncCallback callback, object state) { }

	public IAsyncResult BeginGetContext(AsyncCallback callback, object state) { }

	internal void CheckDisposed() { }

	private void cleanupContextQueue(bool force) { }

	private void cleanupContextRegistry() { }

	private void cleanupWaitQueue(string message) { }

	private void close(bool force) { }

	public void Close() { }

	public HttpListenerContext EndGetContext(IAsyncResult asyncResult) { }

	public AuthenticationSchemes get_AuthenticationSchemes() { }

	public Func<HttpListenerRequest, AuthenticationSchemes> get_AuthenticationSchemeSelector() { }

	public string get_CertificateFolderPath() { }

	public bool get_IgnoreWriteExceptions() { }

	public bool get_IsListening() { }

	public static bool get_IsSupported() { }

	public Logger get_Log() { }

	public HttpListenerPrefixCollection get_Prefixes() { }

	public string get_Realm() { }

	internal bool get_ReuseAddress() { }

	public ServerSslConfiguration get_SslConfiguration() { }

	public bool get_UnsafeConnectionNtlmAuthentication() { }

	public Func<IIdentity, NetworkCredential> get_UserCredentialsFinder() { }

	public HttpListenerContext GetContext() { }

	private string getRealm() { }

	internal bool RegisterContext(HttpListenerContext context) { }

	private AuthenticationSchemes selectAuthenticationScheme(HttpListenerRequest request) { }

	public void set_AuthenticationSchemes(AuthenticationSchemes value) { }

	public void set_AuthenticationSchemeSelector(Func<HttpListenerRequest, AuthenticationSchemes> value) { }

	public void set_CertificateFolderPath(string value) { }

	public void set_IgnoreWriteExceptions(bool value) { }

	public void set_Realm(string value) { }

	internal void set_ReuseAddress(bool value) { }

	public void set_UnsafeConnectionNtlmAuthentication(bool value) { }

	public void set_UserCredentialsFinder(Func<IIdentity, NetworkCredential> value) { }

	public void Start() { }

	public void Stop() { }

	private override void System.IDisposable.Dispose() { }

	internal void UnregisterContext(HttpListenerContext context) { }

}

