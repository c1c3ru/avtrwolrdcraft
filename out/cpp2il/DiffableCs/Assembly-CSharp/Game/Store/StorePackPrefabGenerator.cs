namespace Game.Store;

public static class StorePackPrefabGenerator
{
	internal enum WindowLayoutType
	{
		None = 0,
		Layout1 = 1,
		Layout2 = 2,
	}

	public const string PACK_ART_RESOURCES_ROOT = "Store/PackArt/"; //Field offset: 0x0
	private static readonly Dictionary<String, StorePackWindowData> _windowDataByArtName; //Field offset: 0x0
	private const WindowLayoutType DEFAULT_WINDOW_LAYOUT_TYPE = 2; //Field offset: 0x0
	private const string TEMPLATES_PARENT_NAME = "StoreGeneratedPrefabTemplates"; //Field offset: 0x0
	private const string PACK_VIDEO_URL_EXTENSION = ".mp4"; //Field offset: 0x0
	private const string PACK_VIDEO_URL_ROOT = "https://awstore.pazudrive.com/"; //Field offset: 0x0
	private const int LAYOUT_1_MAX_ICONS_COUNT = 3; //Field offset: 0x0
	private const string TITLE_TEXT_CHILD_NAME = "TitleText"; //Field offset: 0x0
	private const string TITLE_BACKGROUND_CHILD_NAME = "TitleBackground"; //Field offset: 0x0
	private const string TITLE_CHILD_NAME = "Title"; //Field offset: 0x0
	private const string COVER_IMAGE_CHILD_NAME = "CoverImage"; //Field offset: 0x0
	private const string WINDOW_LAYOUT_2_BASE_PREFAB_NAME = "StorePackItemWindow_2_Base_ForGeneration"; //Field offset: 0x0
	private const string PACK_ITEM_BASE_PREFAB_NAME = "StorePackItem_Base_ForGeneration"; //Field offset: 0x0
	private const string BASE_PREFABS_RESOURCES_ROOT = "Store/Bases/"; //Field offset: 0x0
	public const string PACK_NAME_SUFFIX = "Pack"; //Field offset: 0x0
	public const string PACK_ITEM_WINDOW_NAME_PREFIX = "StorePackItemWindow_"; //Field offset: 0x0
	public const string PACK_ITEM_NAME_PREFIX = "StorePackItem_"; //Field offset: 0x0
	public const string COVER_ART_SUFFIX = "_Cover"; //Field offset: 0x0
	public const string PACK_ART_SUFFIX = "_Pack"; //Field offset: 0x0
	public const string PACK_ITEM_WINDOWS_RESOURCES_ROOT = "Store/PackItemWindows/"; //Field offset: 0x0
	public const string PACK_ITEMS_RESOURCES_ROOT = "Store/PackItems/"; //Field offset: 0x0
	public const string PACK_DATA_RESOURCES_ROOT = "Store/PackData/"; //Field offset: 0x0
	private const string WINDOW_LAYOUT_1_BASE_PREFAB_NAME = "StorePackItemWindow_1_Base_ForGeneration"; //Field offset: 0x0
	private static readonly Dictionary<String, StorePackItemBase> _generatedPackItems; //Field offset: 0x8
	private static readonly Dictionary<String, StorePackItemWindow> _generatedPackItemWindows; //Field offset: 0x10
	private static Transform _templatesParent; //Field offset: 0x18

	private static StorePackPrefabGenerator() { }

	private static void ApplyFallbackVideoUrl(Item itemData, string packName) { }

	private static void ApplyIcons(StorePackItemWindow template, string artName, StorePackWindowData windowData) { }

	private static void ApplyPackArt(Transform root, string childName, string artName, string suffix, bool shouldSetNativeSize, bool isRequired) { }

	private static void ApplySprite(Image image, Sprite sprite, bool shouldSetNativeSize) { }

	private static bool ApplyTitleBackgroundArt(Transform root, string artName, StorePackWindowData windowData) { }

	private static void ApplyTitleKey(Transform root, StorePackWindowData windowData) { }

	private static void ApplyTitleText(Transform root, string artName, StorePackWindowData windowData, bool hasTitleBackground) { }

	public static StorePackItemBase GeneratePackItem(Item itemData) { }

	public static StorePackItemWindow GeneratePackItemWindow(Item itemData) { }

	public static string GetArtName(string packName) { }

	public static string GetPackArtFilePath(string artName, string artFileName) { }

	public static string GetPackArtPath(string artName, string suffix) { }

	private static Transform GetTemplatesParent() { }

	public static string GetTitleText(string artName) { }

	private static string GetWindowBasePrefabName(WindowLayoutType layoutType) { }

	private static StorePackWindowData GetWindowData(string artName) { }

	public static string GetWindowDataPath(string artName) { }

	public static WindowLayoutType GetWindowLayoutType(StorePackWindowData windowData) { }

	private static T LoadBasePrefab(string prefabName) { }

	private static StorePackWindowData LoadWindowData(string artName) { }

	private static string RemoveTrailingPackCode(string artName) { }

	private static bool TryGetChildComponent(Transform root, string childName, out T component) { }

	private static bool TryGetPackName(Item itemData, out string packName) { }

	public static bool TryLoadCoverSprite(Item itemData, out Sprite sprite) { }

	private static bool TryLoadPackArt(string artName, string suffix, out Sprite sprite) { }

	private static bool TryLoadPackArtFile(string artName, string artFileName, out Sprite sprite) { }

}

