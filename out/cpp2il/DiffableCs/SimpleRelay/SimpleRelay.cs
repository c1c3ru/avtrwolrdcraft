//Type is in global namespace

public class SimpleRelay : MonoBehaviour
{
	[CompilerGenerated]
	private struct <OnAllocate>d__18 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
		public SimpleRelay <>4__this; //Field offset: 0x28
		private TaskAwaiter<Allocation> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <OnJoin>d__21 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
		public SimpleRelay <>4__this; //Field offset: 0x28
		private TaskAwaiter<JoinAllocation> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <OnJoinCode>d__20 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
		public SimpleRelay <>4__this; //Field offset: 0x28
		private TaskAwaiter<String> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <OnRegion>d__17 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
		public SimpleRelay <>4__this; //Field offset: 0x28
		private TaskAwaiter<List`1<Region>> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <OnSignIn>d__16 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
		public SimpleRelay <>4__this; //Field offset: 0x28
		private TaskAwaiter <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <Start>d__14 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
		public SimpleRelay <>4__this; //Field offset: 0x28
		private TaskAwaiter <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	public Text PlayerIdText; //Field offset: 0x20
	public Dropdown RegionsDropdown; //Field offset: 0x28
	public Text HostAllocationIdText; //Field offset: 0x30
	public Text JoinCodeText; //Field offset: 0x38
	public Text PlayerAllocationIdText; //Field offset: 0x40
	private Guid hostAllocationId; //Field offset: 0x48
	private Guid playerAllocationId; //Field offset: 0x58
	private string allocationRegion; //Field offset: 0x68
	private string joinCode; //Field offset: 0x70
	private string playerId; //Field offset: 0x78
	private string autoSelectRegionName; //Field offset: 0x80
	private int regionAutoSelectIndex; //Field offset: 0x88
	private List<Region> regions; //Field offset: 0x90
	private List<String> regionOptions; //Field offset: 0x98

	public SimpleRelay() { }

	[CompilerGenerated]
	private bool <UpdateUI>b__15_0(OptionData option) { }

	private string GetRegionOrQosDefault() { }

	[AsyncStateMachine(typeof(<OnAllocate>d__18))]
	public void OnAllocate() { }

	[AsyncStateMachine(typeof(<OnJoin>d__21))]
	public void OnJoin() { }

	[AsyncStateMachine(typeof(<OnJoinCode>d__20))]
	public void OnJoinCode() { }

	[AsyncStateMachine(typeof(<OnRegion>d__17))]
	public void OnRegion() { }

	[AsyncStateMachine(typeof(<OnSignIn>d__16))]
	public void OnSignIn() { }

	[AsyncStateMachine(typeof(<Start>d__14))]
	private void Start() { }

	private void UpdateUI() { }

}

