//Type is in global namespace

public class LobbyHelloWorld : MonoBehaviour
{
	[CompilerGenerated]
	private struct <CleanupDemoLobbyAsync>d__5 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public LobbyHelloWorld <>4__this; //Field offset: 0x20
		private TaskAwaiter <>u__1; //Field offset: 0x28

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <ExecuteLobbyDemoAsync>d__6 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public LobbyHelloWorld <>4__this; //Field offset: 0x20
		private Player <loggedInPlayer>5__2; //Field offset: 0x28
		private TaskAwaiter <>u__1; //Field offset: 0x30
		private TaskAwaiter<Player> <>u__2; //Field offset: 0x38
		private TaskAwaiter<QueryResponse> <>u__3; //Field offset: 0x40
		private TaskAwaiter<Lobby> <>u__4; //Field offset: 0x48

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <GetPlayerFromAnonymousLoginAsync>d__7 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Player> <>t__builder; //Field offset: 0x8
		private TaskAwaiter <>u__1; //Field offset: 0x20

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <Start>d__4 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
		public LobbyHelloWorld <>4__this; //Field offset: 0x28
		private TaskAwaiter <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	public string newLobbyName; //Field offset: 0x20
	public int maxPlayers; //Field offset: 0x28
	public bool isPrivate; //Field offset: 0x2C
	private Lobby currentLobby; //Field offset: 0x30

	public LobbyHelloWorld() { }

	[AsyncStateMachine(typeof(<CleanupDemoLobbyAsync>d__5))]
	private Task CleanupDemoLobbyAsync() { }

	[AsyncStateMachine(typeof(<ExecuteLobbyDemoAsync>d__6))]
	private Task ExecuteLobbyDemoAsync() { }

	[AsyncStateMachine(typeof(<GetPlayerFromAnonymousLoginAsync>d__7))]
	private static Task<Player> GetPlayerFromAnonymousLoginAsync() { }

	[AsyncStateMachine(typeof(<Start>d__4))]
	private void Start() { }

}

