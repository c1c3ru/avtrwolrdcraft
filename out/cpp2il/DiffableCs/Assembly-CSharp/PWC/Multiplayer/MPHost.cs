namespace PWC.Multiplayer;

public class MPHost : MPRelayConnectionBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass40_0
	{
		public MPHost <>4__this; //Field offset: 0x10
		public NetworkConnection connection; //Field offset: 0x18

		public <>c__DisplayClass40_0() { }

		internal void <SendSystemPopup>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass41_0
	{
		public MPHost <>4__this; //Field offset: 0x10
		public int playerUID; //Field offset: 0x18

		public <>c__DisplayClass41_0() { }

		internal void <DisconnectFromClientWithMessage>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass42_0
	{
		public MPHost <>4__this; //Field offset: 0x10
		public NetworkConnection incomingConnection; //Field offset: 0x18
		public Action <>9__0; //Field offset: 0x20

		public <>c__DisplayClass42_0() { }

		internal void <UpdateHost>b__0() { }

	}

	[CompilerGenerated]
	private struct <AllocateHost>d__33 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public MPHost <>4__this; //Field offset: 0x20
		private int <maxConnections>5__2; //Field offset: 0x28
		private TaskAwaiter<Allocation> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <GetJoinCode>d__35 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<String> <>t__builder; //Field offset: 0x8
		public MPHost <>4__this; //Field offset: 0x20
		private TaskAwaiter<String> <>u__1; //Field offset: 0x28

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <InitInternal>d__32 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public MPHost <>4__this; //Field offset: 0x20
		private TaskAwaiter <>u__1; //Field offset: 0x28
		private TaskAwaiter<String> <>u__2; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	private const int MAX_UID_VALUE = 100; //Field offset: 0x0
	private const int MAX_CONNECTIONS = 3; //Field offset: 0x0
	private int _uidCounter; //Field offset: 0x60
	private int _changesCounter; //Field offset: 0x64
	private readonly Dictionary<Int32, Int32> _idToUID; //Field offset: 0x68
	private readonly Dictionary<Int32, Int32> _uidToID; //Field offset: 0x70
	private Allocation _hostAllocation; //Field offset: 0x78
	private NetworkDriver _hostDriver; //Field offset: 0x80
	private NativeList<NetworkConnection> _serverConnections; //Field offset: 0x330
	private NetworkPipeline _hostPipeline; //Field offset: 0x340
	private bool _didReachedUIDLimitOnce; //Field offset: 0x344
	[CompilerGenerated]
	private bool <IsReady>k__BackingField; //Field offset: 0x345
	[CompilerGenerated]
	private Action<String> OnReadyAction; //Field offset: 0x348
	[CompilerGenerated]
	private Action<Int32, Int32> OnConnectionAddedAction; //Field offset: 0x350
	[CompilerGenerated]
	private Action<Int32> OnConnectionRemovedAction; //Field offset: 0x358

	public event Action<Int32, Int32> OnConnectionAddedAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Action<Int32> OnConnectionRemovedAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Action<String> OnReadyAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public private bool IsReady
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public MPHost() { }

	[CompilerGenerated]
	[DebuggerHidden]
	private Task <>n__0() { }

	[CompilerGenerated]
	private void <DisconnectAndDestroy_Implementation>b__28_0() { }

	[CompilerGenerated]
	public void add_OnConnectionAddedAction(Action<Int32, Int32> value) { }

	[CompilerGenerated]
	public void add_OnConnectionRemovedAction(Action<Int32> value) { }

	[CompilerGenerated]
	public void add_OnReadyAction(Action<String> value) { }

	[AsyncStateMachine(typeof(<AllocateHost>d__33))]
	private Task AllocateHost() { }

	private void Awake() { }

	private void BindHostToRelay() { }

	protected virtual void DisconnectAndDestroy_Implementation() { }

	private void DisconnectClients() { }

	private void DisconnectFromClient(int playerUID) { }

	public void DisconnectFromClientWithMessage(int playerUID, PopupType popupType) { }

	[CompilerGenerated]
	public bool get_IsReady() { }

	public IReadOnlyCollection<Int32> GetAllPlayersUIDs() { }

	public int GetConnectionsCount() { }

	[AsyncStateMachine(typeof(<GetJoinCode>d__35))]
	private Task<String> GetJoinCode() { }

	private int GetNextAvailableUID() { }

	private int GetNextUID() { }

	[AsyncStateMachine(typeof(<InitInternal>d__32))]
	protected virtual Task InitInternal() { }

	private void OnDestroy() { }

	protected virtual void ReceiveData(MPDataBase data, int connectionIndex) { }

	[CompilerGenerated]
	public void remove_OnConnectionAddedAction(Action<Int32, Int32> value) { }

	[CompilerGenerated]
	public void remove_OnConnectionRemovedAction(Action<Int32> value) { }

	[CompilerGenerated]
	public void remove_OnReadyAction(Action<String> value) { }

	private void SendMessageToClients_Internal(Byte[] bytes, ICollection<Int32> uids) { }

	protected virtual void SendMessageToNetwork_Implementation(Byte[] data, ICollection<Int32> uids = null) { }

	private void SendSystemPopup(NetworkConnection connection, PopupType popupType) { }

	[CompilerGenerated]
	private void set_IsReady(bool value) { }

	private void Update() { }

	private void UpdateHost() { }

}

