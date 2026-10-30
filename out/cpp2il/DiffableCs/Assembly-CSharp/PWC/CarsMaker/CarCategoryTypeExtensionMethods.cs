namespace PWC.CarsMaker;

[Extension]
public static class CarCategoryTypeExtensionMethods
{

	[Extension]
	public static bool CoversTheHalf(CarFullStickerCoverage coverage, CarCategoryType half) { }

	[Extension]
	public static bool DoesConflictStand(CarFullStickerCoverage coverage, CarCategoryType categoryType, CarCategoryType conflictingCategoryType) { }

	[Extension]
	public static CarCategoryType GetArtCategory(CarCategoryType categoryType) { }

	[Extension]
	public static string GetArtCategoryName(CarCategoryType categoryType) { }

	[Extension]
	public static List<Int32> GetCategoryTypesOfSameSlot(CarCategoryType categoryType) { }

	[Extension]
	public static PWSpriteColorType GetColorBlend(CarCategoryType categoryType) { }

	[Extension]
	public static int GetColorSlotsCount(CarCategoryType categoryType) { }

	[Extension]
	public static List<CarCategoryType> GetConflictingCategories(CarCategoryType categoryType) { }

	[Extension]
	public static List<CarCategoryType> GetParentAndSisterCategories(CarCategoryType categoryType) { }

	[Extension]
	public static CarCategoryType GetParentCategory(CarCategoryType categoryType) { }

	[Extension]
	public static List<CarCategoryType> GetSubCategories(CarCategoryType categoryType) { }

	[Extension]
	public static bool IsColorOnly(CarCategoryType categoryType) { }

	[Extension]
	public static bool IsParentCategory(CarCategoryType categoryType) { }

	[Extension]
	public static bool IsRemovable(CarCategoryType categoryType) { }

	[Extension]
	public static bool IsSticker(CarCategoryType categoryType) { }

	[Extension]
	public static bool IsSubcategory(CarCategoryType categoryType) { }

	[Extension]
	public static bool IsTiled(CarCategoryType categoryType) { }

	[Extension]
	public static bool ReplacesPartSprite(CarCategoryType categoryType) { }

	[Extension]
	public static bool UsesColorableMarker(CarCategoryType categoryType) { }

}

