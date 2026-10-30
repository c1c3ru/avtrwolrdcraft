namespace Game.Store;

public class StorePackKittyBankItem : StorePackItemBase
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action <>9__10_2; //Field offset: 0x8
		public static Action <>9__11_0; //Field offset: 0x10
		public static Action<StorePackItemBase> <>9__15_0; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal void <GoToStoreViewFocusAndTryClaim>b__15_0(StorePackItemBase focusedItem) { }

		internal void <OnAvatarIDCTAClick>b__11_0() { }

		internal void <TryClaim>b__10_2() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public Action<StorePackItemBase> onComplete; //Field offset: 0x10

		public <>c__DisplayClass9_0() { }

		internal void <GoToStoreViewFocusAndTryClaim_Internal>b__1() { }

		internal void <GoToStoreViewFocusAndTryClaim_Internal>g__OnFocus|0(StorePackItemBase focusedItem) { }

	}

	[SerializeField]
	private TextMeshProUGUI _text; //Field offset: 0x38
	[SerializeField]
	private GameObject _claimButton; //Field offset: 0x40
	public Action<StorePackKittyBankItem> OnEndInitAction; //Field offset: 0x48
	private bool _isInit; //Field offset: 0x50
	private bool _isClaimingInProgress; //Field offset: 0x51

	public bool IsInit
	{
		 get { } //Length: 8
	}

	public StorePackKittyBankItem() { }

	[CompilerGenerated]
	private void <Init>b__7_0(int x) { }

	[CompilerGenerated]
	private void <OnClickWhileClaimable>b__13_0(List<AWAAchievementWorth> achievements) { }

	[CompilerGenerated]
	private void <OnClickWhileClaimable>b__13_1() { }

	[CompilerGenerated]
	private void <TryClaim>b__10_0(List<AWAAchievementWorth> list) { }

	[CompilerGenerated]
	private void <TryClaim>b__10_1() { }

	public bool get_IsInit() { }

	public static void GoToStoreAndTryClaimPendingAchievements() { }

	private static void GoToStoreViewFocusAndTryClaim() { }

	public static void GoToStoreViewFocusAndTryClaim_Internal(Action<StorePackItemBase> onComplete) { }

	public virtual void Init(Item itemData) { }

	private void OnAvatarIDCTAClick() { }

	protected virtual void OnClickWhileClaimable() { }

	protected virtual void OnClickWhileRequireAvatarID() { }

	private static void OnKittyBankEndInit(StorePackKittyBankItem kittyBankItem) { }

	public void TryClaim() { }

}

