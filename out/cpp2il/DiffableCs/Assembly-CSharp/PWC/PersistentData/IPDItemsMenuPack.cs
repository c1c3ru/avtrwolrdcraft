namespace PWC.PersistentData;

public interface IPDItemsMenuPack : IPDPack
{

	public StorePackType GetStorePackType() { }

	public bool TryGetPrefabGuids(out List<String>& prefabGuids) { }

}

