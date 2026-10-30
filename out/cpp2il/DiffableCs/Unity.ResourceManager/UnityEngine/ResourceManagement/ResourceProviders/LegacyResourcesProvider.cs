namespace UnityEngine.ResourceManagement.ResourceProviders;

[DisplayName("Assets from Legacy Resources")]
public class LegacyResourcesProvider : ResourceProviderBase
{
	public class InternalOp
	{
		private ResourceRequest m_RequestOperation; //Field offset: 0x10
		private ProvideHandle m_ProvideHandle; //Field offset: 0x18

		public InternalOp() { }

		private void AsyncOperationCompleted(AsyncOperation op) { }

		public float PercentComplete() { }

		public void Start(ProvideHandle provideHandle) { }

		private bool WaitForCompletionHandler() { }

	}


	public LegacyResourcesProvider() { }

	public virtual void Provide(ProvideHandle pi) { }

	public virtual void Release(IResourceLocation location, object asset) { }

}

