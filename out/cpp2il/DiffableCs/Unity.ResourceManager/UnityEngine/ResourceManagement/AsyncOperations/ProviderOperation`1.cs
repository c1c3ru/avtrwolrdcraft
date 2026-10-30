namespace UnityEngine.ResourceManagement.AsyncOperations;

[Preserve]
internal class ProviderOperation : AsyncOperationBase<TObject>, IGenericProviderOperation, ICachable
{
	private const float k_OperationWaitingToCompletePercentComplete = 0,99; //Field offset: 0x0
	internal const string kInvalidHandleMsg = "The ProvideHandle is invalid. After the handle has been completed, it can no longer be used"; //Field offset: 0x0
	private bool m_ReleaseDependenciesOnFailure; //Field offset: 0x0
	private Func<Single> m_GetProgressCallback; //Field offset: 0x0
	private Func<DownloadStatus> m_GetDownloadProgressCallback; //Field offset: 0x0
	private Func<Boolean> m_WaitForCompletionCallback; //Field offset: 0x0
	private bool m_ProviderCompletedCalled; //Field offset: 0x0
	private DownloadStatus m_DownloadStatus; //Field offset: 0x0
	private IResourceProvider m_Provider; //Field offset: 0x0
	internal AsyncOperationHandle<IList`1<AsyncOperationHandle>> m_DepOp; //Field offset: 0x0
	private IResourceLocation m_Location; //Field offset: 0x0
	private int m_ProvideHandleVersion; //Field offset: 0x0
	private bool m_NeedsRelease; //Field offset: 0x0
	[CompilerGenerated]
	private IOperationCacheKey <UnityEngine.ResourceManagement.AsyncOperations.ICachable.Key>k__BackingField; //Field offset: 0x0
	private ResourceManager m_ResourceManager; //Field offset: 0x0

	protected virtual string DebugName
	{
		 get { } //Length: 360
	}

	public override int DependencyCount
	{
		 get { } //Length: 264
	}

	public override IResourceLocation Location
	{
		 get { } //Length: 8
	}

	protected virtual float Progress
	{
		 get { } //Length: 1280
	}

	public override int ProvideHandleVersion
	{
		 get { } //Length: 8
	}

	public override Type RequestedType
	{
		 get { } //Length: 100
	}

	private override IOperationCacheKey UnityEngine.ResourceManagement.AsyncOperations.ICachable.Key
	{
		[CompilerGenerated]
		private get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 16
	}

	public ProviderOperation`1() { }

	protected virtual void Destroy() { }

	protected virtual void Execute() { }

	protected virtual string get_DebugName() { }

	public override int get_DependencyCount() { }

	public override IResourceLocation get_Location() { }

	protected virtual float get_Progress() { }

	public override int get_ProvideHandleVersion() { }

	public override Type get_RequestedType() { }

	public virtual void GetDependencies(List<AsyncOperationHandle> deps) { }

	public override void GetDependencies(IList<Object> dstList) { }

	public override TDepObject GetDependency(int index) { }

	internal virtual DownloadStatus GetDownloadStatus(HashSet<Object> visited) { }

	public override void Init(ResourceManager rm, IResourceProvider provider, IResourceLocation location, AsyncOperationHandle<IList`1<AsyncOperationHandle>> depOp, bool releaseDependenciesOnFailure) { }

	public override void Init(ResourceManager rm, IResourceProvider provider, IResourceLocation location, AsyncOperationHandle<IList`1<AsyncOperationHandle>> depOp) { }

	protected virtual bool InvokeWaitForCompletion() { }

	public override void ProviderCompleted(T result, bool status, Exception e) { }

	internal virtual void ReleaseDependencies() { }

	public override void SetDownloadProgressCallback(Func<DownloadStatus> callback) { }

	public override void SetProgressCallback(Func<Single> callback) { }

	public override void SetWaitForCompletionCallback(Func<Boolean> callback) { }

	[CompilerGenerated]
	private override IOperationCacheKey UnityEngine.ResourceManagement.AsyncOperations.ICachable.get_Key() { }

	[CompilerGenerated]
	private override void UnityEngine.ResourceManagement.AsyncOperations.ICachable.set_Key(IOperationCacheKey value) { }

	private bool WaitForCompletionHandler() { }

}

