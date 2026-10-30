namespace UnityEngine.ResourceManagement.ResourceProviders;

[DisplayName("AssetBundle Provider")]
public class AssetBundleProvider : ResourceProviderBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_0
	{
		public IResourceLocation location; //Field offset: 0x10

		public <>c__DisplayClass12_0() { }

		internal void <Release>b__0(AsyncOperation op) { }

	}

	internal static Dictionary<String, AssetBundleUnloadOperation> m_UnloadingBundles; //Field offset: 0x0

	internal static int AssetBundleCount
	{
		internal get { } //Length: 128
	}

	internal static int UnloadingAssetBundleCount
	{
		internal get { } //Length: 120
	}

	protected internal static Dictionary<String, AssetBundleUnloadOperation> UnloadingBundles
	{
		private get { } //Length: 88
		internal set { } //Length: 104
	}

	private static AssetBundleProvider() { }

	public AssetBundleProvider() { }

	internal override IOperationCacheKey CreateCacheKeyForLocation(ResourceManager rm, IResourceLocation location, Type desiredType) { }

	internal static int get_AssetBundleCount() { }

	internal static int get_UnloadingAssetBundleCount() { }

	protected private static Dictionary<String, AssetBundleUnloadOperation> get_UnloadingBundles() { }

	public virtual Type GetDefaultType(IResourceLocation location) { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::SubsystemRegistration (4))]
	private static void Init() { }

	public virtual void Provide(ProvideHandle providerInterface) { }

	public virtual void Release(IResourceLocation location, object asset) { }

	internal static void set_UnloadingBundles(Dictionary<String, AssetBundleUnloadOperation> value) { }

	internal static void WaitForAllUnloadingBundlesToComplete() { }

}

