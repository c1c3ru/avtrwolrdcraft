namespace Game.Store;

public static class StoreUtils
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<StorePackItemBase> <>9__23_1; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <ShowStoreAndOpenPack>b__23_1(StorePackItemBase focusedItem) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass23_0
	{
		public Func<Int32> getFocusIndex; //Field offset: 0x10

		public <>c__DisplayClass23_0() { }

		internal void <ShowStoreAndOpenPack>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass25_0
	{
		public string packName; //Field offset: 0x10

		public <>c__DisplayClass25_0() { }

		internal bool <TryGetPackItemIndex>b__0(Item x) { }

	}

	public const string STORE_PACK_WINDOW_BACKGROUND_PATH = "Store/LevelPrefabs/LevelStorePackItemWindowBackground"; //Field offset: 0x0
	private const float WIDGET_COVER_SCALE = 0,37246; //Field offset: 0x0
	private const float WIDGET_PACK_ITEM_SCALE = 0,5; //Field offset: 0x0
	private static readonly Vector2 _widgetCoverPosition; //Field offset: 0x0
	private static readonly Vector2 _widgetPackItemPosition; //Field offset: 0x8

	private static StoreUtils() { }

	public static bool CanPurchaseUsingCurrency(Item itemData, out int missingCurrencyAmount) { }

	public static string GetItemPartOfBundleSpriteResourcesPath(Item itemData) { }

	public static StorePackItemBase GetPackItemPrefab(Item packItemData, bool isSilent = false) { }

	public static StorePackItemWindow GetPackItemWindowPrefab(Item dataItem, bool isSilent = false) { }

	public static string GetSourceValueForClaimCloudRequests() { }

	public static Sprite GetWidgetSprite(Item item) { }

	public static Sprite GetWidgetSprite(string packName) { }

	public static Sprite GetWidgetSprite(StorePackType storePackType) { }

	public static bool IsStoreScene(string sceneName) { }

	public static StorePackItemWindow ShowPackItemWindow(StorePackItem packItem, Transform parent) { }

	public static void ShowStoreAndFocusOnAvatarPassGiftsCategory() { }

	public static void ShowStoreAndFocusOnGiftsCategory() { }

	public static void ShowStoreAndOpenPack(Func<Int32> getFocusIndex) { }

	public static void SpawnStorePackItemsInGroup(StoreData storeData, Group group, Transform parent, ref List<MonoBehaviour>& spawnedItems, GameObject context, bool skipHiddenHolidayPacks = false) { }

	public static bool TryGetKittyBankItemIndex(out int itemIndex) { }

	public static bool TryGetNewUserGiftItemIndex(out int itemIndex) { }

	public static bool TryGetPackCoverSprite(Item itemData, out Sprite coverSprite) { }

	public static bool TryGetPackItemIndex(StorePackType storePackType, out int itemIndex) { }

	public static bool TryGetPackItemIndex(string packName, out int itemIndex) { }

	public static bool TryGetPackNameFromPrefabGuidInItemsMenu(string prefabGuid, out string packName, DataType dataType) { }

	public static bool TrySetPackWidgetImage(Item itemData, Image image) { }

	public static bool TryShowStoreAndFocusOnCategory(string categoryName, bool shouldTryRequirePurchaseFirst = false) { }

}

