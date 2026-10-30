namespace UnityEngine.AddressableAssets;

public class AssetReferenceSprite : AssetReferenceT<Sprite>
{

	public AssetReferenceSprite(string guid) { }

	public virtual bool ValidateAsset(string path) { }

}

