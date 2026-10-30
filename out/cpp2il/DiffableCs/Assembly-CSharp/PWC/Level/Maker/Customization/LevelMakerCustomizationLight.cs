namespace PWC.Level.Maker.Customization;

public class LevelMakerCustomizationLight : LevelMakerCustomizationHandlerBase
{
	[SerializeField]
	private LightSource _lightSource; //Field offset: 0x58

	public LevelMakerCustomizationLight() { }

	protected virtual void SetColorInternal(Color color) { }

	protected virtual void SetTextureInternal(Texture2D texture) { }

}

