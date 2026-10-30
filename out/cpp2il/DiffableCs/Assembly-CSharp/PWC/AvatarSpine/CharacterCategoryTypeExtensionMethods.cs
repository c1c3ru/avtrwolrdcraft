namespace PWC.AvatarSpine;

[Extension]
public static class CharacterCategoryTypeExtensionMethods
{
	[CompilerGenerated]
	private struct <>c__DisplayClass17_0
	{
		public List<Int32> categoryTypesOfSameSlot; //Field offset: 0x0

	}


	[CompilerGenerated]
	internal static void <GetCategoryTypesOfSameSlot>g__AddCategoryType|17_1(int categoryTypeToAdd, ref <>c__DisplayClass17_0 unnamed_param_1) { }

	[CompilerGenerated]
	internal static void <GetCategoryTypesOfSameSlot>g__AddFamilyOf|17_0(CharacterCategoryType parentCategoryType, ref <>c__DisplayClass17_0 unnamed_param_1) { }

	public static int CountAccessoriesSubCategories(List<Int32> categoryTypes) { }

	[Extension]
	public static List<Int32> GetCategoryTypesOfSameSlot(CharacterCategoryType categoryType) { }

	[Extension]
	public static List<CharacterCategoryType> GetHiddenCategories(CharacterCategoryType categoryType) { }

	[Extension]
	public static void GetMaterialConfig(CharacterCategoryType categoryType, string skinName, bool isColorable, out AvatarSpineColoringConfig coloringConfig) { }

	[Extension]
	public static List<CharacterCategoryType> GetParentAndSisterCategories(CharacterCategoryType categoryType) { }

	[Extension]
	public static CharacterCategoryType GetParentCategory(CharacterCategoryType categoryType) { }

	[Extension]
	public static CharacterCategoryType GetParentColorCategory(CharacterCategoryType categoryType) { }

	[Extension]
	public static List<CharacterCategoryType> GetSisterCategories(CharacterCategoryType categoryType, bool excludeSelfFromList) { }

	[Extension]
	public static CharacterCategoryType GetSUTSystemCategoryKey(CharacterCategoryType categoryType) { }

	[Extension]
	private static bool isAccessoryBody(CharacterCategoryType categoryType) { }

	[Extension]
	private static bool isAccessoryFace(CharacterCategoryType categoryType) { }

	[Extension]
	public static bool IsCategoryTypeBodyCategory(CharacterCategoryType categoryType) { }

	[Extension]
	public static bool IsChangeable(CharacterCategoryType categoryType) { }

	[Extension]
	public static bool IsDeletable(CharacterCategoryType categoryType) { }

	[Extension]
	public static bool IsParentCategory(CharacterCategoryType categoryType, bool includeSubCategory = false) { }

	[Extension]
	public static bool IsSisterCategoriesUnderSameSlot(CharacterCategoryType categoryType) { }

	[Extension]
	public static bool IsSubcategory(CharacterCategoryType categoryType) { }

	[Extension]
	public static bool ShouldUseSUTSystem(CharacterCategoryType categoryType) { }

}

