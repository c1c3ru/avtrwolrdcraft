namespace Store.Level;

[CreateAssetMenu(menuName = "AvatarWorld/Level/Store Pack Map")]
public class LevelStorePackMap : ScriptableObject
{
	internal class Item
	{
		public StorePackType storePackType; //Field offset: 0x10
		public string prefabGuid; //Field offset: 0x18
		public PDTextBulkData bulkData; //Field offset: 0x20

		public Item() { }

	}

	private static LevelStorePackMap _instance; //Field offset: 0x0
	public List<Item> items; //Field offset: 0x18
	private Dictionary<StorePackType, Item> _hashedItems; //Field offset: 0x20

	public LevelStorePackMap() { }

	public static LevelStorePackMap Get() { }

	public static bool TryGetPrefabGuidForStorePackType(StorePackType storePackType, out Item item) { }

	private bool TryGetPrefabGuidForStorePackTypeImplement(StorePackType storePackType, out Item item) { }

}

