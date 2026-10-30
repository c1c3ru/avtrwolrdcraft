namespace UnityEngine;

[NativeHeader("Modules/AssetBundle/Public/AssetBundleUnloadOperation.h")]
[RequiredByNativeCode]
public class AssetBundleUnloadOperation : AsyncOperation
{

	public AssetBundleUnloadOperation() { }

	[NativeMethod("WaitForCompletion")]
	public void WaitForCompletion() { }

}

