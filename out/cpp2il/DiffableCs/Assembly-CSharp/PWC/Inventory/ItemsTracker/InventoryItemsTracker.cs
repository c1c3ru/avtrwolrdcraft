namespace PWC.Inventory.ItemsTracker;

public class InventoryItemsTracker
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_0
	{
		public string prefabGuid; //Field offset: 0x10

		public <>c__DisplayClass3_0() { }

		internal bool <TryGetItemsByPrefabGuid>b__0(Item item) { }

	}

	internal class ItemsState : ISerializationCallbackReceiver
	{
		[CompilerGenerated]
		private sealed class <>c__DisplayClass15_0
		{
			public HashSet<String> sceneGuids; //Field offset: 0x10

			public <>c__DisplayClass15_0() { }

			internal bool <DeleteSceneGuidsFromState>b__0(Item item) { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass16_0
		{
			public HashSet<String> prefabGuids; //Field offset: 0x10

			public <>c__DisplayClass16_0() { }

			internal bool <DeletePrefabGuidsFromState>b__0(Item item) { }

		}

		internal class Item
		{
			public string sceneGuid; //Field offset: 0x10
			public string prefabGuid; //Field offset: 0x18
			public string sceneName; //Field offset: 0x20
			public Vector2 position; //Field offset: 0x28
			public PDPrefabPDSnapshot pdSnapshot; //Field offset: 0x30

			public Item() { }

		}

		public List<Item> items; //Field offset: 0x10
		public List<Item> itemsToRestore; //Field offset: 0x18
		private readonly Dictionary<String, Item> _hashedItems; //Field offset: 0x20
		private readonly Dictionary<String, Dictionary`2<String, Item>> _itemsToRestoreForScenes; //Field offset: 0x28
		[CompilerGenerated]
		private bool <IsDirty>k__BackingField; //Field offset: 0x30

		public bool IsDirty
		{
			[CompilerGenerated]
			 get { } //Length: 8
			[CompilerGenerated]
			 set { } //Length: 12
		}

		public ItemsState() { }

		public void ClearSceneRestoreData(string sceneName) { }

		public bool ContainsSceneGuid(string sceneGuid) { }

		public void DeleteItemsFromState(Predicate<Item> predicate) { }

		public void DeletePrefabGuidsFromState(HashSet<String> prefabGuids) { }

		public void DeleteSceneGuidsFromState(HashSet<String> sceneGuids) { }

		private void FillHashedValues() { }

		[CompilerGenerated]
		public bool get_IsDirty() { }

		[CompilerGenerated]
		public void set_IsDirty(bool value) { }

		public void SetItemData(Item item) { }

		public void SetItemToBeRestored(string sceneGuid) { }

		public bool TryGetSceneRestoreData(string sceneName, out List<Item>& resultItems) { }

		private override void UnityEngine.ISerializationCallbackReceiver.OnAfterDeserialize() { }

		private override void UnityEngine.ISerializationCallbackReceiver.OnBeforeSerialize() { }

	}

	public const string STATE_KEY = "PWCInventoryItemsTracker_State"; //Field offset: 0x0
	private ItemsState _itemsState; //Field offset: 0x10

	public InventoryItemsTracker() { }

	public void AddItemToRestore(string sceneGuid) { }

	public void ClearRestoreData(string sceneName) { }

	public void DeletePrefabGuidsFromState(HashSet<String> prefabGuids) { }

	public void DeleteSceneGuidsFromState(HashSet<String> sceneGuids) { }

	public void DeleteState() { }

	public bool IsTrackingSceneGuid(string sceneGuid) { }

	public void LoadState() { }

	private void MigrateStateFileIfNeeded() { }

	public void SaveStateIfNeeded() { }

	public void SetItemState(string sceneGuid, PDPrefab pdPRefab, string sceneName, Vector2 position) { }

	public bool TryGetItemsByPrefabGuid(string prefabGuid, out List<Item>& items) { }

	public bool TryGetItemsToRestoreForScene(string sceneName, out List<Item>& items) { }

}

