namespace System.IO.Enumeration;

[IsByRefLike]
[Obsolete("Types with embedded references are not supported in this version of your compiler.", True)]
public struct FileSystemEntry
{
	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <_fileNameBuffer>e__FixedBuffer
	{
		public char FixedElementField; //Field offset: 0x0

	}

	internal DirectoryEntry _directoryEntry; //Field offset: 0x0
	private FileStatus _status; //Field offset: 0x10
	private Span<Char> _pathBuffer; //Field offset: 0x88
	private ReadOnlySpan<Char> _fullPath; //Field offset: 0x98
	private ReadOnlySpan<Char> _fileName; //Field offset: 0xA8
	[FixedBuffer(typeof(char), 256)]
	private <_fileNameBuffer>e__FixedBuffer _fileNameBuffer; //Field offset: 0xB8
	private FileAttributes _initialAttributes; //Field offset: 0x2B8
	[CompilerGenerated]
	private ReadOnlySpan<Char> <Directory>k__BackingField; //Field offset: 0x2C0
	[CompilerGenerated]
	private ReadOnlySpan<Char> <RootDirectory>k__BackingField; //Field offset: 0x2D0
	[CompilerGenerated]
	private ReadOnlySpan<Char> <OriginalRootDirectory>k__BackingField; //Field offset: 0x2E0

	public FileAttributes Attributes
	{
		 get { } //Length: 72
	}

	public private ReadOnlySpan<Char> Directory
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 16
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public ReadOnlySpan<Char> FileName
	{
		 get { } //Length: 112
	}

	private ReadOnlySpan<Char> FullPath
	{
		private get { } //Length: 304
	}

	public bool IsDirectory
	{
		 get { } //Length: 8
	}

	public private ReadOnlySpan<Char> OriginalRootDirectory
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 16
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public private ReadOnlySpan<Char> RootDirectory
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 16
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public FileAttributes get_Attributes() { }

	[CompilerGenerated]
	[IsReadOnly]
	public ReadOnlySpan<Char> get_Directory() { }

	public ReadOnlySpan<Char> get_FileName() { }

	private ReadOnlySpan<Char> get_FullPath() { }

	public bool get_IsDirectory() { }

	[CompilerGenerated]
	[IsReadOnly]
	public ReadOnlySpan<Char> get_OriginalRootDirectory() { }

	[CompilerGenerated]
	[IsReadOnly]
	public ReadOnlySpan<Char> get_RootDirectory() { }

	internal static FileAttributes Initialize(ref FileSystemEntry entry, DirectoryEntry directoryEntry, ReadOnlySpan<Char> directory, ReadOnlySpan<Char> rootDirectory, ReadOnlySpan<Char> originalRootDirectory, Span<Char> pathBuffer) { }

	[CompilerGenerated]
	private void set_Directory(ReadOnlySpan<Char> value) { }

	[CompilerGenerated]
	private void set_OriginalRootDirectory(ReadOnlySpan<Char> value) { }

	[CompilerGenerated]
	private void set_RootDirectory(ReadOnlySpan<Char> value) { }

	public FileSystemInfo ToFileSystemInfo() { }

	public string ToFullPath() { }

	public string ToSpecifiedFullPath() { }

}

