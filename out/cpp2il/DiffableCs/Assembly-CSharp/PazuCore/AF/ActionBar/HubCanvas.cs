namespace PazuCore.AF.ActionBar;

public class HubCanvas : AddressablesFeatureViewBase
{
	[CompilerGenerated]
	private static HubCanvas <Instance>k__BackingField; //Field offset: 0x0
	[SerializeField]
	private Image _animBg; //Field offset: 0x48
	[SerializeField]
	private HubButtons _hubButtons; //Field offset: 0x50
	[SerializeField]
	private Animator _animator; //Field offset: 0x58
	[SerializeField]
	private GameObject _nextGameHandler; //Field offset: 0x60
	[SerializeField]
	private Canvas _canvas; //Field offset: 0x68
	private Action _switchTabAction; //Field offset: 0x70
	private bool _multiTouchEnabledOnAwake; //Field offset: 0x78
	[CompilerGenerated]
	private HashSet<String> <SceneNamesToIgnore>k__BackingField; //Field offset: 0x80

	public HubButtons HubButtons
	{
		 get { } //Length: 8
	}

	public private static HubCanvas Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public private HashSet<String> SceneNamesToIgnore
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public HubCanvas() { }

	protected virtual void Awake() { }

	public HubButtons get_HubButtons() { }

	[CompilerGenerated]
	public static HubCanvas get_Instance() { }

	[CompilerGenerated]
	public HashSet<String> get_SceneNamesToIgnore() { }

	public Vector3 GetFooterTopPosition() { }

	public Vector3 GetHeaderTopPosition() { }

	public void GoHome() { }

	public void GoLibrary() { }

	private void InvokeSwitchTabAction() { }

	private void OnAddressablesFeatureClose(AddressablesFeatureType type) { }

	private void OnAddressablesFeatureOpen(AddressablesFeatureType type) { }

	private void OnDeepLinkContentInvokedSuccessfully() { }

	protected virtual void OnDestroy() { }

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) { }

	private void OnSceneUnloaded(Scene scene) { }

	[CompilerGenerated]
	private static void set_Instance(HubCanvas value) { }

	[CompilerGenerated]
	private void set_SceneNamesToIgnore(HashSet<String> value) { }

	private void Start() { }

	public void SwitchTab(Action onSwitchTab) { }

}

