namespace UnityWebSocketSharp.Net;

internal class RequestStream : Stream
{
	private long _bodyLeft; //Field offset: 0x28
	private int _count; //Field offset: 0x30
	private bool _disposed; //Field offset: 0x34
	private Byte[] _initialBuffer; //Field offset: 0x38
	private Stream _innerStream; //Field offset: 0x40
	private int _offset; //Field offset: 0x48

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

	internal int Count
	{
		internal get { } //Length: 8
	}

	internal Byte[] InitialBuffer
	{
		internal get { } //Length: 8
	}

	public virtual long Length
	{
		 get { } //Length: 56
	}

	internal int Offset
	{
		internal get { } //Length: 8
	}

	public virtual long Position
	{
		 get { } //Length: 56
		 set { } //Length: 56
	}

	internal RequestStream(Stream innerStream, Byte[] initialBuffer, int offset, int count, long contentLength) { }

	public virtual IAsyncResult BeginRead(Byte[] buffer, int offset, int count, AsyncCallback callback, object state) { }

	public virtual IAsyncResult BeginWrite(Byte[] buffer, int offset, int count, AsyncCallback callback, object state) { }

	public virtual void Close() { }

	public virtual int EndRead(IAsyncResult asyncResult) { }

	public virtual void EndWrite(IAsyncResult asyncResult) { }

	private int fillFromInitialBuffer(Byte[] buffer, int offset, int count) { }

	public virtual void Flush() { }

	public virtual bool get_CanRead() { }

	public virtual bool get_CanSeek() { }

	public virtual bool get_CanWrite() { }

	internal int get_Count() { }

	internal Byte[] get_InitialBuffer() { }

	public virtual long get_Length() { }

	internal int get_Offset() { }

	public virtual long get_Position() { }

	public virtual int Read(Byte[] buffer, int offset, int count) { }

	public virtual long Seek(long offset, SeekOrigin origin) { }

	public virtual void set_Position(long value) { }

	public virtual void SetLength(long value) { }

	public virtual void Write(Byte[] buffer, int offset, int count) { }

}

