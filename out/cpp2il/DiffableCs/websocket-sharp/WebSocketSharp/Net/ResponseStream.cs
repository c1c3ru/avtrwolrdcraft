namespace WebSocketSharp.Net;

internal class ResponseStream : Stream
{
	private static readonly Byte[] _crlf; //Field offset: 0x0
	private static readonly Byte[] _lastChunk; //Field offset: 0x8
	private static readonly int _maxHeadersLength; //Field offset: 0x10
	private MemoryStream _bodyBuffer; //Field offset: 0x28
	private bool _disposed; //Field offset: 0x30
	private Stream _innerStream; //Field offset: 0x38
	private HttpListenerResponse _response; //Field offset: 0x40
	private bool _sendChunked; //Field offset: 0x48
	private Action<Byte[], Int32, Int32> _write; //Field offset: 0x50
	private Action<Byte[], Int32, Int32> _writeBody; //Field offset: 0x58
	private Action<Byte[], Int32, Int32> _writeChunked; //Field offset: 0x60

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
		 get { } //Length: 16
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

	internal ResponseStream(Stream innerStream, HttpListenerResponse response, bool ignoreWriteExceptions) { }

	public virtual IAsyncResult BeginRead(Byte[] buffer, int offset, int count, AsyncCallback callback, object state) { }

	public virtual IAsyncResult BeginWrite(Byte[] buffer, int offset, int count, AsyncCallback callback, object state) { }

	public virtual void Close() { }

	internal void Close(bool force) { }

	protected virtual void Dispose(bool disposing) { }

	public virtual int EndRead(IAsyncResult asyncResult) { }

	public virtual void EndWrite(IAsyncResult asyncResult) { }

	private bool flush(bool closing) { }

	public virtual void Flush() { }

	private void flushBody(bool closing) { }

	private bool flushHeaders() { }

	public virtual bool get_CanRead() { }

	public virtual bool get_CanSeek() { }

	public virtual bool get_CanWrite() { }

	public virtual long get_Length() { }

	public virtual long get_Position() { }

	private static Byte[] getChunkSizeBytes(int size) { }

	internal void InternalWrite(Byte[] buffer, int offset, int count) { }

	public virtual int Read(Byte[] buffer, int offset, int count) { }

	public virtual long Seek(long offset, SeekOrigin origin) { }

	public virtual void set_Position(long value) { }

	public virtual void SetLength(long value) { }

	public virtual void Write(Byte[] buffer, int offset, int count) { }

	private void writeChunked(Byte[] buffer, int offset, int count) { }

	private void writeChunkedWithoutThrowingException(Byte[] buffer, int offset, int count) { }

	private void writeWithoutThrowingException(Byte[] buffer, int offset, int count) { }

}

