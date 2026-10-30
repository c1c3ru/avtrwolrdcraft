namespace WebSocketSharp.Server;

public abstract class WebSocketBehavior : IWebSocketSession
{
	private WebSocketContext _context; //Field offset: 0x10
	private Func<CookieCollection, CookieCollection, Boolean> _cookiesValidator; //Field offset: 0x18
	private bool _emitOnPing; //Field offset: 0x20
	private string _id; //Field offset: 0x28
	private bool _ignoreExtensions; //Field offset: 0x30
	private Func<String, Boolean> _originValidator; //Field offset: 0x38
	private string _protocol; //Field offset: 0x40
	private WebSocketSessionManager _sessions; //Field offset: 0x48
	private DateTime _startTime; //Field offset: 0x50
	private WebSocket _websocket; //Field offset: 0x58

	public override WebSocketState ConnectionState
	{
		 get { } //Length: 20
	}

	public override WebSocketContext Context
	{
		 get { } //Length: 8
	}

	public Func<CookieCollection, CookieCollection, Boolean> CookiesValidator
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public bool EmitOnPing
	{
		 get { } //Length: 28
		 set { } //Length: 36
	}

	protected NameValueCollection Headers
	{
		 get { } //Length: 24
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

	public Func<String, Boolean> OriginValidator
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public override string Protocol
	{
		 get { } //Length: 108
		 set { } //Length: 292
	}

	protected NameValueCollection QueryString
	{
		 get { } //Length: 24
	}

	protected WebSocketSessionManager Sessions
	{
		 get { } //Length: 8
	}

	public override DateTime StartTime
	{
		 get { } //Length: 8
	}

	protected WebSocketBehavior() { }

	private string checkHandshakeRequest(WebSocketContext context) { }

	protected void Close(CloseStatusCode code, string reason) { }

	protected void Close(ushort code, string reason) { }

	protected void Close() { }

	protected void CloseAsync(ushort code, string reason) { }

	protected void CloseAsync() { }

	protected void CloseAsync(CloseStatusCode code, string reason) { }

	public override WebSocketState get_ConnectionState() { }

	public override WebSocketContext get_Context() { }

	public Func<CookieCollection, CookieCollection, Boolean> get_CookiesValidator() { }

	public bool get_EmitOnPing() { }

	protected NameValueCollection get_Headers() { }

	public override string get_ID() { }

	public bool get_IgnoreExtensions() { }

	public Func<String, Boolean> get_OriginValidator() { }

	public override string get_Protocol() { }

	protected NameValueCollection get_QueryString() { }

	protected WebSocketSessionManager get_Sessions() { }

	public override DateTime get_StartTime() { }

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

	protected void SendAsync(Byte[] data, Action<Boolean> completed) { }

	protected void SendAsync(FileInfo fileInfo, Action<Boolean> completed) { }

	protected void SendAsync(Stream stream, int length, Action<Boolean> completed) { }

	public void set_CookiesValidator(Func<CookieCollection, CookieCollection, Boolean> value) { }

	public void set_EmitOnPing(bool value) { }

	public void set_IgnoreExtensions(bool value) { }

	public void set_OriginValidator(Func<String, Boolean> value) { }

	public void set_Protocol(string value) { }

	internal void Start(WebSocketContext context, WebSocketSessionManager sessions) { }

}

