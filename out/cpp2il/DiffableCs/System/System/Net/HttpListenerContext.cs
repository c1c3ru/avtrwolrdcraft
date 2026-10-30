namespace System.Net;

public sealed class HttpListenerContext
{
	private HttpListenerRequest request; //Field offset: 0x10
	private HttpListenerResponse response; //Field offset: 0x18
	private HttpConnection cnc; //Field offset: 0x20
	private string error; //Field offset: 0x28
	private int err_status; //Field offset: 0x30
	internal HttpListener Listener; //Field offset: 0x38

	internal HttpConnection Connection
	{
		internal get { } //Length: 8
	}

	internal string ErrorMessage
	{
		internal get { } //Length: 8
		internal set { } //Length: 8
	}

	internal int ErrorStatus
	{
		internal get { } //Length: 8
		internal set { } //Length: 8
	}

	internal bool HaveError
	{
		internal get { } //Length: 16
	}

	public HttpListenerRequest Request
	{
		 get { } //Length: 8
	}

	public HttpListenerResponse Response
	{
		 get { } //Length: 8
	}

	internal HttpListenerContext(HttpConnection cnc) { }

	internal HttpConnection get_Connection() { }

	internal string get_ErrorMessage() { }

	internal int get_ErrorStatus() { }

	internal bool get_HaveError() { }

	public HttpListenerRequest get_Request() { }

	public HttpListenerResponse get_Response() { }

	internal void set_ErrorMessage(string value) { }

	internal void set_ErrorStatus(int value) { }

}

