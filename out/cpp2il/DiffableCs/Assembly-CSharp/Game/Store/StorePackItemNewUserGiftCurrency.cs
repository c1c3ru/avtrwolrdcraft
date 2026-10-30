namespace Game.Store;

public class StorePackItemNewUserGiftCurrency : StorePackItemBase
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action <>9__3_3; //Field offset: 0x8
		public static Action <>9__5_5; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal void <OnAvatarIDCTAClick>b__5_5() { }

		internal void <OnClickWhileClaimable>b__3_3() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public StorePackItemBase focusedItem; //Field offset: 0x10
		public StorePackItemNewUserGiftCurrency <>4__this; //Field offset: 0x18
		public Action <>9__4; //Field offset: 0x20

		public <>c__DisplayClass5_0() { }

		internal void <OnAvatarIDCTAClick>b__3(StoreClaimItemCloudResponse response) { }

		internal void <OnAvatarIDCTAClick>b__4() { }

	}

	[SerializeField]
	private TextMeshProUGUI _currencyText; //Field offset: 0x38
	[SerializeField]
	private GameObject _claimButton; //Field offset: 0x40
	private bool _isClaimingInProgress; //Field offset: 0x48

	public StorePackItemNewUserGiftCurrency() { }

	[CompilerGenerated]
	private void <OnAvatarIDCTAClick>b__5_0() { }

	[CompilerGenerated]
	private void <OnAvatarIDCTAClick>b__5_1() { }

	[CompilerGenerated]
	private void <OnAvatarIDCTAClick>b__5_2(StorePackItemBase focusedItem) { }

	[CompilerGenerated]
	private void <OnClickWhileClaimable>b__3_0(StoreClaimItemCloudResponse response) { }

	[CompilerGenerated]
	private void <OnClickWhileClaimable>b__3_1() { }

	[CompilerGenerated]
	private void <OnClickWhileClaimable>b__3_2() { }

	public virtual void Init(Item itemData) { }

	private void OnAvatarIDCTAClick() { }

	protected virtual void OnClickWhileClaimable() { }

	protected virtual void OnClickWhileRequireAvatarID() { }

}

