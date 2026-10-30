namespace PazuCore.PazuCoreAddressables.AFC;

[RequireComponent(typeof(TextureComponent))]
public abstract class AFCTextureComponentBase : AFCUnityMessageDrivenHandlerBase
{
	[SerializeField]
	protected TextureComponent _textureComponent; //Field offset: 0x28
	[SerializeField]
	protected float _fadeInDuration; //Field offset: 0x30
	[SerializeField]
	protected Image _image; //Field offset: 0x38
	[SerializeField]
	protected GameObject _loadingObject; //Field offset: 0x40
	[SerializeField]
	private UnityEvent _onLoadSuccess; //Field offset: 0x48
	[SerializeField]
	private UnityEvent _onLoadFailed; //Field offset: 0x50
	protected string _url; //Field offset: 0x58

	protected AFCTextureComponentBase() { }

	[CompilerGenerated]
	private void <LoadTextureFromUrl>b__9_0(bool success) { }

	public abstract void LoadTexture() { }

	protected void LoadTextureFromUrl(string url) { }

	public virtual void PerformAction() { }

}

