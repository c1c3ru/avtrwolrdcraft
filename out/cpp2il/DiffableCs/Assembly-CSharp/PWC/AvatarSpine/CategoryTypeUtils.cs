namespace PWC.AvatarSpine;

public static class CategoryTypeUtils
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Converter<CharacterCategoryType, Int32> <>9__28_0; //Field offset: 0x8
		public static Converter<BabyCategoryType, Int32> <>9__28_1; //Field offset: 0x10
		public static Converter<ToddlerCategoryType, Int32> <>9__28_2; //Field offset: 0x18
		public static Converter<CarCategoryType, Int32> <>9__28_3; //Field offset: 0x20

		private static <>c() { }

		public <>c() { }

		internal int <GetParentAndSisterCategories>b__28_0(CharacterCategoryType x) { }

		internal int <GetParentAndSisterCategories>b__28_1(BabyCategoryType x) { }

		internal int <GetParentAndSisterCategories>b__28_2(ToddlerCategoryType x) { }

		internal int <GetParentAndSisterCategories>b__28_3(CarCategoryType x) { }

	}


	public static int GetArtCategoryType(SpineType spineType, int categoryType) { }

	public static int GetCategoryTypeBody(SpineType spineType) { }

	public static int GetCategoryTypeBodyOutline(SpineType spineType) { }

	public static int GetCategoryTypeBodyShadow(SpineType spineType) { }

	public static Nullable<Int32> GetCategoryTypeBreed(SpineType spineType) { }

	public static int GetCategoryTypeEarShadow(SpineType spineType) { }

	public static int GetCategoryTypeEyebrows(SpineType spineType) { }

	public static int GetCategoryTypeEyes(SpineType spineType) { }

	public static int GetCategoryTypeForClothing(SpineType spineType, int categoryType) { }

	public static int GetCategoryTypeFromClothingType(SpineType spineType, int clothingType) { }

	public static int GetCategoryTypeHairBack(SpineType spineType) { }

	public static int GetCategoryTypeHairFront(SpineType spineType) { }

	public static List<Int32> GetCategoryTypeHiddenCategories(SpineType spineType, int categoryType) { }

	public static int GetCategoryTypeMouth(SpineType spineType) { }

	public static string GetCategoryTypeName(SpineType spineType, int categoryType) { }

	public static int GetCategoryTypePattern(SpineType spineType) { }

	public static int GetCategoryTypePupils(SpineType spineType) { }

	public static int GetCategoryTypeSkin(SpineType spineType) { }

	public static List<Int32> GetCategoryTypesOfSameSlot(SpineType spineType, int categoryType) { }

	public static int GetCategoryTypeTail(SpineType spineType) { }

	public static string GetFoldedSuffix() { }

	public static string GetHangedSuffix() { }

	public static int GetLevelClothingType(SpineType spineType, int categoryType) { }

	public static void GetMaterialConfig(SpineType spineType, string skinName, int categoryType, bool isColorable, out AvatarSpineColoringConfig coloringConfig) { }

	public static List<Int32> GetParentAndSisterCategories(SpineType spineType, int categoryType) { }

	public static int GetParentCategoryType(SpineType spineType, int categoryType) { }

	public static string GetPrefabName(SpineType spineType, int categoryType) { }

	public static string GetSingleItemSuffix(SpineType spineType, int categoryType) { }

	public static List<Int32> GetSlotCategoryTypesOfArt(SpineType spineType, int artCategoryType) { }

	public static string GetSuffixForPremadeMaker(SpineType spineType, int categoryType) { }

	public static bool HasEyebrows(SpineType spineType) { }

	public static bool HasStates(SpineType spineType, int categoryType) { }

	public static bool IsCategoryTypeBodyCategory(SpineType spineType, int categoryType) { }

	public static bool IsCategoryTypeBreed(SpineType spineType, int categoryType) { }

	public static bool IsCategoryTypeDeletable(SpineType spineType, int categoryType) { }

	public static bool IsCategoryTypeEyes(SpineType spineType, int categoryType) { }

	public static bool IsCategoryTypeKind(SpineType spineType, int categoryType) { }

	public static bool IsCategoryTypeParentCategory(SpineType spineType, int categoryType) { }

	public static bool IsCategoryTypeSize(SpineType spineType, int categoryType) { }

	public static bool IsCategoryTypeSkin(SpineType spineType, int categoryType) { }

	public static bool IsCategoryTypeSubcategory(SpineType spineType, int categoryType) { }

	public static bool IsHangableSingleState(SpineType spineType, int categoryType) { }

	public static bool IsParentCategoryTypeLegs(SpineType spineType, int categoryType) { }

	public static bool IsUsingBreed(SpineType spineType, int categoryType) { }

	public static bool ShouldUseSUTSystem(SpineType spineType, int categoryType) { }

	public static bool TryGetCategorySizeType(SpineType spineType, out int categoryType) { }

	public static bool TryGetCategoryType(SpineType spineType, out Type type) { }

}

