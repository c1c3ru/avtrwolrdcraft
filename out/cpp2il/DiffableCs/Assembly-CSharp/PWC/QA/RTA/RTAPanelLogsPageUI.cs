namespace PWC.QA.RTA;

public class RTAPanelLogsPageUI : RTAPanelSettingsPageUI
{
	[CompilerGenerated]
	private struct <StartTests>d__7 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
		private TaskAwaiter <>u__1; //Field offset: 0x28

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[SerializeField]
	private GameObject _panel; //Field offset: 0x40
	[SerializeField]
	private TMP_Text _text; //Field offset: 0x48
	[SerializeField]
	private ScrollRect _scroll; //Field offset: 0x50
	private string _errorSummaryLogPath; //Field offset: 0x58
	private string _warningSummaryLogPath; //Field offset: 0x60
	private string _fullLogPath; //Field offset: 0x68
	private string _assertionLogsPath; //Field offset: 0x70

	public RTAPanelLogsPageUI() { }

	protected virtual string GetInformationText_Internal() { }

	protected virtual string GetLabelText_Internal() { }

	public void HideLogs() { }

	public void OnSetLogType(int index) { }

	public void SetText(string text) { }

	public void ShowAssertionLogs() { }

	public void ShowErrors() { }

	public void ShowFullLogs() { }

	public void ShowLogs() { }

	public void ShowWarnings() { }

	[AsyncStateMachine(typeof(<StartTests>d__7))]
	public virtual void StartTests() { }

}

