namespace PWC.Multiplayer;

public class MPClient : MPRelayConnectionBase
{
	[CompilerGenerated]
	private struct <InitInternal>d__16 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public MPClient <>4__this; //Field offset: 0x20
		private TaskAwaiter <>u__1; //Field offset: 0x28

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <JoinHost>d__17 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
		public MPClient <>4__this; //Field offset: 0x28
		public Action<Boolean> onFinish; //Field offset: 0x30
		public string joinCode; //Field offset: 0x38
		private TaskAwaiter<JoinAllocation> <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	private JoinAllocation _clientAllocation; //Field offset: 0x60
	private NetworkDriver _clientDriver; //Field offset: 0x68
	private NetworkConnection _clientConnection; //Field offset: 0x318
	private NetworkPipeline _clientPipeline; //Field offset: 0x320
	[CompilerGenerated]
	private bool <IsReady>k__BackingField; //Field offset: 0x324
	[CompilerGenerated]
	private Action OnDisconnectedFromHostAction; //Field offset: 0x328
	[CompilerGenerated]
	private Action OnConnectedToHostAction; //Field offset: 0x330

	public event Action OnConnectedToHostAction
	{
		[CompilerGenerated]
		 add { } //Length: 160
		[CompilerGenerated]
		 remove { } //Length: 160
	}

	public event Action OnDisconnectedFromHostAction
	{
		[CompilerGenerated]
		 add { } //Length: 160
		[CompilerGenerated]
		 remove { } //Length: 160
	}

	public private bool IsReady
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public MPClient() { }

	[CompilerGenerated]
	[DebuggerHidden]
	private Task <>n__0() { }

	[CompilerGenerated]
	private void <DisconnectAndDestroy_Implementation>b__18_0() { }

	[CompilerGenerated]
	public void add_OnConnectedToHostAction(Action value) { }

	[CompilerGenerated]
	public void add_OnDisconnectedFromHostAction(Action value) { }

	private void BindClientToRelay() { }

	private void ConnectClient() { }

	protected virtual void DisconnectAndDestroy_Implementation() { }

	private void DisconnectClient() { }

	[CompilerGenerated]
	public bool get_IsReady() { }

	[AsyncStateMachine(typeof(<InitInternal>d__16))]
	protected virtual Task InitInternal() { }

	[AsyncStateMachine(typeof(<JoinHost>d__17))]
	public void JoinHost(string joinCode, Action<Boolean> onFinish) { }

	private void OnDestroy() { }

	protected virtual void ReceiveData(MPDataBase data, int connectionIndex) { }

	[CompilerGenerated]
	public void remove_OnConnectedToHostAction(Action value) { }

	[CompilerGenerated]
	public void remove_OnDisconnectedFromHostAction(Action value) { }

	private void SendMessageToHost_Internal(Byte[] bytes) { }

	protected virtual void SendMessageToNetwork_Implementation(Byte[] data, ICollection<Int32> uids) { }

	[CompilerGenerated]
	private void set_IsReady(bool value) { }

	private void Update() { }

	private void UpdateClient() { }

}

