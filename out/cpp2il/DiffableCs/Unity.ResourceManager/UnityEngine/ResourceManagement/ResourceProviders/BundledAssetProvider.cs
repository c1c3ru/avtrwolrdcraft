namespace UnityEngine.ResourceManagement.ResourceProviders;

[DisplayName("Assets from Bundles Provider")]
public class BundledAssetProvider : ResourceProviderBase
{
	public class InternalOp
	{
		private AssetBundle m_AssetBundle; //Field offset: 0x10
		private AssetBundleRequest m_PreloadRequest; //Field offset: 0x18
		private AssetBundleRequest m_RequestOperation; //Field offset: 0x20
		private object m_Result; //Field offset: 0x28
		private ProvideHandle m_ProvideHandle; //Field offset: 0x30
		private string subObjectName; //Field offset: 0x48

		public InternalOp() { }

		[CompilerGenerated]
		private void <Start>b__7_0(AsyncOperation operation) { }

		private void ActionComplete(AsyncOperation obj) { }

		private void BeginAssetLoad() { }

		private void CompleteOperation() { }

		private void GetArrayResult(Object[] allAssets) { }

		private void GetAssetResult(object asset) { }

		private void GetAssetSubObjectResult(Object[] allAssets) { }

		private void GetListResult(Object[] allAssets) { }

		internal static T LoadBundleFromDependecies(IList<Object> results) { }

		public float ProgressCallback() { }

		public void Start(ProvideHandle provideHandle) { }

		private bool WaitForCompletionHandler() { }

	}


	public BundledAssetProvider() { }

	public virtual void Provide(ProvideHandle provideHandle) { }

}

