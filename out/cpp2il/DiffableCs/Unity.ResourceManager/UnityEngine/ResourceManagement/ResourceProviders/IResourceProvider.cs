namespace UnityEngine.ResourceManagement.ResourceProviders;

public interface IResourceProvider
{

	public ProviderBehaviourFlags BehaviourFlags
	{
		 get { } //Length: 0
	}

	public string ProviderId
	{
		 get { } //Length: 0
	}

	public bool CanProvide(Type type, IResourceLocation location) { }

	public ProviderBehaviourFlags get_BehaviourFlags() { }

	public string get_ProviderId() { }

	public Type GetDefaultType(IResourceLocation location) { }

	public void Provide(ProvideHandle provideHandle) { }

	public void Release(IResourceLocation location, object asset) { }

}

