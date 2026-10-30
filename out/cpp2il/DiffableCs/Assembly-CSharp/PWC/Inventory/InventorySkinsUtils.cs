namespace PWC.Inventory;

public static class InventorySkinsUtils
{
	private const string AVATAR_MAKER_FLAG_INTERACTION_PREFIX = "AvatarMakerFlagInteraction_"; //Field offset: 0x0
	public static InventorySkinsBuildData BuildData; //Field offset: 0x0
	private const string DATA_PATH = "AvatarMaker/Data/InventorySkinsBuildData"; //Field offset: 0x0
	private const string EXPANSION_PACK_DATA_PATH = "AvatarMaker/Data/ExpansionPacksBuildData"; //Field offset: 0x0
	private static InventorySkinsBuildData _expansionPackData; //Field offset: 0x8

	public static void ForEachOwnedPremiumSkinFlag(InventorySkinsBuildData buildData, Func<InventoryFlagType, Boolean> handler) { }

	private static HashSet<Int32> GetAllCategories(InventoryFlagType flagType, SpineType spineType) { }

	public static InventorySkinsBuildData GetDataAsset() { }

	public static InventorySkinsBuildData GetExpansionPackDataAsset() { }

	private static string GetKey(InventoryFlagType flagType, SpineType spineType, int categoryType) { }

	public static bool IsFlagInteractionPerformed(InventoryFlagType flagType, SpineType spineType, int categoryType) { }

	public static bool IsInteractionPerformedForAllClaimedFlags(SpineType spineType, int categoryType) { }

	public static void SetFlagInteractionPerformed(InventoryFlagType flagType, SpineType spineType, int categoryType, bool value) { }

	public static void SetInteractionPerformedForAllClaimedFlags(SpineType spineType, int categoryType) { }

	public static void SetNewFlagNotSeenYet(string flag) { }

	public static void SetNewFlagNotSeenYet(InventoryFlagType flagType) { }

}

