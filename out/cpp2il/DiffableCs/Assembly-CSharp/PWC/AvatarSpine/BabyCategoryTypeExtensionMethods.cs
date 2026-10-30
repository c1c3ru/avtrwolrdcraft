namespace PWC.AvatarSpine;

[Extension]
public static class BabyCategoryTypeExtensionMethods
{

	[Extension]
	public static List<Int32> GetCategoryTypesOfSameSlot(BabyCategoryType categoryType) { }

	[Extension]
	public static List<BabyCategoryType> GetHiddenCategories(BabyCategoryType categoryType) { }

	[Extension]
	public static void GetMaterialConfig(BabyCategoryType categoryType, string skinName, bool isColorable, out AvatarSpineColoringConfig coloringConfig) { }

	[Extension]
	public static List<BabyCategoryType> GetParentAndSisterCategories(BabyCategoryType categoryType) { }

	[Extension]
	public static BabyCategoryType GetParentCategory(BabyCategoryType categoryType) { }

	[Extension]
	public static BabyCategoryType GetParentColorCategory(BabyCategoryType categoryType) { }

	[Extension]
	public static BabyCategoryType GetSUTSystemCategoryKey(BabyCategoryType categoryType) { }

	[Extension]
	public static bool IsCategoryTypeBodyCategory(BabyCategoryType categoryType) { }

	[Extension]
	public static bool IsChangeable(BabyCategoryType categoryType) { }

	[Extension]
	public static bool IsDeletable(BabyCategoryType categoryType) { }

	[Extension]
	public static bool IsParentCategory(BabyCategoryType categoryType) { }

	[Extension]
	public static bool IsSisterCategoriesUnderSameSlot(BabyCategoryType categoryType) { }

	[Extension]
	public static bool ShouldUseSUTSystem(BabyCategoryType categoryType) { }

}

