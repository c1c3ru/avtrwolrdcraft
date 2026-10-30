namespace Game.Store;

public class StorePackItemNoWindow : StorePackItem
{
	[SerializeField]
	private GameObject _button; //Field offset: 0xC8
	[SerializeField]
	private Image _buttonImage; //Field offset: 0xD0
	[SerializeField]
	private Sprite _buttonClaimSprite; //Field offset: 0xD8
	[SerializeField]
	private Sprite _buttonBuySprite; //Field offset: 0xE0
	[SerializeField]
	private Sprite _buttonGetBundleSprite; //Field offset: 0xE8
	[SerializeField]
	private Sprite _buttonPendingSprite; //Field offset: 0xF0
	[SerializeField]
	private bool _useButtom; //Field offset: 0xF8

	public StorePackItemNoWindow() { }

	private void Awake() { }

	protected virtual void OnClickWhileClaimable() { }

	protected virtual void OnClickWhileClaimed() { }

	private void OnDestroy() { }

	public virtual void SynceView() { }

	private void UpdatePandingPurchaseUI(string productId) { }

}

