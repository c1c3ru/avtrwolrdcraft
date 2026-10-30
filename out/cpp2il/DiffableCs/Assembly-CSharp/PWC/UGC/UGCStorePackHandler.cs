namespace PWC.UGC;

public class UGCStorePackHandler : MonoBehaviour, IPDItemsMenuPack, IPDPack
{
	[SerializeField]
	private StorePackType _storePackType; //Field offset: 0x20
	[SerializeField]
	private LevelWorldType _levelWorldType; //Field offset: 0x24

	public UGCStorePackHandler() { }

	public override StorePackType GetStorePackType() { }

	public string GetWorldSceneName() { }

}

