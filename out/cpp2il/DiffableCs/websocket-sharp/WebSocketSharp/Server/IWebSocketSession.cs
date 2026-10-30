namespace WebSocketSharp.Server;

public interface IWebSocketSession
{

	public WebSocketState ConnectionState
	{
		 get { } //Length: 0
	}

	public WebSocketContext Context
	{
		 get { } //Length: 0
	}

	public string ID
	{
		 get { } //Length: 0
	}

	public string Protocol
	{
		 get { } //Length: 0
	}

	public DateTime StartTime
	{
		 get { } //Length: 0
	}

	public WebSocketState get_ConnectionState() { }

	public WebSocketContext get_Context() { }

	public string get_ID() { }

	public string get_Protocol() { }

	public DateTime get_StartTime() { }

}

