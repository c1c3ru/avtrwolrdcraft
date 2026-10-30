namespace BWYW;

public class BWYWFinalGiftSlot : BWYWSlotBase
{
	[SerializeField]
	private TMP_Text _finalTitle; //Field offset: 0x50
	[SerializeField]
	private TMP_Text _targetXpText; //Field offset: 0x58
	[SerializeField]
	private GameObject _xpTextParent; //Field offset: 0x60
	[SerializeField]
	private BWYWRewardsMenuProgressBarSegment _progressSegment; //Field offset: 0x68
	[SerializeField]
	private GameObject _VGameObject; //Field offset: 0x70
	[SerializeField]
	private Image _image; //Field offset: 0x78
	private Action _onResetButtonClickAction; //Field offset: 0x80

	public BWYWFinalGiftSlot() { }

	public void Init(int giftId, BWYWGiftBase gift, bool canBeClaimed, int targetXp, bool isHidden, float progress, Action onResetButtonClickAction) { }

	public void OnResetGifts() { }

}

