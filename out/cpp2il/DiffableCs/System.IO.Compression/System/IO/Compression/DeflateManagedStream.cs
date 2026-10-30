namespace System.IO.Compression;

internal sealed class DeflateManagedStream : Stream
{
	[CompilerGenerated]
	private struct <ReadAsyncCore>d__40 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Int32> <>t__builder; //Field offset: 0x8
		public Task<Int32> readTask; //Field offset: 0x20
		public DeflateManagedStream <>4__this; //Field offset: 0x28
		public CancellationToken cancellationToken; //Field offset: 0x30
		public Byte[] array; //Field offset: 0x38
		public int offset; //Field offset: 0x40
		public int count; //Field offset: 0x44
		private ConfiguredTaskAwaiter<Int32> <>u__1; //Field offset: 0x48

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <WriteAsyncCore>d__47 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public DeflateManagedStream <>4__this; //Field offset: 0x20
		public Byte[] array; //Field offset: 0x28
		public int offset; //Field offset: 0x30
		public int count; //Field offset: 0x34
		public CancellationToken cancellationToken; //Field offset: 0x38
		private ConfiguredTaskAwaiter <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	private Stream _stream; //Field offset: 0x28
	private CompressionMode _mode; //Field offset: 0x30
	private bool _leaveOpen; //Field offset: 0x34
	private InflaterManaged _inflater; //Field offset: 0x38
	private DeflaterManaged _deflater; //Field offset: 0x40
	private Byte[] _buffer; //Field offset: 0x48
	private int _asyncOperations; //Field offset: 0x50
	private IFileFormatWriter _formatWriter; //Field offset: 0x58
	private bool _wroteHeader; //Field offset: 0x60
	private bool _wroteBytes; //Field offset: 0x61

	public virtual bool CanRead
	{
		 get { } //Length: 40
	}

	public virtual bool CanSeek
	{
		 get { } //Length: 8
	}

	public virtual bool CanWrite
	{
		 get { } //Length: 44
	}

	public virtual long Length
	{
		 get { } //Length: 76
	}

	public virtual long Position
	{
		 get { } //Length: 76
		 set { } //Length: 76
	}

	internal DeflateManagedStream(Stream stream, CompressionMethodValues method) { }

	[CompilerGenerated]
	[DebuggerHidden]
	private Task <>n__0(Byte[] buffer, int offset, int count, CancellationToken cancellationToken) { }

	public virtual IAsyncResult BeginRead(Byte[] buffer, int offset, int count, AsyncCallback asyncCallback, object asyncState) { }

	public virtual IAsyncResult BeginWrite(Byte[] buffer, int offset, int count, AsyncCallback asyncCallback, object asyncState) { }

	protected virtual void Dispose(bool disposing) { }

	private void DoMaintenance(Byte[] array, int offset, int count) { }

	public virtual int EndRead(IAsyncResult asyncResult) { }

	public virtual void EndWrite(IAsyncResult asyncResult) { }

	private void EnsureCompressionMode() { }

	private void EnsureDecompressionMode() { }

	private void EnsureNotDisposed() { }

	public virtual void Flush() { }

	public virtual Task FlushAsync(CancellationToken cancellationToken) { }

	public virtual bool get_CanRead() { }

	public virtual bool get_CanSeek() { }

	public virtual bool get_CanWrite() { }

	public virtual long get_Length() { }

	public virtual long get_Position() { }

	internal void InitializeInflater(Stream stream, bool leaveOpen, IFileFormatReader reader = null, CompressionMethodValues method = 8) { }

	private void PurgeBuffers(bool disposing) { }

	public virtual int Read(Byte[] array, int offset, int count) { }

	public virtual Task<Int32> ReadAsync(Byte[] array, int offset, int count, CancellationToken cancellationToken) { }

	[AsyncStateMachine(typeof(<ReadAsyncCore>d__40))]
	private Task<Int32> ReadAsyncCore(Task<Int32> readTask, Byte[] array, int offset, int count, CancellationToken cancellationToken) { }

	public virtual long Seek(long offset, SeekOrigin origin) { }

	public virtual void set_Position(long value) { }

	public virtual void SetLength(long value) { }

	private static void ThrowCannotReadFromDeflateManagedStreamException() { }

	private static void ThrowCannotWriteToDeflateManagedStreamException() { }

	private static void ThrowStreamClosedException() { }

	private void ValidateParameters(Byte[] array, int offset, int count) { }

	public virtual void Write(Byte[] array, int offset, int count) { }

	public virtual Task WriteAsync(Byte[] array, int offset, int count, CancellationToken cancellationToken) { }

	[AsyncStateMachine(typeof(<WriteAsyncCore>d__47))]
	private Task WriteAsyncCore(Byte[] array, int offset, int count, CancellationToken cancellationToken) { }

	private void WriteDeflaterOutput() { }

}

