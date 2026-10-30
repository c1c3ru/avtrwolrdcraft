namespace WebSocketSharp.Net;

internal class RequestStream : Stream
{
	private long _bodyLeft; //Field offset: 0x28
	private Byte[] _buffer; //Field offset: 0x30
	private int _count; //Field offset: 0x38
	private bool _disposed; //Field offset: 0x3C
	private int _offset; //Field offset: 0x40
	private Stream _stream; //Field offset: 0x48

	public virtual bool CanRead
	{
		 get { } //Length: 8
	}

	public virtual bool CanSeek
	{
		 get { } //Length: 8
	}

	public virtual bool CanWrite
	{
		 get { } //Length: 8
	}

	public virtual long Length
	{
		 get { } //Length: 56
	}

	public virtual long Position
	{
		 get { } //Length: 56
		 set { } //Length: 56
	}

	internal RequestStream(Stream stream, Byte[] buffer, int offset, int count, long contentLength) { }

	public virtual IAsyncResult BeginRead(Byte[] buffer, int offset, int count, AsyncCallback callback, object state) { }

	public virtual IAsyncResult BeginWrite(Byte[] buffer, int offset, int count, AsyncCallback callback, object state) { }

	public virtual void Close() { }

	public virtual int EndRead(IAsyncResult asyncResult) { }

	public virtual void EndWrite(IAsyncResult asyncResult) { }

	private int fillFromBuffer(Byte[] buffer, int offset, int count) { }

	public virtual void Flush() { }

	public virtual bool get_CanRead() { }

	public virtual bool get_CanSeek() { }

	public virtual bool get_CanWrite() { }

	public virtual long get_Length() { }

	public virtual long get_Position() { }

	public virtual int Read(Byte[] buffer, int offset, int count) { }

	public virtual long Seek(long offset, SeekOrigin origin) { }

	public virtual void set_Position(long value) { }

	public virtual void SetLength(long value) { }

	public virtual void Write(Byte[] buffer, int offset, int count) { }

}

