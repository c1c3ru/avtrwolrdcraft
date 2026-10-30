namespace Game.Store;

public class StoreTextureComponent : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action <>9__5_1; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <LoadTexture>b__5_1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public StoreTextureComponent <>4__this; //Field offset: 0x10
		public int textureLoadingCallCounterOnCall; //Field offset: 0x18

		public <>c__DisplayClass5_0() { }

		internal void <LoadTexture>b__0(string textureName) { }

	}

	[SerializeField]
	private Image _image; //Field offset: 0x20
	[SerializeField]
	private GameObject _loadingObject; //Field offset: 0x28
	[SerializeField]
	private CanvasGroup _canvasGroup; //Field offset: 0x30
	private int _textureLoadingCallCounter; //Field offset: 0x38

	public StoreTextureComponent() { }

	public void LoadTexture(string imageUrl) { }

	public void SetSize(Vector2 size) { }

}

