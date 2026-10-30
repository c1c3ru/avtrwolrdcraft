namespace UnityWebSocketSharp.Server;

internal interface IWebSocketSession
{

	public string ID
	{
		 get { } //Length: 0
	}

	public DateTime StartTime
	{
		 get { } //Length: 0
	}

	public WebSocket WebSocket
	{
		 get { } //Length: 0
	}

	public string get_ID() { }

	public DateTime get_StartTime() { }

	public WebSocket get_WebSocket() { }

}

