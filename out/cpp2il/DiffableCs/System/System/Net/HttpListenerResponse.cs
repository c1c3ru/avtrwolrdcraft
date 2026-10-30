namespace System.Net;

public sealed class HttpListenerResponse : IDisposable
{
	private static string tspecials; //Field offset: 0x0
	private bool disposed; //Field offset: 0x10
	private Encoding content_encoding; //Field offset: 0x18
	private long content_length; //Field offset: 0x20
	private bool cl_set; //Field offset: 0x28
	private string content_type; //Field offset: 0x30
	private CookieCollection cookies; //Field offset: 0x38
	private WebHeaderCollection headers; //Field offset: 0x40
	private bool keep_alive; //Field offset: 0x48
	private ResponseStream output_stream; //Field offset: 0x50
	private Version version; //Field offset: 0x58
	private string location; //Field offset: 0x60
	private int status_code; //Field offset: 0x68
	private string status_description; //Field offset: 0x70
	private bool chunked; //Field offset: 0x78
	private HttpListenerContext context; //Field offset: 0x80
	internal bool HeadersSent; //Field offset: 0x88
	internal object headers_lock; //Field offset: 0x90
	private bool force_close_chunked; //Field offset: 0x98

	public Encoding ContentEncoding
	{
		 get { } //Length: 48
	}

	public long ContentLength64
	{
		 set { } //Length: 288
	}

	public string ContentType
	{
		 set { } //Length: 204
	}

	internal bool ForceCloseChunked
	{
		internal get { } //Length: 8
	}

	public WebHeaderCollection Headers
	{
		 get { } //Length: 8
	}

	public Stream OutputStream
	{
		 get { } //Length: 72
	}

	public bool SendChunked
	{
		 get { } //Length: 8
		 set { } //Length: 208
	}

	public int StatusCode
	{
		 set { } //Length: 300
	}

	private static HttpListenerResponse() { }

	internal HttpListenerResponse(HttpListenerContext context) { }

	private void Close(bool force) { }

	public void Close() { }

	public void Close(Byte[] responseEntity, bool willBlock) { }

	private static string CookieToClientString(Cookie cookie) { }

	private static string FormatHeaders(WebHeaderCollection headers) { }

	public Encoding get_ContentEncoding() { }

	internal bool get_ForceCloseChunked() { }

	public WebHeaderCollection get_Headers() { }

	public Stream get_OutputStream() { }

	public bool get_SendChunked() { }

	private static bool IsToken(string value) { }

	private static string QuotedString(Cookie cookie, string value) { }

	internal void SendHeaders(bool closing, MemoryStream ms) { }

	public void set_ContentLength64(long value) { }

	public void set_ContentType(string value) { }

	public void set_SendChunked(bool value) { }

	public void set_StatusCode(int value) { }

	private override void System.IDisposable.Dispose() { }

}

