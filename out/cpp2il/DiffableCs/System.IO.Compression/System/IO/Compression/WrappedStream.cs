namespace System.IO.Compression;

internal sealed class WrappedStream : Stream
{
	private readonly Stream _baseStream; //Field offset: 0x28
	private readonly bool _closeBaseStream; //Field offset: 0x30
	private readonly Action<ZipArchiveEntry> _onClosed; //Field offset: 0x38
	private readonly ZipArchiveEntry _zipArchiveEntry; //Field offset: 0x40
	private bool _isDisposed; //Field offset: 0x48

	public virtual bool CanRead
	{
		 get { } //Length: 52
	}

	public virtual bool CanSeek
	{
		 get { } //Length: 52
	}

	public virtual bool CanWrite
	{
		 get { } //Length: 52
	}

	public virtual long Length
	{
		 get { } //Length: 40
	}

	public virtual long Position
	{
		 get { } //Length: 40
		 set { } //Length: 68
	}

	internal WrappedStream(Stream baseStream, bool closeBaseStream) { }

	private WrappedStream(Stream baseStream, bool closeBaseStream, ZipArchiveEntry entry, Action<ZipArchiveEntry> onClosed) { }

	internal WrappedStream(Stream baseStream, ZipArchiveEntry entry, Action<ZipArchiveEntry> onClosed) { }

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

	private void ThrowIfCantSeek() { }

	private void ThrowIfCantWrite() { }

	private void ThrowIfDisposed() { }

	public virtual void Write(Byte[] buffer, int offset, int count) { }

}

