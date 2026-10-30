namespace PWC.Level.Maker.Customization;

public class CategoryCustomizationUIItem : GameUIElement, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private Image _background; //Field offset: 0x28
	[SerializeField]
	private Image _image; //Field offset: 0x30
	private LevelMakerCustomizationObjectHandlerBase _itemHandler; //Field offset: 0x38
	private LevelMakerItemCustomizationMenu _menu; //Field offset: 0x40
	private string _category; //Field offset: 0x48

	public CategoryCustomizationUIItem() { }

	public string GetCategory() { }

	public void Init(LevelMakerItemCustomizationMenu menu, LevelMakerCustomizationObjectHandlerBase objectHandler, string category, Sprite sprite) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public void SetSlected(bool isSlected) { }

}

