namespace PazuCore.AF.Library;

public class LibraryGameBundleWindow : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action <>9__20_1; //Field offset: 0x8
		public static Action<Transform> <>9__20_3; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal void <Show>b__20_1() { }

		internal void <Show>b__20_3(Transform item) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass22_0
	{
		public String[] currentContext; //Field offset: 0x10
		public LibraryGameBundleWindow <>4__this; //Field offset: 0x18

		public <>c__DisplayClass22_0() { }

		internal void <OnCTAButtonClick>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass23_0
	{
		public int amount; //Field offset: 0x10

		public <>c__DisplayClass23_0() { }

		internal bool <ApplyIconsLayout>b__0(IconsLayout x) { }

	}

	internal class IconsLayout
	{
		public int amount; //Field offset: 0x10
		public List<Vector2> positions; //Field offset: 0x18
		public List<Single> scales; //Field offset: 0x20
		public List<Single> rotations; //Field offset: 0x28
		public Vector2 parentPosition; //Field offset: 0x30
		public float parentScale; //Field offset: 0x38

		public IconsLayout() { }

	}

	[SerializeField]
	private LibraryVideoComponent _videoItem; //Field offset: 0x20
	[SerializeField]
	private LibraryTextureComponent _textureItem; //Field offset: 0x28
	[SerializeField]
	private LibraryTextureComponent _gameBundleIcon; //Field offset: 0x30
	[SerializeField]
	private Text _buttonText; //Field offset: 0x38
	[SerializeField]
	private Transform _gamesParent; //Field offset: 0x40
	[SerializeField]
	private Image _ctaImage; //Field offset: 0x48
	[SerializeField]
	private GameObject _includedRibbon; //Field offset: 0x50
	[SerializeField]
	private Text _includedRibbonText; //Field offset: 0x58
	[SerializeField]
	private Text _gamesTitle; //Field offset: 0x60
	[SerializeField]
	private RectTransform _gamesSection; //Field offset: 0x68
	[SerializeField]
	private RectTransform _gameBundleIconParent; //Field offset: 0x70
	[SerializeField]
	private LibraryGameBundleGameItem _gameItemPrefab; //Field offset: 0x78
	[SerializeField]
	private List<IconsLayout> _iconsLayouts; //Field offset: 0x80
	private LibraryGame _gameBundle; //Field offset: 0x88
	private int _sectionId; //Field offset: 0x90
	private GameObject _bg; //Field offset: 0x98
	private String[] _analyticsContext; //Field offset: 0xA0

	public LibraryVideoComponent VideoItem
	{
		 get { } //Length: 8
	}

	public LibraryGameBundleWindow() { }

	[CompilerGenerated]
	private void <Show>b__20_0() { }

	[CompilerGenerated]
	private void <Show>b__20_2() { }

	private void ApplyIconsLayout() { }

	public void Close() { }

	public LibraryVideoComponent get_VideoItem() { }

	public void OnCTAButtonClick() { }

	public void Show(int gameBundleId, int referrerSectionId, GameObject bgPrefab) { }

}

