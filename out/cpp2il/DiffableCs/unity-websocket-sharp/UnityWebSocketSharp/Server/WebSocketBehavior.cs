namespace UnityWebSocketSharp.Server;

internal abstract class WebSocketBehavior : IWebSocketSession
{
	private WebSocketContext _context; //Field offset: 0x10
	private Func<CookieCollection, CookieCollection, Boolean> _cookiesValidator; //Field offset: 0x18
	private bool _emitOnPing; //Field offset: 0x20
	private Func<String, Boolean> _hostValidator; //Field offset: 0x28
	private string _id; //Field offset: 0x30
	private bool _ignoreExtensions; //Field offset: 0x38
	private Func<String, Boolean> _originValidator; //Field offset: 0x40
	private string _protocol; //Field offset: 0x48
	private WebSocketSessionManager _sessions; //Field offset: 0x50
	private DateTime _startTime; //Field offset: 0x58
	private WebSocket _websocket; //Field offset: 0x60

	public Func<CookieCollection, CookieCollection, Boolean> CookiesValidator
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public bool EmitOnPing
	{
		 get { } //Length: 28
		 set { } //Length: 32
	}

	protected NameValueCollection Headers
	{
		 get { } //Length: 100
	}

	public Func<String, Boolean> HostValidator
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public override string ID
	{
		 get { } //Length: 8
	}

	public bool IgnoreExtensions
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	protected bool IsAlive
	{
		 get { } //Length: 96
	}

	public Func<String, Boolean> OriginValidator
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public string Protocol
	{
		 get { } //Length: 108
		 set { } //Length: 292
	}

	protected NameValueCollection QueryString
	{
		 get { } //Length: 100
	}

	protected WebSocketState ReadyState
	{
		 get { } //Length: 96
	}

	protected WebSocketSessionManager Sessions
	{
		 get { } //Length: 92
	}

	public override DateTime StartTime
	{
		 get { } //Length: 8
	}

	private override WebSocket UnityWebSocketSharp.Server.IWebSocketSession.WebSocket
	{
		private get { } //Length: 8
	}

	protected IPrincipal User
	{
		 get { } //Length: 104
	}

	protected IPEndPoint UserEndPoint
	{
		 get { } //Length: 104
	}

	protected WebSocketBehavior() { }

	private string checkHandshakeRequest(WebSocketContext context) { }

	protected void Close(ushort code, string reason) { }

	protected void Close(CloseStatusCode code, string reason) { }

	protected void Close() { }

	protected void CloseAsync() { }

	protected void CloseAsync(ushort code, string reason) { }

	protected void CloseAsync(CloseStatusCode code, string reason) { }

	public Func<CookieCollection, CookieCollection, Boolean> get_CookiesValidator() { }

	public bool get_EmitOnPing() { }

	protected NameValueCollection get_Headers() { }

	public Func<String, Boolean> get_HostValidator() { }

	public override string get_ID() { }

	public bool get_IgnoreExtensions() { }

	protected bool get_IsAlive() { }

	public Func<String, Boolean> get_OriginValidator() { }

	public string get_Protocol() { }

	protected NameValueCollection get_QueryString() { }

	protected WebSocketState get_ReadyState() { }

	protected WebSocketSessionManager get_Sessions() { }

	public override DateTime get_StartTime() { }

	protected IPrincipal get_User() { }

	protected IPEndPoint get_UserEndPoint() { }

	private void onClose(object sender, CloseEventArgs e) { }

	protected override void OnClose(CloseEventArgs e) { }

	private void onError(object sender, ErrorEventArgs e) { }

	protected override void OnError(ErrorEventArgs e) { }

	private void onMessage(object sender, MessageEventArgs e) { }

	protected override void OnMessage(MessageEventArgs e) { }

	private void onOpen(object sender, EventArgs e) { }

	protected override void OnOpen() { }

	protected bool Ping(string message) { }

	protected bool Ping() { }

	protected void Send(Byte[] data) { }

	protected void Send(FileInfo fileInfo) { }

	protected void Send(string data) { }

	protected void Send(Stream stream, int length) { }

	protected void SendAsync(string data, Action<Boolean> completed) { }

	protected void SendAsync(Stream stream, int length, Action<Boolean> completed) { }

	protected void SendAsync(FileInfo fileInfo, Action<Boolean> completed) { }

	protected void SendAsync(Byte[] data, Action<Boolean> completed) { }

	public void set_CookiesValidator(Func<CookieCollection, CookieCollection, Boolean> value) { }

	public void set_EmitOnPing(bool value) { }

	public void set_HostValidator(Func<String, Boolean> value) { }

	public void set_IgnoreExtensions(bool value) { }

	public void set_OriginValidator(Func<String, Boolean> value) { }

	public void set_Protocol(string value) { }

	internal void Start(WebSocketContext context, WebSocketSessionManager sessions) { }

	private override WebSocket UnityWebSocketSharp.Server.IWebSocketSession.get_WebSocket() { }

}

