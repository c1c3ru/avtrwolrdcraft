namespace Game.Store;

public class StoreData
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<Int32> <>9__26_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <RemoveItemFromGroup>b__26_0(int item) { }

	}

	internal class Group
	{
		internal enum SpacingType
		{
			None = 0,
			Default = 1,
			Narrow = 2,
		}

		public string key; //Field offset: 0x10
		public List<ItemsLayoutGroup> items; //Field offset: 0x18
		public List<String> groups; //Field offset: 0x20
		public SpacingType spacingType; //Field offset: 0x28

		public Group() { }

	}

	internal class Item
	{
		internal class Discount
		{
			public string text; //Field offset: 0x10
			public string discountPercentage; //Field offset: 0x18
			public string originalPrice; //Field offset: 0x20

			public Discount() { }

			public bool IsValid() { }

		}

		internal class Entitlements
		{
			public int pazuCurrency; //Field offset: 0x10
			public int loyaltyPoints; //Field offset: 0x14

			public Entitlements() { }

		}

		internal enum ItemContentType
		{
			None = 0,
			Default = 1,
			Bundle = 2,
			Link = 3,
			AvatarPass = 4,
			Currency = 5,
			LinkToStoreCategory = 6,
		}

		internal enum ItemStateType
		{
			None = 0,
			Claimable = 1,
			Claimed = 2,
			RequireUpdate = 3,
			ComingSoon = 4,
			LinkToPack = 5,
			SuggestAvatarPass = 6,
			ShowAvatarPass = 7,
			RequireAvatarID = 8,
		}

		internal enum PurchaseMethodType
		{
			None = 0,
			PazuCurrency = 1,
			RealMoney = 2,
		}

		internal class Window
		{
			public string videoUrl; //Field offset: 0x10

			public Window() { }

		}

		public const string LAST_LOCAL_PRICE = "GameStore_StoreDataItem_LastLocalPrice_"; //Field offset: 0x0
		public const string LAST_SYMBOL = "GameStore_StoreDataItem_Symbol_"; //Field offset: 0x0
		public const string LAST_CURENCY_CODE = "GameStore_StoreDataItem_CurrencyCode_"; //Field offset: 0x0
		public string name; //Field offset: 0x10
		public string itemGuid; //Field offset: 0x18
		public ItemStateType itemStateType; //Field offset: 0x20
		public ItemContentType itemContentType; //Field offset: 0x24
		public string productName; //Field offset: 0x28
		public bool hasParent; //Field offset: 0x30
		public int parentItemIndex; //Field offset: 0x34
		public PurchaseMethodType purchaseMethodType; //Field offset: 0x38
		public Window window; //Field offset: 0x40
		public long durationUntilAvailableMs; //Field offset: 0x48
		public ItemStateType itemStateTypeOnAvailable; //Field offset: 0x50
		public string preProductPrice; //Field offset: 0x58
		public bool isIncludedInAvatarPass; //Field offset: 0x60
		public bool isFree; //Field offset: 0x61
		public bool isInInventory; //Field offset: 0x62
		public bool isRevealRequired; //Field offset: 0x63
		public int pazuCurrencyPrice; //Field offset: 0x64
		public Entitlements entitlements; //Field offset: 0x68
		public string badge; //Field offset: 0x70
		public string offerText; //Field offset: 0x78
		public Discount discount; //Field offset: 0x80
		public string categoryName; //Field offset: 0x88
		public Group bundleItems; //Field offset: 0x90

		public Item() { }

		public bool IsPartOfBundle() { }

		public bool IsRequirePurchase() { }

		public bool IsRequireRealMoneyPurchase() { }

		public bool ShouldLinkToBundle() { }

	}

	internal class ItemsLayoutGroup
	{
		public LayoutType layoutType; //Field offset: 0x10
		public List<Int32> items; //Field offset: 0x18

		public ItemsLayoutGroup() { }

	}

	internal enum LayoutType
	{
		None = 0,
		Default = 1,
		TopSmallAndBottomSmall = 2,
		TopTwoSmallAndBottomWide = 3,
		TopWideAndBottomTwoSmall = 4,
		TopWideAndBottomWide = 5,
	}

	internal class Scene
	{
		public string scene; //Field offset: 0x10
		public List<Int32> items; //Field offset: 0x18

		public Scene() { }

	}

	public string defaultGroupKey; //Field offset: 0x10
	public List<Group> groups; //Field offset: 0x18
	public List<Item> items; //Field offset: 0x20
	public List<Int32> worldSceneWidgets; //Field offset: 0x28
	public List<Int32> homeSceneWidgets; //Field offset: 0x30
	public List<Int32> worldSceneWidgets2; //Field offset: 0x38
	public List<Scene> scenes; //Field offset: 0x40
	public bool isAvatarPassEnabled; //Field offset: 0x48
	public bool isAvatarPassSubscriptionActive; //Field offset: 0x49
	public Group currencyPacksWindowGroup; //Field offset: 0x50
	public int avatarPassCurrecnyReward; //Field offset: 0x58
	public List<LoyaltyPassMilestone> loyaltyPass; //Field offset: 0x60
	public List<Int32> overrideAllScenesWithItems; //Field offset: 0x68
	private HashSet<String> _subgroups; //Field offset: 0x70
	private Dictionary<String, Int32> _groupIndexes; //Field offset: 0x78
	private Dictionary<String, Scene> _scenes; //Field offset: 0x80
	private Dictionary<String, Int32> _packFocusIndexes; //Field offset: 0x88

	public StoreData() { }

	private Dictionary<String, Int32> BuildPackFocusIndexes() { }

	private HashSet<Int32> GetListedItemIndexes() { }

	private bool IsBundleTile(Item item) { }

	public bool IsSubgroup(string groupKey) { }

	private static void RemoveItemFromGroup(Group group, int itemIndex) { }

	public void RemoveItemFromGroups(int itemIndex) { }

	public bool TryGetGroupIndex(string groupKey, out int groupIndex) { }

	public bool TryGetPackFocusIndex(string packName, out int itemIndex) { }

	public bool TryGetScene(string sceneName, out Scene sceneData) { }

}

