namespace Spine.Unity;

public abstract class OnDemandTextureLoader : ScriptableObject
{
	internal sealed class TextureLoadDelegate : MulticastDelegate
	{

		public TextureLoadDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(OnDemandTextureLoader loader, Material material, int textureIndex, AsyncCallback callback, object object) { }

		public override void EndInvoke(IAsyncResult result) { }

		public override void Invoke(OnDemandTextureLoader loader, Material material, int textureIndex) { }

	}

	public AtlasAssetBase atlasAsset; //Field offset: 0x18
	public SkeletonDataAsset skeletonDataAsset; //Field offset: 0x20
	[CompilerGenerated]
	private TextureLoadDelegate onTextureRequested; //Field offset: 0x28
	[CompilerGenerated]
	private TextureLoadDelegate onTextureLoaded; //Field offset: 0x30
	[CompilerGenerated]
	private TextureLoadDelegate onTextureLoadFailed; //Field offset: 0x38
	[CompilerGenerated]
	private TextureLoadDelegate onTextureUnloaded; //Field offset: 0x40

	protected event TextureLoadDelegate onTextureLoaded
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	protected event TextureLoadDelegate onTextureLoadFailed
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	protected event TextureLoadDelegate onTextureRequested
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	protected event TextureLoadDelegate onTextureUnloaded
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public event TextureLoadDelegate TextureLoaded
	{
		 add { } //Length: 4
		 remove { } //Length: 4
	}

	public event TextureLoadDelegate TextureLoadFailed
	{
		 add { } //Length: 4
		 remove { } //Length: 4
	}

	public event TextureLoadDelegate TextureRequested
	{
		 add { } //Length: 4
		 remove { } //Length: 4
	}

	public event TextureLoadDelegate TextureUnloaded
	{
		 add { } //Length: 4
		 remove { } //Length: 4
	}

	protected OnDemandTextureLoader() { }

	[CompilerGenerated]
	protected void add_onTextureLoaded(TextureLoadDelegate value) { }

	[CompilerGenerated]
	protected void add_onTextureLoadFailed(TextureLoadDelegate value) { }

	[CompilerGenerated]
	protected void add_onTextureRequested(TextureLoadDelegate value) { }

	[CompilerGenerated]
	protected void add_onTextureUnloaded(TextureLoadDelegate value) { }

	public void add_TextureLoaded(TextureLoadDelegate value) { }

	public void add_TextureLoadFailed(TextureLoadDelegate value) { }

	public void add_TextureRequested(TextureLoadDelegate value) { }

	public void add_TextureUnloaded(TextureLoadDelegate value) { }

	public abstract bool AssignPlaceholderTextures(out IEnumerable<Material>& modifiedMaterials) { }

	public abstract bool AssignTargetTextures(out IEnumerable<Material>& modifiedMaterials) { }

	public abstract void BeginCustomTextureLoading() { }

	public abstract void Clear(bool clearAtlasAsset = false) { }

	public abstract void EndCustomTextureLoading() { }

	public abstract string GetPlaceholderTextureName(string originalTextureName) { }

	public override bool HasNullMainTexturesAssigned(out List<Material>& nullTextureMaterials) { }

	public abstract bool HasPlaceholderAssigned(Material material) { }

	public abstract bool HasPlaceholderTexturesAssigned(out List<Material>& placeholderMaterials) { }

	protected void OnTextureLoaded(Material material, int textureIndex) { }

	protected void OnTextureLoadFailed(Material material, int textureIndex) { }

	protected void OnTextureRequested(Material material, int textureIndex) { }

	protected void OnTextureUnloaded(Material material, int textureIndex) { }

	[CompilerGenerated]
	protected void remove_onTextureLoaded(TextureLoadDelegate value) { }

	[CompilerGenerated]
	protected void remove_onTextureLoadFailed(TextureLoadDelegate value) { }

	[CompilerGenerated]
	protected void remove_onTextureRequested(TextureLoadDelegate value) { }

	[CompilerGenerated]
	protected void remove_onTextureUnloaded(TextureLoadDelegate value) { }

	public void remove_TextureLoaded(TextureLoadDelegate value) { }

	public void remove_TextureLoadFailed(TextureLoadDelegate value) { }

	public void remove_TextureRequested(TextureLoadDelegate value) { }

	public void remove_TextureUnloaded(TextureLoadDelegate value) { }

	public abstract void RequestLoadMaterialTextures(Material material, ref Material overrideMaterial) { }

	public abstract void RequestLoadTexture(Texture placeholderTexture, ref Texture replacementTexture, Action<Texture> onTextureLoaded = null) { }

}

