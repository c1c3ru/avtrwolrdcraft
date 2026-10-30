namespace UnityEngine.AddressableAssets;

public class AssetReferenceT : AssetReference
{

	public AssetReferenceT`1(string guid) { }

	[Obsolete]
	public AsyncOperationHandle<TObject> LoadAsset() { }

	public override AsyncOperationHandle<TObject> LoadAssetAsync() { }

	public virtual bool ValidateAsset(object obj) { }

	public virtual bool ValidateAsset(string mainAssetPath) { }

}

