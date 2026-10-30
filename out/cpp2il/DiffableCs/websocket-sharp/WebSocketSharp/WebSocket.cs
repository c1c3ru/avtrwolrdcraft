namespace WebSocketSharp;

public class WebSocket : IDisposable
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<String, Boolean> <>9__120_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <checkProtocols>b__120_0(string protocol) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass125_0
	{
		public Action<PayloadData, Boolean, Boolean, Boolean> closer; //Field offset: 0x10

		public <>c__DisplayClass125_0() { }

		internal void <closeAsync>b__0(IAsyncResult ar) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass145_0
	{
		public WebSocket <>4__this; //Field offset: 0x10
		public MessageEventArgs e; //Field offset: 0x18

		public <>c__DisplayClass145_0() { }

		internal void <messages>b__0(object state) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass167_0
	{
		public Func<Opcode, Stream, Boolean> sender; //Field offset: 0x10
		public Action<Boolean> completed; //Field offset: 0x18
		public WebSocket <>4__this; //Field offset: 0x20

		public <>c__DisplayClass167_0() { }

		internal void <sendAsync>b__0(IAsyncResult ar) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass174_0
	{
		public WebSocket <>4__this; //Field offset: 0x10
		public Action receive; //Field offset: 0x18
		public Action<WebSocketFrame> <>9__1; //Field offset: 0x20
		public Action<Exception> <>9__2; //Field offset: 0x28

		public <>c__DisplayClass174_0() { }

		internal void <startReceiving>b__0() { }

		internal void <startReceiving>b__1(WebSocketFrame frame) { }

		internal void <startReceiving>b__2(Exception ex) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass176_0
	{
		public string method; //Field offset: 0x10

		public <>c__DisplayClass176_0() { }

		internal bool <validateSecWebSocketExtensionsServerHeader>b__0(string t) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass177_0
	{
		public string value; //Field offset: 0x10

		public <>c__DisplayClass177_0() { }

		internal bool <validateSecWebSocketProtocolServerHeader>b__0(string p) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass189_0
	{
		public Func<Boolean> acceptor; //Field offset: 0x10
		public WebSocket <>4__this; //Field offset: 0x18

		public <>c__DisplayClass189_0() { }

		internal void <AcceptAsync>b__0(IAsyncResult ar) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass201_0
	{
		public Func<Boolean> connector; //Field offset: 0x10
		public WebSocket <>4__this; //Field offset: 0x18

		public <>c__DisplayClass201_0() { }

		internal void <ConnectAsync>b__0(IAsyncResult ar) { }

	}

	[CompilerGenerated]
	private sealed class <get_Cookies>d__70 : IEnumerable<Cookie>, IEnumerable, IEnumerator<Cookie>, IDisposable, IEnumerator
	{
		private int <>1__state; //Field offset: 0x10
		private Cookie <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x20
		public WebSocket <>4__this; //Field offset: 0x28
		private object <>s__1; //Field offset: 0x30
		private bool <>s__2; //Field offset: 0x38
		private IEnumerator<Cookie> <>s__3; //Field offset: 0x40
		private Cookie <cookie>5__4; //Field offset: 0x48

		private override Cookie System.Collections.Generic.IEnumerator<WebSocketSharp.Net.Cookie>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <get_Cookies>d__70(int <>1__state) { }

		private void <>m__Finally1() { }

		private void <>m__Finally2() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<Cookie> System.Collections.Generic.IEnumerable<WebSocketSharp.Net.Cookie>.GetEnumerator() { }

		[DebuggerHidden]
		private override Cookie System.Collections.Generic.IEnumerator<WebSocketSharp.Net.Cookie>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private const string _version = "13"; //Field offset: 0x0
	private static readonly int _maxRetryCountForConnect; //Field offset: 0x0
	private const string _guid = "258EAFA5-E914-47DA-95CA-C5AB0DC85B11"; //Field offset: 0x0
	internal static readonly Byte[] EmptyBytes; //Field offset: 0x8
	internal static readonly int FragmentLength; //Field offset: 0x10
	internal static readonly RandomNumberGenerator RandomNumber; //Field offset: 0x18
	private AuthenticationChallenge _authChallenge; //Field offset: 0x10
	private string _base64Key; //Field offset: 0x18
	private bool _client; //Field offset: 0x20
	private Action _closeContext; //Field offset: 0x28
	private CompressionMethod _compression; //Field offset: 0x30
	private WebSocketContext _context; //Field offset: 0x38
	private CookieCollection _cookies; //Field offset: 0x40
	private NetworkCredential _credentials; //Field offset: 0x48
	private bool _emitOnPing; //Field offset: 0x50
	private bool _enableRedirection; //Field offset: 0x51
	private string _extensions; //Field offset: 0x58
	private bool _extensionsRequested; //Field offset: 0x60
	private object _forMessageEventQueue; //Field offset: 0x68
	private object _forPing; //Field offset: 0x70
	private object _forSend; //Field offset: 0x78
	private object _forState; //Field offset: 0x80
	private MemoryStream _fragmentsBuffer; //Field offset: 0x88
	private bool _fragmentsCompressed; //Field offset: 0x90
	private Opcode _fragmentsOpcode; //Field offset: 0x91
	private Func<WebSocketContext, String> _handshakeRequestChecker; //Field offset: 0x98
	private bool _ignoreExtensions; //Field offset: 0xA0
	private bool _inContinuation; //Field offset: 0xA1
	private bool _inMessage; //Field offset: 0xA2
	private Logger _logger; //Field offset: 0xA8
	private Action<MessageEventArgs> _message; //Field offset: 0xB0
	private Queue<MessageEventArgs> _messageEventQueue; //Field offset: 0xB8
	private uint _nonceCount; //Field offset: 0xC0
	private string _origin; //Field offset: 0xC8
	private ManualResetEvent _pongReceived; //Field offset: 0xD0
	private bool _preAuth; //Field offset: 0xD8
	private string _protocol; //Field offset: 0xE0
	private String[] _protocols; //Field offset: 0xE8
	private bool _protocolsRequested; //Field offset: 0xF0
	private NetworkCredential _proxyCredentials; //Field offset: 0xF8
	private Uri _proxyUri; //Field offset: 0x100
	private WebSocketState _readyState; //Field offset: 0x108
	private ManualResetEvent _receivingExited; //Field offset: 0x110
	private int _retryCountForConnect; //Field offset: 0x118
	private bool _secure; //Field offset: 0x11C
	private ClientSslConfiguration _sslConfig; //Field offset: 0x120
	private Stream _stream; //Field offset: 0x128
	private TcpClient _tcpClient; //Field offset: 0x130
	private Uri _uri; //Field offset: 0x138
	private TimeSpan _waitTime; //Field offset: 0x140
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private EventHandler<CloseEventArgs> OnClose; //Field offset: 0x148
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private EventHandler<ErrorEventArgs> OnError; //Field offset: 0x150
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private EventHandler<MessageEventArgs> OnMessage; //Field offset: 0x158
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private EventHandler OnOpen; //Field offset: 0x160

	public event EventHandler<CloseEventArgs> OnClose
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event EventHandler<ErrorEventArgs> OnError
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event EventHandler<MessageEventArgs> OnMessage
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event EventHandler OnOpen
	{
		[CompilerGenerated]
		 add { } //Length: 160
		[CompilerGenerated]
		 remove { } //Length: 160
	}

	public CompressionMethod Compression
	{
		 get { } //Length: 8
		 set { } //Length: 396
	}

	internal CookieCollection CookieCollection
	{
		internal get { } //Length: 8
	}

	public IEnumerable<Cookie> Cookies
	{
		[IteratorStateMachine(typeof(<get_Cookies>d__70))]
		 get { } //Length: 124
	}

	public NetworkCredential Credentials
	{
		 get { } //Length: 8
	}

	internal Func<WebSocketContext, String> CustomHandshakeRequestChecker
	{
		internal get { } //Length: 8
		internal set { } //Length: 8
	}

	public bool EmitOnPing
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public bool EnableRedirection
	{
		 get { } //Length: 8
		 set { } //Length: 400
	}

	public string Extensions
	{
		 get { } //Length: 84
	}

	internal bool HasMessage
	{
		internal get { } //Length: 248
	}

	internal bool IgnoreExtensions
	{
		internal get { } //Length: 8
		internal set { } //Length: 12
	}

	public bool IsAlive
	{
		 get { } //Length: 96
	}

	internal bool IsConnected
	{
		internal get { } //Length: 64
	}

	public bool IsSecure
	{
		 get { } //Length: 8
	}

	public internal Logger Log
	{
		 get { } //Length: 24
		internal set { } //Length: 44
	}

	public string Origin
	{
		 get { } //Length: 8
		 set { } //Length: 804
	}

	public internal string Protocol
	{
		 get { } //Length: 84
		internal set { } //Length: 8
	}

	public WebSocketState ReadyState
	{
		 get { } //Length: 24
	}

	public ClientSslConfiguration SslConfiguration
	{
		 get { } //Length: 120
	}

	public Uri Url
	{
		 get { } //Length: 56
	}

	public TimeSpan WaitTime
	{
		 get { } //Length: 8
		 set { } //Length: 500
	}

	private static WebSocket() { }

	internal WebSocket(HttpListenerWebSocketContext context, string protocol) { }

	internal WebSocket(TcpListenerWebSocketContext context, string protocol) { }

	public WebSocket(string url, String[] protocols) { }

	[CompilerGenerated]
	private void <open>b__146_0(IAsyncResult ar) { }

	[CompilerGenerated]
	private bool <processSecWebSocketProtocolClientHeader>b__157_0(string val) { }

	private bool accept() { }

	public void Accept() { }

	public void AcceptAsync() { }

	private bool acceptHandshake() { }

	[CompilerGenerated]
	public void add_OnClose(EventHandler<CloseEventArgs> value) { }

	[CompilerGenerated]
	public void add_OnError(EventHandler<ErrorEventArgs> value) { }

	[CompilerGenerated]
	public void add_OnMessage(EventHandler<MessageEventArgs> value) { }

	[CompilerGenerated]
	public void add_OnOpen(EventHandler value) { }

	private bool canSet(out string message) { }

	private bool checkHandshakeRequest(WebSocketContext context, out string message) { }

	private bool checkHandshakeResponse(HttpResponse response, out string message) { }

	private static bool checkProtocols(String[] protocols, out string message) { }

	private bool checkReceivedFrame(WebSocketFrame frame, out string message) { }

	private void close(ushort code, string reason) { }

	private void close(PayloadData payloadData, bool send, bool receive, bool received) { }

	public void Close(ushort code) { }

	public void Close(CloseStatusCode code) { }

	public void Close() { }

	public void Close(ushort code, string reason) { }

	internal void Close(PayloadData payloadData, Byte[] frameAsBytes) { }

	public void Close(CloseStatusCode code, string reason) { }

	internal void Close(HttpStatusCode code) { }

	internal void Close(HttpResponse response) { }

	private void closeAsync(ushort code, string reason) { }

	private void closeAsync(PayloadData payloadData, bool send, bool receive, bool received) { }

	public void CloseAsync(ushort code) { }

	public void CloseAsync(CloseStatusCode code) { }

	public void CloseAsync() { }

	public void CloseAsync(ushort code, string reason) { }

	public void CloseAsync(CloseStatusCode code, string reason) { }

	private bool closeHandshake(PayloadData payloadData, bool send, bool receive, bool received) { }

	private bool closeHandshake(Byte[] frameAsBytes, bool receive, bool received) { }

	private bool connect() { }

	public void Connect() { }

	public void ConnectAsync() { }

	internal static string CreateBase64Key() { }

	private string createExtensions() { }

	private HttpResponse createHandshakeFailureResponse(HttpStatusCode code) { }

	private HttpRequest createHandshakeRequest() { }

	private HttpResponse createHandshakeResponse() { }

	internal static string CreateResponseKey(string base64Key) { }

	private bool customCheckHandshakeRequest(WebSocketContext context, out string message) { }

	private MessageEventArgs dequeueFromMessageEventQueue() { }

	private void doHandshake() { }

	private void enqueueToMessageEventQueue(MessageEventArgs e) { }

	private void error(string message, Exception exception) { }

	private void fatal(string message, CloseStatusCode code) { }

	private void fatal(string message, ushort code) { }

	private void fatal(string message, Exception exception) { }

	public CompressionMethod get_Compression() { }

	internal CookieCollection get_CookieCollection() { }

	[IteratorStateMachine(typeof(<get_Cookies>d__70))]
	public IEnumerable<Cookie> get_Cookies() { }

	public NetworkCredential get_Credentials() { }

	internal Func<WebSocketContext, String> get_CustomHandshakeRequestChecker() { }

	public bool get_EmitOnPing() { }

	public bool get_EnableRedirection() { }

	public string get_Extensions() { }

	internal bool get_HasMessage() { }

	internal bool get_IgnoreExtensions() { }

	public bool get_IsAlive() { }

	internal bool get_IsConnected() { }

	public bool get_IsSecure() { }

	public Logger get_Log() { }

	public string get_Origin() { }

	public string get_Protocol() { }

	public WebSocketState get_ReadyState() { }

	public ClientSslConfiguration get_SslConfiguration() { }

	public Uri get_Url() { }

	public TimeSpan get_WaitTime() { }

	private ClientSslConfiguration getSslConfiguration() { }

	private void init() { }

	internal void InternalAccept() { }

	private void message() { }

	private void messagec(MessageEventArgs e) { }

	private void messages(MessageEventArgs e) { }

	private void open() { }

	private bool ping(Byte[] data) { }

	public bool Ping(string message) { }

	internal bool Ping(Byte[] frameAsBytes, TimeSpan timeout) { }

	public bool Ping() { }

	private bool processCloseFrame(WebSocketFrame frame) { }

	private void processCookies(CookieCollection cookies) { }

	private bool processDataFrame(WebSocketFrame frame) { }

	private bool processFragmentFrame(WebSocketFrame frame) { }

	private bool processPingFrame(WebSocketFrame frame) { }

	private bool processPongFrame(WebSocketFrame frame) { }

	private bool processReceivedFrame(WebSocketFrame frame) { }

	private void processSecWebSocketExtensionsClientHeader(string value) { }

	private void processSecWebSocketExtensionsServerHeader(string value) { }

	private void processSecWebSocketProtocolClientHeader(IEnumerable<String> values) { }

	private bool processUnsupportedFrame(WebSocketFrame frame) { }

	private void refuseHandshake(CloseStatusCode code, string reason) { }

	private void releaseClientResources() { }

	private void releaseCommonResources() { }

	private void releaseResources() { }

	private void releaseServerResources() { }

	[CompilerGenerated]
	public void remove_OnClose(EventHandler<CloseEventArgs> value) { }

	[CompilerGenerated]
	public void remove_OnError(EventHandler<ErrorEventArgs> value) { }

	[CompilerGenerated]
	public void remove_OnMessage(EventHandler<MessageEventArgs> value) { }

	[CompilerGenerated]
	public void remove_OnOpen(EventHandler value) { }

	private bool send(Opcode opcode, Stream stream) { }

	private bool send(Opcode opcode, Stream stream, bool compressed) { }

	private bool send(Fin fin, Opcode opcode, Byte[] data, bool compressed) { }

	public void Send(FileInfo fileInfo) { }

	public void Send(string data) { }

	public void Send(Stream stream, int length) { }

	internal void Send(Opcode opcode, Stream stream, Dictionary<CompressionMethod, Stream> cache) { }

	internal void Send(Opcode opcode, Byte[] data, Dictionary<CompressionMethod, Byte[]> cache) { }

	public void Send(Byte[] data) { }

	private void sendAsync(Opcode opcode, Stream stream, Action<Boolean> completed) { }

	public void SendAsync(Byte[] data, Action<Boolean> completed) { }

	public void SendAsync(FileInfo fileInfo, Action<Boolean> completed) { }

	public void SendAsync(string data, Action<Boolean> completed) { }

	public void SendAsync(Stream stream, int length, Action<Boolean> completed) { }

	private bool sendBytes(Byte[] bytes) { }

	private HttpResponse sendHandshakeRequest() { }

	private HttpResponse sendHttpRequest(HttpRequest request, int millisecondsTimeout) { }

	private bool sendHttpResponse(HttpResponse response) { }

	private void sendProxyConnectRequest() { }

	public void set_Compression(CompressionMethod value) { }

	internal void set_CustomHandshakeRequestChecker(Func<WebSocketContext, String> value) { }

	public void set_EmitOnPing(bool value) { }

	public void set_EnableRedirection(bool value) { }

	internal void set_IgnoreExtensions(bool value) { }

	internal void set_Log(Logger value) { }

	public void set_Origin(string value) { }

	internal void set_Protocol(string value) { }

	public void set_WaitTime(TimeSpan value) { }

	private void setClientStream() { }

	public void SetCookie(Cookie cookie) { }

	public void SetCredentials(string username, string password, bool preAuth) { }

	public void SetProxy(string url, string username, string password) { }

	private void startReceiving() { }

	private override void System.IDisposable.Dispose() { }

	private bool validateSecWebSocketAcceptHeader(string value) { }

	private bool validateSecWebSocketExtensionsServerHeader(string value) { }

	private bool validateSecWebSocketProtocolServerHeader(string value) { }

	private bool validateSecWebSocketVersionServerHeader(string value) { }

}

