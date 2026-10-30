namespace System.Net;

internal class RequestStream : Stream
{
	private Byte[] buffer; //Field offset: 0x28
	private int offset; //Field offset: 0x30
	private int length; //Field offset: 0x34
	private long remaining_body; //Field offset: 0x38
	private bool disposed; //Field offset: 0x40
	private Stream stream; //Field offset: 0x48

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

	internal RequestStream(Stream stream, Byte[] buffer, int offset, int length) { }

	internal RequestStream(Stream stream, Byte[] buffer, int offset, int length, long contentlength) { }

	public virtual IAsyncResult BeginRead(Byte[] buffer, int offset, int count, AsyncCallback cback, object state) { }

	public virtual IAsyncResult BeginWrite(Byte[] buffer, int offset, int count, AsyncCallback cback, object state) { }

	public virtual void Close() { }

	public virtual int EndRead(IAsyncResult ares) { }

	public virtual void EndWrite(IAsyncResult async_result) { }

	private int FillFromBuffer(Byte[] buffer, int off, int count) { }

	public virtual void Flush() { }

	public virtual bool get_CanRead() { }

	public virtual bool get_CanSeek() { }

	public virtual bool get_CanWrite() { }

	public virtual long get_Length() { }

	public virtual long get_Position() { }

	public virtual int Read(out Byte[] buffer, int offset, int count) { }

	public virtual long Seek(long offset, SeekOrigin origin) { }

	public virtual void set_Position(long value) { }

	public virtual void SetLength(long value) { }

	public virtual void Write(Byte[] buffer, int offset, int count) { }

}

