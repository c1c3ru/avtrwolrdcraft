namespace UnityEngine.ResourceManagement.AsyncOperations;

internal interface IGenericProviderOperation
{

	public int DependencyCount
	{
		 get { } //Length: 0
	}

	public IResourceLocation Location
	{
		 get { } //Length: 0
	}

	public int ProvideHandleVersion
	{
		 get { } //Length: 0
	}

	public Type RequestedType
	{
		 get { } //Length: 0
	}

	public int get_DependencyCount() { }

	public IResourceLocation get_Location() { }

	public int get_ProvideHandleVersion() { }

	public Type get_RequestedType() { }

	public void GetDependencies(IList<Object> dstList) { }

	public TDepObject GetDependency(int index) { }

	public void Init(ResourceManager rm, IResourceProvider provider, IResourceLocation location, AsyncOperationHandle<IList`1<AsyncOperationHandle>> depOp) { }

	public void Init(ResourceManager rm, IResourceProvider provider, IResourceLocation location, AsyncOperationHandle<IList`1<AsyncOperationHandle>> depOp, bool releaseDependenciesOnFailure) { }

	public void ProviderCompleted(T result, bool status, Exception e) { }

	public void SetDownloadProgressCallback(Func<DownloadStatus> callback) { }

	public void SetProgressCallback(Func<Single> callback) { }

	public void SetWaitForCompletionCallback(Func<Boolean> callback) { }

}

