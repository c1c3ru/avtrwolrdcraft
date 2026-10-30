namespace PWC.Game.Promotions;

public static class PromotionsConfigurationUtils
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<StorePackItemBase> <>9__16_3; //Field offset: 0x8
		public static Predicate<Group> <>9__20_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal bool <GetPromotionPopupCategory>b__20_0(Group x) { }

		internal void <TryShowBundlePopUpMessage>b__16_3(StorePackItemBase focusedItem) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass16_0
	{
		public Item packToSuggest; //Field offset: 0x10
		public bool isLinkToBundle; //Field offset: 0x18

		public <>c__DisplayClass16_0() { }

		internal void <TryShowBundlePopUpMessage>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass16_1
	{
		public Item storePack; //Field offset: 0x10

		public <>c__DisplayClass16_1() { }

		internal void <TryShowBundlePopUpMessage>b__2() { }

	}

	internal enum PromotionPopupType
	{
		None = 0,
		Pack = 1,
		Bundle = 2,
	}

	private static List<Item> _includedInPromotionList; //Field offset: 0x0
	private const string PROMOTION_POPUP_COOLDOWN_START_TIME_KEY = "PromotionPopUp_Cooldown_StartTime"; //Field offset: 0x0
	private const string PROMOTION_POPUP_COUNTER_KEY = "PromotionPopUp_Counter"; //Field offset: 0x0
	private const string PROMOTION_POPUP_TYPE_KEY = "PromotionPopUp_Type"; //Field offset: 0x0
	public const string PROMOTION_POPUP_CATEGORY_NAME = "PromotionPopUp"; //Field offset: 0x0
	private const string PROMOTION_POPUP_LAST_BUILD_NUMBER_KEY = "PromotionPopUp_LastBuildNumber"; //Field offset: 0x0
	private const float COOLDOWN_IN_HOURS = 0,5; //Field offset: 0x0
	private const float COOLDOWN_TIME = 1800; //Field offset: 0x0
	private const int MAX_NUMBER_OF_TIMES_TO_SHOW_POPUP = 2; //Field offset: 0x0
	public static bool IsPromotionPopUpContext; //Field offset: 0x8
	private static bool _isSuccessTryGetPromotionType; //Field offset: 0x9
	private static bool _useStarsPassPromo; //Field offset: 0xA
	private static PromotionPopupType _currentPromotionType; //Field offset: 0xC

	private static PromotionsConfigurationUtils() { }

	[CompilerGenerated]
	internal static void <TryShowBundlePopUpMessage>g__GoToPackPage|16_0(Item storePack, bool isBundle) { }

	public static void EnsureIncludedBundlesData() { }

	public static Item GetBestBundleNameToSuggest() { }

	private static int GetNumOfTimesShowedPopUp() { }

	public static Group GetPromotionPopupCategory() { }

	public static Sprite GetPromotionSpriteByName(string spriteName) { }

	public static int GetStorePromotionMode() { }

	public static bool HasAvailablePromotions(Group promotionPopUpCategory) { }

	private static bool IsCooldownEnded() { }

	private static void SetPopUpType(PromotionPopupType type) { }

	public static bool ShouldHidePromotionCategory(Group promotionPopUpCategory) { }

	public static void ShowBundlePopUpMessageIfNeeded(Transform transform) { }

	public static bool StoreManager_TryOverrideSourceValueForClaimCloudRequests(out string source) { }

	public static void TryShowBundlePopUpMessage(Transform transform, bool resetCooldown) { }

}

