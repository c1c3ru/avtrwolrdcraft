namespace Game.Store;

public class StorePackItemCurrency : StorePackItemBase
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action <>9__6_2; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <OnClickWhileClaimable>b__6_2() { }

	}

	[SerializeField]
	private StorePackItemPriceViewer _priceViewer; //Field offset: 0x38
	[SerializeField]
	private StorePackItemOfferViewer _offerViewer; //Field offset: 0x40
	[SerializeField]
	private StorePackItemStarsViewer _starsViewer; //Field offset: 0x48
	[SerializeField]
	private TextMeshProUGUI _currencyText; //Field offset: 0x50
	[SerializeField]
	private Image _badge; //Field offset: 0x58
	[SerializeField]
	private TextMeshProUGUI _badgeText; //Field offset: 0x60

	public StorePackItemCurrency() { }

	[CompilerGenerated]
	private void <OnClickWhileClaimable>b__6_0(StoreClaimItemCloudResponse response) { }

	[CompilerGenerated]
	private void <OnClickWhileClaimable>b__6_1() { }

	public virtual void Init(Item itemData) { }

	protected virtual void OnClickWhileClaimable() { }

}

