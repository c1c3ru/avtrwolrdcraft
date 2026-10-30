namespace PWC.Level.Maker.Customization;

public class ColorCustomizationUIItem : CustomizationUIItemBase
{
	[SerializeField]
	protected Image _image; //Field offset: 0x68
	private Color _color; //Field offset: 0x70

	public Color Color
	{
		 get { } //Length: 12
	}

	public ColorCustomizationUIItem() { }

	public Color get_Color() { }

	public void Init(LevelMakerCustomizationObjectHandlerBase objectHandler, string category, LevelMakerCustomizationHandlerBase[] handlers, Color color) { }

	public virtual void OnPointerClick(PointerEventData eventData) { }

}

