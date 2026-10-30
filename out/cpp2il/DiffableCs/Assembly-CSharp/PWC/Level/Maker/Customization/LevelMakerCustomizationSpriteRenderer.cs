namespace PWC.Level.Maker.Customization;

public class LevelMakerCustomizationSpriteRenderer : LevelMakerCustomizationHandlerBase
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x58

	public LevelMakerCustomizationSpriteRenderer() { }

	protected virtual void SetColorInternal(Color color) { }

	protected virtual void SetTextureInternal(Texture2D texture) { }

}

