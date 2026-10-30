namespace Game.Level;

public class LevelBulkDataInstantiatorWithMenuItems : LevelBulkDataInstantiator, IPDItemsMenuPack, IPDPack
{

	public LevelBulkDataInstantiatorWithMenuItems() { }

	public override StorePackType GetStorePackType() { }

	protected virtual bool IsIgnoringItemTracker() { }

}

