namespace Game.Store;

public class StoreInsufficientCurrencyWindow : StoreCurrencyRelatedWindowBase
{
	[SerializeField]
	private TextMeshProUGUI _Text; //Field offset: 0x30
	[SerializeField]
	private TextMeshProUGUI _subText; //Field offset: 0x38
	private Item _itemData; //Field offset: 0x40

	public StoreInsufficientCurrencyWindow() { }

	private void Init(Item itemData) { }

	public void OnCTAButtonClick() { }

	public static void Show(Item itemData) { }

}

