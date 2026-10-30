namespace Game.Store;

public abstract class StorePackItemBase : MonoBehaviour
{
	[SerializeField]
	private Image _image; //Field offset: 0x20
	protected Item _itemData; //Field offset: 0x28
	public Func<StorePackItemBase, Boolean> TryOverrideClickAction; //Field offset: 0x30

	public Item ItemData
	{
		 get { } //Length: 8
	}

	public Image MyImage
	{
		 get { } //Length: 8
	}

	protected StorePackItemBase() { }

	public Item get_ItemData() { }

	public Image get_MyImage() { }

	public override void Init(Item itemData) { }

	protected void InitViewers(Item itemData, StorePackItemPriceViewer priceViewer, StorePackItemOfferViewer offerViewer, StorePackItemStarsViewer starsViewer) { }

	public void OnClick() { }

	protected abstract void OnClickWhileClaimable() { }

	protected override void OnClickWhileClaimed() { }

	protected override void OnClickWhileComingSoon() { }

	protected override void OnClickWhileLinkToPack() { }

	protected override void OnClickWhileRequireAvatarID() { }

	protected override void OnClickWhileSuggestAvatarPass() { }

}

