namespace PWC.AvatarSpine;

[Extension]
public static class ToddlerCategoryTypeExtensionMethods
{

	[Extension]
	public static List<Int32> GetCategoryTypesOfSameSlot(ToddlerCategoryType categoryType) { }

	[Extension]
	public static List<ToddlerCategoryType> GetHiddenCategories(ToddlerCategoryType categoryType) { }

	[Extension]
	public static void GetMaterialConfig(ToddlerCategoryType categoryType, string skinName, bool isColorable, out AvatarSpineColoringConfig coloringConfig) { }

	[Extension]
	public static List<ToddlerCategoryType> GetParentAndSisterCategories(ToddlerCategoryType categoryType) { }

	[Extension]
	public static ToddlerCategoryType GetParentCategory(ToddlerCategoryType categoryType) { }

	[Extension]
	public static ToddlerCategoryType GetParentColorCategory(ToddlerCategoryType categoryType) { }

	[Extension]
	public static ToddlerCategoryType GetSUTSystemCategoryKey(ToddlerCategoryType categoryType) { }

	[Extension]
	public static bool IsCategoryTypeBodyCategory(ToddlerCategoryType categoryType) { }

	[Extension]
	public static bool IsChangeable(ToddlerCategoryType categoryType) { }

	[Extension]
	public static bool IsDeletable(ToddlerCategoryType categoryType) { }

	[Extension]
	public static bool IsParentCategory(ToddlerCategoryType categoryType) { }

	[Extension]
	public static bool IsSisterCategoriesUnderSameSlot(ToddlerCategoryType categoryType) { }

	[Extension]
	public static bool IsSubcategory(ToddlerCategoryType categoryType) { }

	[Extension]
	public static bool ShouldUseSUTSystem(ToddlerCategoryType categoryType) { }

	[Extension]
	public static bool TryGetCategoryTypeOfBabyClothes(ToddlerCategoryType toddlerCategoryType, out BabyCategoryType babyCategoryType) { }

}

