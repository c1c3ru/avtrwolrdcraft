namespace UnityWebSocketSharp.Net;

internal class HttpListenerAsyncResult : IAsyncResult
{
	private AsyncCallback _callback; //Field offset: 0x10
	private bool _completed; //Field offset: 0x18
	private bool _completedSynchronously; //Field offset: 0x19
	private HttpListenerContext _context; //Field offset: 0x20
	private bool _endCalled; //Field offset: 0x28
	private Exception _exception; //Field offset: 0x30
	private object _state; //Field offset: 0x38
	private object _sync; //Field offset: 0x40
	private ManualResetEvent _waitHandle; //Field offset: 0x48

	public override object AsyncState
	{
		 get { } //Length: 8
	}

	public override WaitHandle AsyncWaitHandle
	{
		 get { } //Length: 296
	}

	public override bool CompletedSynchronously
	{
		 get { } //Length: 8
	}

	internal HttpListenerContext Context
	{
		internal get { } //Length: 48
	}

	internal bool EndCalled
	{
		internal get { } //Length: 8
		internal set { } //Length: 12
	}

	public override bool IsCompleted
	{
		 get { } //Length: 200
	}

	internal object SyncRoot
	{
		internal get { } //Length: 8
	}

	internal HttpListenerAsyncResult(AsyncCallback callback, object state) { }

	[CompilerGenerated]
	private void <complete>b__25_0(object state) { }

	private void complete() { }

	internal void Complete(Exception exception) { }

	internal void Complete(HttpListenerContext context, bool completedSynchronously) { }

	public override object get_AsyncState() { }

	public override WaitHandle get_AsyncWaitHandle() { }

	public override bool get_CompletedSynchronously() { }

	internal HttpListenerContext get_Context() { }

	internal bool get_EndCalled() { }

	public override bool get_IsCompleted() { }

	internal object get_SyncRoot() { }

	internal void set_EndCalled(bool value) { }

}

