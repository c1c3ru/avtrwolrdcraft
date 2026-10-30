namespace WebSocketSharp.Net;

public sealed class HttpListenerResponse : IDisposable
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass72_0
	{
		public Stream stream; //Field offset: 0x10
		public HttpListenerResponse <>4__this; //Field offset: 0x18

		public <>c__DisplayClass72_0() { }

		internal void <Close>b__0(IAsyncResult ar) { }

	}

	[CompilerGenerated]
	private sealed class <findCookie>d__65 : IEnumerable<Cookie>, IEnumerable, IEnumerator<Cookie>, IDisposable, IEnumerator
	{
		private int <>1__state; //Field offset: 0x10
		private Cookie <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x20
		private Cookie cookie; //Field offset: 0x28
		public Cookie <>3__cookie; //Field offset: 0x30
		public HttpListenerResponse <>4__this; //Field offset: 0x38
		private IEnumerator<Cookie> <>s__1; //Field offset: 0x40
		private Cookie <c>5__2; //Field offset: 0x48

		private override Cookie System.Collections.Generic.IEnumerator<WebSocketSharp.Net.Cookie>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <findCookie>d__65(int <>1__state) { }

		private void <>m__Finally1() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<Cookie> System.Collections.Generic.IEnumerable<WebSocketSharp.Net.Cookie>.GetEnumerator() { }

		[DebuggerHidden]
		private override Cookie System.Collections.Generic.IEnumerator<WebSocketSharp.Net.Cookie>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private bool _closeConnection; //Field offset: 0x10
	private Encoding _contentEncoding; //Field offset: 0x18
	private long _contentLength; //Field offset: 0x20
	private string _contentType; //Field offset: 0x28
	private HttpListenerContext _context; //Field offset: 0x30
	private CookieCollection _cookies; //Field offset: 0x38
	private bool _disposed; //Field offset: 0x40
	private WebHeaderCollection _headers; //Field offset: 0x48
	private bool _headersSent; //Field offset: 0x50
	private bool _keepAlive; //Field offset: 0x51
	private ResponseStream _outputStream; //Field offset: 0x58
	private Uri _redirectLocation; //Field offset: 0x60
	private bool _sendChunked; //Field offset: 0x68
	private int _statusCode; //Field offset: 0x6C
	private string _statusDescription; //Field offset: 0x70
	private Version _version; //Field offset: 0x78

	internal bool CloseConnection
	{
		internal get { } //Length: 8
		internal set { } //Length: 12
	}

	public Encoding ContentEncoding
	{
		 get { } //Length: 8
		 set { } //Length: 184
	}

	public long ContentLength64
	{
		 get { } //Length: 8
		 set { } //Length: 260
	}

	public string ContentType
	{
		 get { } //Length: 8
		 set { } //Length: 328
	}

	public CookieCollection Cookies
	{
		 get { } //Length: 112
		 set { } //Length: 8
	}

	internal WebHeaderCollection FullHeaders
	{
		internal get { } //Length: 1808
	}

	public WebHeaderCollection Headers
	{
		 get { } //Length: 124
		 set { } //Length: 120
	}

	internal bool HeadersSent
	{
		internal get { } //Length: 8
		internal set { } //Length: 12
	}

	public bool KeepAlive
	{
		 get { } //Length: 8
		 set { } //Length: 188
	}

	public Stream OutputStream
	{
		 get { } //Length: 188
	}

	public Version ProtocolVersion
	{
		 get { } //Length: 8
	}

	public string RedirectLocation
	{
		 get { } //Length: 136
		 set { } //Length: 412
	}

	public bool SendChunked
	{
		 get { } //Length: 8
		 set { } //Length: 188
	}

	public int StatusCode
	{
		 get { } //Length: 8
		 set { } //Length: 340
	}

	public string StatusDescription
	{
		 get { } //Length: 8
		 set { } //Length: 460
	}

	internal string StatusLine
	{
		internal get { } //Length: 144
	}

	internal HttpListenerResponse(HttpListenerContext context) { }

	[CompilerGenerated]
	private void <close>b__63_0() { }

	public void Abort() { }

	public void AppendCookie(Cookie cookie) { }

	public void AppendHeader(string name, string value) { }

	private bool canSetCookie(Cookie cookie) { }

	private void close(bool force) { }

	private void close(Byte[] responseEntity, int bufferLength, bool willBlock) { }

	public void Close(Byte[] responseEntity, bool willBlock) { }

	public void Close() { }

	public void CopyFrom(HttpListenerResponse templateResponse) { }

	private static string createContentTypeHeaderText(string value, Encoding encoding) { }

	[IteratorStateMachine(typeof(<findCookie>d__65))]
	private IEnumerable<Cookie> findCookie(Cookie cookie) { }

	internal bool get_CloseConnection() { }

	public Encoding get_ContentEncoding() { }

	public long get_ContentLength64() { }

	public string get_ContentType() { }

	public CookieCollection get_Cookies() { }

	internal WebHeaderCollection get_FullHeaders() { }

	public WebHeaderCollection get_Headers() { }

	internal bool get_HeadersSent() { }

	public bool get_KeepAlive() { }

	public Stream get_OutputStream() { }

	public Version get_ProtocolVersion() { }

	public string get_RedirectLocation() { }

	public bool get_SendChunked() { }

	public int get_StatusCode() { }

	public string get_StatusDescription() { }

	internal string get_StatusLine() { }

	private static bool isValidForContentType(string value) { }

	private static bool isValidForStatusDescription(string value) { }

	public void Redirect(string url) { }

	internal void set_CloseConnection(bool value) { }

	public void set_ContentEncoding(Encoding value) { }

	public void set_ContentLength64(long value) { }

	public void set_ContentType(string value) { }

	public void set_Cookies(CookieCollection value) { }

	public void set_Headers(WebHeaderCollection value) { }

	internal void set_HeadersSent(bool value) { }

	public void set_KeepAlive(bool value) { }

	public void set_RedirectLocation(string value) { }

	public void set_SendChunked(bool value) { }

	public void set_StatusCode(int value) { }

	public void set_StatusDescription(string value) { }

	public void SetCookie(Cookie cookie) { }

	public void SetHeader(string name, string value) { }

	private override void System.IDisposable.Dispose() { }

}

