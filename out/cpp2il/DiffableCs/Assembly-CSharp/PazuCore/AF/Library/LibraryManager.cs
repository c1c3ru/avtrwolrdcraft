namespace PazuCore.AF.Library;

public class LibraryManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Boolean> <>9__54_0; //Field offset: 0x8
		public static Predicate<Int32> <>9__71_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal bool <InitSections>b__71_0(int gameId) { }

		internal bool <Start>b__54_0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass72_0
	{
		public LibraryManager <>4__this; //Field offset: 0x10
		public MaskableGraphic image; //Field offset: 0x18
		public Action<Boolean> onFinish; //Field offset: 0x20
		public TextureWrapMode wrapMode; //Field offset: 0x28

		public <>c__DisplayClass72_0() { }

		internal void <AssignTextureToImage>b__0(string textureName) { }

		internal void <AssignTextureToImage>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass72_1
	{
		public string textureName; //Field offset: 0x10
		public <>c__DisplayClass72_0 CS$<>8__locals1; //Field offset: 0x18

		public <>c__DisplayClass72_1() { }

		internal void <AssignTextureToImage>b__2(Texture2D texture) { }

	}

	[CompilerGenerated]
	private sealed class <Start>d__54 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LibraryManager <>4__this; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <Start>d__54(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private static string _previousSceneName; //Field offset: 0x0
	private static LoadSceneMode _currentLoadSceneMode; //Field offset: 0x8
	[CompilerGenerated]
	private static bool <IsSceneOpen>k__BackingField; //Field offset: 0xC
	[CompilerGenerated]
	private static LibraryType <CurrentLibraryType>k__BackingField; //Field offset: 0x10
	private static readonly Dictionary<String, Int32> _texturesRefCountOutsideOfScene; //Field offset: 0x18
	[CompilerGenerated]
	private static Action OnSceneOpen; //Field offset: 0x20
	[CompilerGenerated]
	private static Action OnSceneClose; //Field offset: 0x28
	[CompilerGenerated]
	private static LibraryManager <Instance>k__BackingField; //Field offset: 0x30
	[SerializeField]
	private Canvas _canvas; //Field offset: 0x20
	[SerializeField]
	private ScrollRect _scrollRect; //Field offset: 0x28
	[SerializeField]
	private GameObject _bgPrefab; //Field offset: 0x30
	[SerializeField]
	private RectTransform _headerOrFooterImagePrefab; //Field offset: 0x38
	[SerializeField]
	private LibraryFeaturedSectionBase _featuredSectionPrefab; //Field offset: 0x40
	[SerializeField]
	private List<LibraryGamesScroll> _libraryGamesScrollPrefabs; //Field offset: 0x48
	[SerializeField]
	private GameObject _libraryGameWindowPrefab; //Field offset: 0x50
	[SerializeField]
	private GameObject _libraryGameBundleWindowPrefab; //Field offset: 0x58
	[SerializeField]
	private Sprite _badge_new; //Field offset: 0x60
	[SerializeField]
	private Sprite _badge_choice; //Field offset: 0x68
	[SerializeField]
	private Sprite _badge_top10; //Field offset: 0x70
	private Dictionary<String, LibraryGamesScroll> _libraryGamesScrollDictionaryPrefabs; //Field offset: 0x78
	private LibraryGameWindow _gameWindow; //Field offset: 0x80
	private LibraryGameBundleWindow _gameBundleWindow; //Field offset: 0x88
	private LibraryFeaturedSectionBase _featuredSection; //Field offset: 0x90
	private Bounds _loadingTexturesAreaBounds; //Field offset: 0x98
	private readonly Dictionary<String, HashSet`1<MaskableGraphic>> _textureNameForImageUsages; //Field offset: 0xB0
	[CompilerGenerated]
	private bool <IsSceneClosing>k__BackingField; //Field offset: 0xB8
	private bool _isShowingScene; //Field offset: 0xB9
	[CompilerGenerated]
	private float <ExtraHeaderOrFooterRightPadding>k__BackingField; //Field offset: 0xBC

	public static event Action OnSceneClose
	{
		[CompilerGenerated]
		 add { } //Length: 220
		[CompilerGenerated]
		 remove { } //Length: 220
	}

	public static event Action OnSceneOpen
	{
		[CompilerGenerated]
		 add { } //Length: 220
		[CompilerGenerated]
		 remove { } //Length: 220
	}

	public Sprite BadgeChoice
	{
		 get { } //Length: 8
	}

	public Sprite BadgeNew
	{
		 get { } //Length: 8
	}

	public Sprite BadgeTop10
	{
		 get { } //Length: 8
	}

	public private static LibraryType CurrentLibraryType
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		private set { } //Length: 92
	}

	public private float ExtraHeaderOrFooterRightPadding
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private static LibraryManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		private set { } //Length: 96
	}

	public private bool IsSceneClosing
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public private static bool IsSceneOpen
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		private set { } //Length: 96
	}

	private static LibraryManager() { }

	public LibraryManager() { }

	[CompilerGenerated]
	public static void add_OnSceneClose(Action value) { }

	[CompilerGenerated]
	public static void add_OnSceneOpen(Action value) { }

	public void AddTextureUsageForImage(string textureName, MaskableGraphic image) { }

	public string AssignTextureToImage(MaskableGraphic image, string url, Action<Boolean> onFinish = null, TextureWrapMode wrapMode = 1) { }

	private void Awake() { }

	private void CalculateTexturesLoadingAreaBounds() { }

	private void ClearTexturesUsage() { }

	public void CloseScene() { }

	private void CloseSceneImplement() { }

	public static void DecrementTextureOutsideOfSceneRefCount(string textureName) { }

	private void FreeLayouts() { }

	public Sprite get_BadgeChoice() { }

	public Sprite get_BadgeNew() { }

	public Sprite get_BadgeTop10() { }

	[CompilerGenerated]
	public static LibraryType get_CurrentLibraryType() { }

	[CompilerGenerated]
	public float get_ExtraHeaderOrFooterRightPadding() { }

	[CompilerGenerated]
	public static LibraryManager get_Instance() { }

	[CompilerGenerated]
	public bool get_IsSceneClosing() { }

	[CompilerGenerated]
	public static bool get_IsSceneOpen() { }

	public LibraryGame GetCurrentlyShownFeaturedGame() { }

	public void HideScene() { }

	public static void IncrementTextureOutsideOfSceneRefCount(string textureName) { }

	private void InitFeaturedGames() { }

	private void InitSections() { }

	private void InitSpacing(float height) { }

	public bool IsPointInsideLoadingTextureAreaBounds(Vector2 point) { }

	private void OnAddressablesFeatureClose(AddressablesFeatureType type) { }

	private void OnAddressablesFeatureOpen(AddressablesFeatureType type) { }

	private bool OnBackButton() { }

	public void OnBackButtonClick() { }

	public void OnCloseSceneWithoutCloseSceneMethod() { }

	private void OnDestroy() { }

	public void OnGameWindowClose() { }

	public static void OpenScene(LibraryType libraryType, LoadSceneMode loadSceneMode = 0, string forcePreviousScene = null) { }

	public void PlaySound(string soundName) { }

	[CompilerGenerated]
	public static void remove_OnSceneClose(Action value) { }

	[CompilerGenerated]
	public static void remove_OnSceneOpen(Action value) { }

	public static void RemoveOutsideTextureFromMemoryIfNeeded(string textureName) { }

	public void RemoveTextureUsageForImage(string textureName, MaskableGraphic image) { }

	[CompilerGenerated]
	private static void set_CurrentLibraryType(LibraryType value) { }

	[CompilerGenerated]
	private void set_ExtraHeaderOrFooterRightPadding(float value) { }

	[CompilerGenerated]
	private static void set_Instance(LibraryManager value) { }

	[CompilerGenerated]
	private void set_IsSceneClosing(bool value) { }

	[CompilerGenerated]
	private static void set_IsSceneOpen(bool value) { }

	public void ShowGameWindow(int gameId, int referrerSectionId) { }

	public void ShowScene() { }

	[IteratorStateMachine(typeof(<Start>d__54))]
	private IEnumerator Start() { }

}

