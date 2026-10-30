namespace Game.Store;

public class StorePackItemWindow : MonoBehaviour
{
	[SerializeField]
	private StorePackItemBuyOrSubscribePanel _buyOrSubscribePanel; //Field offset: 0x20
	[SerializeField]
	private StorePackItemPriceViewer _priceViewer; //Field offset: 0x28
	[SerializeField]
	private VideoComponent _videoComponent; //Field offset: 0x30
	[SerializeField]
	private Image _coverImage; //Field offset: 0x38
	[SerializeField]
	private GameObject _button; //Field offset: 0x40
	[SerializeField]
	private Image _buttonImage; //Field offset: 0x48
	[SerializeField]
	private Sprite _buttonClaimSprite; //Field offset: 0x50
	[SerializeField]
	private Sprite _buttonBuySprite; //Field offset: 0x58
	[SerializeField]
	private Sprite _buttonPendingSprite; //Field offset: 0x60
	[SerializeField]
	private Sprite _buttonGetBundleSprite; //Field offset: 0x68
	[SerializeField]
	private Sprite _buttonGetSprite; //Field offset: 0x70
	[SerializeField]
	private GameObject _ownedBadge; //Field offset: 0x78
	[SerializeField]
	private GameObject _resetPackButton; //Field offset: 0x80
	[SerializeField]
	private Image _bundleImage; //Field offset: 0x88
	[SerializeField]
	private GameObject _avatarPassBadge; //Field offset: 0x90
	[SerializeField]
	private GameObject _giftTag; //Field offset: 0x98
	private Item _packItemData; //Field offset: 0xA0
	private StorePackItem _packItem; //Field offset: 0xA8
	public Func<StorePackItemWindow, Boolean> TryOverrideClickClaimAction; //Field offset: 0xB0

	public Item PackItemData
	{
		 get { } //Length: 8
	}

	public StorePackItemWindow() { }

	[CompilerGenerated]
	private void <Init>b__25_0(bool success) { }

	[CompilerGenerated]
	private void <OnResetPackButtonClick>b__27_0() { }

	private void Awake() { }

	public Item get_PackItemData() { }

	public Sprite GetCoverImage() { }

	public void Init(StorePackItemBase packItem) { }

	public void Init(Item packItemData, bool disableClaim = false) { }

	public void OnClaimItemButtonClick() { }

	private void OnDestroy() { }

	public void OnResetPackButtonClick() { }

	private void UpdatePandingPurchaseUI(string productId) { }

}

