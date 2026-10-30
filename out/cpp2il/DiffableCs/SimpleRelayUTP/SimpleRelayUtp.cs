//Type is in global namespace

public class SimpleRelayUtp : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass36_0
	{
		public Action clickButton; //Field offset: 0x10
		public InputField inputField; //Field offset: 0x18

		public <>c__DisplayClass36_0() { }

		internal void <AddEnterKeyListenerToInputField>b__0(string _) { }

	}

	[CompilerGenerated]
	private struct <OnAllocate>d__46 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
		public SimpleRelayUtp <>4__this; //Field offset: 0x28
		private int <maxConnections>5__2; //Field offset: 0x30
		private TaskAwaiter<Allocation> <>u__1; //Field offset: 0x38

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <OnJoin>d__49 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
		public SimpleRelayUtp <>4__this; //Field offset: 0x28
		private TaskAwaiter<JoinAllocation> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <OnJoinCode>d__48 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
		public SimpleRelayUtp <>4__this; //Field offset: 0x28
		private TaskAwaiter<String> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <OnRegion>d__44 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
		public SimpleRelayUtp <>4__this; //Field offset: 0x28
		private TaskAwaiter<List`1<Region>> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <OnSignIn>d__43 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
		public SimpleRelayUtp <>4__this; //Field offset: 0x28
		private TaskAwaiter <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <Start>d__35 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
		public SimpleRelayUtp <>4__this; //Field offset: 0x28
		private TaskAwaiter <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	public Text HostPlayerIdText; //Field offset: 0x20
	public Text PlayerPlayerIdText; //Field offset: 0x28
	public Dropdown RegionsDropdown; //Field offset: 0x30
	public Text HostAllocationIdText; //Field offset: 0x38
	public Text JoinCodeText; //Field offset: 0x40
	public InputField JoinCodeInput; //Field offset: 0x48
	public Text PlayerAllocationIdText; //Field offset: 0x50
	public Text PlayerRegionText; //Field offset: 0x58
	public Text HostBoundText; //Field offset: 0x60
	public Text PlayerBoundText; //Field offset: 0x68
	public Text PlayerConnectedText; //Field offset: 0x70
	public InputField HostMessageInput; //Field offset: 0x78
	public InputField PlayerMessageInput; //Field offset: 0x80
	public GameObject MainMenuPanel; //Field offset: 0x88
	public GameObject HostPanel; //Field offset: 0x90
	public GameObject PlayerPanel; //Field offset: 0x98
	public Text HostMessageReceivedText; //Field offset: 0xA0
	public Text HostConnectedPlayersText; //Field offset: 0xA8
	public Text PlayerMessageReceivedText; //Field offset: 0xB0
	private string joinCode; //Field offset: 0xB8
	private string playerId; //Field offset: 0xC0
	private string autoSelectRegionName; //Field offset: 0xC8
	private int regionAutoSelectIndex; //Field offset: 0xD0
	private List<Region> regions; //Field offset: 0xD8
	private List<String> regionOptions; //Field offset: 0xE0
	private string hostLatestMessageReceived; //Field offset: 0xE8
	private string playerLatestMessageReceived; //Field offset: 0xF0
	private Allocation hostAllocation; //Field offset: 0xF8
	private JoinAllocation playerAllocation; //Field offset: 0x100
	private bool isHost; //Field offset: 0x108
	private bool isPlayer; //Field offset: 0x109
	private NetworkDriver hostDriver; //Field offset: 0x110
	private NetworkDriver playerDriver; //Field offset: 0x3C0
	private NativeList<NetworkConnection> serverConnections; //Field offset: 0x670
	private NetworkConnection clientConnection; //Field offset: 0x680

	public SimpleRelayUtp() { }

	[CompilerGenerated]
	private bool <UpdateHostUI>b__39_0(OptionData option) { }

	private void AddEnterKeyListenerToInputField(InputField inputField, Action clickButton) { }

	private string GetRegionOrQosDefault() { }

	[AsyncStateMachine(typeof(<OnAllocate>d__46))]
	public void OnAllocate() { }

	public void OnBindHost() { }

	public void OnBindPlayer() { }

	public void OnConnectPlayer() { }

	private void OnDestroy() { }

	public void OnDisconnect() { }

	public void OnDisconnectPlayers() { }

	public void OnHostSendMessage() { }

	[AsyncStateMachine(typeof(<OnJoin>d__49))]
	public void OnJoin() { }

	[AsyncStateMachine(typeof(<OnJoinCode>d__48))]
	public void OnJoinCode() { }

	public void OnPlayerSendMessage() { }

	[AsyncStateMachine(typeof(<OnRegion>d__44))]
	public void OnRegion() { }

	[AsyncStateMachine(typeof(<OnSignIn>d__43))]
	public void OnSignIn() { }

	public void OnStartClientAsHost() { }

	public void OnStartClientAsPlayer() { }

	[AsyncStateMachine(typeof(<Start>d__35))]
	private void Start() { }

	private void Update() { }

	private void UpdateHost() { }

	private void UpdateHostUI() { }

	private void UpdatePlayer() { }

	private void UpdatePlayerUI() { }

}

