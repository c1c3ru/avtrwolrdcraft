namespace WebSocketSharp.Net;

internal sealed class HttpListenerPrefix
{
	private string _host; //Field offset: 0x10
	private HttpListener _listener; //Field offset: 0x18
	private string _original; //Field offset: 0x20
	private string _path; //Field offset: 0x28
	private string _port; //Field offset: 0x30
	private string _prefix; //Field offset: 0x38
	private bool _secure; //Field offset: 0x40

	public string Host
	{
		 get { } //Length: 8
	}

	public bool IsSecure
	{
		 get { } //Length: 8
	}

	public HttpListener Listener
	{
		 get { } //Length: 8
	}

	public string Original
	{
		 get { } //Length: 8
	}

	public string Path
	{
		 get { } //Length: 8
	}

	public string Port
	{
		 get { } //Length: 8
	}

	internal HttpListenerPrefix(string uriPrefix, HttpListener listener) { }

	public static void CheckPrefix(string uriPrefix) { }

	public virtual bool Equals(object obj) { }

	public string get_Host() { }

	public bool get_IsSecure() { }

	public HttpListener get_Listener() { }

	public string get_Original() { }

	public string get_Path() { }

	public string get_Port() { }

	public virtual int GetHashCode() { }

	private void parse(string uriPrefix) { }

	public virtual string ToString() { }

}

