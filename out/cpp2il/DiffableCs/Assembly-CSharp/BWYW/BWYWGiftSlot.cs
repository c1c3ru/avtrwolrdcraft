namespace BWYW;

public class BWYWGiftSlot : BWYWSlotBase
{
	[SerializeField]
	private Image _topImage; //Field offset: 0x50
	[SerializeField]
	private Image _bottomImage; //Field offset: 0x58
	[SerializeField]
	private TMP_Text _topTitle; //Field offset: 0x60
	[SerializeField]
	private TMP_Text _bottomTitle; //Field offset: 0x68
	[SerializeField]
	private TMP_Text _targetXpText; //Field offset: 0x70
	[SerializeField]
	private GameObject _xpTextParent; //Field offset: 0x78
	[SerializeField]
	private BWYWRewardsMenuProgressBarSegment _progressSegment; //Field offset: 0x80
	[SerializeField]
	private GameObject _VGameObject; //Field offset: 0x88
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x90
	[SerializeField]
	private GameObject _cardParent; //Field offset: 0x98
	[SerializeField]
	private GameObject _resetButton; //Field offset: 0xA0
	private Action _onResetButtonClickAction; //Field offset: 0xA8

	public BWYWGiftSlot() { }

	private void Animate() { }

	public void Init(int giftId, BWYWGiftBase topGift, BWYWGiftBase bottomGift, bool canBeClaimed, int targetXp, bool isHidden, float progress, Action onResetButtonClickAction = null) { }

	public virtual void OnClaimClick() { }

	public void OnResetGifts() { }

	public void RestoreInteractabilityAfterFTUEIfNeeded() { }

}

