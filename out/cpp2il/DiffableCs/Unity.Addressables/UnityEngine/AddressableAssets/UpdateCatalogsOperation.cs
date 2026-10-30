namespace UnityEngine.AddressableAssets;

internal class UpdateCatalogsOperation : AsyncOperationBase<List`1<IResourceLocator>>
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<IResourceProvider, Boolean> <>9__6_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <Start>b__6_0(IResourceProvider rp) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass11_0
	{
		public UpdateCatalogsOperation <>4__this; //Field offset: 0x10
		public List<IResourceLocator> catalogs; //Field offset: 0x18

		public <>c__DisplayClass11_0() { }

		internal void <OnCleanCacheCompleted>b__0(AsyncOperationHandle<Boolean> obj) { }

	}

	private AddressablesImpl m_Addressables; //Field offset: 0x98
	private List<ResourceLocatorInfo> m_LocatorInfos; //Field offset: 0xA0
	internal AsyncOperationHandle<IList`1<AsyncOperationHandle>> m_DepOp; //Field offset: 0xA8
	private AsyncOperationHandle<Boolean> m_CleanCacheOp; //Field offset: 0xC0
	private bool m_AutoCleanBundleCache; //Field offset: 0xD8

	public UpdateCatalogsOperation(AddressablesImpl aa) { }

	protected virtual void Destroy() { }

	protected virtual void Execute() { }

	public virtual void GetDependencies(List<AsyncOperationHandle> dependencies) { }

	protected virtual bool InvokeWaitForCompletion() { }

	private void OnCleanCacheCompleted(AsyncOperationHandle<Boolean> handle, List<IResourceLocator> catalogs) { }

	public AsyncOperationHandle<List`1<IResourceLocator>> Start(IEnumerable<String> catalogIds, bool autoCleanBundleCache) { }

}

