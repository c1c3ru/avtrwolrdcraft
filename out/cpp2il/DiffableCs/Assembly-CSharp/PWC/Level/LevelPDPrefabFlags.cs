namespace PWC.Level;

[Flags]
public enum LevelPDPrefabFlags
{
	None = 0,
	LevelItem = 1,
	LevelMakerItem = 2,
	PDPack = 4,
	Clothing = 8,
	Avatar = 16,
	PartOfStorePack = 32,
	ClothingBase = 64,
	Eatable = 128,
	Drinkable = 256,
	ItemWithConstantData = 512,
	LevelBoxedFurniture = 1024,
	UICountExtraPrefab = 2048,
	UGCItem = 4096,
	UGCPresetHolder = 8192,
	UGCLevelEntrance = 16384,
	ClothingWithBulkData = 32768,
}

