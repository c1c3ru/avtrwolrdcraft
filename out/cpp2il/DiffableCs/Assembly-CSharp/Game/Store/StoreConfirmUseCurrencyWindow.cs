namespace Game.Store;

public class StoreConfirmUseCurrencyWindow : StoreCurrencyRelatedWindowBase
{
	[SerializeField]
	private StorePackItemPriceViewer _priceViewer; //Field offset: 0x30
	private Item _itemData; //Field offset: 0x38

	public StoreConfirmUseCurrencyWindow() { }

	private void Init(Item itemData) { }

	public void OnCTAButtonClick() { }

	public static void Show(Item itemData) { }

}

