namespace PWC.QA.RTA;

public class RTAPanelLevelsSettingsPageUI : RTAPanelIndexesSettingsPageUI
{
	[CompilerGenerated]
	private struct <StartTests>d__1 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
		public RTAPanelLevelsSettingsPageUI <>4__this; //Field offset: 0x28
		private TaskAwaiter<Dictionary`2<LevelWorldType, List`1<LevelType>>> <>u__1; //Field offset: 0x30
		private TaskAwaiter <>u__2; //Field offset: 0x38

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	private bool _runWithSwitchers; //Field offset: 0x58

	public RTAPanelLevelsSettingsPageUI() { }

	protected virtual string GetLabelText_Internal() { }

	protected virtual int MaxCount_Internal() { }

	public void OnSetRunWithSwitchers(bool value) { }

	[AsyncStateMachine(typeof(<StartTests>d__1))]
	public virtual void StartTests() { }

}

