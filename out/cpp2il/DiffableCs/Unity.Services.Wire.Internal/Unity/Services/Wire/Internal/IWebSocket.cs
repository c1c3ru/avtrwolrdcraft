namespace Unity.Services.Wire.Internal;

internal interface IWebSocket
{

	public event WebSocketCloseEventHandler OnClose
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	public event WebSocketErrorEventHandler OnError
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	public event WebSocketMessageEventHandler OnMessage
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	public event WebSocketOpenEventHandler OnOpen
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	[CompilerGenerated]
	public void add_OnClose(WebSocketCloseEventHandler value) { }

	[CompilerGenerated]
	public void add_OnError(WebSocketErrorEventHandler value) { }

	[CompilerGenerated]
	public void add_OnMessage(WebSocketMessageEventHandler value) { }

	[CompilerGenerated]
	public void add_OnOpen(WebSocketOpenEventHandler value) { }

	public void Close(WebSocketCloseCode code = 1000, string reason = null) { }

	public void Connect() { }

	public WebSocketState GetState() { }

	[CompilerGenerated]
	public void remove_OnClose(WebSocketCloseEventHandler value) { }

	[CompilerGenerated]
	public void remove_OnError(WebSocketErrorEventHandler value) { }

	[CompilerGenerated]
	public void remove_OnMessage(WebSocketMessageEventHandler value) { }

	[CompilerGenerated]
	public void remove_OnOpen(WebSocketOpenEventHandler value) { }

	public void Send(Byte[] data) { }

}

