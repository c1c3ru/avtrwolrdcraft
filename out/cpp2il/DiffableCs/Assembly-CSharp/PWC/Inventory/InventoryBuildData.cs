namespace PWC.Inventory;

[CreateAssetMenu(fileName = "InventoryBuildData", menuName = "AvatarWorld/Inventory/Inventory Build Data")]
public class InventoryBuildData : ScriptableObject, ISerializationCallbackReceiver
{
	internal class PacksToItemsMap
	{
		internal class Pack
		{
			public string guid; //Field offset: 0x10
			public List<String> items; //Field offset: 0x18

			public Pack() { }

		}

		public List<Pack> packs; //Field offset: 0x10

		public PacksToItemsMap() { }

	}

	public PacksToItemsMap packToItems; //Field offset: 0x18
	private Dictionary<String, HashSet`1<String>> _hashedPacksToItemsMap; //Field offset: 0x20
	private Dictionary<String, String> _hashedItemsToPackGuid; //Field offset: 0x28

	public IReadOnlyDictionary<String, HashSet`1<String>> HashedPacksToItemsMap
	{
		 get { } //Length: 8
	}

	public InventoryBuildData() { }

	public bool ContainsItem(string prefabGuid) { }

	private void FillHashsedData() { }

	public IReadOnlyDictionary<String, HashSet`1<String>> get_HashedPacksToItemsMap() { }

	public bool TryGetPackItems(string prefabGuid, out HashSet<String>& items) { }

	public bool TryGetPackPrefabGuid(string itemPrefabGuid, out string packPrefabGuid) { }

	private override void UnityEngine.ISerializationCallbackReceiver.OnAfterDeserialize() { }

	private override void UnityEngine.ISerializationCallbackReceiver.OnBeforeSerialize() { }

}

