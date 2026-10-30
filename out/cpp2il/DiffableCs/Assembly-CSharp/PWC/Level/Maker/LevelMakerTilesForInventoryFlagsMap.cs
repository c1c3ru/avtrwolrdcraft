namespace PWC.Level.Maker;

public static class LevelMakerTilesForInventoryFlagsMap
{
	private const string TILE_PACK_DATA_FOLDER_PATH = "LevelMaker/TilePackData/"; //Field offset: 0x0
	private static Dictionary<CustomizationCategoryType, List`1<InventoryFlagType>> _tilePackMap; //Field offset: 0x0

	private static void EnsureTilePackMap() { }

	public static IReadOnlyList<InventoryFlagType> GetPremiumTilePacksByCategoryType(CustomizationCategoryType categoryType) { }

}

