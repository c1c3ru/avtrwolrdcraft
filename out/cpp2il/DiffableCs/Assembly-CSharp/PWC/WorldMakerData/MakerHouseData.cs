namespace PWC.WorldMakerData;

public class MakerHouseData
{
	public string ID; //Field offset: 0x10
	public WorldMakerStreetType StreetType; //Field offset: 0x18
	public WorldMakerBuildingType BuildingType; //Field offset: 0x1C
	public List<MakerLevelData> MakerLevelsData; //Field offset: 0x20

	public MakerHouseData(string makerHouseID, WorldMakerStreetType streetType, WorldMakerBuildingType buildingType, List<MakerLevelData> makerLevelsData) { }

}

