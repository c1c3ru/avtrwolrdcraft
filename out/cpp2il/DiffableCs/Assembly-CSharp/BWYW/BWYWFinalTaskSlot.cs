namespace BWYW;

public class BWYWFinalTaskSlot : BWYWSlotBase
{
	[SerializeField]
	private TMP_Text _titleText; //Field offset: 0x50
	[SerializeField]
	private TMP_Text _detailsText; //Field offset: 0x58
	[SerializeField]
	private Image _image; //Field offset: 0x60

	public BWYWFinalTaskSlot() { }

	public void Init(SkillType skillType) { }

}

