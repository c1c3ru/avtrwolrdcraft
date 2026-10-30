namespace Unity.Services.Wire.Internal;

internal class WebSocket : IWebSocket
{
	private TcpClient _tcpClient; //Field offset: 0x10
	[CompilerGenerated]
	private WebSocketOpenEventHandler OnOpen; //Field offset: 0x18
	[CompilerGenerated]
	private WebSocketMessageEventHandler OnMessage; //Field offset: 0x20
	[CompilerGenerated]
	private WebSocketErrorEventHandler OnError; //Field offset: 0x28
	[CompilerGenerated]
	private WebSocketCloseEventHandler OnClose; //Field offset: 0x30
	protected WebSocket ws; //Field offset: 0x38

	public override event WebSocketCloseEventHandler OnClose
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public override event WebSocketErrorEventHandler OnError
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public override event WebSocketMessageEventHandler OnMessage
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public override event WebSocketOpenEventHandler OnOpen
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public WebSocket(string url) { }

	[CompilerGenerated]
	private void <.ctor>b__14_0(object sender, EventArgs ev) { }

	[CompilerGenerated]
	private void <.ctor>b__14_1(object sender, MessageEventArgs ev) { }

	[CompilerGenerated]
	private void <.ctor>b__14_2(object sender, ErrorEventArgs ev) { }

	[CompilerGenerated]
	private void <.ctor>b__14_3(object sender, CloseEventArgs ev) { }

	[CompilerGenerated]
	public override void add_OnClose(WebSocketCloseEventHandler value) { }

	[CompilerGenerated]
	public override void add_OnError(WebSocketErrorEventHandler value) { }

	[CompilerGenerated]
	public override void add_OnMessage(WebSocketMessageEventHandler value) { }

	[CompilerGenerated]
	public override void add_OnOpen(WebSocketOpenEventHandler value) { }

	public override void Close(WebSocketCloseCode code = 1000, string reason = null) { }

	public override void Connect() { }

	public override WebSocketState GetState() { }

	private NetworkStream GetStream(string url, int port) { }

	[CompilerGenerated]
	public override void remove_OnClose(WebSocketCloseEventHandler value) { }

	[CompilerGenerated]
	public override void remove_OnError(WebSocketErrorEventHandler value) { }

	[CompilerGenerated]
	public override void remove_OnMessage(WebSocketMessageEventHandler value) { }

	[CompilerGenerated]
	public override void remove_OnOpen(WebSocketOpenEventHandler value) { }

	public override void Send(Byte[] data) { }

}

