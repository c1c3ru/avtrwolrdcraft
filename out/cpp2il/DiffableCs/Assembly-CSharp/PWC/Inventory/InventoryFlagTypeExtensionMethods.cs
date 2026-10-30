namespace PWC.Inventory;

[Extension]
public static class InventoryFlagTypeExtensionMethods
{
	private static readonly HashSet<InventoryFlagType> _pets; //Field offset: 0x0
	private static readonly Dictionary<InventoryFlagType, StorePackType> _storePackTypesByFlag; //Field offset: 0x8

	private static InventoryFlagTypeExtensionMethods() { }

	private static AvatarType GetAvatarTypeForPack(Dictionary<SpineType, HashSet`1<String>> spineTypeDictionary) { }

	[Extension]
	public static string GetStorePackName(InventoryFlagType flagType) { }

	private static void SetCarBreedPackData(InventoryFlagType flagType, out string sceneToLoad) { }

	private static void SetExpansionPackData(InventoryFlagType flagType, out string sceneToLoad) { }

	[Extension]
	public static bool ShouldOpenUGCPreset(InventoryFlagType flagType) { }

	[Extension]
	public static bool TryGetSceneToLoad(InventoryFlagType flagType, out string sceneName) { }

}

