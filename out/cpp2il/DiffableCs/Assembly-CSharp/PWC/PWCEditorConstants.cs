namespace PWC;

public static class PWCEditorConstants
{
	public const string BAD_ASSET_NAME_REGEX = "^_|\W|^\d|^[a-z]|(_[^A-Z0-9_])|(_$)|[^\x00-\x7F]"; //Field offset: 0x0
	public const string ALL_PROPERTIES = "__ALL_PROPERTIES__"; //Field offset: 0x0
	public const string GUID = "\w{8}-\w{4}-\w{4}-\w{4}-\w{12}"; //Field offset: 0x0
	public const string GUID_IN_ASSET = "\w{8}-\w{4}-\w{4}-\w{4}-\w{12}$"; //Field offset: 0x0
	public const string CLOTHING_BASE_PREFAB_PREFIX = "Clothing_"; //Field offset: 0x0
	public const string SCOPE_WITHOUT_STATE = "(_)([A-Z]+\d+)"; //Field offset: 0x0
	public const string SCOPE = "(_)([A-Z]+\d+)(__|$)"; //Field offset: 0x0
	public const string PTLPB_PREFIX = "PTLPB_"; //Field offset: 0x0
	public const string SHOP_PACKS_PREFABS_PATH = "Assets/Game/General/Resources/Level/CrossItems/10_Shop_Packs/"; //Field offset: 0x0
	public const string UGC_EXTERIOR_PREFABS_PATH = "Assets/Game/General/Resources/Level/UGCItems/"; //Field offset: 0x0
	public const string BWYW_GIFTS_PREFABS_PATH = "Assets/Game/General/Resources/Level/CrossItems/13_BWYW"; //Field offset: 0x0
	public const string LEVELS_PREFABS_PATH = "Assets/Game/General/Resources/Level/SceneItems/"; //Field offset: 0x0

}

