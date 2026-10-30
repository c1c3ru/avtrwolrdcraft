namespace UnityEngine.ResourceManagement.ResourceProviders;

[DisplayName("Sprites from Atlases Provider")]
public class AtlasSpriteProvider : ResourceProviderBase
{

	public AtlasSpriteProvider() { }

	public virtual void Provide(ProvideHandle providerInterface) { }

	public virtual void Release(IResourceLocation location, object obj) { }

}

