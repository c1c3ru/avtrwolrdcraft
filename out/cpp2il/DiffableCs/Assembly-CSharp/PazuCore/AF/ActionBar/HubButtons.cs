namespace PazuCore.AF.ActionBar;

public class HubButtons : MonoBehaviour
{
	internal enum ViewMode
	{
		Home = 0,
		WithoutHeader = 1,
		Snapshot = 2,
	}

	[SerializeField]
	private GameObject _plusButton; //Field offset: 0x20
	[SerializeField]
	private GameObject _header; //Field offset: 0x28
	[SerializeField]
	private GameObject _footer; //Field offset: 0x30
	[SerializeField]
	private Toggle _libraryToggle; //Field offset: 0x38
	[SerializeField]
	private Toggle _homeToggle; //Field offset: 0x40
	[SerializeField]
	private GameHomePlayButton _gameHomePlayButton; //Field offset: 0x48
	[SerializeField]
	private GameObject _emptyWidget; //Field offset: 0x50
	[SerializeField]
	private GameObject _nextGameWidget; //Field offset: 0x58
	[CompilerGenerated]
	private ViewMode <CurrentViewMode>k__BackingField; //Field offset: 0x60
	private bool _useHomePlayButton; //Field offset: 0x64

	public private ViewMode CurrentViewMode
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public RectTransform FooterRectTransform
	{
		 get { } //Length: 104
	}

	public RectTransform HeaderRectTransform
	{
		 get { } //Length: 104
	}

	public Toggle HomeToggle
	{
		 get { } //Length: 8
	}

	public Toggle LibraryToggle
	{
		 get { } //Length: 8
	}

	public HubButtons() { }

	public void ActiveFooter() { }

	private void Awake() { }

	[CompilerGenerated]
	public ViewMode get_CurrentViewMode() { }

	public RectTransform get_FooterRectTransform() { }

	public RectTransform get_HeaderRectTransform() { }

	public Toggle get_HomeToggle() { }

	public Toggle get_LibraryToggle() { }

	private bool OnBackButton() { }

	private void OnDestroy() { }

	public void OnTapBuyButton() { }

	private void OnUserSync(SyncType syncType) { }

	[CompilerGenerated]
	private void set_CurrentViewMode(ViewMode value) { }

	public void ShowHubHomeMode() { }

	public void ShowHubSnapshotMode() { }

	public void ShowHubWithoutHeader() { }

	private void Start() { }

	private void SyncButtons() { }

	private void SyncGameHomeButton() { }

}

