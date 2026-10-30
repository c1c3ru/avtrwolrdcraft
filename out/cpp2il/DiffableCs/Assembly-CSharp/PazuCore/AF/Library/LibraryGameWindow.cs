namespace PazuCore.AF.Library;

public class LibraryGameWindow : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action <>9__21_1; //Field offset: 0x8
		public static Action<Transform> <>9__21_3; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal void <Show>b__21_1() { }

		internal void <Show>b__21_3(Transform item) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass23_0
	{
		public String[] currentContext; //Field offset: 0x10

		public <>c__DisplayClass23_0() { }

		internal void <OnCTAButtonClick>b__0(bool success) { }

	}

	[SerializeField]
	private LibraryVideoComponent _videoItem; //Field offset: 0x20
	[SerializeField]
	private LibraryTextureComponent _textureItem; //Field offset: 0x28
	[SerializeField]
	private LibraryTextureComponent _gameIcon; //Field offset: 0x30
	[SerializeField]
	private GameObject _newBadge; //Field offset: 0x38
	[SerializeField]
	private Text _newBadgeText; //Field offset: 0x40
	[SerializeField]
	private GameObject _top10Badge; //Field offset: 0x48
	[SerializeField]
	private Text _top10BadgeText; //Field offset: 0x50
	[SerializeField]
	private Text _buttonText; //Field offset: 0x58
	[SerializeField]
	private Image _buttonIcon; //Field offset: 0x60
	[SerializeField]
	private Transform _skillsParent; //Field offset: 0x68
	[SerializeField]
	private LibrarySkillItem _skillItemPrefab; //Field offset: 0x70
	[SerializeField]
	private GameObject _skillDotPrefab; //Field offset: 0x78
	[SerializeField]
	private Image _ctaImage; //Field offset: 0x80
	[SerializeField]
	private Text _description; //Field offset: 0x88
	[SerializeField]
	private Sprite _downloadIcon; //Field offset: 0x90
	[SerializeField]
	private Sprite _playIcon; //Field offset: 0x98
	private LibraryGame _game; //Field offset: 0xA0
	private GameObject _bg; //Field offset: 0xA8
	private String[] _analyticsContext; //Field offset: 0xB0

	public LibraryVideoComponent VideoItem
	{
		 get { } //Length: 8
	}

	public LibraryGameWindow() { }

	[CompilerGenerated]
	private void <Show>b__21_0() { }

	[CompilerGenerated]
	private void <Show>b__21_2() { }

	public void Close() { }

	public LibraryVideoComponent get_VideoItem() { }

	public void OnCTAButtonClick() { }

	public void Show(int gameId, int referrerSectionId, GameObject bgPrefab) { }

}

