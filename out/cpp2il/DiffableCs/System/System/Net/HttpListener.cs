namespace System.Net;

public sealed class HttpListener : IDisposable
{
	private MonoTlsProvider tlsProvider; //Field offset: 0x10
	private MonoTlsSettings tlsSettings; //Field offset: 0x18
	private X509Certificate certificate; //Field offset: 0x20
	private AuthenticationSchemes auth_schemes; //Field offset: 0x28
	private HttpListenerPrefixCollection prefixes; //Field offset: 0x30
	private AuthenticationSchemeSelector auth_selector; //Field offset: 0x38
	private string realm; //Field offset: 0x40
	private bool ignore_write_exceptions; //Field offset: 0x48
	private bool listening; //Field offset: 0x49
	private bool disposed; //Field offset: 0x4A
	private readonly object _internalLock; //Field offset: 0x50
	private Hashtable registry; //Field offset: 0x58
	private ArrayList ctx_queue; //Field offset: 0x60
	private ArrayList wait_queue; //Field offset: 0x68
	private Hashtable connections; //Field offset: 0x70
	private ServiceNameStore defaultServiceNames; //Field offset: 0x78
	private ExtendedProtectionPolicy extendedProtectionPolicy; //Field offset: 0x80

	public AuthenticationSchemes AuthenticationSchemes
	{
		 get { } //Length: 8
	}

	public AuthenticationSchemeSelector AuthenticationSchemeSelectorDelegate
	{
		 get { } //Length: 8
	}

	public bool IgnoreWriteExceptions
	{
		 get { } //Length: 8
	}

	public bool IsListening
	{
		 get { } //Length: 8
	}

	public HttpListenerPrefixCollection Prefixes
	{
		 get { } //Length: 24
	}

	public string Realm
	{
		 get { } //Length: 8
	}

	public HttpListener() { }

	internal void AddConnection(HttpConnection cnc) { }

	public IAsyncResult BeginGetContext(AsyncCallback callback, object state) { }

	internal void CheckDisposed() { }

	private void Cleanup(bool close_existing) { }

	private void Close(bool force) { }

	internal SslStream CreateSslStream(Stream innerStream, bool ownsStream, RemoteCertificateValidationCallback callback) { }

	public AuthenticationSchemes get_AuthenticationSchemes() { }

	public AuthenticationSchemeSelector get_AuthenticationSchemeSelectorDelegate() { }

	public bool get_IgnoreWriteExceptions() { }

	public bool get_IsListening() { }

	public HttpListenerPrefixCollection get_Prefixes() { }

	public string get_Realm() { }

	private HttpListenerContext GetContextFromQueue() { }

	internal X509Certificate LoadCertificateAndKey(IPAddress addr, int port) { }

	internal void RegisterContext(HttpListenerContext context) { }

	internal void RemoveConnection(HttpConnection cnc) { }

	internal AuthenticationSchemes SelectAuthenticationScheme(HttpListenerContext context) { }

	public void Start() { }

	private override void System.IDisposable.Dispose() { }

	internal void UnregisterContext(HttpListenerContext context) { }

}

