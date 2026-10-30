namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCInstantiateAssetHandler : AFCUnityMessageDrivenHandlerBase
{
	[SerializeField]
	private AssetReferenceGameObject _assetReference; //Field offset: 0x28
	[SerializeField]
	private string _localPath; //Field offset: 0x30
	[SerializeField]
	private UnityEvent _onAssetLoaded; //Field offset: 0x38
	private bool _didCallLoadAssets; //Field offset: 0x40
	private AsyncOperationHandle<GameObject> _handle; //Field offset: 0x48
	[CompilerGenerated]
	private bool <UseLocalAsset>k__BackingField; //Field offset: 0x60

	public bool UseLocalAsset
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public AFCInstantiateAssetHandler() { }

	[CompilerGenerated]
	private void <InstantiateAsset>b__10_0(AsyncOperationHandle<GameObject> handle) { }

	[CompilerGenerated]
	public bool get_UseLocalAsset() { }

	public void InstantiateAsset() { }

	protected virtual void OnDestroy() { }

	public virtual void PerformAction() { }

	[CompilerGenerated]
	public void set_UseLocalAsset(bool value) { }

}

