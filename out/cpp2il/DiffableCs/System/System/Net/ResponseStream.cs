namespace System.Net;

internal class ResponseStream : Stream
{
	private static Byte[] crlf; //Field offset: 0x0
	private HttpListenerResponse response; //Field offset: 0x28
	private bool ignore_errors; //Field offset: 0x30
	private bool disposed; //Field offset: 0x31
	private bool trailer_sent; //Field offset: 0x32
	private Stream stream; //Field offset: 0x38

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

	private static ResponseStream() { }

	internal ResponseStream(Stream stream, HttpListenerResponse response, bool ignore_errors) { }

	public virtual IAsyncResult BeginRead(Byte[] buffer, int offset, int count, AsyncCallback cback, object state) { }

	public virtual IAsyncResult BeginWrite(Byte[] buffer, int offset, int count, AsyncCallback cback, object state) { }

	public virtual void Close() { }

	public virtual int EndRead(IAsyncResult ares) { }

	public virtual void EndWrite(IAsyncResult ares) { }

	public virtual void Flush() { }

	public virtual bool get_CanRead() { }

	public virtual bool get_CanSeek() { }

	public virtual bool get_CanWrite() { }

	public virtual long get_Length() { }

	public virtual long get_Position() { }

	private static Byte[] GetChunkSizeBytes(int size, bool final) { }

	private MemoryStream GetHeaders(bool closing) { }

	internal void InternalWrite(Byte[] buffer, int offset, int count) { }

	public virtual int Read(out Byte[] buffer, int offset, int count) { }

	public virtual long Seek(long offset, SeekOrigin origin) { }

	public virtual void set_Position(long value) { }

	public virtual void SetLength(long value) { }

	public virtual void Write(Byte[] buffer, int offset, int count) { }

}

