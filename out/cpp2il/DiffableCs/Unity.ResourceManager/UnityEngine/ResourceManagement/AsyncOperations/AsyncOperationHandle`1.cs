namespace UnityEngine.ResourceManagement.AsyncOperations;

public struct AsyncOperationHandle : IEnumerator, IEquatable<AsyncOperationHandle`1<TObject>>
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c<TObject> <>9; //Field offset: 0x0
		public static Action<AsyncOperationHandle`1<TObject>> <>9__20_0; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal void <ReleaseHandleOnCompletion>b__20_0(AsyncOperationHandle<TObject> op) { }

	}

	internal AsyncOperationBase<TObject> m_InternalOp; //Field offset: 0x0
	private int m_Version; //Field offset: 0x0
	private string m_LocationName; //Field offset: 0x0

	public event Action<AsyncOperationHandle`1<TObject>> Completed
	{
		 add { } //Length: 116
		 remove { } //Length: 116
	}

	public event Action<AsyncOperationHandle> CompletedTypeless
	{
		 add { } //Length: 116
		 remove { } //Length: 116
	}

	public event Action<AsyncOperationHandle> Destroyed
	{
		 add { } //Length: 116
		 remove { } //Length: 116
	}

	public string DebugName
	{
		 get { } //Length: 272
	}

	internal AsyncOperationBase<TObject> InternalOp
	{
		internal get { } //Length: 132
	}

	public bool IsDone
	{
		 get { } //Length: 160
	}

	internal string LocationName
	{
		internal get { } //Length: 8
		internal set { } //Length: 8
	}

	public Exception OperationException
	{
		 get { } //Length: 100
	}

	public float PercentComplete
	{
		 get { } //Length: 108
	}

	internal int ReferenceCount
	{
		internal get { } //Length: 100
	}

	public TObject Result
	{
		 get { } //Length: 100
	}

	public AsyncOperationStatus Status
	{
		 get { } //Length: 100
	}

	private override object System.Collections.IEnumerator.Current
	{
		private get { } //Length: 108
	}

	public Task<TObject> Task
	{
		 get { } //Length: 108
	}

	internal int Version
	{
		internal get { } //Length: 8
	}

	internal AsyncOperationHandle`1(IAsyncOperation op, int version, string locationName) { }

	internal AsyncOperationHandle`1(AsyncOperationBase<TObject> op) { }

	internal AsyncOperationHandle`1(IAsyncOperation op, string locationName) { }

	internal AsyncOperationHandle`1(IAsyncOperation op) { }

	internal AsyncOperationHandle`1(IAsyncOperation op, int version) { }

	internal AsyncOperationHandle<TObject> Acquire() { }

	public void add_Completed(Action<AsyncOperationHandle`1<TObject>> value) { }

	public void add_CompletedTypeless(Action<AsyncOperationHandle> value) { }

	public void add_Destroyed(Action<AsyncOperationHandle> value) { }

	public override bool Equals(AsyncOperationHandle<TObject> other) { }

	public string get_DebugName() { }

	internal AsyncOperationBase<TObject> get_InternalOp() { }

	public bool get_IsDone() { }

	internal string get_LocationName() { }

	public Exception get_OperationException() { }

	public float get_PercentComplete() { }

	internal int get_ReferenceCount() { }

	public TObject get_Result() { }

	public AsyncOperationStatus get_Status() { }

	public Task<TObject> get_Task() { }

	internal int get_Version() { }

	public void GetDependencies(List<AsyncOperationHandle> deps) { }

	public DownloadStatus GetDownloadStatus() { }

	public virtual int GetHashCode() { }

	internal DownloadStatus InternalGetDownloadStatus(HashSet<Object> visited) { }

	public bool IsValid() { }

	public static AsyncOperationHandle op_Implicit(AsyncOperationHandle<TObject> obj) { }

	public void Release() { }

	public void ReleaseHandleOnCompletion() { }

	public void remove_Completed(Action<AsyncOperationHandle`1<TObject>> value) { }

	public void remove_CompletedTypeless(Action<AsyncOperationHandle> value) { }

	public void remove_Destroyed(Action<AsyncOperationHandle> value) { }

	internal void set_LocationName(string value) { }

	private override object System.Collections.IEnumerator.get_Current() { }

	private override bool System.Collections.IEnumerator.MoveNext() { }

	private override void System.Collections.IEnumerator.Reset() { }

	public TObject WaitForCompletion() { }

}

