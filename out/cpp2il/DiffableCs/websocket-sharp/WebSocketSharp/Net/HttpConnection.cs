namespace WebSocketSharp.Net;

internal sealed class HttpConnection
{
	private static readonly int _bufferLength; //Field offset: 0x0
	private static readonly int _maxInputLength; //Field offset: 0x4
	private int _attempts; //Field offset: 0x10
	private Byte[] _buffer; //Field offset: 0x18
	private HttpListenerContext _context; //Field offset: 0x20
	private StringBuilder _currentLine; //Field offset: 0x28
	private InputState _inputState; //Field offset: 0x30
	private RequestStream _inputStream; //Field offset: 0x38
	private LineState _lineState; //Field offset: 0x40
	private EndPointListener _listener; //Field offset: 0x48
	private EndPoint _localEndPoint; //Field offset: 0x50
	private ResponseStream _outputStream; //Field offset: 0x58
	private int _position; //Field offset: 0x60
	private EndPoint _remoteEndPoint; //Field offset: 0x68
	private MemoryStream _requestBuffer; //Field offset: 0x70
	private int _reuses; //Field offset: 0x78
	private bool _secure; //Field offset: 0x7C
	private Socket _socket; //Field offset: 0x80
	private Stream _stream; //Field offset: 0x88
	private object _sync; //Field offset: 0x90
	private int _timeout; //Field offset: 0x98
	private Dictionary<Int32, Boolean> _timeoutCanceled; //Field offset: 0xA0
	private Timer _timer; //Field offset: 0xA8

	public bool IsClosed
	{
		 get { } //Length: 16
	}

	public bool IsLocal
	{
		 get { } //Length: 176
	}

	public bool IsSecure
	{
		 get { } //Length: 8
	}

	public IPEndPoint LocalEndPoint
	{
		 get { } //Length: 120
	}

	public IPEndPoint RemoteEndPoint
	{
		 get { } //Length: 120
	}

	public int Reuses
	{
		 get { } //Length: 8
	}

	public Stream Stream
	{
		 get { } //Length: 8
	}

	private static HttpConnection() { }

	internal HttpConnection(Socket socket, EndPointListener listener) { }

	internal void BeginReadRequest() { }

	private void close() { }

	public void Close() { }

	internal void Close(bool force) { }

	private void closeSocket() { }

	private void disposeRequestBuffer() { }

	private void disposeStream() { }

	private void disposeTimer() { }

	public bool get_IsClosed() { }

	public bool get_IsLocal() { }

	public bool get_IsSecure() { }

	public IPEndPoint get_LocalEndPoint() { }

	public IPEndPoint get_RemoteEndPoint() { }

	public int get_Reuses() { }

	public Stream get_Stream() { }

	public RequestStream GetRequestStream(long contentLength, bool chunked) { }

	public ResponseStream GetResponseStream() { }

	private void init(int timeout) { }

	private static void onRead(IAsyncResult asyncResult) { }

	private static void onTimeout(object state) { }

	private bool processInput(Byte[] data, int length) { }

	private string readLineFrom(Byte[] buffer, int offset, int length, out int nread) { }

}

