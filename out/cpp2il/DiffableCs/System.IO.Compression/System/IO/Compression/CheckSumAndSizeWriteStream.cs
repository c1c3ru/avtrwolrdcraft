namespace System.IO.Compression;

internal sealed class CheckSumAndSizeWriteStream : Stream
{
	private readonly Stream _baseStream; //Field offset: 0x28
	private readonly Stream _baseBaseStream; //Field offset: 0x30
	private long _position; //Field offset: 0x38
	private uint _checksum; //Field offset: 0x40
	private readonly bool _leaveOpenOnClose; //Field offset: 0x44
	private bool _canWrite; //Field offset: 0x45
	private bool _isDisposed; //Field offset: 0x46
	private bool _everWritten; //Field offset: 0x47
	private long _initialPosition; //Field offset: 0x48
	private readonly ZipArchiveEntry _zipArchiveEntry; //Field offset: 0x50
	private readonly EventHandler _onClose; //Field offset: 0x58
	private readonly Action<Int64, Int64, UInt32, Stream, ZipArchiveEntry, EventHandler> _saveCrcAndSizes; //Field offset: 0x60

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
		 get { } //Length: 80
	}

	public virtual long Position
	{
		 get { } //Length: 24
		 set { } //Length: 80
	}

	public CheckSumAndSizeWriteStream(Stream baseStream, Stream baseBaseStream, bool leaveOpenOnClose, ZipArchiveEntry entry, EventHandler onClose, Action<Int64, Int64, UInt32, Stream, ZipArchiveEntry, EventHandler> saveCrcAndSizes) { }

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

	private void ThrowIfDisposed() { }

	public virtual void Write(Byte[] buffer, int offset, int count) { }

}

