namespace UnityEngine.ResourceManagement.AsyncOperations;

internal interface IAsyncOperation
{

	public event Action<AsyncOperationHandle> CompletedTypeless
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	public event Action<AsyncOperationHandle> Destroyed
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	public string DebugName
	{
		 get { } //Length: 0
	}

	public AsyncOperationHandle Handle
	{
		 get { } //Length: 0
	}

	public bool IsDone
	{
		 get { } //Length: 0
	}

	public bool IsRunning
	{
		 get { } //Length: 0
	}

	public Action<IAsyncOperation> OnDestroy
	{
		 set { } //Length: 0
	}

	public Exception OperationException
	{
		 get { } //Length: 0
	}

	public float PercentComplete
	{
		 get { } //Length: 0
	}

	public int ReferenceCount
	{
		 get { } //Length: 0
	}

	public Type ResultType
	{
		 get { } //Length: 0
	}

	public AsyncOperationStatus Status
	{
		 get { } //Length: 0
	}

	public Task<Object> Task
	{
		 get { } //Length: 0
	}

	public int Version
	{
		 get { } //Length: 0
	}

	[CompilerGenerated]
	public void add_CompletedTypeless(Action<AsyncOperationHandle> value) { }

	[CompilerGenerated]
	public void add_Destroyed(Action<AsyncOperationHandle> value) { }

	public void DecrementReferenceCount() { }

	public string get_DebugName() { }

	public AsyncOperationHandle get_Handle() { }

	public bool get_IsDone() { }

	public bool get_IsRunning() { }

	public Exception get_OperationException() { }

	public float get_PercentComplete() { }

	public int get_ReferenceCount() { }

	public Type get_ResultType() { }

	public AsyncOperationStatus get_Status() { }

	public Task<Object> get_Task() { }

	public int get_Version() { }

	public void GetDependencies(List<AsyncOperationHandle> deps) { }

	public DownloadStatus GetDownloadStatus(HashSet<Object> visited) { }

	public object GetResultAsObject() { }

	public void IncrementReferenceCount() { }

	public void InvokeCompletionEvent() { }

	[CompilerGenerated]
	public void remove_CompletedTypeless(Action<AsyncOperationHandle> value) { }

	[CompilerGenerated]
	public void remove_Destroyed(Action<AsyncOperationHandle> value) { }

	public void set_OnDestroy(Action<IAsyncOperation> value) { }

	public void Start(ResourceManager rm, AsyncOperationHandle dependency, DelegateList<Single> updateCallbacks) { }

	public void WaitForCompletion() { }

}

