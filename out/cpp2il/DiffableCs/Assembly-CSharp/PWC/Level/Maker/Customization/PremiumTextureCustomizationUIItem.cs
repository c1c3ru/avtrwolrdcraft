namespace PWC.Level.Maker.Customization;

public class PremiumTextureCustomizationUIItem : TextureCustomizationUIItem
{
	[SerializeField]
	private Image _image; //Field offset: 0x80
	[SerializeField]
	private Sprite _selected; //Field offset: 0x88
	[SerializeField]
	private Sprite _unselected; //Field offset: 0x90

	public PremiumTextureCustomizationUIItem() { }

	protected virtual void SetSelected(bool value) { }

}

