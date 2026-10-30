namespace WebSocketSharp.Server;

public abstract class WebSocketServiceHost
{
	private Logger _log; //Field offset: 0x10
	private string _path; //Field offset: 0x18
	private WebSocketSessionManager _sessions; //Field offset: 0x20

	public abstract Type BehaviorType
	{
		 get { } //Length: 0
	}

	public bool KeepClean
	{
		 get { } //Length: 36
		 set { } //Length: 28
	}

	protected Logger Log
	{
		 get { } //Length: 8
	}

	public string Path
	{
		 get { } //Length: 8
	}

	public WebSocketSessionManager Sessions
	{
		 get { } //Length: 8
	}

	internal ServerState State
	{
		internal get { } //Length: 36
	}

	public TimeSpan WaitTime
	{
		 get { } //Length: 28
		 set { } //Length: 24
	}

	protected WebSocketServiceHost(string path, Logger log) { }

	protected abstract WebSocketBehavior CreateSession() { }

	public abstract Type get_BehaviorType() { }

	public bool get_KeepClean() { }

	protected Logger get_Log() { }

	public string get_Path() { }

	public WebSocketSessionManager get_Sessions() { }

	internal ServerState get_State() { }

	public TimeSpan get_WaitTime() { }

	public void set_KeepClean(bool value) { }

	public void set_WaitTime(TimeSpan value) { }

	internal void Start() { }

	internal void StartSession(WebSocketContext context) { }

	internal void Stop(ushort code, string reason) { }

}

