namespace Game.Store;

public class StorePackItemBundleHandler : MonoBehaviour
{
	[SerializeField]
	private GameObject _claimableState; //Field offset: 0x20
	[SerializeField]
	private GameObject _linkToPackState; //Field offset: 0x28
	private StorePackItem _packItem; //Field offset: 0x30

	public StorePackItemBundleHandler() { }

	[CompilerGenerated]
	private void <OnItemSyncView>g__Show|6_0(GameObject target) { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnItemSyncView(StorePackItem _) { }

	private bool TryOverrideClickAction(StorePackItemBase _) { }

}

