namespace PWC.QA.RTA;

public class RTAPanelUIHandler : RTAMonoBehaviour
{
	[CompilerGenerated]
	private struct <ResetWorld>d__32 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
		public RTAPanelUIHandler <>4__this; //Field offset: 0x28
		private TaskAwaiter <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <ResetWorldAsync_Internal>d__21 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		private TaskAwaiter <>u__1; //Field offset: 0x20

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <ShowPanel>d__19 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
		private TaskAwaiter <>u__1; //Field offset: 0x28

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	private const string RESOURCES_PATH = "RTA/RTAPanelCanvasUI"; //Field offset: 0x0
	private const float MIN_TIMESCALE = 1; //Field offset: 0x0
	private const float MAX_TIMESCALE = 10; //Field offset: 0x0
	private static RTAPanelUIHandler _instance; //Field offset: 0x0
	private static CanvasGroup _instanceCanvasParent; //Field offset: 0x8
	[SerializeField]
	private Transform _rtaPanelParent; //Field offset: 0x20
	[SerializeField]
	private RTAPanelStoreSettingsPageUI _storePage; //Field offset: 0x28
	[SerializeField]
	private RTAPanelLevelsSettingsPageUI _levelsPage; //Field offset: 0x30
	[SerializeField]
	private RTAPanelAllTestsSettingsPageUI _allTestsPage; //Field offset: 0x38
	[SerializeField]
	private RTAPanelLogsPageUI _logsPage; //Field offset: 0x40
	[SerializeField]
	private TMP_Text _minTimeScaleText; //Field offset: 0x48
	[SerializeField]
	private TMP_Text _maxTimeScaleText; //Field offset: 0x50
	[SerializeField]
	private Slider _timeScaleSlider; //Field offset: 0x58
	[SerializeField]
	private Button _playPauseButton; //Field offset: 0x60
	[SerializeField]
	private Button _stopButton; //Field offset: 0x68
	[SerializeField]
	private Sprite _playSprite; //Field offset: 0x70
	[SerializeField]
	private Sprite _pauseSprite; //Field offset: 0x78
	private RTAPanelSettingsPageUI _currentSettingsPage; //Field offset: 0x80

	public RTAPanelUIHandler() { }

	protected virtual void Awake() { }

	public void HidePanel() { }

	[AsyncStateMachine(typeof(<ResetWorld>d__32))]
	public void ResetWorld() { }

	[AsyncStateMachine(typeof(<ResetWorldAsync_Internal>d__21))]
	private static Task ResetWorldAsync_Internal() { }

	private void SetTestsPlayMode_Internal(TestPlayMode playMode) { }

	private void SetTimeScale_Internal(float timeScale) { }

	public void ShowAllTestsPage() { }

	public void ShowLevelsTestsPage() { }

	public void ShowLogsPage() { }

	[AsyncStateMachine(typeof(<ShowPanel>d__19))]
	public static void ShowPanel() { }

	private void ShowPanel_Internal() { }

	private void ShowSingleSettingsPage_Internal(RTAPanelSettingsPageUI settingsPage) { }

	public void ShowStoreTestsPage() { }

	public static void StartTests() { }

	private void StopTests_Internal() { }

	private void TestsTogglePlayMode_Internal() { }

}

