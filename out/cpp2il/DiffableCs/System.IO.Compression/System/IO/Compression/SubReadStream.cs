namespace System.IO.Compression;

internal sealed class SubReadStream : Stream
{
	private readonly long _startInSuperStream; //Field offset: 0x28
	private long _positionInSuperStream; //Field offset: 0x30
	private readonly long _endInSuperStream; //Field offset: 0x38
	private readonly Stream _superStream; //Field offset: 0x40
	private bool _canRead; //Field offset: 0x48
	private bool _isDisposed; //Field offset: 0x49

	public virtual bool CanRead
	{
		 get { } //Length: 64
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
		 get { } //Length: 32
	}

	public virtual long Position
	{
		 get { } //Length: 28
		 set { } //Length: 80
	}

	public SubReadStream(Stream superStream, long startPosition, long maxLength) { }

	protected virtual void Dispose(bool disposing) { }

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

	private void ThrowIfCantRead() { }

	private void ThrowIfDisposed() { }

	public virtual void Write(Byte[] buffer, int offset, int count) { }

}

