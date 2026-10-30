namespace BWYW;

public class BWYWSeparetorSlot : BWYWSlotBase
{
	[SerializeField]
	private TMP_Text _dayText; //Field offset: 0x50
	[SerializeField]
	private Sprite[] _sprites; //Field offset: 0x58
	[SerializeField]
	private Image _image; //Field offset: 0x60
	[SerializeField]
	private Sprite _lockedSeperatorSprite; //Field offset: 0x68

	public BWYWSeparetorSlot() { }

	public void Init(bool isLocked, int chapter) { }

	public void Init(int day) { }

	public virtual bool OnClickInternal() { }

}

