namespace PazuCore.AF.Library;

public class LibraryRegularFeaturedSection : LibraryFeaturedSectionBase
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action <>9__9_2; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <Init>b__9_2() { }

	}

	[SerializeField]
	private Image _buttonImage; //Field offset: 0x28
	[SerializeField]
	private Text _buttonText; //Field offset: 0x30
	[SerializeField]
	private Image _buttonIcon; //Field offset: 0x38
	[SerializeField]
	private LibraryTextureComponent _textureComponent; //Field offset: 0x40
	[SerializeField]
	private Sprite _downloadIcon; //Field offset: 0x48
	[SerializeField]
	private Sprite _playIcon; //Field offset: 0x50
	private LibraryGame _game; //Field offset: 0x58

	public LibraryGame MyGame
	{
		 get { } //Length: 8
	}

	public LibraryRegularFeaturedSection() { }

	[CompilerGenerated]
	private void <Init>b__9_0() { }

	[CompilerGenerated]
	private void <Init>b__9_1() { }

	public LibraryGame get_MyGame() { }

	public virtual void Init() { }

	public void OnPlayButtonClick() { }

}

