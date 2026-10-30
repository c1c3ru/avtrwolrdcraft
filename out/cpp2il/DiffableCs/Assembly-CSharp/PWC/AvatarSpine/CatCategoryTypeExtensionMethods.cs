namespace PWC.AvatarSpine;

[Extension]
public static class CatCategoryTypeExtensionMethods
{

	[Extension]
	public static List<Int32> GetCategoryTypesOfSameSlot(CatCategoryType categoryType) { }

	[Extension]
	public static List<CatCategoryType> GetHiddenCategories(CatCategoryType categoryType) { }

	[Extension]
	public static void GetMaterialConfig(CatCategoryType categoryType, string skinName, bool isColorable, out AvatarSpineColoringConfig coloringConfig) { }

	[Extension]
	public static CatCategoryType GetParentCategory(CatCategoryType categoryType) { }

	[Extension]
	public static CatCategoryType GetParentColorCategory(CatCategoryType categoryType) { }

	[Extension]
	public static CatCategoryType GetSUTSystemCategoryKey(CatCategoryType categoryType) { }

	[Extension]
	public static bool IsCategoryTypeBodyCategory(CatCategoryType categoryType) { }

	[Extension]
	public static bool IsChangeable(CatCategoryType categoryType) { }

	[Extension]
	public static bool IsDeletable(CatCategoryType categoryType) { }

	[Extension]
	public static bool IsParentCategory(CatCategoryType categoryType) { }

	[Extension]
	public static bool IsSisterCategoriesUnderSameSlot(CatCategoryType categoryType) { }

	[Extension]
	public static bool IsUsingBreed(CatCategoryType categoryType) { }

	[Extension]
	public static bool ShouldUseSUTSystem(CatCategoryType categoryType) { }

}

