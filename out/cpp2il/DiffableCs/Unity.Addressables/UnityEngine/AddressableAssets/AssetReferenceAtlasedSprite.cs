namespace UnityEngine.AddressableAssets;

public class AssetReferenceAtlasedSprite : AssetReferenceT<Sprite>
{

	public AssetReferenceAtlasedSprite(string guid) { }

	public virtual bool ValidateAsset(object obj) { }

	public virtual bool ValidateAsset(string path) { }

}

