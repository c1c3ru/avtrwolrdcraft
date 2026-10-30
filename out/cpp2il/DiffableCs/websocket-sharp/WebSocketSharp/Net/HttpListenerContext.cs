namespace WebSocketSharp.Net;

public sealed class HttpListenerContext
{
	private HttpConnection _connection; //Field offset: 0x10
	private string _errorMessage; //Field offset: 0x18
	private int _errorStatusCode; //Field offset: 0x20
	private HttpListener _listener; //Field offset: 0x28
	private HttpListenerRequest _request; //Field offset: 0x30
	private HttpListenerResponse _response; //Field offset: 0x38
	private IPrincipal _user; //Field offset: 0x40
	private HttpListenerWebSocketContext _websocketContext; //Field offset: 0x48

	internal HttpConnection Connection
	{
		internal get { } //Length: 8
	}

	internal string ErrorMessage
	{
		internal get { } //Length: 8
		internal set { } //Length: 8
	}

	internal int ErrorStatusCode
	{
		internal get { } //Length: 8
		internal set { } //Length: 8
	}

	internal bool HasErrorMessage
	{
		internal get { } //Length: 16
	}

	internal HttpListener Listener
	{
		internal get { } //Length: 8
		internal set { } //Length: 8
	}

	public HttpListenerRequest Request
	{
		 get { } //Length: 8
	}

	public HttpListenerResponse Response
	{
		 get { } //Length: 8
	}

	public internal IPrincipal User
	{
		 get { } //Length: 8
		internal set { } //Length: 8
	}

	internal HttpListenerContext(HttpConnection connection) { }

	public HttpListenerWebSocketContext AcceptWebSocket(string protocol) { }

	private static string createErrorContent(int statusCode, string statusDescription, string message) { }

	internal HttpConnection get_Connection() { }

	internal string get_ErrorMessage() { }

	internal int get_ErrorStatusCode() { }

	internal bool get_HasErrorMessage() { }

	internal HttpListener get_Listener() { }

	public HttpListenerRequest get_Request() { }

	public HttpListenerResponse get_Response() { }

	public IPrincipal get_User() { }

	internal HttpListenerWebSocketContext GetWebSocketContext(string protocol) { }

	internal void SendAuthenticationChallenge(AuthenticationSchemes scheme, string realm) { }

	internal void SendError() { }

	internal void set_ErrorMessage(string value) { }

	internal void set_ErrorStatusCode(int value) { }

	internal void set_Listener(HttpListener value) { }

	internal void set_User(IPrincipal value) { }

	internal void Unregister() { }

}

