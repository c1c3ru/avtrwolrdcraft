namespace PWC.CarsMaker;

public static class CarPartsLoader
{
	public const string PARTS_RESOURCES_PATH = "CarsMaker/Parts/"; //Field offset: 0x0
	public const string COMMON_PARTS_FOLDER = "Common_Parts"; //Field offset: 0x0
	private const string COLORABLE_MARKER = "_Color"; //Field offset: 0x0
	private static readonly Dictionary<String, Sprite> _spritesBySkinName; //Field offset: 0x0
	private static readonly Dictionary<String, Texture2D> _tilesBySkinName; //Field offset: 0x8
	private static CarPartsIndex _index; //Field offset: 0x10
	private static bool _didTryLoadIndex; //Field offset: 0x18

	private static CarPartsLoader() { }

	public static void ClearCache() { }

	public static void ClearLoadedParts() { }

	private static string GetResourcePath(string skinName) { }

	public static void GetSkinNames(string categoryName, List<String> skinNames) { }

	public static Sprite GetSprite(string skinName) { }

	public static bool IsColorableSkinName(string skinName) { }

	public static Sprite ResolvePart(string skinName, bool isRequired) { }

	private static bool TryGetIndex(out CarPartsIndex index) { }

	public static bool TryGetSprite(string skinName, out Sprite sprite) { }

	private static bool TryGetSprite(string skinName, bool logIfMissing, out Sprite sprite) { }

	public static bool TryGetTile(string skinName, out Texture2D tile) { }

}

