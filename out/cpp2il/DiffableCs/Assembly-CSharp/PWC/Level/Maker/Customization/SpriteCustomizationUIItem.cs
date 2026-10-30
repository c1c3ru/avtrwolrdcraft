namespace PWC.Level.Maker.Customization;

public class SpriteCustomizationUIItem : CustomizationUIItemBase
{
	[SerializeField]
	private Image _image; //Field offset: 0x68
	private Sprite _sprite; //Field offset: 0x70
	private string _spritePath; //Field offset: 0x78

	public SpriteCustomizationUIItem() { }

	public void Init(LevelMakerCustomizationHandlerBase[] handlers, Sprite sprite, string spritePath) { }

	public virtual void OnPointerClick(PointerEventData eventData) { }

}

