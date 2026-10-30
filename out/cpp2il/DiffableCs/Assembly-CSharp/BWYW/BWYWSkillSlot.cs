namespace BWYW;

public class BWYWSkillSlot : BWYWSlotBase
{
	public static int currentFocusedSlotId; //Field offset: 0x0
	[SerializeField]
	private Image _chapterImage; //Field offset: 0x50
	[SerializeField]
	private GameObject _back; //Field offset: 0x58
	[SerializeField]
	private GameObject _front; //Field offset: 0x60
	[SerializeField]
	private GameObject _newIndication; //Field offset: 0x68
	[SerializeField]
	private Sprite _activatedButtonSprite; //Field offset: 0x70
	[SerializeField]
	private Sprite _deactivatedButtonSprite; //Field offset: 0x78
	[SerializeField]
	private GameObject _lock; //Field offset: 0x80
	[SerializeField]
	private GameObject _progressBarParent; //Field offset: 0x88
	[SerializeField]
	private BWYWSkillLevelProgressBarManager _progressBarManager; //Field offset: 0x90
	private SkillType _slotSkillType; //Field offset: 0x98
	private Image _activationButtonImage; //Field offset: 0xA0
	private bool _isLocked; //Field offset: 0xA8
	private bool _isComingSoon; //Field offset: 0xA9

	public SkillType SlotSkillType
	{
		 get { } //Length: 8
	}

	public BWYWSkillSlot() { }

	public SkillType get_SlotSkillType() { }

	public void Init(SkillType skillType, int id, bool isLocked, bool isComingSoon) { }

	public virtual void OnClaimClickInternal() { }

	public virtual void OnClick() { }

	public void OnDeactivated() { }

}

