namespace System.IO.Compression;

internal sealed class PositionPreservingWriteOnlyStreamWrapper : Stream
{
	private readonly Stream _stream; //Field offset: 0x28
	private long _position; //Field offset: 0x30

	public virtual bool CanRead
	{
		 get { } //Length: 8
	}

	public virtual bool CanSeek
	{
		 get { } //Length: 8
	}

	public virtual bool CanTimeout
	{
		 get { } //Length: 32
	}

	public virtual bool CanWrite
	{
		 get { } //Length: 8
	}

	public virtual long Length
	{
		 get { } //Length: 76
	}

	public virtual long Position
	{
		 get { } //Length: 8
		 set { } //Length: 76
	}

	public virtual int ReadTimeout
	{
		 get { } //Length: 36
		 set { } //Length: 36
	}

	public virtual int WriteTimeout
	{
		 get { } //Length: 36
		 set { } //Length: 36
	}

	public PositionPreservingWriteOnlyStreamWrapper(Stream stream) { }

	public virtual IAsyncResult BeginWrite(Byte[] buffer, int offset, int count, AsyncCallback callback, object state) { }

	public virtual void Close() { }

	protected virtual void Dispose(bool disposing) { }

	public virtual void EndWrite(IAsyncResult asyncResult) { }

	public virtual void Flush() { }

	public virtual Task FlushAsync(CancellationToken cancellationToken) { }

	public virtual bool get_CanRead() { }

	public virtual bool get_CanSeek() { }

	public virtual bool get_CanTimeout() { }

	public virtual bool get_CanWrite() { }

	public virtual long get_Length() { }

	public virtual long get_Position() { }

	public virtual int get_ReadTimeout() { }

	public virtual int get_WriteTimeout() { }

	public virtual int Read(Byte[] buffer, int offset, int count) { }

	public virtual long Seek(long offset, SeekOrigin origin) { }

	public virtual void set_Position(long value) { }

	public virtual void set_ReadTimeout(int value) { }

	public virtual void set_WriteTimeout(int value) { }

	public virtual void SetLength(long value) { }

	public virtual void Write(Byte[] buffer, int offset, int count) { }

	public virtual Task WriteAsync(Byte[] buffer, int offset, int count, CancellationToken cancellationToken) { }

	public virtual void WriteByte(byte value) { }

}

