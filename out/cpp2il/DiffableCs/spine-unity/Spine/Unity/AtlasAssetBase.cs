namespace Spine.Unity;

public abstract class AtlasAssetBase : ScriptableObject
{
	internal enum LoadingMode
	{
		Normal = 0,
		OnDemand = 1,
	}

	[SerializeField]
	protected LoadingMode textureLoadingMode; //Field offset: 0x18
	[SerializeField]
	protected OnDemandTextureLoader onDemandTextureLoader; //Field offset: 0x20

	public abstract bool IsLoaded
	{
		 get { } //Length: 0
	}

	public abstract int MaterialCount
	{
		 get { } //Length: 0
	}

	public abstract IEnumerable<Material> Materials
	{
		 get { } //Length: 0
	}

	public OnDemandTextureLoader OnDemandTextureLoader
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public abstract Material PrimaryMaterial
	{
		 get { } //Length: 0
	}

	public override LoadingMode TextureLoadingMode
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	protected AtlasAssetBase() { }

	public override void BeginCustomTextureLoading() { }

	public abstract void Clear() { }

	public override void EndCustomTextureLoading() { }

	public abstract bool get_IsLoaded() { }

	public abstract int get_MaterialCount() { }

	public abstract IEnumerable<Material> get_Materials() { }

	public OnDemandTextureLoader get_OnDemandTextureLoader() { }

	public abstract Material get_PrimaryMaterial() { }

	public override LoadingMode get_TextureLoadingMode() { }

	public abstract Atlas GetAtlas(bool onlyMetaData = false) { }

	public override void RequireTextureLoaded(Texture placeholderTexture, ref Texture replacementTexture, Action<Texture> onTextureLoaded) { }

	public override void RequireTexturesLoaded(Material material, ref Material overrideMaterial) { }

	public void set_OnDemandTextureLoader(OnDemandTextureLoader value) { }

	public override void set_TextureLoadingMode(LoadingMode value) { }

}

