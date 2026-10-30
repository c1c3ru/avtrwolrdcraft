namespace PWC.Level.Maker.CustomizationConfig;

public class LevelMakerCCBase
{
	public const string ASSETS_ROOT = "LevelMaker/"; //Field offset: 0x0
	public string name; //Field offset: 0x10
	public InventoryFlagType inventoryFlagType; //Field offset: 0x18

	public LevelMakerCCBase() { }

	public IList<T> GetAssets(IList<String> paths) { }

}

