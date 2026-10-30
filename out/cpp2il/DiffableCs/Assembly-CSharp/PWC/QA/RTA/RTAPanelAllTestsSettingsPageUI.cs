namespace PWC.QA.RTA;

public class RTAPanelAllTestsSettingsPageUI : RTAPanelSettingsPageUI
{
	[CompilerGenerated]
	private struct <StartTests>d__0 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
		[TupleElementNames(new IL2CPP_TYPE_STRING[] {"itemIndex", "item"})]
		private List<ValueTuple`2<Int32, Item>> <>7__wrap1; //Field offset: 0x28
		private TaskAwaiter<Dictionary`2<LevelWorldType, List`1<LevelType>>> <>u__1; //Field offset: 0x30
		private TaskAwaiter <>u__2; //Field offset: 0x38

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}


	public RTAPanelAllTestsSettingsPageUI() { }

	protected virtual string GetInformationText_Internal() { }

	protected virtual string GetLabelText_Internal() { }

	[AsyncStateMachine(typeof(<StartTests>d__0))]
	public virtual void StartTests() { }

}

