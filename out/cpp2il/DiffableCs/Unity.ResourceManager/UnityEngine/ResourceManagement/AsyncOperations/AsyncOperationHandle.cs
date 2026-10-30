namespace UnityEngine.ResourceManagement.AsyncOperations;

public struct AsyncOperationHandle : IEnumerator
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<AsyncOperationHandle> <>9__16_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <ReleaseHandleOnCompletion>b__16_0(AsyncOperationHandle op) { }

	}

	internal IAsyncOperation m_InternalOp; //Field offset: 0x0
	private int m_Version; //Field offset: 0x8
	private string m_LocationName; //Field offset: 0x10

	public event Action<AsyncOperationHandle> Completed
	{
		 add { } //Length: 180
		 remove { } //Length: 180
	}

	public event Action<AsyncOperationHandle> Destroyed
	{
		 add { } //Length: 180
		 remove { } //Length: 180
	}

	public string DebugName
	{
		 get { } //Length: 220
	}

	private IAsyncOperation InternalOp
	{
		private get { } //Length: 252
	}

	public bool IsDone
	{
		 get { } //Length: 200
	}

	internal string LocationName
	{
		internal get { } //Length: 8
		internal set { } //Length: 8
	}

	public Exception OperationException
	{
		 get { } //Length: 172
	}

	public float PercentComplete
	{
		 get { } //Length: 172
	}

	internal int ReferenceCount
	{
		internal get { } //Length: 172
	}

	public object Result
	{
		 get { } //Length: 168
	}

	public AsyncOperationStatus Status
	{
		 get { } //Length: 172
	}

	private override object System.Collections.IEnumerator.Current
	{
		private get { } //Length: 4
	}

	public Task<Object> Task
	{
		 get { } //Length: 172
	}

	internal int Version
	{
		internal get { } //Length: 8
	}

	internal AsyncOperationHandle(IAsyncOperation op) { }

	internal AsyncOperationHandle(IAsyncOperation op, int version) { }

	internal AsyncOperationHandle(IAsyncOperation op, string locationName) { }

	internal AsyncOperationHandle(IAsyncOperation op, int version, string locationName) { }

	internal AsyncOperationHandle Acquire() { }

	public void add_Completed(Action<AsyncOperationHandle> value) { }

	public void add_Destroyed(Action<AsyncOperationHandle> value) { }

	public AsyncOperationHandle<T> Convert() { }

	public bool Equals(AsyncOperationHandle other) { }

	public string get_DebugName() { }

	private IAsyncOperation get_InternalOp() { }

	public bool get_IsDone() { }

	internal string get_LocationName() { }

	public Exception get_OperationException() { }

	public float get_PercentComplete() { }

	internal int get_ReferenceCount() { }

	public object get_Result() { }

	public AsyncOperationStatus get_Status() { }

	public Task<Object> get_Task() { }

	internal int get_Version() { }

	public void GetDependencies(List<AsyncOperationHandle> deps) { }

	public DownloadStatus GetDownloadStatus() { }

	public virtual int GetHashCode() { }

	internal DownloadStatus InternalGetDownloadStatus(HashSet<Object> visited) { }

	public bool IsValid() { }

	public void Release() { }

	public void ReleaseHandleOnCompletion() { }

	public void remove_Completed(Action<AsyncOperationHandle> value) { }

	public void remove_Destroyed(Action<AsyncOperationHandle> value) { }

	internal void set_LocationName(string value) { }

	private override object System.Collections.IEnumerator.get_Current() { }

	private override bool System.Collections.IEnumerator.MoveNext() { }

	private override void System.Collections.IEnumerator.Reset() { }

	public object WaitForCompletion() { }

}

