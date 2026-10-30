namespace UnityEngine.ResourceManagement;

public class ResourceManager : IDisposable
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass100_0
	{
		public Action<TObject> callback; //Field offset: 0x0
		public bool releaseDependenciesOnFailure; //Field offset: 0x0
		public ResourceManager <>4__this; //Field offset: 0x0

		public <>c__DisplayClass100_0`1() { }

		internal void <ProvideResources>b__0(AsyncOperationHandle x) { }

		internal AsyncOperationHandle<IList`1<TObject>> <ProvideResources>b__1(AsyncOperationHandle resultHandle) { }

	}

	private class CompletedOperation : AsyncOperationBase<TObject>
	{
		private bool m_Success; //Field offset: 0x0
		private Exception m_Exception; //Field offset: 0x0
		private bool m_ReleaseDependenciesOnFailure; //Field offset: 0x0

		protected virtual string DebugName
		{
			 get { } //Length: 64
		}

		public CompletedOperation`1() { }

		protected virtual void Execute() { }

		protected virtual string get_DebugName() { }

		public void Init(TObject result, bool success, string errorMsg, bool releaseDependenciesOnFailure = true) { }

		public void Init(TObject result, bool success, Exception exception, bool releaseDependenciesOnFailure = true) { }

		protected virtual bool InvokeWaitForCompletion() { }

	}

	private struct DeferredCallbackRegisterRequest
	{
		internal IAsyncOperation operation; //Field offset: 0x0
		internal bool incrementRefCount; //Field offset: 0x8

	}

	internal struct DiagnosticEventContext
	{
		[CompilerGenerated]
		private readonly AsyncOperationHandle <OperationHandle>k__BackingField; //Field offset: 0x0
		[CompilerGenerated]
		private readonly DiagnosticEventType <Type>k__BackingField; //Field offset: 0x18
		[CompilerGenerated]
		private readonly int <EventValue>k__BackingField; //Field offset: 0x1C
		[CompilerGenerated]
		private readonly IResourceLocation <Location>k__BackingField; //Field offset: 0x20
		[CompilerGenerated]
		private readonly object <Context>k__BackingField; //Field offset: 0x28
		[CompilerGenerated]
		private readonly string <Error>k__BackingField; //Field offset: 0x30

		public object Context
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 8
		}

		public string Error
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 8
		}

		public int EventValue
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 8
		}

		public IResourceLocation Location
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 8
		}

		public AsyncOperationHandle OperationHandle
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 20
		}

		public DiagnosticEventType Type
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 8
		}

		public DiagnosticEventContext(AsyncOperationHandle op, DiagnosticEventType type, int eventValue = 0, string error = null, object context = null) { }

		[CompilerGenerated]
		[IsReadOnly]
		public object get_Context() { }

		[CompilerGenerated]
		[IsReadOnly]
		public string get_Error() { }

		[CompilerGenerated]
		[IsReadOnly]
		public int get_EventValue() { }

		[CompilerGenerated]
		[IsReadOnly]
		public IResourceLocation get_Location() { }

		[CompilerGenerated]
		[IsReadOnly]
		public AsyncOperationHandle get_OperationHandle() { }

		[CompilerGenerated]
		[IsReadOnly]
		public DiagnosticEventType get_Type() { }

	}

	internal enum DiagnosticEventType
	{
		AsyncOperationFail = 0,
		AsyncOperationCreate = 1,
		AsyncOperationPercentComplete = 2,
		AsyncOperationComplete = 3,
		AsyncOperationReferenceCount = 4,
		AsyncOperationDestroy = 5,
	}

	public class InstanceOperation : AsyncOperationBase<GameObject>
	{
		private AsyncOperationHandle<GameObject> m_dependency; //Field offset: 0x98
		private InstantiationParameters m_instantiationParams; //Field offset: 0xB0
		private IInstanceProvider m_instanceProvider; //Field offset: 0xE0
		private GameObject m_instance; //Field offset: 0xE8
		private Scene m_scene; //Field offset: 0xF0

		protected virtual string DebugName
		{
			 get { } //Length: 272
		}

		protected virtual float Progress
		{
			 get { } //Length: 72
		}

		public InstanceOperation() { }

		protected virtual void Destroy() { }

		protected virtual void Execute() { }

		protected virtual string get_DebugName() { }

		protected virtual float get_Progress() { }

		public virtual void GetDependencies(List<AsyncOperationHandle> deps) { }

		internal virtual DownloadStatus GetDownloadStatus(HashSet<Object> visited) { }

		public void Init(ResourceManager rm, IInstanceProvider instanceProvider, InstantiationParameters instantiationParams, AsyncOperationHandle<GameObject> dependency) { }

		public Scene InstanceScene() { }

		protected virtual bool InvokeWaitForCompletion() { }

	}

	[CompilerGenerated]
	private static Action<AsyncOperationHandle, Exception> <ExceptionHandler>k__BackingField; //Field offset: 0x0
	private static int s_GroupOperationTypeHash; //Field offset: 0x8
	private static int s_InstanceOperationTypeHash; //Field offset: 0xC
	internal bool postProfilerEvents; //Field offset: 0x10
	[CompilerGenerated]
	private Func<IResourceLocation, String> <InternalIdTransformFunc>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private Action<UnityWebRequest> <WebRequestOverride>k__BackingField; //Field offset: 0x20
	internal bool CallbackHooksEnabled; //Field offset: 0x28
	private ListWithEvents<IResourceProvider> m_ResourceProviders; //Field offset: 0x30
	private IAllocationStrategy m_allocator; //Field offset: 0x38
	internal ListWithEvents<IUpdateReceiver> m_UpdateReceivers; //Field offset: 0x40
	private List<IUpdateReceiver> m_UpdateReceiversToRemove; //Field offset: 0x48
	private bool m_UpdatingReceivers; //Field offset: 0x50
	private bool m_InsideUpdateMethod; //Field offset: 0x51
	internal Dictionary<Int32, IResourceProvider> m_providerMap; //Field offset: 0x58
	private Dictionary<IOperationCacheKey, IAsyncOperation> m_AssetOperationCache; //Field offset: 0x60
	private HashSet<InstanceOperation> m_TrackedInstanceOperations; //Field offset: 0x68
	internal DelegateList<Single> m_UpdateCallbacks; //Field offset: 0x70
	private List<IAsyncOperation> m_DeferredCompleteCallbacks; //Field offset: 0x78
	private bool m_InsideExecuteDeferredCallbacksMethod; //Field offset: 0x80
	private List<DeferredCallbackRegisterRequest> m_DeferredCallbacksToRegister; //Field offset: 0x88
	private Action<AsyncOperationHandle, DiagnosticEventType, Int32, Object> m_obsoleteDiagnosticsHandler; //Field offset: 0x90
	private Action<DiagnosticEventContext> m_diagnosticsHandler; //Field offset: 0x98
	private Action<IAsyncOperation> m_ReleaseOpNonCached; //Field offset: 0xA0
	private Action<IAsyncOperation> m_ReleaseOpCached; //Field offset: 0xA8
	private Action<IAsyncOperation> m_ReleaseInstanceOp; //Field offset: 0xB0
	[CompilerGenerated]
	private CertificateHandler <CertificateHandlerInstance>k__BackingField; //Field offset: 0xB8
	private bool m_RegisteredForCallbacks; //Field offset: 0xC0
	private Dictionary<Type, Type> m_ProviderOperationTypeCache; //Field offset: 0xC8

	public IAllocationStrategy Allocator
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public CertificateHandler CertificateHandlerInstance
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	internal int DeferredCallbackCount
	{
		internal get { } //Length: 76
	}

	internal int DeferredCompleteCallbacksCount
	{
		internal get { } //Length: 72
	}

	public static Action<AsyncOperationHandle, Exception> ExceptionHandler
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		 set { } //Length: 104
	}

	internal int InstanceOperationCount
	{
		internal get { } //Length: 72
	}

	public Func<IResourceLocation, String> InternalIdTransformFunc
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	internal int OperationCacheCount
	{
		internal get { } //Length: 80
	}

	public IList<IResourceProvider> ResourceProviders
	{
		 get { } //Length: 8
	}

	public Action<UnityWebRequest> WebRequestOverride
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	private static ResourceManager() { }

	public ResourceManager(IAllocationStrategy alloc = null) { }

	[CompilerGenerated]
	private void <.ctor>b__57_0(IUpdateReceiver x) { }

	public AsyncOperationHandle<TObject> Acquire(AsyncOperationHandle<TObject> handle) { }

	public void Acquire(AsyncOperationHandle handle) { }

	private GroupOperation AcquireGroupOpFromCache(IOperationCacheKey key) { }

	internal void AddOperationToCache(IOperationCacheKey key, IAsyncOperation operation) { }

	public void AddUpdateReceiver(IUpdateReceiver receiver) { }

	internal int CachedOperationCount() { }

	private int CalculateLocationsHash(IList<IResourceLocation> locations, Type t = null) { }

	public void CleanupSceneInstances(Scene scene) { }

	public void ClearDiagnosticCallbacks() { }

	[Obsolete("ClearDiagnosticsCallback is Obsolete, use ClearDiagnosticCallbacks instead.")]
	public void ClearDiagnosticsCallback() { }

	internal void ClearOperationCache() { }

	internal IOperationCacheKey CreateCacheKeyForLocation(IResourceProvider provider, IResourceLocation location, Type desiredType = null) { }

	public AsyncOperationHandle<TObject> CreateChainOperation(AsyncOperationHandle dependentOp, Func<AsyncOperationHandle, AsyncOperationHandle`1<TObject>> callback) { }

	public AsyncOperationHandle<TObject> CreateChainOperation(AsyncOperationHandle dependentOp, Func<AsyncOperationHandle, AsyncOperationHandle`1<TObject>> callback, bool releaseDependenciesOnFailure = true) { }

	public AsyncOperationHandle<TObject> CreateChainOperation(AsyncOperationHandle<TObjectDependency> dependentOp, Func<AsyncOperationHandle`1<TObjectDependency>, AsyncOperationHandle`1<TObject>> callback, bool releaseDependenciesOnFailure = true) { }

	public AsyncOperationHandle<TObject> CreateChainOperation(AsyncOperationHandle<TObjectDependency> dependentOp, Func<AsyncOperationHandle`1<TObjectDependency>, AsyncOperationHandle`1<TObject>> callback) { }

	public AsyncOperationHandle<TObject> CreateCompletedOperation(TObject result, string errorMsg) { }

	internal AsyncOperationHandle<TObject> CreateCompletedOperationInternal(TObject result, bool success, Exception exception, bool releaseDependenciesOnFailure = true) { }

	public AsyncOperationHandle<TObject> CreateCompletedOperationWithException(TObject result, Exception exception) { }

	public AsyncOperationHandle<IList`1<AsyncOperationHandle>> CreateGenericGroupOperation(List<AsyncOperationHandle> operations, bool releasedCachedOpOnComplete = false) { }

	internal AsyncOperationHandle<IList`1<AsyncOperationHandle>> CreateGroupOperation(IList<IResourceLocation> locations, bool allowFailedDependencies) { }

	public AsyncOperationHandle<IList`1<AsyncOperationHandle>> CreateGroupOperation(IList<IResourceLocation> locations) { }

	internal T CreateOperation(Type actualType, int typeHash, IOperationCacheKey cacheKey, Action<IAsyncOperation> onDestroyAction) { }

	public override void Dispose() { }

	private void ExecuteDeferredCallbacks() { }

	public IAllocationStrategy get_Allocator() { }

	[CompilerGenerated]
	public CertificateHandler get_CertificateHandlerInstance() { }

	internal int get_DeferredCallbackCount() { }

	internal int get_DeferredCompleteCallbacksCount() { }

	[CompilerGenerated]
	public static Action<AsyncOperationHandle, Exception> get_ExceptionHandler() { }

	internal int get_InstanceOperationCount() { }

	[CompilerGenerated]
	public Func<IResourceLocation, String> get_InternalIdTransformFunc() { }

	internal int get_OperationCacheCount() { }

	public IList<IResourceProvider> get_ResourceProviders() { }

	[CompilerGenerated]
	public Action<UnityWebRequest> get_WebRequestOverride() { }

	private Type GetDefaultTypeForLocation(IResourceLocation loc) { }

	internal IAsyncOperation GetOperationFromCache(IResourceLocation location, Type desiredType) { }

	public IResourceProvider GetResourceProvider(Type t, IResourceLocation location) { }

	internal bool IsOperationCached(IOperationCacheKey key) { }

	private void OnInstanceOperationDestroy(IAsyncOperation o) { }

	private void OnObjectAdded(object obj) { }

	private void OnObjectRemoved(object obj) { }

	private void OnOperationDestroyCached(IAsyncOperation o) { }

	private void OnOperationDestroyNonCached(IAsyncOperation o) { }

	internal void PostDiagnosticEvent(DiagnosticEventContext context) { }

	public AsyncOperationHandle<GameObject> ProvideInstance(IInstanceProvider provider, IResourceLocation location, InstantiationParameters instantiateParameters) { }

	private AsyncOperationHandle ProvideResource(IResourceLocation location, Type desiredType = null, bool releaseDependenciesOnFailure = true) { }

	public AsyncOperationHandle<TObject> ProvideResource(IResourceLocation location) { }

	internal AsyncOperationHandle<IList`1<AsyncOperationHandle>> ProvideResourceGroupCached(IList<IResourceLocation> locations, int groupHash, Type desiredType, Action<AsyncOperationHandle> callback, bool releaseDependenciesOnFailure = true) { }

	public AsyncOperationHandle<IList`1<TObject>> ProvideResources(IList<IResourceLocation> locations, Action<TObject> callback = null) { }

	public AsyncOperationHandle<IList`1<TObject>> ProvideResources(IList<IResourceLocation> locations, bool releaseDependenciesOnFailure, Action<TObject> callback = null) { }

	public AsyncOperationHandle<SceneInstance> ProvideScene(ISceneProvider sceneProvider, IResourceLocation location, LoadSceneParameters loadSceneParameters, bool activateOnLoad, int priority) { }

	public AsyncOperationHandle<SceneInstance> ProvideScene(ISceneProvider sceneProvider, IResourceLocation location, LoadSceneMode loadSceneMode, bool activateOnLoad, int priority) { }

	[Obsolete]
	public void RegisterDiagnosticCallback(Action<AsyncOperationHandle, DiagnosticEventType, Int32, Object> func) { }

	public void RegisterDiagnosticCallback(Action<DiagnosticEventContext> func) { }

	internal void RegisterForCallbacks() { }

	internal void RegisterForDeferredCallback(IAsyncOperation op, bool incrementRefCount = true) { }

	public void Release(AsyncOperationHandle handle) { }

	public AsyncOperationHandle<SceneInstance> ReleaseScene(ISceneProvider sceneProvider, AsyncOperationHandle<SceneInstance> sceneLoadHandle) { }

	internal bool RemoveOperationFromCache(IOperationCacheKey key) { }

	public void RemoveUpdateReciever(IUpdateReceiver receiver) { }

	public void set_Allocator(IAllocationStrategy value) { }

	[CompilerGenerated]
	public void set_CertificateHandlerInstance(CertificateHandler value) { }

	[CompilerGenerated]
	public static void set_ExceptionHandler(Action<AsyncOperationHandle, Exception> value) { }

	[CompilerGenerated]
	public void set_InternalIdTransformFunc(Func<IResourceLocation, String> value) { }

	[CompilerGenerated]
	public void set_WebRequestOverride(Action<UnityWebRequest> value) { }

	public AsyncOperationHandle<TObject> StartOperation(AsyncOperationBase<TObject> operation, AsyncOperationHandle dependency) { }

	internal AsyncOperationHandle StartOperation(IAsyncOperation operation, AsyncOperationHandle dependency) { }

	public string TransformInternalId(IResourceLocation location) { }

	public void UnregisterDiagnosticCallback(Action<DiagnosticEventContext> func) { }

	internal void Update(float unscaledDeltaTime) { }

}

