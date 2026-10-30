namespace System.Net;

internal sealed class HttpConnection
{
	private enum InputState
	{
		RequestLine = 0,
		Headers = 1,
	}

	private enum LineState
	{
		None = 0,
		CR = 1,
		LF = 2,
	}

	private static AsyncCallback onread_cb; //Field offset: 0x0
	private Socket sock; //Field offset: 0x10
	private Stream stream; //Field offset: 0x18
	private EndPointListener epl; //Field offset: 0x20
	private MemoryStream ms; //Field offset: 0x28
	private Byte[] buffer; //Field offset: 0x30
	private HttpListenerContext context; //Field offset: 0x38
	private StringBuilder current_line; //Field offset: 0x40
	private ListenerPrefix prefix; //Field offset: 0x48
	private RequestStream i_stream; //Field offset: 0x50
	private ResponseStream o_stream; //Field offset: 0x58
	private bool chunked; //Field offset: 0x60
	private int reuses; //Field offset: 0x64
	private bool context_bound; //Field offset: 0x68
	private bool secure; //Field offset: 0x69
	private X509Certificate cert; //Field offset: 0x70
	private int s_timeout; //Field offset: 0x78
	private Timer timer; //Field offset: 0x80
	private IPEndPoint local_ep; //Field offset: 0x88
	private HttpListener last_listener; //Field offset: 0x90
	private Int32[] client_cert_errors; //Field offset: 0x98
	private X509Certificate2 client_cert; //Field offset: 0xA0
	private SslStream ssl_stream; //Field offset: 0xA8
	private InputState input_state; //Field offset: 0xB0
	private LineState line_state; //Field offset: 0xB4
	private int position; //Field offset: 0xB8

	public bool IsSecure
	{
		 get { } //Length: 8
	}

	public IPEndPoint LocalEndPoint
	{
		 get { } //Length: 212
	}

	public ListenerPrefix Prefix
	{
		 set { } //Length: 8
	}

	public int Reuses
	{
		 get { } //Length: 8
	}

	private static HttpConnection() { }

	public HttpConnection(Socket sock, EndPointListener epl, bool secure, X509Certificate cert) { }

	[CompilerGenerated]
	private bool <.ctor>b__24_0(object t, X509Certificate c, X509Chain ch, SslPolicyErrors e) { }

	public void BeginReadRequest() { }

	internal void Close(bool force_close) { }

	private void CloseSocket() { }

	public bool get_IsSecure() { }

	public IPEndPoint get_LocalEndPoint() { }

	public int get_Reuses() { }

	public RequestStream GetRequestStream(bool chunked, long contentlength) { }

	public ResponseStream GetResponseStream() { }

	private void Init() { }

	private static void OnRead(IAsyncResult ares) { }

	private void OnReadInternal(IAsyncResult ares) { }

	private void OnTimeout(object unused) { }

	private bool ProcessInput(MemoryStream ms) { }

	private string ReadLine(Byte[] buffer, int offset, int len, ref int used) { }

	private void RemoveConnection() { }

	public void SendError(string msg, int status) { }

	public void SendError() { }

	public void set_Prefix(ListenerPrefix value) { }

	private void Unbind() { }

}

