namespace PWC.AvatarSpine;

[Extension]
public static class DogCategoryTypeExtensionMethods
{

	[Extension]
	public static List<Int32> GetCategoryTypesOfSameSlot(DogCategoryType categoryType) { }

	[Extension]
	public static List<DogCategoryType> GetHiddenCategories(DogCategoryType categoryType) { }

	[Extension]
	public static void GetMaterialConfig(DogCategoryType categoryType, string skinName, bool isColorable, out AvatarSpineColoringConfig coloringConfig) { }

	[Extension]
	public static DogCategoryType GetParentCategory(DogCategoryType categoryType) { }

	[Extension]
	public static DogCategoryType GetParentColorCategory(DogCategoryType categoryType) { }

	[Extension]
	public static DogCategoryType GetSUTSystemCategoryKey(DogCategoryType categoryType) { }

	[Extension]
	public static bool IsCategoryTypeBodyCategory(DogCategoryType categoryType) { }

	[Extension]
	public static bool IsChangeable(DogCategoryType categoryType) { }

	[Extension]
	public static bool IsDeletable(DogCategoryType categoryType) { }

	[Extension]
	public static bool IsParentCategory(DogCategoryType categoryType) { }

	[Extension]
	public static bool IsSisterCategoriesUnderSameSlot(DogCategoryType categoryType) { }

	[Extension]
	public static bool IsUsingBreed(DogCategoryType categoryType) { }

	[Extension]
	public static bool ShouldUseSUTSystem(DogCategoryType categoryType) { }

}

