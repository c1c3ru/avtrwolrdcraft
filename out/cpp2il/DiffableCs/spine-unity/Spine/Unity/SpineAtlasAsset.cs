namespace Spine.Unity;

[CreateAssetMenu(fileName = "New Spine Atlas Asset", menuName = "Spine/Spine Atlas Asset")]
public class SpineAtlasAsset : AtlasAssetBase
{
	public TextAsset atlasFile; //Field offset: 0x28
	public Material[] materials; //Field offset: 0x30
	public TextureLoader customTextureLoader; //Field offset: 0x38
	protected Atlas atlas; //Field offset: 0x40

	public virtual bool IsLoaded
	{
		 get { } //Length: 16
	}

	public virtual int MaterialCount
	{
		 get { } //Length: 24
	}

	public virtual IEnumerable<Material> Materials
	{
		 get { } //Length: 8
	}

	public virtual Material PrimaryMaterial
	{
		 get { } //Length: 40
	}

	public SpineAtlasAsset() { }

	public virtual void Clear() { }

	public static SpineAtlasAsset CreateRuntimeInstance(TextAsset atlasText, Material[] materials, bool initialize, Func<SpineAtlasAsset, TextureLoader> newCustomTextureLoader = null) { }

	public static SpineAtlasAsset CreateRuntimeInstance(TextAsset atlasText, Texture2D[] textures, Material materialPropertySource, bool initialize, Func<SpineAtlasAsset, TextureLoader> newCustomTextureLoader = null, bool renameMaterial = false) { }

	public static SpineAtlasAsset CreateRuntimeInstance(TextAsset atlasText, Texture2D[] textures, Shader shader, bool initialize, Func<SpineAtlasAsset, TextureLoader> newCustomTextureLoader = null) { }

	public Mesh GenerateMesh(string name, Mesh mesh, out Material material, float scale = 0,01) { }

	public virtual bool get_IsLoaded() { }

	public virtual int get_MaterialCount() { }

	public virtual IEnumerable<Material> get_Materials() { }

	public virtual Material get_PrimaryMaterial() { }

	public virtual Atlas GetAtlas(bool onlyMetaData = false) { }

	private void Reset() { }

}

