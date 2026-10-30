namespace PWC.Level.Maker.Customization;

public class LevelMakerCustomizationMeshSkew : LevelMakerCustomizationMeshRenderer
{
	[SerializeField]
	private MeshSkew _meshSkew; //Field offset: 0x70

	public LevelMakerCustomizationMeshSkew() { }

	protected virtual void SetTextureInternal(Texture2D texture) { }

}

