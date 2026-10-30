namespace Game.Store;

[CreateAssetMenu(menuName = "AvatarWorld/Store/Pack Icon Keys Map")]
public class StorePackIconKeysMap : ScriptableObject
{
	internal class Item
	{
		public string name; //Field offset: 0x10
		public string key; //Field offset: 0x18

		public Item() { }

	}

	public const string RESOURCES_PATH = "Store/StorePackIconKeysMap/StorePackIconKeysMap"; //Field offset: 0x0
	public const string ASSET_PATH = "Assets/Game/Store/Resources/Store/StorePackIconKeysMap/StorePackIconKeysMap.asset"; //Field offset: 0x0
	private static StorePackIconKeysMap _instance; //Field offset: 0x0
	public List<Item> items; //Field offset: 0x18
	private Dictionary<String, String> _keysByName; //Field offset: 0x20

	public StorePackIconKeysMap() { }

	public static StorePackIconKeysMap Get() { }

	public static bool TryGetKeyForName(string iconName, out string key) { }

	private bool TryGetKeyForNameImplement(string iconName, out string key) { }

}

