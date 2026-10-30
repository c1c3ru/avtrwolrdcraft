namespace StarsPass;

public class StarsPassCurrencyPackItem : StarsPassPackItem
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<StoreClaimItemCloudResponse> <>9__10_1; //Field offset: 0x8
		public static Action <>9__11_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal void <OnPackClaimed>b__10_1(StoreClaimItemCloudResponse x) { }

		internal void <PlayClaimAnimation>b__11_0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public StarsPassCurrencyPackItem <>4__this; //Field offset: 0x10
		public int currencyAmount; //Field offset: 0x18

		public <>c__DisplayClass9_0() { }

		internal void <CurrencyClaim>b__0() { }

	}

	[SerializeField]
	private TextMeshProUGUI _currencyAmountText; //Field offset: 0x50
	[SerializeField]
	private Image _coinImage; //Field offset: 0x58
	[SerializeField]
	private Sprite[] _coinsSprites; //Field offset: 0x60
	private int _currencyAmount; //Field offset: 0x68
	private string _currencyItemGuid; //Field offset: 0x70

	public StarsPassCurrencyPackItem() { }

	[CompilerGenerated]
	private bool <OnPackClaimed>b__10_0(Item x) { }

	protected virtual void ApplyPackStatus(MilestoneStatus state) { }

	public void AutoClaimCurrencyPack() { }

	public void CurrencyClaim(int currencyAmount) { }

	private void OnPackClaimed(int currencyAmount) { }

	private void PlayClaimAnimation(int currencyAmount) { }

	public void SetCoinsAmount(int currencyAmount) { }

	private void SetCoinsAmountText(int currencyAmount) { }

	public void SetCurrencyItemGuid(string itemGuid) { }

	private void SetPackCoinsImage(int coinsAmount) { }

}

