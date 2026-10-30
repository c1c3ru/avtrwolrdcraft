namespace Game.Level;

public class LevelBulkDataStorePackSpawnHandler : LevelStorePackSpawnHandler, IHasPDTextBulkData, IPDItemsMenuPack, IPDPack
{
	[SerializeField]
	private PDTextBulkData _bulkData; //Field offset: 0x30

	public LevelBulkDataStorePackSpawnHandler() { }

	public override PDTextBulkData GetPDTextBulkData() { }

}

