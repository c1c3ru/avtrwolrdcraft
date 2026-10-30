namespace PWC.Level.Maker.Customization;

public class LevelMakerCustomizationSpine : LevelMakerCustomizationHandlerBase
{
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x58
	[SerializeField]
	private string _textureName; //Field offset: 0x60
	private bool _didEnrureMaterials; //Field offset: 0x68

	public LevelMakerCustomizationSpine() { }

	private List<Material> FilterByTextureName() { }

	protected virtual void SetColorInternal(Color color) { }

	protected virtual void SetTextureInternal(Texture2D texture) { }

}

