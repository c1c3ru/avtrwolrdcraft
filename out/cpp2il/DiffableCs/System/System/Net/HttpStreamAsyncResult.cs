namespace System.Net;

internal class HttpStreamAsyncResult : IAsyncResult
{
	private object locker; //Field offset: 0x10
	private ManualResetEvent handle; //Field offset: 0x18
	private bool completed; //Field offset: 0x20
	internal Byte[] Buffer; //Field offset: 0x28
	internal int Offset; //Field offset: 0x30
	internal int Count; //Field offset: 0x34
	internal AsyncCallback Callback; //Field offset: 0x38
	internal object State; //Field offset: 0x40
	internal int SynchRead; //Field offset: 0x48
	internal Exception Error; //Field offset: 0x50

	public override object AsyncState
	{
		 get { } //Length: 8
	}

	public override WaitHandle AsyncWaitHandle
	{
		 get { } //Length: 320
	}

	public override bool CompletedSynchronously
	{
		 get { } //Length: 20
	}

	public override bool IsCompleted
	{
		 get { } //Length: 200
	}

	public HttpStreamAsyncResult() { }

	public void Complete(Exception e) { }

	public void Complete() { }

	public override object get_AsyncState() { }

	public override WaitHandle get_AsyncWaitHandle() { }

	public override bool get_CompletedSynchronously() { }

	public override bool get_IsCompleted() { }

}

