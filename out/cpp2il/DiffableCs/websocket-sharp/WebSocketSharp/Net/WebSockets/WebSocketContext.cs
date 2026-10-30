namespace WebSocketSharp.Net.WebSockets;

public abstract class WebSocketContext
{

	public abstract CookieCollection CookieCollection
	{
		 get { } //Length: 0
	}

	public abstract NameValueCollection Headers
	{
		 get { } //Length: 0
	}

	public abstract string Host
	{
		 get { } //Length: 0
	}

	public abstract bool IsAuthenticated
	{
		 get { } //Length: 0
	}

	public abstract bool IsLocal
	{
		 get { } //Length: 0
	}

	public abstract bool IsSecureConnection
	{
		 get { } //Length: 0
	}

	public abstract bool IsWebSocketRequest
	{
		 get { } //Length: 0
	}

	public abstract string Origin
	{
		 get { } //Length: 0
	}

	public abstract NameValueCollection QueryString
	{
		 get { } //Length: 0
	}

	public abstract Uri RequestUri
	{
		 get { } //Length: 0
	}

	public abstract string SecWebSocketKey
	{
		 get { } //Length: 0
	}

	public abstract IEnumerable<String> SecWebSocketProtocols
	{
		 get { } //Length: 0
	}

	public abstract string SecWebSocketVersion
	{
		 get { } //Length: 0
	}

	public abstract IPEndPoint ServerEndPoint
	{
		 get { } //Length: 0
	}

	public abstract IPrincipal User
	{
		 get { } //Length: 0
	}

	public abstract IPEndPoint UserEndPoint
	{
		 get { } //Length: 0
	}

	public abstract WebSocket WebSocket
	{
		 get { } //Length: 0
	}

	protected WebSocketContext() { }

	public abstract CookieCollection get_CookieCollection() { }

	public abstract NameValueCollection get_Headers() { }

	public abstract string get_Host() { }

	public abstract bool get_IsAuthenticated() { }

	public abstract bool get_IsLocal() { }

	public abstract bool get_IsSecureConnection() { }

	public abstract bool get_IsWebSocketRequest() { }

	public abstract string get_Origin() { }

	public abstract NameValueCollection get_QueryString() { }

	public abstract Uri get_RequestUri() { }

	public abstract string get_SecWebSocketKey() { }

	public abstract IEnumerable<String> get_SecWebSocketProtocols() { }

	public abstract string get_SecWebSocketVersion() { }

	public abstract IPEndPoint get_ServerEndPoint() { }

	public abstract IPrincipal get_User() { }

	public abstract IPEndPoint get_UserEndPoint() { }

	public abstract WebSocket get_WebSocket() { }

}

