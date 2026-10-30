namespace UnityWebSocketSharp.Server;

internal class HttpServer
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass83_0
	{
		public HttpListenerContext ctx; //Field offset: 0x10
		public HttpServer <>4__this; //Field offset: 0x18

		public <>c__DisplayClass83_0() { }

		internal void <receiveRequest>b__0(object state) { }

	}

	private IPAddress _address; //Field offset: 0x10
	private string _docRootPath; //Field offset: 0x18
	private string _hostname; //Field offset: 0x20
	private HttpListener _listener; //Field offset: 0x28
	private Logger _log; //Field offset: 0x30
	private int _port; //Field offset: 0x38
	private Thread _receiveThread; //Field offset: 0x40
	private bool _secure; //Field offset: 0x48
	private WebSocketServiceManager _services; //Field offset: 0x50
	private ServerState _state; //Field offset: 0x58
	private object _sync; //Field offset: 0x60
	[CompilerGenerated]
	private EventHandler<HttpRequestEventArgs> OnConnect; //Field offset: 0x68
	[CompilerGenerated]
	private EventHandler<HttpRequestEventArgs> OnDelete; //Field offset: 0x70
	[CompilerGenerated]
	private EventHandler<HttpRequestEventArgs> OnGet; //Field offset: 0x78
	[CompilerGenerated]
	private EventHandler<HttpRequestEventArgs> OnHead; //Field offset: 0x80
	[CompilerGenerated]
	private EventHandler<HttpRequestEventArgs> OnOptions; //Field offset: 0x88
	[CompilerGenerated]
	private EventHandler<HttpRequestEventArgs> OnPost; //Field offset: 0x90
	[CompilerGenerated]
	private EventHandler<HttpRequestEventArgs> OnPut; //Field offset: 0x98
	[CompilerGenerated]
	private EventHandler<HttpRequestEventArgs> OnTrace; //Field offset: 0xA0

	public event EventHandler<HttpRequestEventArgs> OnConnect
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event EventHandler<HttpRequestEventArgs> OnDelete
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event EventHandler<HttpRequestEventArgs> OnGet
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event EventHandler<HttpRequestEventArgs> OnHead
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event EventHandler<HttpRequestEventArgs> OnOptions
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event EventHandler<HttpRequestEventArgs> OnPost
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event EventHandler<HttpRequestEventArgs> OnPut
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event EventHandler<HttpRequestEventArgs> OnTrace
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public IPAddress Address
	{
		 get { } //Length: 8
	}

	public AuthenticationSchemes AuthenticationSchemes
	{
		 get { } //Length: 28
		 set { } //Length: 252
	}

	public string DocumentRootPath
	{
		 get { } //Length: 8
		 set { } //Length: 968
	}

	public bool IsListening
	{
		 get { } //Length: 28
	}

	public bool IsSecure
	{
		 get { } //Length: 8
	}

	public bool KeepClean
	{
		 get { } //Length: 36
		 set { } //Length: 28
	}

	public Logger Log
	{
		 get { } //Length: 8
	}

	public int Port
	{
		 get { } //Length: 8
	}

	public string Realm
	{
		 get { } //Length: 28
		 set { } //Length: 252
	}

	public bool ReuseAddress
	{
		 get { } //Length: 28
		 set { } //Length: 248
	}

	public ServerSslConfiguration SslConfiguration
	{
		 get { } //Length: 108
	}

	public Func<IIdentity, NetworkCredential> UserCredentialsFinder
	{
		 get { } //Length: 28
		 set { } //Length: 252
	}

	public TimeSpan WaitTime
	{
		 get { } //Length: 28
		 set { } //Length: 24
	}

	public WebSocketServiceManager WebSocketServices
	{
		 get { } //Length: 8
	}

	public HttpServer() { }

	public HttpServer(int port) { }

	public HttpServer(string url) { }

	public HttpServer(int port, bool secure) { }

	public HttpServer(IPAddress address, int port) { }

	public HttpServer(IPAddress address, int port, bool secure) { }

	private void abort() { }

	[CompilerGenerated]
	public void add_OnConnect(EventHandler<HttpRequestEventArgs> value) { }

	[CompilerGenerated]
	public void add_OnDelete(EventHandler<HttpRequestEventArgs> value) { }

	[CompilerGenerated]
	public void add_OnGet(EventHandler<HttpRequestEventArgs> value) { }

	[CompilerGenerated]
	public void add_OnHead(EventHandler<HttpRequestEventArgs> value) { }

	[CompilerGenerated]
	public void add_OnOptions(EventHandler<HttpRequestEventArgs> value) { }

	[CompilerGenerated]
	public void add_OnPost(EventHandler<HttpRequestEventArgs> value) { }

	[CompilerGenerated]
	public void add_OnPut(EventHandler<HttpRequestEventArgs> value) { }

	[CompilerGenerated]
	public void add_OnTrace(EventHandler<HttpRequestEventArgs> value) { }

	public void AddWebSocketService(string path) { }

	public void AddWebSocketService(string path, Action<TBehavior> initializer) { }

	private bool canSet() { }

	private bool checkCertificate(out string message) { }

	private static HttpListener createListener(string hostname, int port, bool secure) { }

	public IPAddress get_Address() { }

	public AuthenticationSchemes get_AuthenticationSchemes() { }

	public string get_DocumentRootPath() { }

	public bool get_IsListening() { }

	public bool get_IsSecure() { }

	public bool get_KeepClean() { }

	public Logger get_Log() { }

	public int get_Port() { }

	public string get_Realm() { }

	public bool get_ReuseAddress() { }

	public ServerSslConfiguration get_SslConfiguration() { }

	public Func<IIdentity, NetworkCredential> get_UserCredentialsFinder() { }

	public TimeSpan get_WaitTime() { }

	public WebSocketServiceManager get_WebSocketServices() { }

	private void init(string hostname, IPAddress address, int port, bool secure) { }

	private void processRequest(HttpListenerContext context) { }

	private void processRequest(HttpListenerWebSocketContext context) { }

	private void receiveRequest() { }

	[CompilerGenerated]
	public void remove_OnConnect(EventHandler<HttpRequestEventArgs> value) { }

	[CompilerGenerated]
	public void remove_OnDelete(EventHandler<HttpRequestEventArgs> value) { }

	[CompilerGenerated]
	public void remove_OnGet(EventHandler<HttpRequestEventArgs> value) { }

	[CompilerGenerated]
	public void remove_OnHead(EventHandler<HttpRequestEventArgs> value) { }

	[CompilerGenerated]
	public void remove_OnOptions(EventHandler<HttpRequestEventArgs> value) { }

	[CompilerGenerated]
	public void remove_OnPost(EventHandler<HttpRequestEventArgs> value) { }

	[CompilerGenerated]
	public void remove_OnPut(EventHandler<HttpRequestEventArgs> value) { }

	[CompilerGenerated]
	public void remove_OnTrace(EventHandler<HttpRequestEventArgs> value) { }

	public bool RemoveWebSocketService(string path) { }

	public void set_AuthenticationSchemes(AuthenticationSchemes value) { }

	public void set_DocumentRootPath(string value) { }

	public void set_KeepClean(bool value) { }

	public void set_Realm(string value) { }

	public void set_ReuseAddress(bool value) { }

	public void set_UserCredentialsFinder(Func<IIdentity, NetworkCredential> value) { }

	public void set_WaitTime(TimeSpan value) { }

	private void start() { }

	public void Start() { }

	private void startReceiving() { }

	private void stop(ushort code, string reason) { }

	public void Stop() { }

	private void stopReceiving(int millisecondsTimeout) { }

	private static bool tryCreateUri(string uriString, out Uri result, out string message) { }

}

