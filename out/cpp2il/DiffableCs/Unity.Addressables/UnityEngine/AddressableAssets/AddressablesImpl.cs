namespace UnityEngine.AddressableAssets;

internal class AddressablesImpl : IEqualityComparer<IResourceLocation>
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<ResourceLocatorInfo, IResourceLocator> <>9__59_0; //Field offset: 0x8
		public static Func<ResourceLocatorInfo, Boolean> <>9__146_0; //Field offset: 0x10
		public static Func<ResourceLocatorInfo, String> <>9__146_1; //Field offset: 0x18
		public static Func<ResourceLocatorInfo, String> <>9__150_0; //Field offset: 0x20

		private static <>c() { }

		public <>c() { }

		internal string <CleanBundleCache>b__150_0(ResourceLocatorInfo s) { }

		internal bool <get_CatalogsWithAvailableUpdates>b__146_0(ResourceLocatorInfo s) { }

		internal string <get_CatalogsWithAvailableUpdates>b__146_1(ResourceLocatorInfo s) { }

		internal IResourceLocator <get_ResourceLocators>b__59_0(ResourceLocatorInfo l) { }

	}

	[CompilerGenerated]
	private sealed class <>c__115
	{
		public static readonly <>c__115<TObject> <>9; //Field offset: 0x0
		public static Action<AsyncOperationHandle> <>9__115_0; //Field offset: 0x0

		private static <>c__115`1() { }

		public <>c__115`1() { }

		internal void <AutoReleaseHandleOnTypelessCompletion>b__115_0(AsyncOperationHandle op) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass100_0
	{
		public AddressablesImpl <>4__this; //Field offset: 0x10
		public IResourceLocation catalogLoc; //Field offset: 0x18

		public <>c__DisplayClass100_0() { }

		internal AsyncOperationHandle<Int64> <ComputeCatalogSizeWithChain>b__0(AsyncOperationHandle op) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass103_0
	{
		public AddressablesImpl <>4__this; //Field offset: 0x10
		public IEnumerable keys; //Field offset: 0x18

		public <>c__DisplayClass103_0() { }

		internal AsyncOperationHandle<Int64> <GetDownloadSizeWithChain>b__0(AsyncOperationHandle op) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass106_0
	{
		public AddressablesImpl <>4__this; //Field offset: 0x10
		public object key; //Field offset: 0x18

		public <>c__DisplayClass106_0() { }

		internal AsyncOperationHandle<IList`1<IAssetBundleResource>> <DownloadDependenciesAsyncWithChain>b__0(AsyncOperationHandle op) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass110_0
	{
		public AddressablesImpl <>4__this; //Field offset: 0x10
		public IList<IResourceLocation> locations; //Field offset: 0x18

		public <>c__DisplayClass110_0() { }

		internal AsyncOperationHandle<IList`1<IAssetBundleResource>> <DownloadDependenciesAsyncWithChain>b__0(AsyncOperationHandle op) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass112_0
	{
		public AddressablesImpl <>4__this; //Field offset: 0x10
		public IEnumerable keys; //Field offset: 0x18
		public MergeMode mode; //Field offset: 0x20

		public <>c__DisplayClass112_0() { }

		internal AsyncOperationHandle<IList`1<IAssetBundleResource>> <DownloadDependenciesAsyncWithChain>b__0(AsyncOperationHandle op) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass116_0
	{
		public AddressablesImpl <>4__this; //Field offset: 0x10
		public object key; //Field offset: 0x18
		public bool autoReleaseHandle; //Field offset: 0x20

		public <>c__DisplayClass116_0() { }

		internal AsyncOperationHandle<Boolean> <ClearDependencyCacheAsync>b__0(AsyncOperationHandle op) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass117_0
	{
		public AddressablesImpl <>4__this; //Field offset: 0x10
		public IList<IResourceLocation> locations; //Field offset: 0x18
		public bool autoReleaseHandle; //Field offset: 0x20

		public <>c__DisplayClass117_0() { }

		internal AsyncOperationHandle<Boolean> <ClearDependencyCacheAsync>b__0(AsyncOperationHandle op) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass118_0
	{
		public AddressablesImpl <>4__this; //Field offset: 0x10
		public IEnumerable keys; //Field offset: 0x18
		public bool autoReleaseHandle; //Field offset: 0x20

		public <>c__DisplayClass118_0() { }

		internal AsyncOperationHandle<Boolean> <ClearDependencyCacheAsync>b__0(AsyncOperationHandle op) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass123_0
	{
		public AddressablesImpl <>4__this; //Field offset: 0x10
		public object key; //Field offset: 0x18
		public InstantiationParameters instantiateParameters; //Field offset: 0x20

		public <>c__DisplayClass123_0() { }

		internal AsyncOperationHandle<GameObject> <InstantiateWithChain>b__0(AsyncOperationHandle op) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass125_0
	{
		public AddressablesImpl <>4__this; //Field offset: 0x10
		public IResourceLocation location; //Field offset: 0x18
		public InstantiationParameters instantiateParameters; //Field offset: 0x20

		public <>c__DisplayClass125_0() { }

		internal AsyncOperationHandle<GameObject> <InstantiateWithChain>b__0(AsyncOperationHandle op) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass128_0
	{
		public AddressablesImpl <>4__this; //Field offset: 0x10
		public object key; //Field offset: 0x18
		public LoadSceneParameters loadSceneParameters; //Field offset: 0x20
		public bool activateOnLoad; //Field offset: 0x28
		public int priority; //Field offset: 0x2C

		public <>c__DisplayClass128_0() { }

		internal AsyncOperationHandle<SceneInstance> <LoadSceneWithChain>b__0(AsyncOperationHandle op) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass129_0
	{
		public AddressablesImpl <>4__this; //Field offset: 0x10
		public IResourceLocation key; //Field offset: 0x18
		public LoadSceneMode loadMode; //Field offset: 0x20
		public bool activateOnLoad; //Field offset: 0x24
		public int priority; //Field offset: 0x28

		public <>c__DisplayClass129_0() { }

		internal AsyncOperationHandle<SceneInstance> <LoadSceneWithChain>b__0(AsyncOperationHandle op) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass138_0
	{
		public AddressablesImpl <>4__this; //Field offset: 0x10
		public UnloadSceneOptions unloadOptions; //Field offset: 0x18
		public bool autoReleaseHandle; //Field offset: 0x1C

		public <>c__DisplayClass138_0() { }

		internal AsyncOperationHandle<SceneInstance> <CreateUnloadSceneWithChain>b__0(AsyncOperationHandle completedHandle) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass139_0
	{
		public AddressablesImpl <>4__this; //Field offset: 0x10
		public UnloadSceneOptions unloadOptions; //Field offset: 0x18
		public bool autoReleaseHandle; //Field offset: 0x1C

		public <>c__DisplayClass139_0() { }

		internal AsyncOperationHandle<SceneInstance> <CreateUnloadSceneWithChain>b__0(AsyncOperationHandle<SceneInstance> completedHandle) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass143_0
	{
		public AddressablesImpl <>4__this; //Field offset: 0x10
		public bool autoReleaseHandle; //Field offset: 0x18

		public <>c__DisplayClass143_0() { }

		internal AsyncOperationHandle<List`1<String>> <CheckForCatalogUpdatesWithChain>b__0(AsyncOperationHandle op) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass147_0
	{
		public AddressablesImpl <>4__this; //Field offset: 0x10
		public bool autoReleaseHandle; //Field offset: 0x18
		public bool autoCleanBundleCache; //Field offset: 0x19

		public <>c__DisplayClass147_0() { }

		internal AsyncOperationHandle<List`1<IResourceLocator>> <UpdateCatalogs>b__0(AsyncOperationHandle<List`1<String>> depOp) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass152_0
	{
		public AddressablesImpl <>4__this; //Field offset: 0x10
		public AsyncOperationHandle<IList`1<AsyncOperationHandle>> depOp; //Field offset: 0x18
		public bool forceSingleThreading; //Field offset: 0x30

		public <>c__DisplayClass152_0() { }

		internal AsyncOperationHandle<Boolean> <CleanBundleCacheWithChain>b__0(AsyncOperationHandle op) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass153_0
	{
		public AddressablesImpl <>4__this; //Field offset: 0x10
		public IEnumerable<String> catalogIds; //Field offset: 0x18
		public bool forceSingleThreading; //Field offset: 0x20

		public <>c__DisplayClass153_0() { }

		internal AsyncOperationHandle<Boolean> <CleanBundleCacheWithChain>b__0(AsyncOperationHandle op) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass61_0
	{
		public IResourceLocator loc; //Field offset: 0x10

		public <>c__DisplayClass61_0() { }

		internal bool <RemoveResourceLocator>b__0(ResourceLocatorInfo l) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass72_0
	{
		public AddressablesImpl <>4__this; //Field offset: 0x10
		public string catalogPath; //Field offset: 0x18
		public bool autoReleaseHandle; //Field offset: 0x20
		public string providerSuffix; //Field offset: 0x28

		public <>c__DisplayClass72_0() { }

		internal AsyncOperationHandle<IResourceLocator> <LoadContentCatalogAsync>b__0(AsyncOperationHandle op) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass78_0
	{
		public AddressablesImpl <>4__this; //Field offset: 0x0
		public IResourceLocation loc; //Field offset: 0x0

		public <>c__DisplayClass78_0`1() { }

		internal AsyncOperationHandle<TObject> <LoadAssetWithChain>b__0(AsyncOperationHandle op) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass79_0
	{
		public AddressablesImpl <>4__this; //Field offset: 0x0
		public object key; //Field offset: 0x0

		public <>c__DisplayClass79_0`1() { }

		internal AsyncOperationHandle<TObject> <LoadAssetWithChain>b__0(AsyncOperationHandle op) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass83_0
	{
		public AddressablesImpl <>4__this; //Field offset: 0x10
		public IEnumerable keys; //Field offset: 0x18
		public MergeMode mode; //Field offset: 0x20
		public Type type; //Field offset: 0x28

		public <>c__DisplayClass83_0() { }

		internal AsyncOperationHandle<IList`1<IResourceLocation>> <LoadResourceLocationsWithChain>b__0(AsyncOperationHandle op) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass85_0
	{
		public AddressablesImpl <>4__this; //Field offset: 0x10
		public object key; //Field offset: 0x18
		public Type type; //Field offset: 0x20

		public <>c__DisplayClass85_0() { }

		internal AsyncOperationHandle<IList`1<IResourceLocation>> <LoadResourceLocationsWithChain>b__0(AsyncOperationHandle op) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass88_0
	{
		public AddressablesImpl <>4__this; //Field offset: 0x0
		public IList<IResourceLocation> locations; //Field offset: 0x0
		public Action<TObject> callback; //Field offset: 0x0
		public bool releaseDependenciesOnFailure; //Field offset: 0x0

		public <>c__DisplayClass88_0`1() { }

		internal AsyncOperationHandle<IList`1<TObject>> <LoadAssetsWithChain>b__0(AsyncOperationHandle op) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass89_0
	{
		public AddressablesImpl <>4__this; //Field offset: 0x0
		public IEnumerable keys; //Field offset: 0x0
		public Action<TObject> callback; //Field offset: 0x0
		public MergeMode mode; //Field offset: 0x0
		public bool releaseDependenciesOnFailure; //Field offset: 0x0

		public <>c__DisplayClass89_0`1() { }

		internal AsyncOperationHandle<IList`1<TObject>> <LoadAssetsWithChain>b__0(AsyncOperationHandle op) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass91_0
	{
		public AddressablesImpl <>4__this; //Field offset: 0x0
		public object key; //Field offset: 0x0
		public Action<TObject> callback; //Field offset: 0x0
		public bool releaseDependenciesOnFailure; //Field offset: 0x0

		public <>c__DisplayClass91_0`1() { }

		internal AsyncOperationHandle<IList`1<TObject>> <LoadAssetsWithChain>b__0(AsyncOperationHandle op2) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass99_0
	{
		public AddressablesImpl <>4__this; //Field offset: 0x10
		public object key; //Field offset: 0x18

		public <>c__DisplayClass99_0() { }

		internal AsyncOperationHandle<Int64> <GetDownloadSizeWithChain>b__0(AsyncOperationHandle op) { }

	}

	private class LoadResourceLocationKeyOp : AsyncOperationBase<IList`1<IResourceLocation>>
	{
		private object m_Keys; //Field offset: 0x98
		private IList<IResourceLocation> m_locations; //Field offset: 0xA0
		private AddressablesImpl m_Addressables; //Field offset: 0xA8
		private Type m_ResourceType; //Field offset: 0xB0

		protected virtual string DebugName
		{
			 get { } //Length: 32
		}

		public LoadResourceLocationKeyOp() { }

		protected virtual void Execute() { }

		protected virtual string get_DebugName() { }

		public void Init(AddressablesImpl aa, Type t, object keys) { }

		protected virtual bool InvokeWaitForCompletion() { }

	}

	private class LoadResourceLocationKeysOp : AsyncOperationBase<IList`1<IResourceLocation>>
	{
		private IEnumerable m_Key; //Field offset: 0x98
		private MergeMode m_MergeMode; //Field offset: 0xA0
		private IList<IResourceLocation> m_locations; //Field offset: 0xA8
		private AddressablesImpl m_Addressables; //Field offset: 0xB0
		private Type m_ResourceType; //Field offset: 0xB8

		protected virtual string DebugName
		{
			 get { } //Length: 64
		}

		public LoadResourceLocationKeysOp() { }

		protected virtual void Execute() { }

		protected virtual string get_DebugName() { }

		public void Init(AddressablesImpl aa, Type t, IEnumerable key, MergeMode mergeMode) { }

		protected virtual bool InvokeWaitForCompletion() { }

	}

	internal const string kCacheDataFolder = "{UnityEngine.Application.persistentDataPath}/com.unity.addressables/"; //Field offset: 0x0
	private ResourceManager m_ResourceManager; //Field offset: 0x10
	private IInstanceProvider m_InstanceProvider; //Field offset: 0x18
	private int m_CatalogRequestsTimeout; //Field offset: 0x20
	public ISceneProvider SceneProvider; //Field offset: 0x28
	internal List<ResourceLocatorInfo> m_ResourceLocators; //Field offset: 0x30
	private AsyncOperationHandle<IResourceLocator> m_InitializationOperation; //Field offset: 0x38
	private AsyncOperationHandle<List`1<String>> m_ActiveCheckUpdateOperation; //Field offset: 0x50
	internal AsyncOperationHandle<List`1<IResourceLocator>> m_ActiveUpdateOperation; //Field offset: 0x68
	private Action<AsyncOperationHandle> m_OnHandleCompleteAction; //Field offset: 0x80
	private Action<AsyncOperationHandle> m_OnSceneHandleCompleteAction; //Field offset: 0x88
	private Action<AsyncOperationHandle> m_OnHandleDestroyedAction; //Field offset: 0x90
	private Dictionary<Object, AsyncOperationHandle> m_resultToHandle; //Field offset: 0x98
	internal HashSet<AsyncOperationHandle> m_SceneInstances; //Field offset: 0xA0
	private AsyncOperationHandle<Boolean> m_ActiveCleanBundleCacheOperation; //Field offset: 0xA8
	internal bool hasStartedInitialization; //Field offset: 0xC0

	public string BuildPath
	{
		 get { } //Length: 220
	}

	public int CatalogRequestsTimeout
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	internal IEnumerable<String> CatalogsWithAvailableUpdates
	{
		internal get { } //Length: 444
	}

	public AsyncOperationHandle ChainOperation
	{
		 get { } //Length: 440
	}

	public IInstanceProvider InstanceProvider
	{
		 get { } //Length: 8
		 set { } //Length: 148
	}

	public Func<IResourceLocation, String> InternalIdTransformFunc
	{
		 get { } //Length: 28
		 set { } //Length: 28
	}

	public string PlayerBuildDataPath
	{
		 get { } //Length: 172
	}

	public IEnumerable<IResourceLocator> ResourceLocators
	{
		 get { } //Length: 252
	}

	public ResourceManager ResourceManager
	{
		 get { } //Length: 8
	}

	public string RuntimePath
	{
		 get { } //Length: 4
	}

	internal int SceneOperationCount
	{
		internal get { } //Length: 72
	}

	internal bool ShouldChainRequest
	{
		internal get { } //Length: 224
	}

	public string StreamingAssetsSubFolder
	{
		 get { } //Length: 64
	}

	internal int TrackedHandleCount
	{
		internal get { } //Length: 80
	}

	public Action<UnityWebRequest> WebRequestOverride
	{
		 get { } //Length: 28
		 set { } //Length: 28
	}

	public AddressablesImpl(IAllocationStrategy alloc) { }

	[CompilerGenerated]
	private AsyncOperationHandle<Int64> <GetRemoteCatalogHeaderSize>b__102_0(AsyncOperationHandle<UnityWebRequest> getOp) { }

	[CompilerGenerated]
	private void <TrackHandle>b__73_0(AsyncOperationHandle<SceneInstance> sceneHandle) { }

	public void AddResourceLocator(IResourceLocator loc, string localCatalogHash = null, IResourceLocation remoteCatalogLocation = null) { }

	internal void AutoReleaseHandleOnTypelessCompletion(AsyncOperationHandle<TObject> handle) { }

	internal AsyncOperationHandle<List`1<String>> CheckForCatalogUpdates(bool autoReleaseHandle = true) { }

	internal AsyncOperationHandle<List`1<String>> CheckForCatalogUpdatesWithChain(bool autoReleaseHandle) { }

	internal AsyncOperationHandle<Boolean> CleanBundleCache(IEnumerable<String> catalogIds, bool forceSingleThreading) { }

	internal AsyncOperationHandle<Boolean> CleanBundleCache(AsyncOperationHandle<IList`1<AsyncOperationHandle>> depOp, bool forceSingleThreading) { }

	internal AsyncOperationHandle<Boolean> CleanBundleCacheWithChain(AsyncOperationHandle<IList`1<AsyncOperationHandle>> depOp, bool forceSingleThreading) { }

	internal AsyncOperationHandle<Boolean> CleanBundleCacheWithChain(IEnumerable<String> catalogIds, bool forceSingleThreading) { }

	public AsyncOperationHandle<Boolean> ClearDependencyCacheAsync(IEnumerable keys, bool autoReleaseHandle) { }

	public AsyncOperationHandle<Boolean> ClearDependencyCacheAsync(IList<IResourceLocation> locations, bool autoReleaseHandle) { }

	public AsyncOperationHandle<Boolean> ClearDependencyCacheAsync(object key, bool autoReleaseHandle) { }

	internal bool ClearDependencyCacheForKey(object key) { }

	public void ClearResourceLocators() { }

	internal void ClearTrackHandles() { }

	private AsyncOperationHandle<Int64> ComputeCatalogSizeWithChain(IResourceLocation catalogLoc) { }

	public ResourceLocationBase CreateCatalogLocationWithHashDependencies(string catalogPath, string hashFilePath) { }

	public ResourceLocationBase CreateCatalogLocationWithHashDependencies(IResourceLocation catalogLocation) { }

	public ResourceLocationBase CreateCatalogLocationWithHashDependencies(string catalogLocation) { }

	internal AsyncOperationHandle<SceneInstance> CreateUnloadSceneWithChain(AsyncOperationHandle handle, UnloadSceneOptions unloadOptions, bool autoReleaseHandle) { }

	internal AsyncOperationHandle<SceneInstance> CreateUnloadSceneWithChain(AsyncOperationHandle<SceneInstance> handle, UnloadSceneOptions unloadOptions, bool autoReleaseHandle) { }

	public AsyncOperationHandle DownloadDependenciesAsync(IEnumerable keys, MergeMode mode, bool autoReleaseHandle = false) { }

	public AsyncOperationHandle DownloadDependenciesAsync(IList<IResourceLocation> locations, bool autoReleaseHandle = false) { }

	public AsyncOperationHandle DownloadDependenciesAsync(object key, bool autoReleaseHandle = false) { }

	private AsyncOperationHandle DownloadDependenciesAsyncWithChain(AsyncOperationHandle dep, IEnumerable keys, MergeMode mode, bool autoReleaseHandle) { }

	private AsyncOperationHandle DownloadDependenciesAsyncWithChain(AsyncOperationHandle dep, IList<IResourceLocation> locations, bool autoReleaseHandle) { }

	private AsyncOperationHandle DownloadDependenciesAsyncWithChain(AsyncOperationHandle dep, object key, bool autoReleaseHandle) { }

	public override bool Equals(IResourceLocation x, IResourceLocation y) { }

	private object EvaluateKey(object obj) { }

	private static List<IResourceLocation> GatherDependenciesFromLocations(IList<IResourceLocation> locations) { }

	public string get_BuildPath() { }

	public int get_CatalogRequestsTimeout() { }

	internal IEnumerable<String> get_CatalogsWithAvailableUpdates() { }

	public AsyncOperationHandle get_ChainOperation() { }

	public IInstanceProvider get_InstanceProvider() { }

	public Func<IResourceLocation, String> get_InternalIdTransformFunc() { }

	public string get_PlayerBuildDataPath() { }

	public IEnumerable<IResourceLocator> get_ResourceLocators() { }

	public ResourceManager get_ResourceManager() { }

	public string get_RuntimePath() { }

	internal int get_SceneOperationCount() { }

	internal bool get_ShouldChainRequest() { }

	public string get_StreamingAssetsSubFolder() { }

	internal int get_TrackedHandleCount() { }

	public Action<UnityWebRequest> get_WebRequestOverride() { }

	public AsyncOperationHandle<Int64> GetDownloadSizeAsync(object key) { }

	public AsyncOperationHandle<Int64> GetDownloadSizeAsync(IEnumerable keys) { }

	private AsyncOperationHandle<Int64> GetDownloadSizeWithChain(AsyncOperationHandle dep, IEnumerable keys) { }

	private AsyncOperationHandle<Int64> GetDownloadSizeWithChain(AsyncOperationHandle dep, object key) { }

	public override int GetHashCode(IResourceLocation loc) { }

	public ResourceLocatorInfo GetLocatorInfo(string c) { }

	internal AsyncOperationHandle<Int64> GetRemoteCatalogHeaderSize(IResourceLocation catalogLoc) { }

	internal bool GetResourceLocations(object key, Type type, out IList<IResourceLocation>& locations) { }

	internal bool GetResourceLocations(IEnumerable keys, Type type, MergeMode merge, out IList<IResourceLocation>& locations) { }

	public AsyncOperationHandle<IResourceLocator> InitializeAsync() { }

	public AsyncOperationHandle<IResourceLocator> InitializeAsync(bool autoReleaseHandle) { }

	public AsyncOperationHandle<IResourceLocator> InitializeAsync(string runtimeDataPath, string providerSuffix = null, bool autoReleaseHandle = true) { }

	public AsyncOperationHandle<GameObject> InstantiateAsync(IResourceLocation location, Vector3 position, Quaternion rotation, Transform parent = null, bool trackHandle = true) { }

	public AsyncOperationHandle<GameObject> InstantiateAsync(object key, Transform parent = null, bool instantiateInWorldSpace = false, bool trackHandle = true) { }

	public AsyncOperationHandle<GameObject> InstantiateAsync(object key, Vector3 position, Quaternion rotation, Transform parent = null, bool trackHandle = true) { }

	public AsyncOperationHandle<GameObject> InstantiateAsync(object key, InstantiationParameters instantiateParameters, bool trackHandle = true) { }

	public AsyncOperationHandle<GameObject> InstantiateAsync(IResourceLocation location, InstantiationParameters instantiateParameters, bool trackHandle = true) { }

	public AsyncOperationHandle<GameObject> InstantiateAsync(IResourceLocation location, Transform parent = null, bool instantiateInWorldSpace = false, bool trackHandle = true) { }

	private AsyncOperationHandle<GameObject> InstantiateWithChain(AsyncOperationHandle dep, object key, InstantiationParameters instantiateParameters, bool trackHandle = true) { }

	private AsyncOperationHandle<GameObject> InstantiateWithChain(AsyncOperationHandle dep, IResourceLocation location, InstantiationParameters instantiateParameters, bool trackHandle = true) { }

	internal AsyncOperationHandle<SceneInstance> InternalUnloadScene(AsyncOperationHandle<SceneInstance> handle, UnloadSceneOptions unloadOptions, bool autoReleaseHandle) { }

	internal bool IsCatalogCached(IResourceLocation catalogLoc, Hash128 remoteHash) { }

	public AsyncOperationHandle<TObject> LoadAssetAsync(IResourceLocation location) { }

	public AsyncOperationHandle<TObject> LoadAssetAsync(object key) { }

	public AsyncOperationHandle<IList`1<TObject>> LoadAssetsAsync(IEnumerable keys, Action<TObject> callback, MergeMode mode, bool releaseDependenciesOnFailure) { }

	public AsyncOperationHandle<IList`1<TObject>> LoadAssetsAsync(object key, Action<TObject> callback, bool releaseDependenciesOnFailure) { }

	public AsyncOperationHandle<IList`1<TObject>> LoadAssetsAsync(IList<IResourceLocation> locations, Action<TObject> callback, bool releaseDependenciesOnFailure) { }

	private AsyncOperationHandle<IList`1<TObject>> LoadAssetsWithChain(AsyncOperationHandle dep, object key, Action<TObject> callback, bool releaseDependenciesOnFailure) { }

	private AsyncOperationHandle<IList`1<TObject>> LoadAssetsWithChain(AsyncOperationHandle dep, IList<IResourceLocation> locations, Action<TObject> callback, bool releaseDependenciesOnFailure) { }

	private AsyncOperationHandle<IList`1<TObject>> LoadAssetsWithChain(AsyncOperationHandle dep, IEnumerable keys, Action<TObject> callback, MergeMode mode, bool releaseDependenciesOnFailure) { }

	private AsyncOperationHandle<TObject> LoadAssetWithChain(AsyncOperationHandle dep, object key) { }

	private AsyncOperationHandle<TObject> LoadAssetWithChain(AsyncOperationHandle dep, IResourceLocation loc) { }

	public AsyncOperationHandle<IResourceLocator> LoadContentCatalogAsync(string catalogPath, bool autoReleaseHandle = true, string providerSuffix = null) { }

	public AsyncOperationHandle<IList`1<IResourceLocation>> LoadResourceLocationsAsync(object key, Type type = null) { }

	public AsyncOperationHandle<IList`1<IResourceLocation>> LoadResourceLocationsAsync(IEnumerable keys, MergeMode mode, Type type = null) { }

	public AsyncOperationHandle<IList`1<IResourceLocation>> LoadResourceLocationsWithChain(AsyncOperationHandle dep, object key, Type type) { }

	public AsyncOperationHandle<IList`1<IResourceLocation>> LoadResourceLocationsWithChain(AsyncOperationHandle dep, IEnumerable keys, MergeMode mode, Type type) { }

	public AsyncOperationHandle<SceneInstance> LoadSceneAsync(IResourceLocation location, LoadSceneParameters loadSceneParameters, bool activateOnLoad = true, int priority = 100, bool trackHandle = true) { }

	public AsyncOperationHandle<SceneInstance> LoadSceneAsync(IResourceLocation location) { }

	public AsyncOperationHandle<SceneInstance> LoadSceneAsync(object key) { }

	public AsyncOperationHandle<SceneInstance> LoadSceneAsync(IResourceLocation location, LoadSceneMode loadMode = 0, bool activateOnLoad = true, int priority = 100, bool trackHandle = true) { }

	public AsyncOperationHandle<SceneInstance> LoadSceneAsync(object key, LoadSceneParameters loadSceneParameters, bool activateOnLoad = true, int priority = 100, bool trackHandle = true) { }

	internal AsyncOperationHandle<SceneInstance> LoadSceneWithChain(AsyncOperationHandle dep, IResourceLocation key, LoadSceneMode loadMode = 0, bool activateOnLoad = true, int priority = 100) { }

	internal AsyncOperationHandle<SceneInstance> LoadSceneWithChain(AsyncOperationHandle dep, object key, LoadSceneParameters loadSceneParameters, bool activateOnLoad = true, int priority = 100) { }

	public void Log(string msg) { }

	public void LogError(string msg) { }

	public void LogErrorFormat(string format, Object[] args) { }

	public void LogException(Exception ex) { }

	public void LogException(AsyncOperationHandle op, Exception ex) { }

	public void LogFormat(string format, Object[] args) { }

	public void LogWarning(string msg) { }

	public void LogWarningFormat(string format, Object[] args) { }

	private void OnHandleCompleted(AsyncOperationHandle handle) { }

	private void OnHandleDestroyed(AsyncOperationHandle handle) { }

	private void OnSceneHandleCompleted(AsyncOperationHandle handle) { }

	internal void OnSceneUnloaded(Scene scene) { }

	[Conditional("UNITY_EDITOR")]
	private void QueueEditorUpdateIfNeeded() { }

	public void Release(AsyncOperationHandle<TObject> handle) { }

	public void Release(TObject obj) { }

	public void Release(AsyncOperationHandle handle) { }

	public bool ReleaseInstance(GameObject instance) { }

	internal void ReleaseSceneManagerOperation() { }

	public void RemoveResourceLocator(IResourceLocator loc) { }

	public string ResolveInternalId(string id) { }

	public void set_CatalogRequestsTimeout(int value) { }

	public void set_InstanceProvider(IInstanceProvider value) { }

	public void set_InternalIdTransformFunc(Func<IResourceLocation, String> value) { }

	public void set_WebRequestOverride(Action<UnityWebRequest> value) { }

	private AsyncOperationHandle TrackHandle(AsyncOperationHandle handle) { }

	private AsyncOperationHandle<TObject> TrackHandle(AsyncOperationHandle<TObject> handle) { }

	private AsyncOperationHandle<SceneInstance> TrackHandle(AsyncOperationHandle<SceneInstance> handle) { }

	public AsyncOperationHandle<SceneInstance> UnloadSceneAsync(AsyncOperationHandle<SceneInstance> handle, UnloadSceneOptions unloadOptions = 0, bool autoReleaseHandle = true) { }

	public AsyncOperationHandle<SceneInstance> UnloadSceneAsync(AsyncOperationHandle handle, UnloadSceneOptions unloadOptions = 0, bool autoReleaseHandle = true) { }

	public AsyncOperationHandle<SceneInstance> UnloadSceneAsync(SceneInstance scene, UnloadSceneOptions unloadOptions = 0, bool autoReleaseHandle = true) { }

	internal AsyncOperationHandle<List`1<IResourceLocator>> UpdateCatalogs(IEnumerable<String> catalogIds = null, bool autoReleaseHandle = true, bool autoCleanBundleCache = false) { }

	internal static void WrapAsDownloadLocations(List<IResourceLocation> locations) { }

}

