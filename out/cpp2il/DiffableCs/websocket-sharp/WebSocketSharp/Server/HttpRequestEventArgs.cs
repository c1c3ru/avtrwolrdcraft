namespace WebSocketSharp.Server;

public class HttpRequestEventArgs : EventArgs
{
	private HttpListenerContext _context; //Field offset: 0x10
	private string _docRootPath; //Field offset: 0x18

	public HttpListenerRequest Request
	{
		 get { } //Length: 28
	}

	public HttpListenerResponse Response
	{
		 get { } //Length: 28
	}

	public IPrincipal User
	{
		 get { } //Length: 28
	}

	internal HttpRequestEventArgs(HttpListenerContext context, string documentRootPath) { }

	private string createFilePath(string childPath) { }

	public HttpListenerRequest get_Request() { }

	public HttpListenerResponse get_Response() { }

	public IPrincipal get_User() { }

	public Byte[] ReadFile(string path) { }

	private static bool tryReadFile(string path, out Byte[] contents) { }

	public bool TryReadFile(string path, out Byte[] contents) { }

}

