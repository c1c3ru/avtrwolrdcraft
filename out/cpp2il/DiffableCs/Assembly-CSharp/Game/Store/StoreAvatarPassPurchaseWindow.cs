namespace Game.Store;

public class StoreAvatarPassPurchaseWindow : StoreCurrencyRelatedWindowBase
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<Item> <>9__24_0; //Field offset: 0x8
		public static Action<StoreClaimItemCloudResponse> <>9__29_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal bool <Init>b__24_0(Item x) { }

		internal void <OnCTAClick>b__29_0(StoreClaimItemCloudResponse response) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass24_0
	{
		public bool isOpenFromAutoPopup; //Field offset: 0x10
		public StoreAvatarPassPurchaseWindow <>4__this; //Field offset: 0x18

		public <>c__DisplayClass24_0() { }

		internal void <Init>b__1(StoreAvatarPassNextRewardStatusCloudResponse response) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass25_0
	{
		public Item rewardItem; //Field offset: 0x10
		public StoreAvatarPassPurchaseWindow <>4__this; //Field offset: 0x18

		public <>c__DisplayClass25_0() { }

		internal void <ClaimReward>b__0(StoreClaimItemCloudResponse response) { }

	}

	public static Action OnCTAClickAction; //Field offset: 0x0
	public static Action OnBeforeClaimRewardAction; //Field offset: 0x8
	[CompilerGenerated]
	private static StoreAvatarPassPurchaseWindow <Instance>k__BackingField; //Field offset: 0x10
	[SerializeField]
	private Text _priceText; //Field offset: 0x30
	[SerializeField]
	private GameObject _ctaButton; //Field offset: 0x38
	[SerializeField]
	private GameObject _activePassInsteadOfCTAButton; //Field offset: 0x40
	[SerializeField]
	private GameObject _activeTag; //Field offset: 0x48
	[SerializeField]
	private Sprite _normalCtaSprite; //Field offset: 0x50
	[SerializeField]
	private Sprite _pandingCtaSprite; //Field offset: 0x58
	[SerializeField]
	private StorePazuCurrencyViewer _pazuCurrencyViewer; //Field offset: 0x60
	[SerializeField]
	private StoreAvatarPassStatusViewer _passStatusViewer; //Field offset: 0x68
	[SerializeField]
	private StarsPassBarManager _passStarsBar; //Field offset: 0x70
	private Item _itemData; //Field offset: 0x78
	private bool _isPending; //Field offset: 0x80

	public private static StoreAvatarPassPurchaseWindow Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public StoreAvatarPassPurchaseWindow() { }

	public void AnimatePassStarsBar() { }

	protected virtual void Awake() { }

	public void BaselinePassStarsBar() { }

	private void ClaimReward(Item rewardItem) { }

	[CompilerGenerated]
	public static StoreAvatarPassPurchaseWindow get_Instance() { }

	public void Init(bool isOpenFromAutoPopup) { }

	public bool IsVisible() { }

	public void OnBackButtonClick() { }

	public void OnCTAClick() { }

	protected virtual void OnCurrencyBalanceChangedPostClaim() { }

	protected virtual void OnDestroy() { }

	private void OnEnable() { }

	private void OnIAPEnded(IAPResult result) { }

	public void OnPrivacyPolicyClick() { }

	public void OnRestorePurchaseClick() { }

	public void OnTermOfUseClick() { }

	[CompilerGenerated]
	private static void set_Instance(StoreAvatarPassPurchaseWindow value) { }

	private void SetPriceText() { }

	public static void Show(bool isOpenFromAutoPopup = false) { }

	public void SyncText() { }

	private void UpdatePandingPurchaseUI(string productId) { }

}

