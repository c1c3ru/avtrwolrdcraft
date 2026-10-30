namespace PazuCore.MediaGeneric;

public class TextureComponent : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		public TextureComponent <>4__this; //Field offset: 0x10
		public Coroutine textureLoadingCoroutine; //Field offset: 0x18
		public bool alreadyInCache; //Field offset: 0x20
		public float fadeDuration; //Field offset: 0x24
		public string textureUrl; //Field offset: 0x28
		public Action<Boolean> onFinish; //Field offset: 0x30

		public <>c__DisplayClass10_0() { }

		internal void <LoadTexture>b__0(bool success) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass11_0
	{
		public TextureComponent <>4__this; //Field offset: 0x10
		public Image image; //Field offset: 0x18
		public Action<Boolean> onFinish; //Field offset: 0x20

		public <>c__DisplayClass11_0() { }

		internal void <AssignTextureToImage>b__0(string textureName) { }

		internal void <AssignTextureToImage>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass11_1
	{
		public string textureName; //Field offset: 0x10
		public <>c__DisplayClass11_0 CS$<>8__locals1; //Field offset: 0x18

		public <>c__DisplayClass11_1() { }

		internal void <AssignTextureToImage>b__2(Texture2D texture) { }

	}

	[SerializeField]
	protected Image _image; //Field offset: 0x20
	[SerializeField]
	private TextureLoading _textureLoading; //Field offset: 0x28
	private string _textureName; //Field offset: 0x30

	public Image TextureImage
	{
		 get { } //Length: 8
	}

	public string TextureName
	{
		 get { } //Length: 8
	}

	public TextureComponent() { }

	private string AssignTextureToImage(Image image, string url, Action<Boolean> onFinish = null) { }

	protected override void Awake() { }

	private void FadeIn(float duration) { }

	public void FadeOut(Action onFinish) { }

	public Image get_TextureImage() { }

	public string get_TextureName() { }

	private float GetAlpha() { }

	private void HideTextureLoading() { }

	public void LoadTexture(string textureUrl, float fadeDuration = 0,3, Action<Boolean> onFinish = null) { }

	protected override void OnDestroy() { }

	protected override void OnDisable() { }

	private void OnFadeUpdate(float value) { }

	protected void SetAlpha(float alpha) { }

	public void ShowTextureLoading() { }

}

