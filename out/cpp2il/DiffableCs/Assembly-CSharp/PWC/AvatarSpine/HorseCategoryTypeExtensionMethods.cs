namespace PWC.AvatarSpine;

[Extension]
public static class HorseCategoryTypeExtensionMethods
{

	[Extension]
	public static List<Int32> GetCategoryTypesOfSameSlot(HorseCategoryType categoryType) { }

	[Extension]
	public static void GetMaterialConfig(HorseCategoryType categoryType, string skinName, bool isColorable, out AvatarSpineColoringConfig coloringConfig) { }

	[Extension]
	public static HorseCategoryType GetParentCategory(HorseCategoryType categoryType) { }

	[Extension]
	public static HorseCategoryType GetParentColorCategory(HorseCategoryType categoryType) { }

	[Extension]
	public static HorseCategoryType GetSUTSystemCategoryKey(HorseCategoryType categoryType) { }

	[Extension]
	public static bool IsCategoryTypeBodyCategory(HorseCategoryType categoryType) { }

	[Extension]
	public static bool IsDeletable(HorseCategoryType categoryType) { }

	[Extension]
	public static bool IsParentCategory(HorseCategoryType categoryType) { }

	[Extension]
	public static bool IsSubcategory(HorseCategoryType categoryType) { }

	[Extension]
	public static bool IsUsingBreed(HorseCategoryType categoryType) { }

	[Extension]
	public static bool ShouldUseSUTSystem(HorseCategoryType categoryType) { }

}

