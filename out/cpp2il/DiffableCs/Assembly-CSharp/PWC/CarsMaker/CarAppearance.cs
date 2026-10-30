namespace PWC.CarsMaker;

public static class CarAppearance
{
	public const string BREEDS_RESOURCES_PATH = "CarsMaker/Breeds/"; //Field offset: 0x0
	public const string BREED_PREFIX = "CM"; //Field offset: 0x0
	public const string DEFAULT_BREED = "CM03"; //Field offset: 0x0
	[CompilerGenerated]
	private static string <BreedForNewCar>k__BackingField; //Field offset: 0x0
	public const string BREED_ICONS_RESOURCES_PATH = "CarsMaker/BreedIcons/"; //Field offset: 0x0
	private static readonly Dictionary<String, Sprite> _iconsByBreed; //Field offset: 0x8

	public static string BreedForNewCar
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		 set { } //Length: 104
	}

	private static CarAppearance() { }

	public static void Apply(CarView carView, AvatarSpineData data) { }

	private static void ApplyPart(CarView carView, CarCategoryType categoryType, string skinName) { }

	public static void ApplySlot(CarView carView, CarCategoryType categoryType, string skinName, Color[] colors) { }

	public static void ClearIconCache() { }

	public static void ClearSlot(CarView carView, CarCategoryType categoryType) { }

	public static string ConsumeBreedForNewCar() { }

	[CompilerGenerated]
	public static string get_BreedForNewCar() { }

	public static string GetBreedFromThumbName(string thumbName) { }

	public static Sprite GetBreedIcon(int carId) { }

	public static string GetUsableBreed(string breed) { }

	public static bool IsBreedOwned(string breed) { }

	private static void ReportRefusedBreed(string breed) { }

	[CompilerGenerated]
	public static void set_BreedForNewCar(string value) { }

	private static void StripLevelOnlyComponents(GameObject instance) { }

	public static bool TryCreateVisual(string breed, Transform parent, out GameObject instance, out CarView carView) { }

	public static bool TryGetBreed(int carId, out string breed) { }

	public static bool TryGetBreed(AvatarSpineData data, out string breed) { }

	public static bool TryGetBreedColors(int carId, out Color[] colors) { }

	public static bool TryGetCarData(int carId, out AvatarSpineData data) { }

}

