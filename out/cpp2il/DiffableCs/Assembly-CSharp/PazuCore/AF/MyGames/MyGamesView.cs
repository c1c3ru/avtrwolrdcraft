namespace PazuCore.AF.MyGames;

public class MyGamesView : AddressablesFeatureViewBase
{
	[CompilerGenerated]
	private static bool <IsSceneOpen>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private static MyGamesView <Instance>k__BackingField; //Field offset: 0x8
	[SerializeField]
	private Canvas _canvas; //Field offset: 0x48
	[SerializeField]
	private RectTransform _loadingArea; //Field offset: 0x50
	[SerializeField]
	private CanvasScaler _canvasScaler; //Field offset: 0x58
	private Bounds _loadingTexturesAreaBounds; //Field offset: 0x60
	private List<Int32> _installedGames; //Field offset: 0x78

	public private static MyGamesView Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public private static bool IsSceneOpen
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public MyGamesView() { }

	protected virtual void Awake() { }

	private void CalculateTexturesLoadingAreaBounds() { }

	public void CloseScene() { }

	[CompilerGenerated]
	public static MyGamesView get_Instance() { }

	[CompilerGenerated]
	public static bool get_IsSceneOpen() { }

	public void Init() { }

	public bool IsPointInsideLoadingTextureAreaBounds(Vector2 point) { }

	private void OnAddressablesFeatureClose(AddressablesFeatureType type) { }

	private void OnAddressablesFeatureOpen(AddressablesFeatureType type) { }

	private bool OnBackButton() { }

	protected virtual void OnDestroy() { }

	public static void OpenScene() { }

	[CompilerGenerated]
	private static void set_Instance(MyGamesView value) { }

	[CompilerGenerated]
	private static void set_IsSceneOpen(bool value) { }

}

