namespace System.IO.Compression;

public class ZipArchive : IDisposable
{
	private Stream _archiveStream; //Field offset: 0x10
	private ZipArchiveEntry _archiveStreamOwner; //Field offset: 0x18
	private BinaryReader _archiveReader; //Field offset: 0x20
	private ZipArchiveMode _mode; //Field offset: 0x28
	private List<ZipArchiveEntry> _entries; //Field offset: 0x30
	private ReadOnlyCollection<ZipArchiveEntry> _entriesCollection; //Field offset: 0x38
	private Dictionary<String, ZipArchiveEntry> _entriesDictionary; //Field offset: 0x40
	private bool _readEntries; //Field offset: 0x48
	private bool _leaveOpen; //Field offset: 0x49
	private long _centralDirectoryStart; //Field offset: 0x50
	private bool _isDisposed; //Field offset: 0x58
	private uint _numberOfThisDisk; //Field offset: 0x5C
	private long _expectedNumberOfEntries; //Field offset: 0x60
	private Stream _backingStream; //Field offset: 0x68
	private Byte[] _archiveComment; //Field offset: 0x70
	private Encoding _entryNameEncoding; //Field offset: 0x78

	internal BinaryReader ArchiveReader
	{
		internal get { } //Length: 8
	}

	internal Stream ArchiveStream
	{
		internal get { } //Length: 8
	}

	public ReadOnlyCollection<ZipArchiveEntry> Entries
	{
		 get { } //Length: 132
	}

	internal Encoding EntryNameEncoding
	{
		internal get { } //Length: 8
		private set { } //Length: 200
	}

	public ZipArchiveMode Mode
	{
		 get { } //Length: 8
	}

	internal uint NumberOfThisDisk
	{
		internal get { } //Length: 8
	}

	public ZipArchive(Stream stream, ZipArchiveMode mode, bool leaveOpen, Encoding entryNameEncoding) { }

	internal void AcquireArchiveStream(ZipArchiveEntry entry) { }

	private void AddEntry(ZipArchiveEntry entry) { }

	private void CloseStreams() { }

	public ZipArchiveEntry CreateEntry(string entryName) { }

	public ZipArchiveEntry CreateEntry(string entryName, CompressionLevel compressionLevel) { }

	protected override void Dispose(bool disposing) { }

	public override void Dispose() { }

	private ZipArchiveEntry DoCreateEntry(string entryName, Nullable<CompressionLevel> compressionLevel) { }

	private void EnsureCentralDirectoryRead() { }

	internal BinaryReader get_ArchiveReader() { }

	internal Stream get_ArchiveStream() { }

	public ReadOnlyCollection<ZipArchiveEntry> get_Entries() { }

	internal Encoding get_EntryNameEncoding() { }

	public ZipArchiveMode get_Mode() { }

	internal uint get_NumberOfThisDisk() { }

	private void Init(Stream stream, ZipArchiveMode mode, bool leaveOpen) { }

	private void ReadCentralDirectory() { }

	private void ReadEndOfCentralDirectory() { }

	internal void ReleaseArchiveStream(ZipArchiveEntry entry) { }

	internal void RemoveEntry(ZipArchiveEntry entry) { }

	private void set_EntryNameEncoding(Encoding value) { }

	internal void ThrowIfDisposed() { }

	private void WriteArchiveEpilogue(long startOfCentralDirectory, long sizeOfCentralDirectory) { }

	private void WriteFile() { }

}

