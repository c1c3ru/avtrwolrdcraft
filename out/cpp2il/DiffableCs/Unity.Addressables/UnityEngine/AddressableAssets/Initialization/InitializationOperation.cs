namespace UnityEngine.AddressableAssets.Initialization;

internal class InitializationOperation : AsyncOperationBase<IResourceLocator>
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<IResourceProvider, Boolean> <>9__13_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <Execute>b__13_0(IResourceProvider rp) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass16_0
	{
		public AddressablesImpl addressables; //Field offset: 0x10
		public string providerSuffix; //Field offset: 0x18
		public IResourceLocation remoteHashLocation; //Field offset: 0x20

		public <>c__DisplayClass16_0() { }

		internal AsyncOperationHandle<IResourceLocator> <LoadContentCatalog>b__0(AsyncOperationHandle<ContentCatalogData> res) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass18_0
	{
		public InitializationOperation <>4__this; //Field offset: 0x10
		public IList<IResourceLocation> catalogs; //Field offset: 0x18
		public ResourceLocationMap locMap; //Field offset: 0x20
		public int index; //Field offset: 0x28
		public IResourceLocation remoteHashLocation; //Field offset: 0x30

		public <>c__DisplayClass18_0() { }

		internal void <LoadContentCatalogInternal>b__0(AsyncOperationHandle<IResourceLocator> op) { }

	}

	private AsyncOperationHandle<ResourceManagerRuntimeData> m_rtdOp; //Field offset: 0x98
	private AsyncOperationHandle<IResourceLocator> m_loadCatalogOp; //Field offset: 0xB0
	private string m_ProviderSuffix; //Field offset: 0xC8
	private AddressablesImpl m_Addressables; //Field offset: 0xD0
	private ResourceManagerDiagnostics m_Diagnostics; //Field offset: 0xD8
	private InitalizationObjectsOperation m_InitGroupOps; //Field offset: 0xE0

	protected virtual string DebugName
	{
		 get { } //Length: 64
	}

	protected virtual float Progress
	{
		 get { } //Length: 128
	}

	public InitializationOperation(AddressablesImpl aa) { }

	internal static AsyncOperationHandle<IResourceLocator> CreateInitializationOperation(AddressablesImpl aa, string playerSettingsLocation, string providerSuffix) { }

	protected virtual void Execute() { }

	protected virtual string get_DebugName() { }

	protected virtual float get_Progress() { }

	protected virtual bool InvokeWaitForCompletion() { }

	public static AsyncOperationHandle<IResourceLocator> LoadContentCatalog(AddressablesImpl addressables, IResourceLocation loc, string providerSuffix, IResourceLocation remoteHashLocation = null) { }

	public AsyncOperationHandle<IResourceLocator> LoadContentCatalog(IResourceLocation loc, string providerSuffix, IResourceLocation remoteHashLocation) { }

	internal AsyncOperationHandle<IResourceLocator> LoadContentCatalogInternal(IList<IResourceLocation> catalogs, int index, ResourceLocationMap locMap, IResourceLocation remoteHashLocation) { }

	private void LoadOpComplete(AsyncOperationHandle<IResourceLocator> op, IList<IResourceLocation> catalogs, ResourceLocationMap locMap, int index, IResourceLocation remoteHashLocation) { }

	private static void LoadProvider(AddressablesImpl addressables, ObjectInitializationData providerData, string providerSuffix) { }

	private static AsyncOperationHandle<IResourceLocator> OnCatalogDataLoaded(AddressablesImpl addressables, AsyncOperationHandle<ContentCatalogData> op, string providerSuffix, IResourceLocation remoteHashLocation) { }

}

