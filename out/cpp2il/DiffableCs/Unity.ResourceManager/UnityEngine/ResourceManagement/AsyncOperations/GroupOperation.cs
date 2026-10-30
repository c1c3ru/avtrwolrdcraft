namespace UnityEngine.ResourceManagement.AsyncOperations;

internal class GroupOperation : AsyncOperationBase<IList`1<AsyncOperationHandle>>, ICachable
{
	[Flags]
	internal enum GroupOperationSettings
	{
		None = 0,
		ReleaseDependenciesOnFailure = 1,
		AllowFailedDependencies = 2,
	}

	private const int k_MaxDisplayedLocationLength = 45; //Field offset: 0x0
	private Action<AsyncOperationHandle> m_InternalOnComplete; //Field offset: 0x98
	private int m_LoadedCount; //Field offset: 0xA0
	private GroupOperationSettings m_Settings; //Field offset: 0xA4
	private string debugName; //Field offset: 0xA8
	[CompilerGenerated]
	private IOperationCacheKey <UnityEngine.ResourceManagement.AsyncOperations.ICachable.Key>k__BackingField; //Field offset: 0xB0
	private HashSet<String> m_CachedDependencyLocations; //Field offset: 0xB8

	protected virtual string DebugName
	{
		 get { } //Length: 732
	}

	protected virtual float Progress
	{
		 get { } //Length: 492
	}

	private override IOperationCacheKey UnityEngine.ResourceManagement.AsyncOperations.ICachable.Key
	{
		[CompilerGenerated]
		private get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public GroupOperation() { }

	private void CompleteIfDependenciesComplete() { }

	private bool DependenciesAreUnchanged(List<AsyncOperationHandle> deps) { }

	protected virtual void Destroy() { }

	protected virtual void Execute() { }

	protected virtual string get_DebugName() { }

	protected virtual float get_Progress() { }

	public virtual void GetDependencies(List<AsyncOperationHandle> deps) { }

	internal IList<AsyncOperationHandle> GetDependentOps() { }

	internal virtual DownloadStatus GetDownloadStatus(HashSet<Object> visited) { }

	public void Init(List<AsyncOperationHandle> operations, GroupOperationSettings settings) { }

	public void Init(List<AsyncOperationHandle> operations, bool releaseDependenciesOnFailure = true, bool allowFailedDependencies = false) { }

	protected virtual bool InvokeWaitForCompletion() { }

	private void OnOperationCompleted(AsyncOperationHandle op) { }

	internal virtual void ReleaseDependencies() { }

	[CompilerGenerated]
	private override IOperationCacheKey UnityEngine.ResourceManagement.AsyncOperations.ICachable.get_Key() { }

	[CompilerGenerated]
	private override void UnityEngine.ResourceManagement.AsyncOperations.ICachable.set_Key(IOperationCacheKey value) { }

}

