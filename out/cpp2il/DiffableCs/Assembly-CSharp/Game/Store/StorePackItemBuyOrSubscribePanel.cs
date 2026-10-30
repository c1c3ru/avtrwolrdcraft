namespace Game.Store;

public class StorePackItemBuyOrSubscribePanel : MonoBehaviour
{
	[SerializeField]
	private StorePackItemPriceViewer _priceViewer; //Field offset: 0x20
	[SerializeField]
	private Button _buyButton; //Field offset: 0x28
	[SerializeField]
	private Sprite _buttonPendingSprite; //Field offset: 0x30
	private Item _itemData; //Field offset: 0x38

	public StorePackItemBuyOrSubscribePanel() { }

	private void Awake() { }

	public void Hide() { }

	public void Init(Item itemData) { }

	public void OnBuyButtonClick() { }

	private void OnDestroy() { }

	public void OnGetAvatarPassButtonClick() { }

	private void UpdatePandingPurchaseUI(string productId) { }

}

