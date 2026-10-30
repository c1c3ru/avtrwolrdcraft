namespace Unity.Services.Wire.Internal;

internal class Client : IWire, IServiceComponent
{
	[CompilerGenerated]
	private struct <<OnIdentityChanged>b__27_0>d : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public Client <>4__this; //Field offset: 0x20
		private TaskAwaiter <>u__1; //Field offset: 0x28

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass39_0
	{
		public Client <>4__this; //Field offset: 0x10
		public TimeSpan duration; //Field offset: 0x18

		public <>c__DisplayClass39_0() { }

		internal void <CheckNetworkState>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass45_0
	{
		public TaskCompletionSource<Boolean> tcs; //Field offset: 0x10

		public <>c__DisplayClass45_0() { }

		internal void <SubscribeAsync>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass46_0
	{
		private struct <<CreateChannel>b__0>d : IAsyncStateMachine
		{
			public int <>1__state; //Field offset: 0x0
			public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
			public <>c__DisplayClass46_0 <>4__this; //Field offset: 0x28
			public TaskCompletionSource<Boolean> completionSource; //Field offset: 0x30
			private TaskAwaiter <>u__1; //Field offset: 0x38

			private override void MoveNext() { }

			[DebuggerHidden]
			private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

		}

		private struct <<CreateChannel>b__1>d : IAsyncStateMachine
		{
			public int <>1__state; //Field offset: 0x0
			public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
			public <>c__DisplayClass46_0 <>4__this; //Field offset: 0x28
			public TaskCompletionSource<Boolean> completionSource; //Field offset: 0x30
			private TaskAwaiter <>u__1; //Field offset: 0x38

			private override void MoveNext() { }

			[DebuggerHidden]
			private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

		}

		public Client <>4__this; //Field offset: 0x10
		public Subscription subscription; //Field offset: 0x18

		public <>c__DisplayClass46_0() { }

		[AsyncStateMachine(typeof(<<CreateChannel>b__0>d))]
		internal void <CreateChannel>b__0(TaskCompletionSource<Boolean> completionSource) { }

		[AsyncStateMachine(typeof(<<CreateChannel>b__1>d))]
		internal void <CreateChannel>b__1(TaskCompletionSource<Boolean> completionSource) { }

		internal void <CreateChannel>b__2() { }

		internal void <CreateChannel>b__3() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass50_0
	{
		public Client <>4__this; //Field offset: 0x10
		public WebSocketCloseCode code; //Field offset: 0x18

		public <>c__DisplayClass50_0() { }

		internal void <WebsocketCloseListener>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass51_0
	{
		public Client <>4__this; //Field offset: 0x10
		public string msg; //Field offset: 0x18

		public <>c__DisplayClass51_0() { }

		internal void <WebsocketErrorListener>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass52_0
	{
		public Client <>4__this; //Field offset: 0x10
		public Byte[] data; //Field offset: 0x18

		public <>c__DisplayClass52_0() { }

		internal void <WebsocketMessageListener>b__0() { }

	}

	[CompilerGenerated]
	private struct <ConnectAsync>d__30 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public Client <>4__this; //Field offset: 0x20
		private TaskAwaiter<ConnectionState> <>u__1; //Field offset: 0x28

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <OnWebsocketOpen>d__31 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
		public Client <>4__this; //Field offset: 0x28
		private TaskAwaiter<Dictionary`2<String, SubscribeRequest>> <>u__1; //Field offset: 0x30
		private TaskAwaiter<Reply> <>u__2; //Field offset: 0x38

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <ResetAsync>d__29 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public Client <>4__this; //Field offset: 0x20
		public bool reconnect; //Field offset: 0x28
		private TaskAwaiter <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <SendCommandAsync>d__26 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Reply> <>t__builder; //Field offset: 0x8
		public Client <>4__this; //Field offset: 0x20
		public Command command; //Field offset: 0x28
		public uint id; //Field offset: 0x30
		private DateTime <time>5__2; //Field offset: 0x38
		private Dictionary<String, String> <tags>5__3; //Field offset: 0x40
		private TaskAwaiter<ConnectionState> <>u__1; //Field offset: 0x48
		private TaskAwaiter<Reply> <>u__2; //Field offset: 0x50

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <SubscribeAsync>d__45 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public Client <>4__this; //Field offset: 0x20
		private <>c__DisplayClass45_0 <>8__1; //Field offset: 0x28
		public Subscription subscription; //Field offset: 0x30
		private TaskAwaiter <>u__1; //Field offset: 0x38
		private TaskAwaiter<Boolean> <>u__2; //Field offset: 0x40
		private TaskAwaiter<String> <>u__3; //Field offset: 0x48
		private TaskAwaiter<Reply> <>u__4; //Field offset: 0x50

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <UnsubscribeAsync>d__48 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public Client <>4__this; //Field offset: 0x20
		public Subscription subscription; //Field offset: 0x28
		private TaskAwaiter<Reply> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <WebsocketCloseListener>d__50 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
		public Client <>4__this; //Field offset: 0x28
		public WebSocketCloseCode code; //Field offset: 0x30
		private TaskAwaiter <>u__1; //Field offset: 0x38

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <WebsocketErrorListener>d__51 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
		public Client <>4__this; //Field offset: 0x28
		public string msg; //Field offset: 0x30
		private TaskAwaiter <>u__1; //Field offset: 0x38

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <WebsocketMessageListener>d__52 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
		public Client <>4__this; //Field offset: 0x28
		public Byte[] data; //Field offset: 0x30
		private TaskAwaiter <>u__1; //Field offset: 0x38

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <WebsocketOpenListener>d__49 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
		public Client <>4__this; //Field offset: 0x28
		private TaskAwaiter <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	public enum ConnectionState
	{
		Disconnected = 0,
		Connected = 1,
		Connecting = 2,
		Disconnecting = 3,
	}

	public readonly ISubscriptionRepository SubscriptionRepository; //Field offset: 0x10
	private TaskCompletionSource<ConnectionState> m_ConnectionCompletionSource; //Field offset: 0x18
	private TaskCompletionSource<ConnectionState> m_DisconnectionCompletionSource; //Field offset: 0x20
	internal ConnectionState m_ConnectionState; //Field offset: 0x28
	private IWebSocket m_WebsocketClient; //Field offset: 0x30
	internal IBackoffStrategy m_Backoff; //Field offset: 0x38
	private readonly CommandManager m_CommandManager; //Field offset: 0x40
	private readonly Configuration m_Config; //Field offset: 0x48
	private readonly IMetrics m_Metrics; //Field offset: 0x50
	private readonly IUnityThreadUtils m_ThreadUtils; //Field offset: 0x58
	private readonly IWebsocketFactory m_WebsocketFactory; //Field offset: 0x60
	[CompilerGenerated]
	private Action m_OnConnected; //Field offset: 0x68
	internal bool m_WantConnected; //Field offset: 0x70
	internal Byte[] k_PongMessage; //Field offset: 0x78
	private bool m_Disabled; //Field offset: 0x80
	private bool m_Pong; //Field offset: 0x81
	private uint m_ServerPingIntervalS; //Field offset: 0x84
	private TimeSpan m_NetworkCheckInterval; //Field offset: 0x88
	private IActionScheduler m_ActionScheduler; //Field offset: 0x90
	private long m_PingDeadlineScheduledId; //Field offset: 0x98
	private long m_ReconnectionActionId; //Field offset: 0xA0

	private event Action m_OnConnected
	{
		[CompilerGenerated]
		private add { } //Length: 156
		[CompilerGenerated]
		private remove { } //Length: 156
	}

	public Client(Configuration config, IActionScheduler actionScheduler, IMetrics metrics, IUnityThreadUtils threadUtils, IWebsocketFactory websocketFactory) { }

	[CompilerGenerated]
	private void <.ctor>b__24_0(int subscriptionCount) { }

	[AsyncStateMachine(typeof(<<OnIdentityChanged>b__27_0>d))]
	[CompilerGenerated]
	private Task <OnIdentityChanged>b__27_0() { }

	[CompilerGenerated]
	private void <OnWebsocketClose>b__38_0() { }

	[CompilerGenerated]
	private void <OnWebsocketClose>b__38_1() { }

	[CompilerGenerated]
	private void add_m_OnConnected(Action value) { }

	private void CancelPingDeadline() { }

	private void ChangeConnectionState(ConnectionState state) { }

	internal long CheckNetworkState(TimeSpan duration) { }

	[AsyncStateMachine(typeof(<ConnectAsync>d__30))]
	public Task ConnectAsync() { }

	public override IChannel CreateChannel(IChannelTokenProvider tokenProvider) { }

	public void Disable() { }

	internal Task DisconnectAsync() { }

	private void HandleCommandReply(Reply reply) { }

	private void HandlePushMessage(Push push) { }

	private void HandleServerPing() { }

	internal Configuration InitNetworkUtil(Configuration config) { }

	private void InitWebsocket() { }

	internal void OnIdentityChanged(string playerId) { }

	internal void OnWebsocketClose(WebSocketCloseCode originalCode) { }

	private void OnWebsocketError(string msg) { }

	internal void OnWebsocketMessage(Byte[] payload) { }

	[AsyncStateMachine(typeof(<OnWebsocketOpen>d__31))]
	internal void OnWebsocketOpen() { }

	private void PingDeadline() { }

	[CompilerGenerated]
	private void remove_m_OnConnected(Action value) { }

	[AsyncStateMachine(typeof(<ResetAsync>d__29))]
	internal Task ResetAsync(bool reconnect) { }

	[AsyncStateMachine(typeof(<SendCommandAsync>d__26))]
	private Task<Reply> SendCommandAsync(uint id, Command command) { }

	private void SetupPingDeadline() { }

	private bool ShouldReconnect(CentrifugeCloseCode code) { }

	[AsyncStateMachine(typeof(<SubscribeAsync>d__45))]
	private Task SubscribeAsync(Subscription subscription) { }

	[AsyncStateMachine(typeof(<UnsubscribeAsync>d__48))]
	private Task UnsubscribeAsync(Subscription subscription) { }

	[AsyncStateMachine(typeof(<WebsocketCloseListener>d__50))]
	private void WebsocketCloseListener(WebSocketCloseCode code) { }

	[AsyncStateMachine(typeof(<WebsocketErrorListener>d__51))]
	private void WebsocketErrorListener(string msg) { }

	[AsyncStateMachine(typeof(<WebsocketMessageListener>d__52))]
	private void WebsocketMessageListener(Byte[] data) { }

	[AsyncStateMachine(typeof(<WebsocketOpenListener>d__49))]
	private void WebsocketOpenListener() { }

}

