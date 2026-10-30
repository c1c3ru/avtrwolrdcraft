namespace WebSocketSharp.Net.WebSockets;

internal class TcpListenerWebSocketContext : WebSocketContext
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass51_0
	{
		public int retry; //Field offset: 0x10
		public TcpListenerWebSocketContext <>4__this; //Field offset: 0x18
		public AuthenticationSchemes scheme; //Field offset: 0x20
		public string realm; //Field offset: 0x28
		public Func<IIdentity, NetworkCredential> credentialsFinder; //Field offset: 0x30
		public string chal; //Field offset: 0x38
		public Func<Boolean> auth; //Field offset: 0x40

		public <>c__DisplayClass51_0() { }

		internal bool <Authenticate>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <get_SecWebSocketProtocols>d__39 : IEnumerable<String>, IEnumerable, IEnumerator<String>, IDisposable, IEnumerator
	{
		private int <>1__state; //Field offset: 0x10
		private string <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x20
		public TcpListenerWebSocketContext <>4__this; //Field offset: 0x28
		private string <val>5__1; //Field offset: 0x30
		private String[] <>s__2; //Field offset: 0x38
		private int <>s__3; //Field offset: 0x40
		private string <elm>5__4; //Field offset: 0x48
		private string <protocol>5__5; //Field offset: 0x50

		private override string System.Collections.Generic.IEnumerator<System.String>.Current
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
		public <get_SecWebSocketProtocols>d__39(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<String> System.Collections.Generic.IEnumerable<System.String>.GetEnumerator() { }

		[DebuggerHidden]
		private override string System.Collections.Generic.IEnumerator<System.String>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private Logger _log; //Field offset: 0x10
	private NameValueCollection _queryString; //Field offset: 0x18
	private HttpRequest _request; //Field offset: 0x20
	private Uri _requestUri; //Field offset: 0x28
	private bool _secure; //Field offset: 0x30
	private EndPoint _serverEndPoint; //Field offset: 0x38
	private Stream _stream; //Field offset: 0x40
	private TcpClient _tcpClient; //Field offset: 0x48
	private IPrincipal _user; //Field offset: 0x50
	private EndPoint _userEndPoint; //Field offset: 0x58
	private WebSocket _websocket; //Field offset: 0x60

	public virtual CookieCollection CookieCollection
	{
		 get { } //Length: 28
	}

	public virtual NameValueCollection Headers
	{
		 get { } //Length: 28
	}

	public virtual string Host
	{
		 get { } //Length: 96
	}

	public virtual bool IsAuthenticated
	{
		 get { } //Length: 16
	}

	public virtual bool IsLocal
	{
		 get { } //Length: 124
	}

	public virtual bool IsSecureConnection
	{
		 get { } //Length: 8
	}

	public virtual bool IsWebSocketRequest
	{
		 get { } //Length: 28
	}

	internal Logger Log
	{
		internal get { } //Length: 8
	}

	public virtual string Origin
	{
		 get { } //Length: 96
	}

	public virtual NameValueCollection QueryString
	{
		 get { } //Length: 212
	}

	public virtual Uri RequestUri
	{
		 get { } //Length: 316
	}

	public virtual string SecWebSocketKey
	{
		 get { } //Length: 96
	}

	public virtual IEnumerable<String> SecWebSocketProtocols
	{
		[IteratorStateMachine(typeof(<get_SecWebSocketProtocols>d__39))]
		 get { } //Length: 124
	}

	public virtual string SecWebSocketVersion
	{
		 get { } //Length: 96
	}

	public virtual IPEndPoint ServerEndPoint
	{
		 get { } //Length: 120
	}

	internal Stream Stream
	{
		internal get { } //Length: 8
	}

	public virtual IPrincipal User
	{
		 get { } //Length: 8
	}

	public virtual IPEndPoint UserEndPoint
	{
		 get { } //Length: 120
	}

	public virtual WebSocket WebSocket
	{
		 get { } //Length: 8
	}

	internal TcpListenerWebSocketContext(TcpClient tcpClient, string protocol, bool secure, ServerSslConfiguration sslConfig, Logger log) { }

	internal bool Authenticate(AuthenticationSchemes scheme, string realm, Func<IIdentity, NetworkCredential> credentialsFinder) { }

	internal void Close() { }

	internal void Close(HttpStatusCode code) { }

	public virtual CookieCollection get_CookieCollection() { }

	public virtual NameValueCollection get_Headers() { }

	public virtual string get_Host() { }

	public virtual bool get_IsAuthenticated() { }

	public virtual bool get_IsLocal() { }

	public virtual bool get_IsSecureConnection() { }

	public virtual bool get_IsWebSocketRequest() { }

	internal Logger get_Log() { }

	public virtual string get_Origin() { }

	public virtual NameValueCollection get_QueryString() { }

	public virtual Uri get_RequestUri() { }

	public virtual string get_SecWebSocketKey() { }

	[IteratorStateMachine(typeof(<get_SecWebSocketProtocols>d__39))]
	public virtual IEnumerable<String> get_SecWebSocketProtocols() { }

	public virtual string get_SecWebSocketVersion() { }

	public virtual IPEndPoint get_ServerEndPoint() { }

	internal Stream get_Stream() { }

	public virtual IPrincipal get_User() { }

	public virtual IPEndPoint get_UserEndPoint() { }

	public virtual WebSocket get_WebSocket() { }

	private HttpRequest sendAuthenticationChallenge(string challenge) { }

	public virtual string ToString() { }

}

