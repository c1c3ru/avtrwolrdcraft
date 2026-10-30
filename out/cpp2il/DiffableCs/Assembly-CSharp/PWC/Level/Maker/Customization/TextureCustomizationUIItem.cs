namespace PWC.Level.Maker.Customization;

public class TextureCustomizationUIItem : CustomizationUIItemBase
{
	[SerializeField]
	private RawImage _rawImage; //Field offset: 0x68
	private Texture2D _texture; //Field offset: 0x70
	private string _texturePath; //Field offset: 0x78

	public TextureCustomizationUIItem() { }

	public void Init(LevelMakerCustomizationObjectHandlerBase objectHandler, string category, LevelMakerCustomizationHandlerBase[] handlers, Texture2D texture, string texturePath) { }

	public virtual void OnPointerClick(PointerEventData eventData) { }

}

