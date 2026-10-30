namespace PWC.AvatarSpine;

public static class AvatarSpineDefaultColors
{
	private static Dictionary<CharacterCategoryType, Color[]> _defaultCharacterColorsByCategoryType; //Field offset: 0x0
	private static Dictionary<BabyCategoryType, Color[]> _defaultBabyColorsByCategoryType; //Field offset: 0x8
	private static Dictionary<ToddlerCategoryType, Color[]> _defaultToddlerColorsByCategoryType; //Field offset: 0x10
	private static Dictionary<DogCategoryType, Color[]> _defaultDogColorsByCategoryType; //Field offset: 0x18
	private static Dictionary<CatCategoryType, Color[]> _defaultCatColorsByCategoryType; //Field offset: 0x20
	private static Dictionary<HorseCategoryType, Color[]> _defaultHorseColorsByCategoryType; //Field offset: 0x28

	private static AvatarSpineDefaultColors() { }

	public static Color[] GetDefaultColors(SpineType spineType, int categoryType) { }

}

