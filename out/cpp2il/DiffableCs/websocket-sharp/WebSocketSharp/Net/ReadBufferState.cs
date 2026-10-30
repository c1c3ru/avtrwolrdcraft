namespace WebSocketSharp.Net;

internal class ReadBufferState
{
	private HttpStreamAsyncResult _asyncResult; //Field offset: 0x10
	private Byte[] _buffer; //Field offset: 0x18
	private int _count; //Field offset: 0x20
	private int _initialCount; //Field offset: 0x24
	private int _offset; //Field offset: 0x28

	public HttpStreamAsyncResult AsyncResult
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public Byte[] Buffer
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public int Count
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public int InitialCount
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public int Offset
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public ReadBufferState(Byte[] buffer, int offset, int count, HttpStreamAsyncResult asyncResult) { }

	public HttpStreamAsyncResult get_AsyncResult() { }

	public Byte[] get_Buffer() { }

	public int get_Count() { }

	public int get_InitialCount() { }

	public int get_Offset() { }

	public void set_AsyncResult(HttpStreamAsyncResult value) { }

	public void set_Buffer(Byte[] value) { }

	public void set_Count(int value) { }

	public void set_InitialCount(int value) { }

	public void set_Offset(int value) { }

}

