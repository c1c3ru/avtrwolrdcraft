namespace Unity.Services.Lobbies.Internal;

internal class LobbyChannel : ILobbyEvents
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		private struct <<-ctor>b__0>d : IAsyncStateMachine
		{
			public int <>1__state; //Field offset: 0x0
			public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
			public <>c__DisplayClass10_0 <>4__this; //Field offset: 0x28
			public string payload; //Field offset: 0x30
			private TaskAwaiter <>u__1; //Field offset: 0x38

			private override void MoveNext() { }

			[DebuggerHidden]
			private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

		}

		public LobbyChannel <>4__this; //Field offset: 0x10
		public LobbyEventCallbacks callbacks; //Field offset: 0x18

		public <>c__DisplayClass10_0() { }

		[AsyncStateMachine(typeof(<<-ctor>b__0>d))]
		internal void <.ctor>b__0(string payload) { }

		internal void <.ctor>b__1() { }

		internal void <.ctor>b__2(SubscriptionState state) { }

	}

	[CompilerGenerated]
	private struct <HandleLobbyChanges>d__16 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public LobbyChannel <>4__this; //Field offset: 0x20
		public ILobbyChanges changes; //Field offset: 0x28
		public LobbyEventCallbacks callbacks; //Field offset: 0x30
		private ILobbyChanges <nextToProcess>5__2; //Field offset: 0x38
		private TaskAwaiter <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <OnLobbySubscriptionMessage>d__13 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public string payload; //Field offset: 0x20
		public LobbyChannel <>4__this; //Field offset: 0x28
		public LobbyEventCallbacks callbacks; //Field offset: 0x30
		private TaskAwaiter <>u__1; //Field offset: 0x38

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <ProcessEvent>d__17 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public LobbyChannel <>4__this; //Field offset: 0x20
		public ILobbyChanges nextToProcess; //Field offset: 0x28
		public LobbyEventCallbacks callbacks; //Field offset: 0x30
		private Dictionary<String, Lobby> <lobbyCacheDict>5__2; //Field offset: 0x38
		private Lobby <cachedLobby>5__3; //Field offset: 0x40
		private TaskAwaiter<Lobby> <>u__1; //Field offset: 0x48

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <SubscribeAsync>d__11 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public LobbyChannel <>4__this; //Field offset: 0x20
		private TaskAwaiter <>u__1; //Field offset: 0x28

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <UnsubscribeAsync>d__12 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public LobbyChannel <>4__this; //Field offset: 0x20
		private TaskAwaiter <>u__1; //Field offset: 0x28

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	private readonly IChannel channelSubscription; //Field offset: 0x10
	private int mostRecentEventVersion; //Field offset: 0x18
	private readonly string lobbyId; //Field offset: 0x20
	private readonly ILobbyService lobbyService; //Field offset: 0x28
	private readonly SortedList<Int32, ILobbyChanges> eventProcessQueue; //Field offset: 0x30
	private readonly object eventLock; //Field offset: 0x38
	private readonly object mostRecentEventVersionLock; //Field offset: 0x40
	[CompilerGenerated]
	private readonly LobbyEventCallbacks <Callbacks>k__BackingField; //Field offset: 0x48

	public override LobbyEventCallbacks Callbacks
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	internal LobbyChannel(IChannel channel, LobbyEventCallbacks callbacks, string lobbyId, ILobbyService lobbyService) { }

	[CompilerGenerated]
	public override LobbyEventCallbacks get_Callbacks() { }

	[AsyncStateMachine(typeof(<HandleLobbyChanges>d__16))]
	private Task HandleLobbyChanges(ILobbyChanges changes, LobbyEventCallbacks callbacks) { }

	private void OnLobbySubscriptionKick(LobbyEventCallbacks callbacks) { }

	[AsyncStateMachine(typeof(<OnLobbySubscriptionMessage>d__13))]
	private Task OnLobbySubscriptionMessage(string payload, LobbyEventCallbacks callbacks) { }

	private void OnLobbySubscriptionNewState(SubscriptionState state, LobbyEventCallbacks callbacks) { }

	[AsyncStateMachine(typeof(<ProcessEvent>d__17))]
	private Task ProcessEvent(ILobbyChanges nextToProcess, LobbyEventCallbacks callbacks) { }

	private bool ResolveTrivialEvent(ILobbyChanges changes, LobbyEventCallbacks callbacks, Lobby cachedLobby) { }

	[AsyncStateMachine(typeof(<SubscribeAsync>d__11))]
	public override Task SubscribeAsync() { }

	[AsyncStateMachine(typeof(<UnsubscribeAsync>d__12))]
	public override Task UnsubscribeAsync() { }

	private bool WasRemovedFromLobby(ILobbyChanges changes, Lobby cachedLobby) { }

}

