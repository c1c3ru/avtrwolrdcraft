namespace System.Net;

internal sealed class EndPointListener
{
	private HttpListener listener; //Field offset: 0x10
	private IPEndPoint endpoint; //Field offset: 0x18
	private Socket sock; //Field offset: 0x20
	private Hashtable prefixes; //Field offset: 0x28
	private ArrayList unhandled; //Field offset: 0x30
	private ArrayList all; //Field offset: 0x38
	private X509Certificate cert; //Field offset: 0x40
	private bool secure; //Field offset: 0x48
	private Dictionary<HttpConnection, HttpConnection> unregistered; //Field offset: 0x50

	internal HttpListener Listener
	{
		internal get { } //Length: 8
	}

	public EndPointListener(HttpListener listener, IPAddress addr, int port, bool secure) { }

	private static void Accept(Socket socket, SocketAsyncEventArgs e, ref Socket accepted) { }

	public void AddPrefix(ListenerPrefix prefix, HttpListener listener) { }

	private void AddSpecial(ArrayList coll, ListenerPrefix prefix) { }

	public bool BindContext(HttpListenerContext context) { }

	private void CheckIfRemove() { }

	public void Close() { }

	internal HttpListener get_Listener() { }

	private HttpListener MatchFromList(string host, string path, ArrayList list, out ListenerPrefix prefix) { }

	private static void OnAccept(object sender, SocketAsyncEventArgs e) { }

	private static void ProcessAccept(SocketAsyncEventArgs args) { }

	internal void RemoveConnection(HttpConnection conn) { }

	public void RemovePrefix(ListenerPrefix prefix, HttpListener listener) { }

	private bool RemoveSpecial(ArrayList coll, ListenerPrefix prefix) { }

	private HttpListener SearchListener(Uri uri, out ListenerPrefix prefix) { }

	public void UnbindContext(HttpListenerContext context) { }

}

