namespace UnityEngine.ResourceManagement;

internal class ChainOperationTypelessDepedency : AsyncOperationBase<TObject>
{
	private AsyncOperationHandle m_DepOp; //Field offset: 0x0
	private AsyncOperationHandle<TObject> m_WrappedOp; //Field offset: 0x0
	private DownloadStatus m_depStatus; //Field offset: 0x0
	private DownloadStatus m_wrapStatus; //Field offset: 0x0
	private Func<AsyncOperationHandle, AsyncOperationHandle`1<TObject>> m_Callback; //Field offset: 0x0
	private Action<AsyncOperationHandle`1<TObject>> m_CachedOnWrappedCompleted; //Field offset: 0x0
	private bool m_ReleaseDependenciesOnFailure; //Field offset: 0x0

	protected virtual string DebugName
	{
		 get { } //Length: 216
	}

	protected virtual float Progress
	{
		 get { } //Length: 304
	}

	internal AsyncOperationHandle<TObject> WrappedOp
	{
		internal get { } //Length: 20
	}

	public ChainOperationTypelessDepedency`1() { }

	protected virtual void Destroy() { }

	protected virtual void Execute() { }

	protected virtual string get_DebugName() { }

	protected virtual float get_Progress() { }

	internal AsyncOperationHandle<TObject> get_WrappedOp() { }

	public virtual void GetDependencies(List<AsyncOperationHandle> deps) { }

	internal virtual DownloadStatus GetDownloadStatus(HashSet<Object> visited) { }

	public void Init(AsyncOperationHandle dependentOp, Func<AsyncOperationHandle, AsyncOperationHandle`1<TObject>> callback, bool releaseDependenciesOnFailure) { }

	protected virtual bool InvokeWaitForCompletion() { }

	private void OnWrappedCompleted(AsyncOperationHandle<TObject> x) { }

	private void RefreshDownloadStatus(HashSet<Object> visited = null) { }

	internal virtual void ReleaseDependencies() { }

}

