namespace WebSocketSharp.Net;

internal sealed class EndPointListener
{
	private static readonly string _defaultCertFolderPath; //Field offset: 0x0
	private List<HttpListenerPrefix> _all; //Field offset: 0x10
	private Dictionary<HttpConnection, HttpConnection> _connections; //Field offset: 0x18
	private object _connectionsSync; //Field offset: 0x20
	private IPEndPoint _endpoint; //Field offset: 0x28
	private List<HttpListenerPrefix> _prefixes; //Field offset: 0x30
	private bool _secure; //Field offset: 0x38
	private Socket _socket; //Field offset: 0x40
	private ServerSslConfiguration _sslConfig; //Field offset: 0x48
	private List<HttpListenerPrefix> _unhandled; //Field offset: 0x50

	public IPAddress Address
	{
		 get { } //Length: 28
	}

	public bool IsSecure
	{
		 get { } //Length: 8
	}

	public int Port
	{
		 get { } //Length: 28
	}

	public ServerSslConfiguration SslConfiguration
	{
		 get { } //Length: 8
	}

	private static EndPointListener() { }

	internal EndPointListener(IPEndPoint endpoint, bool secure, string certificateFolderPath, ServerSslConfiguration sslConfig, bool reuseAddress) { }

	public void AddPrefix(HttpListenerPrefix prefix) { }

	private static void addSpecial(List<HttpListenerPrefix> prefixes, HttpListenerPrefix prefix) { }

	internal static bool CertificateExists(int port, string folderPath) { }

	private void clearConnections() { }

	public void Close() { }

	private static RSACryptoServiceProvider createRSAFromFile(string path) { }

	public IPAddress get_Address() { }

	public bool get_IsSecure() { }

	public int get_Port() { }

	public ServerSslConfiguration get_SslConfiguration() { }

	private static X509Certificate2 getCertificate(int port, string folderPath, X509Certificate2 defaultCertificate) { }

	private void leaveIfNoPrefix() { }

	private static void onAccept(IAsyncResult asyncResult) { }

	private static void processAccepted(Socket socket, EndPointListener listener) { }

	internal void RemoveConnection(HttpConnection connection) { }

	public void RemovePrefix(HttpListenerPrefix prefix) { }

	private static bool removeSpecial(List<HttpListenerPrefix> prefixes, HttpListenerPrefix prefix) { }

	private static HttpListener searchHttpListenerFromSpecial(string path, List<HttpListenerPrefix> prefixes) { }

	internal bool TrySearchHttpListener(Uri uri, out HttpListener listener) { }

}

