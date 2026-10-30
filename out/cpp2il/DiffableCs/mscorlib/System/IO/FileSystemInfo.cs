namespace System.IO;

public abstract class FileSystemInfo : MarshalByRefObject, ISerializable
{
	private FileStatus _fileStatus; //Field offset: 0x18
	protected string FullPath; //Field offset: 0x90
	protected string OriginalPath; //Field offset: 0x98
	internal string _name; //Field offset: 0xA0

	public FileAttributes Attributes
	{
		 get { } //Length: 204
	}

	public override bool Exists
	{
		 get { } //Length: 136
	}

	internal bool ExistsCore
	{
		internal get { } //Length: 152
	}

	public override string FullName
	{
		 get { } //Length: 8
	}

	public DateTime LastWriteTime
	{
		 get { } //Length: 116
	}

	internal DateTimeOffset LastWriteTimeCore
	{
		internal get { } //Length: 108
		internal set { } //Length: 24
	}

	public DateTime LastWriteTimeUtc
	{
		 get { } //Length: 116
	}

	public override string Name
	{
		 get { } //Length: 8
	}

	internal string NormalizedPath
	{
		internal get { } //Length: 8
	}

	protected FileSystemInfo() { }

	protected FileSystemInfo(SerializationInfo info, StreamingContext context) { }

	internal static FileSystemInfo Create(string fullPath, string fileName, ref FileStatus fileStatus) { }

	public abstract void Delete() { }

	public FileAttributes get_Attributes() { }

	public override bool get_Exists() { }

	internal bool get_ExistsCore() { }

	public override string get_FullName() { }

	public DateTime get_LastWriteTime() { }

	internal DateTimeOffset get_LastWriteTimeCore() { }

	public DateTime get_LastWriteTimeUtc() { }

	public override string get_Name() { }

	internal string get_NormalizedPath() { }

	[ComVisible(False)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context) { }

	internal void Init(ref FileStatus fileStatus) { }

	internal void set_LastWriteTimeCore(DateTimeOffset value) { }

	internal static void ThrowNotFound(string path) { }

	public virtual string ToString() { }

}

