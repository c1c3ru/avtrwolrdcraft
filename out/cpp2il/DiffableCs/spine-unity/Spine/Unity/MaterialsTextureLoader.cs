namespace Spine.Unity;

public class MaterialsTextureLoader : TextureLoader
{
	private SpineAtlasAsset atlasAsset; //Field offset: 0x10
	private readonly Dictionary<String, Material> _hashedMaterials; //Field offset: 0x18

	public MaterialsTextureLoader(SpineAtlasAsset atlasAsset) { }

	public override void Load(AtlasPage page, string path) { }

	public override void Unload(object texture) { }

}

