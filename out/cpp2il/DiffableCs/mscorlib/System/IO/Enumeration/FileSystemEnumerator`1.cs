namespace System.IO.Enumeration;

public abstract class FileSystemEnumerator : CriticalFinalizerObject, IEnumerator<TResult>, IDisposable, IEnumerator
{
	private readonly string _originalRootDirectory; //Field offset: 0x0
	private readonly string _rootDirectory; //Field offset: 0x0
	private readonly EnumerationOptions _options; //Field offset: 0x0
	private readonly object _lock; //Field offset: 0x0
	private string _currentPath; //Field offset: 0x0
	private IntPtr _directoryHandle; //Field offset: 0x0
	private bool _lastEntryFound; //Field offset: 0x0
	private Queue<String> _pending; //Field offset: 0x0
	private DirectoryEntry _entry; //Field offset: 0x0
	private TResult _current; //Field offset: 0x0
	private Char[] _pathBuffer; //Field offset: 0x0
	private Byte[] _entryBuffer; //Field offset: 0x0

	public override TResult Current
	{
		 get { } //Length: 8
	}

	private override object System.Collections.IEnumerator.Current
	{
		private get { } //Length: 8
	}

	public FileSystemEnumerator`1(string directory, EnumerationOptions options = null) { }

	private void CloseDirectoryHandle() { }

	protected override bool ContinueOnError(int error) { }

	private IntPtr CreateDirectoryHandle(string path, bool ignoreNotFound = false) { }

	private bool DequeueNextDirectory() { }

	private void DirectoryFinished() { }

	public override void Dispose() { }

	protected override void Dispose(bool disposing) { }

	protected virtual void Finalize() { }

	private void FindNextEntry() { }

	private void FindNextEntry(Byte* entryBufferPtr, int bufferLength) { }

	public override TResult get_Current() { }

	private bool InternalContinueOnError(ErrorInfo info, bool ignoreNotFound = false) { }

	private void InternalDispose(bool disposing) { }

	private static bool IsAccessError(ErrorInfo info) { }

	private static bool IsDirectoryNotFound(ErrorInfo info) { }

	public override bool MoveNext() { }

	protected override void OnDirectoryFinished(ReadOnlySpan<Char> directory) { }

	public override void Reset() { }

	protected override bool ShouldIncludeEntry(ref FileSystemEntry entry) { }

	protected override bool ShouldRecurseIntoEntry(ref FileSystemEntry entry) { }

	private override object System.Collections.IEnumerator.get_Current() { }

	protected abstract TResult TransformEntry(ref FileSystemEntry entry) { }

}

