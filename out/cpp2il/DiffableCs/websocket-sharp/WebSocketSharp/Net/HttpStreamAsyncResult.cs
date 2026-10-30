namespace WebSocketSharp.Net;

internal class HttpStreamAsyncResult : IAsyncResult
{
	private Byte[] _buffer; //Field offset: 0x10
	private AsyncCallback _callback; //Field offset: 0x18
	private bool _completed; //Field offset: 0x20
	private int _count; //Field offset: 0x24
	private Exception _exception; //Field offset: 0x28
	private int _offset; //Field offset: 0x30
	private object _state; //Field offset: 0x38
	private object _sync; //Field offset: 0x40
	private int _syncRead; //Field offset: 0x48
	private ManualResetEvent _waitHandle; //Field offset: 0x50

	public override object AsyncState
	{
		 get { } //Length: 8
	}

	public override WaitHandle AsyncWaitHandle
	{
		 get { } //Length: 296
	}

	internal Byte[] Buffer
	{
		internal get { } //Length: 8
		internal set { } //Length: 8
	}

	public override bool CompletedSynchronously
	{
		 get { } //Length: 20
	}

	internal int Count
	{
		internal get { } //Length: 8
		internal set { } //Length: 8
	}

	internal Exception Exception
	{
		internal get { } //Length: 8
	}

	internal bool HasException
	{
		internal get { } //Length: 16
	}

	public override bool IsCompleted
	{
		 get { } //Length: 200
	}

	internal int Offset
	{
		internal get { } //Length: 8
		internal set { } //Length: 8
	}

	internal int SyncRead
	{
		internal get { } //Length: 8
		internal set { } //Length: 8
	}

	internal HttpStreamAsyncResult(AsyncCallback callback, object state) { }

	[CompilerGenerated]
	private void <Complete>b__35_0(IAsyncResult ar) { }

	[CompilerGenerated]
	private void <Complete>b__36_0(IAsyncResult ar) { }

	internal void Complete() { }

	internal void Complete(Exception exception) { }

	public override object get_AsyncState() { }

	public override WaitHandle get_AsyncWaitHandle() { }

	internal Byte[] get_Buffer() { }

	public override bool get_CompletedSynchronously() { }

	internal int get_Count() { }

	internal Exception get_Exception() { }

	internal bool get_HasException() { }

	public override bool get_IsCompleted() { }

	internal int get_Offset() { }

	internal int get_SyncRead() { }

	internal void set_Buffer(Byte[] value) { }

	internal void set_Count(int value) { }

	internal void set_Offset(int value) { }

	internal void set_SyncRead(int value) { }

}

