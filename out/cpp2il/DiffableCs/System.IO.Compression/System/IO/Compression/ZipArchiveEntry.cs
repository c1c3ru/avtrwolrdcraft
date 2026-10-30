namespace System.IO.Compression;

public class ZipArchiveEntry
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<Int64, Int64, UInt32, Stream, ZipArchiveEntry, EventHandler> <>9__69_0; //Field offset: 0x8
		public static EventHandler <>9__72_0; //Field offset: 0x10
		public static Action<ZipArchiveEntry> <>9__73_0; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal void <GetDataCompressor>b__69_0(long initialPosition, long currentPosition, uint checkSum, Stream backing, ZipArchiveEntry thisRef, EventHandler closeHandler) { }

		internal void <OpenInUpdateMode>b__73_0(ZipArchiveEntry thisRef) { }

		internal void <OpenInWriteMode>b__72_0(object o, EventArgs e) { }

	}

	[Flags]
	private enum BitFlagValues
	{
		DataDescriptor = 8,
		UnicodeFileName = 2048,
	}

	public enum CompressionMethodValues
	{
		Stored = 0,
		Deflate = 8,
		Deflate64 = 9,
		BZip2 = 12,
		LZMA = 14,
	}

	private sealed class DirectToArchiveWriterStream : Stream
	{
		private long _position; //Field offset: 0x28
		private CheckSumAndSizeWriteStream _crcSizeStream; //Field offset: 0x30
		private bool _everWritten; //Field offset: 0x38
		private bool _isDisposed; //Field offset: 0x39
		private ZipArchiveEntry _entry; //Field offset: 0x40
		private bool _usedZip64inLH; //Field offset: 0x48
		private bool _canWrite; //Field offset: 0x49

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

		public DirectToArchiveWriterStream(CheckSumAndSizeWriteStream crcSizeStream, ZipArchiveEntry entry) { }

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

	private static readonly bool s_allowLargeZipArchiveEntriesInUpdateMode; //Field offset: 0x0
	internal static readonly ZipVersionMadeByPlatform CurrentZipPlatform; //Field offset: 0x1
	private ZipArchive _archive; //Field offset: 0x10
	private readonly bool _originallyInArchive; //Field offset: 0x18
	private readonly int _diskNumberStart; //Field offset: 0x1C
	private readonly ZipVersionMadeByPlatform _versionMadeByPlatform; //Field offset: 0x20
	private ZipVersionNeededValues _versionMadeBySpecification; //Field offset: 0x22
	private ZipVersionNeededValues _versionToExtract; //Field offset: 0x24
	private BitFlagValues _generalPurposeBitFlag; //Field offset: 0x26
	private CompressionMethodValues _storedCompressionMethod; //Field offset: 0x28
	private DateTimeOffset _lastModified; //Field offset: 0x30
	private long _compressedSize; //Field offset: 0x40
	private long _uncompressedSize; //Field offset: 0x48
	private long _offsetOfLocalHeader; //Field offset: 0x50
	private Nullable<Int64> _storedOffsetOfCompressedData; //Field offset: 0x58
	private uint _crc32; //Field offset: 0x68
	private Byte[][] _compressedBytes; //Field offset: 0x70
	private MemoryStream _storedUncompressedData; //Field offset: 0x78
	private bool _currentlyOpenForWrite; //Field offset: 0x80
	private bool _everOpenedForWrite; //Field offset: 0x81
	private Stream _outstandingWriteStream; //Field offset: 0x88
	private uint _externalFileAttr; //Field offset: 0x90
	private string _storedEntryName; //Field offset: 0x98
	private Byte[] _storedEntryNameBytes; //Field offset: 0xA0
	private List<ZipGenericExtraField> _cdUnknownExtraFields; //Field offset: 0xA8
	private List<ZipGenericExtraField> _lhUnknownExtraFields; //Field offset: 0xB0
	private Byte[] _fileComment; //Field offset: 0xB8
	private Nullable<CompressionLevel> _compressionLevel; //Field offset: 0xC0

	private CompressionMethodValues CompressionMethod
	{
		private get { } //Length: 8
		private set { } //Length: 108
	}

	internal bool EverOpenedForWrite
	{
		internal get { } //Length: 8
	}

	public private string FullName
	{
		 get { } //Length: 8
		private set { } //Length: 344
	}

	public DateTimeOffset LastWriteTime
	{
		 get { } //Length: 12
		 set { } //Length: 492
	}

	public long Length
	{
		 get { } //Length: 96
	}

	private long OffsetOfCompressedData
	{
		private get { } //Length: 320
	}

	private MemoryStream UncompressedData
	{
		private get { } //Length: 724
	}

	private static ZipArchiveEntry() { }

	internal ZipArchiveEntry(ZipArchive archive, string entryName) { }

	internal ZipArchiveEntry(ZipArchive archive, ZipCentralDirectoryFileHeader cd) { }

	internal ZipArchiveEntry(ZipArchive archive, string entryName, CompressionLevel compressionLevel) { }

	private void CloseStreams() { }

	private string DecodeEntryName(Byte[] entryNameBytes) { }

	public void Delete() { }

	private Byte[] EncodeEntryName(string entryName, out bool isUTF8) { }

	private CompressionMethodValues get_CompressionMethod() { }

	internal bool get_EverOpenedForWrite() { }

	public string get_FullName() { }

	public DateTimeOffset get_LastWriteTime() { }

	public long get_Length() { }

	private long get_OffsetOfCompressedData() { }

	private MemoryStream get_UncompressedData() { }

	private CheckSumAndSizeWriteStream GetDataCompressor(Stream backingStream, bool leaveBackingStreamOpen, EventHandler onClose) { }

	private Stream GetDataDecompressor(Stream compressedStreamToRead) { }

	private static string GetFileName_Unix(string path) { }

	private static string GetFileName_Windows(string path) { }

	private bool IsOpenable(bool needToUncompress, bool needToLoadIntoMemory, out string message) { }

	internal bool LoadLocalHeaderExtraFieldAndCompressedBytesIfNeeded() { }

	public Stream Open() { }

	private Stream OpenInReadMode(bool checkOpenable) { }

	private Stream OpenInUpdateMode() { }

	private Stream OpenInWriteMode() { }

	internal static string ParseFileName(string path, ZipVersionMadeByPlatform madeByPlatform) { }

	private void set_CompressionMethod(CompressionMethodValues value) { }

	private void set_FullName(string value) { }

	public void set_LastWriteTime(DateTimeOffset value) { }

	private bool SizesTooLarge() { }

	private void ThrowIfInvalidArchive() { }

	internal void ThrowIfNotOpenable(bool needToUncompress, bool needToLoadIntoMemory) { }

	public virtual string ToString() { }

	private void UnloadStreams() { }

	private void VersionToExtractAtLeast(ZipVersionNeededValues value) { }

	internal void WriteAndFinishLocalEntry() { }

	internal void WriteCentralDirectoryFileHeader() { }

	private void WriteCrcAndSizesInLocalHeader(bool zip64HeaderUsed) { }

	private void WriteDataDescriptor() { }

	private bool WriteLocalFileHeader(bool isEmptyFile) { }

	private void WriteLocalFileHeaderAndDataIfNeeded() { }

}

