namespace Game.Store;

public class StorePackGiftCurrencyItemHandler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<StorePackItemBase> <>9__7_2; //Field offset: 0x8
		public static Action <>9__8_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal void <OnAvatarIDCTAClick>b__7_2(StorePackItemBase focusedItem) { }

		internal void <OnClaimSuccess>b__8_0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		public string packName; //Field offset: 0x10
		public Action <>9__1; //Field offset: 0x18

		public <>c__DisplayClass7_0() { }

		internal void <OnAvatarIDCTAClick>b__0() { }

		internal void <OnAvatarIDCTAClick>b__1() { }

	}

	[SerializeField]
	private TextMeshProUGUI _currencyText; //Field offset: 0x20
	[SerializeField]
	private GameObject _claimButton; //Field offset: 0x28
	private StorePackItem _packItem; //Field offset: 0x30

	public StorePackGiftCurrencyItemHandler() { }

	private void Awake() { }

	private void OnAvatarIDCTAClick() { }

	private void OnClaimSuccess(StoreClaimItemCloudResponse response) { }

	private void OnDestroy() { }

	private void OnItemSyncView(StorePackItem item) { }

	private bool TryOverrideClickAction(StorePackItemBase _) { }

}

