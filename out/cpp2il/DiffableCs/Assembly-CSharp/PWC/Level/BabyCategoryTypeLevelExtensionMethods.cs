namespace PWC.Level;

[Extension]
public static class BabyCategoryTypeLevelExtensionMethods
{

	[Extension]
	public static BabyClothingType GetLevelClothingType(BabyCategoryType categoryType) { }

	[Extension]
	public static string GetPrefabName(BabyCategoryType categoryType) { }

	[Extension]
	public static string GetSingleItemSuffix(BabyCategoryType categoryType) { }

	[Extension]
	public static string GetSuffixForPremadeMaker(BabyCategoryType categoryType) { }

	[Extension]
	public static bool IsHangableSingleState(BabyCategoryType categoryType) { }

}

