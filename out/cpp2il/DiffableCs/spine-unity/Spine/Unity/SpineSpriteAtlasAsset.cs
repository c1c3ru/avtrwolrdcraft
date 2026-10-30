namespace Spine.Unity;

[CreateAssetMenu(fileName = "New Spine SpriteAtlas Asset", menuName = "Spine/Spine SpriteAtlas Asset")]
public class SpineSpriteAtlasAsset : AtlasAssetBase
{
	internal class SavedRegionInfo
	{
		public float x; //Field offset: 0x10
		public float y; //Field offset: 0x14
		public float width; //Field offset: 0x18
		public float height; //Field offset: 0x1C
		public SpritePackingRotation packingRotation; //Field offset: 0x20

		public SavedRegionInfo() { }

	}

	public SpriteAtlas spriteAtlasFile; //Field offset: 0x28
	public Material[] materials; //Field offset: 0x30
	protected Atlas atlas; //Field offset: 0x38
	public bool updateRegionsInPlayMode; //Field offset: 0x40
	[SerializeField]
	protected SavedRegionInfo[] savedRegions; //Field offset: 0x48

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

	public SpineSpriteAtlasAsset() { }

	public static Sprite[] AccessPackedSprites(SpriteAtlas spriteAtlas) { }

	public static Texture2D AccessPackedTexture(Sprite[] sprites) { }

	protected void AssignRegionsFromSavedRegions(Sprite[] sprites, Atlas usedAtlas) { }

	public virtual void Clear() { }

	public static SpineSpriteAtlasAsset CreateRuntimeInstance(SpriteAtlas spriteAtlasFile, Material[] materials, bool initialize) { }

	public virtual bool get_IsLoaded() { }

	public virtual int get_MaterialCount() { }

	public virtual IEnumerable<Material> get_Materials() { }

	public virtual Material get_PrimaryMaterial() { }

	public virtual Atlas GetAtlas(bool onlyMetaData = false) { }

	private Atlas LoadAtlas(SpriteAtlas spriteAtlas) { }

	private void Reset() { }

}

