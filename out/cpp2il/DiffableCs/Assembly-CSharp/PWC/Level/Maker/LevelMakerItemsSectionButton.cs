namespace PWC.Level.Maker;

public class LevelMakerItemsSectionButton : GameUIElement, IPointerClickHandler, IEventSystemHandler
{
	private static LevelMakerItemsSectionButton _selected; //Field offset: 0x0
	[SerializeField]
	private GameObject _selectedIndicator; //Field offset: 0x28
	[SerializeField]
	private Image _image; //Field offset: 0x30
	private DataType _dataType; //Field offset: 0x38
	private string _section; //Field offset: 0x40
	private Action _action; //Field offset: 0x48

	public LevelMakerItemsSectionButton() { }

	public void Init(string section, DataType dataType, Action action) { }

	public void OnDeselect() { }

	private void OnDestroy() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public void OnSelect() { }

	public void Select() { }

}

