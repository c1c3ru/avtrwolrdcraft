namespace UnityEngine.ResourceManagement;

internal class ChainOperation : AsyncOperationBase<TObject>
{
	private AsyncOperationHandle<TObjectDependency> m_DepOp; //Field offset: 0x0
	private AsyncOperationHandle<TObject> m_WrappedOp; //Field offset: 0x0
	private DownloadStatus m_depStatus; //Field offset: 0x0
	private DownloadStatus m_wrapStatus; //Field offset: 0x0
	private Func<AsyncOperationHandle`1<TObjectDependency>, AsyncOperationHandle`1<TObject>> m_Callback; //Field offset: 0x0
	private Action<AsyncOperationHandle`1<TObject>> m_CachedOnWrappedCompleted; //Field offset: 0x0
	private bool m_ReleaseDependenciesOnFailure; //Field offset: 0x0

	protected virtual string DebugName
	{
		 get { } //Length: 480
	}

	protected virtual float Progress
	{
		 get { } //Length: 320
	}

	public ChainOperation`2() { }

	protected virtual void Destroy() { }

	protected virtual void Execute() { }

	protected virtual string get_DebugName() { }

	protected virtual float get_Progress() { }

	public virtual void GetDependencies(List<AsyncOperationHandle> deps) { }

	internal virtual DownloadStatus GetDownloadStatus(HashSet<Object> visited) { }

	public void Init(AsyncOperationHandle<TObjectDependency> dependentOp, Func<AsyncOperationHandle`1<TObjectDependency>, AsyncOperationHandle`1<TObject>> callback, bool releaseDependenciesOnFailure) { }

	protected virtual bool InvokeWaitForCompletion() { }

	private void OnWrappedCompleted(AsyncOperationHandle<TObject> x) { }

	private void RefreshDownloadStatus(HashSet<Object> visited = null) { }

	internal virtual void ReleaseDependencies() { }

}

