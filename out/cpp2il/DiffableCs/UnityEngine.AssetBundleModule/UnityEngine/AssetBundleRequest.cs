namespace UnityEngine;

[NativeHeader("Modules/AssetBundle/Public/AssetBundleLoadAssetOperation.h")]
[RequiredByNativeCode]
public class AssetBundleRequest : ResourceRequest
{

	public Object[] allAssets
	{
		[NativeMethod("GetAllLoadedAssets")]
		 get { } //Length: 60
	}

	public object asset
	{
		 get { } //Length: 12
	}

	public AssetBundleRequest() { }

	[NativeMethod("GetAllLoadedAssets")]
	public Object[] get_allAssets() { }

	public object get_asset() { }

	[NativeMethod("GetLoadedAsset")]
	protected virtual object GetResult() { }

}

