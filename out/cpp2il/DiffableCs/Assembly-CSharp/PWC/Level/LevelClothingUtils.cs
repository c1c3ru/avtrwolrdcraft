namespace PWC.Level;

public static class LevelClothingUtils
{
	private static Dictionary<SpineType, LevelAvatarClothingMap> _clothingMaps; //Field offset: 0x0
	private static readonly String[] _suffixes; //Field offset: 0x8

	private static LevelClothingUtils() { }

	public static string GetClothesPrefabsBasePath(SpineType spineType) { }

	public static string GetClothingDataBasePath(SpineType spineType) { }

	public static List<LevelClothingItemPD> GetClothingItemsPDFromMennequinPD(Dictionary<String, Object> data) { }

	public static LevelAvatarClothingMap GetClothingMap(SpineType spineType) { }

	private static Vector2 GetPositionForSpawnedClothingItem(SpineType spineType, int categoryType, Vector2 ownerPosition) { }

	public static string GetSkinNameFromSpriteName(SpineType spineType, string spriteName) { }

	public static string GetSpecialClothingDataBasePath(SpineType spineType) { }

	public static void RefreshLitSpineAfterPutClothing(AvatarSpineSkinsManagerBase skinsManager) { }

	private static string SkinNameKeyForCAData(string skinName) { }

	public static ILevelClothingItem SpawnClothingItem(SpineType spineType, int categoryType, string skinName, Vector2 ownerPosition, AvatarSpineSkinsManagerBase avatarSpineSkinsManager = null) { }

	public static bool TryAddCAHandlerFromSkinName(ICATarget caTarget, SpineType spineType, Dictionary<String, LevelCASpineSkinHandlerBase> skinCAHandlers, ref GameObject skinCAHandlersGameObject, string skinName) { }

	public static bool TryGetCAHandlerTypeForSkinName(SpineType spineType, string skinName, out Type handlerType) { }

	public static bool TryGetCAHandlerWithDataForSkinName(SpineType spineType, string skinName, out LevelCAItemHandlerData data) { }

	public static bool TryGetClothingPrefab(SpineType spineType, string skinName, int categoryType, out PDPrefab prefab, out Item dataItem, bool logIfError = true) { }

	public static bool TryGetClothingPrefabData(SpineType spineType, string skinName, int categoryType, out Item dataItem, bool logIfError = true) { }

	public static bool TryRemoveCAHandlerFromSkinName(ICATarget caTarget, Dictionary<String, LevelCASpineSkinHandlerBase> skinCAHandlers, string skinName) { }

}

