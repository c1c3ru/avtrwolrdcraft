namespace PWC.World.Buildings;

public static class WorldBuildingsDataManager
{
	private const string WORLD_BUILDING_DATA_PLAYER_PREFS_PREFIX = "WorldBuildingData_"; //Field offset: 0x0

	public static void SaveBuildingData(WorldBuildingType buildingType, LevelType levelType) { }

	public static bool TryLoadBuildingData(WorldBuildingType buildingType, out LevelType levelType) { }

}

