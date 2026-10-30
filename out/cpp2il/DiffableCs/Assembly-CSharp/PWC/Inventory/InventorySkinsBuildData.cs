namespace PWC.Inventory;

public class InventorySkinsBuildData : ScriptableObject
{
	internal class FlagsToSkinsMap
	{
		internal class Pack
		{
			internal class SpineTypeToSkins
			{
				public SpineType spineType; //Field offset: 0x10
				public List<String> skins; //Field offset: 0x18

				public SpineTypeToSkins() { }

			}

			public InventoryFlagType flag; //Field offset: 0x10
			public List<SpineTypeToSkins> spines; //Field offset: 0x18

			public Pack() { }

		}

		public List<Pack> packs; //Field offset: 0x10

		public FlagsToSkinsMap() { }

	}

	public const string MAP_CSV_PATH = "AvatarMaker/Data/Avatar_MKR_Packs"; //Field offset: 0x0
	private const string SkinsPack = "FlagPack"; //Field offset: 0x0
	public FlagsToSkinsMap flagsToSkins; //Field offset: 0x18
	private Dictionary<InventoryFlagType, Dictionary`2<SpineType, HashSet`1<String>>> _hashedFlagsToSkinsMap; //Field offset: 0x20
	private HashSet<String> _hashedItems; //Field offset: 0x28
	private HashSet<InventoryFlagType> _hashedFlags; //Field offset: 0x30

	public InventorySkinsBuildData() { }

	public bool ContainsItem(string skinName) { }

	public void EnsureInit() { }

	private static void GetColumnsValues(String[][] tables, int index, List<String> resluts) { }

	public Dictionary<SpineType, HashSet`1<String>> GetDictionaryForSpecificFlagType(InventoryFlagType flagType) { }

	public HashSet<InventoryFlagType> GetPremiumSkinsInventoryFlags() { }

	private static String[][] GetTableFromText(string text) { }

	public bool TryGetCategoriesFromFlag(InventoryFlagType flag, SpineType spineType, out HashSet<Int32>& categories) { }

	public bool TryGetSkinsFromFlag(InventoryFlagType flag, SpineType spineType, int categoryType, out HashSet<String>& skins) { }

	private bool TryGetSkinsFromFlagForSpine(InventoryFlagType flag, SpineType spineType, int categoryType, out HashSet<String>& skins) { }

	public static bool TryGetText(string path, out string text) { }

}

