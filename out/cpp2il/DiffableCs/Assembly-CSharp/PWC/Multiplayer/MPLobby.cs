namespace PWC.Multiplayer;

public class MPLobby : MonoBehaviour
{
	[CompilerGenerated]
	private struct <CleanupDemoLobbyAsync>d__9 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public MPLobby <>4__this; //Field offset: 0x20
		private TaskAwaiter <>u__1; //Field offset: 0x28

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <CreateInstance>d__6 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
		public Action<MPLobby> onReadyAction; //Field offset: 0x28
		private TaskAwaiter <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <CreateLobby>d__11 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
		public string lobbyName; //Field offset: 0x28
		public int maxPlayers; //Field offset: 0x30
		public Dictionary<String, DataObject> lobbyData; //Field offset: 0x38
		public bool isPrivate; //Field offset: 0x40
		public MPLobby <>4__this; //Field offset: 0x48
		private TaskAwaiter<Lobby> <>u__1; //Field offset: 0x50

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <DeleteInstance>d__7 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
		private TaskAwaiter <>u__1; //Field offset: 0x28

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <GetAvailableLobbies>d__10 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<List`1<Lobby>> <>t__builder; //Field offset: 0x8
		private TaskAwaiter<QueryResponse> <>u__1; //Field offset: 0x20

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <GetPlayerFromAnonymousLoginAsync>d__13 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Player> <>t__builder; //Field offset: 0x8
		private TaskAwaiter <>u__1; //Field offset: 0x20

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <Init>d__8 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public MPLobby <>4__this; //Field offset: 0x20
		private TaskAwaiter <>u__1; //Field offset: 0x28
		private TaskAwaiter<Player> <>u__2; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <JoinLobby>d__12 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
		public Lobby lobby; //Field offset: 0x28
		public MPLobby <>4__this; //Field offset: 0x30
		private TaskAwaiter<Lobby> <>u__1; //Field offset: 0x38

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private static MPLobby <Instance>k__BackingField; //Field offset: 0x0
	private Lobby _currentLobby; //Field offset: 0x20
	private Player _player; //Field offset: 0x28

	public private static MPLobby Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public MPLobby() { }

	[AsyncStateMachine(typeof(<CleanupDemoLobbyAsync>d__9))]
	private Task CleanupDemoLobbyAsync() { }

	[AsyncStateMachine(typeof(<CreateInstance>d__6))]
	public static void CreateInstance(Action<MPLobby> onReadyAction) { }

	[AsyncStateMachine(typeof(<CreateLobby>d__11))]
	public void CreateLobby(string lobbyName, int maxPlayers, Dictionary<String, DataObject> lobbyData, bool isPrivate) { }

	[AsyncStateMachine(typeof(<DeleteInstance>d__7))]
	public static void DeleteInstance() { }

	[CompilerGenerated]
	public static MPLobby get_Instance() { }

	[AsyncStateMachine(typeof(<GetAvailableLobbies>d__10))]
	private Task<List`1<Lobby>> GetAvailableLobbies() { }

	[AsyncStateMachine(typeof(<GetPlayerFromAnonymousLoginAsync>d__13))]
	private static Task<Player> GetPlayerFromAnonymousLoginAsync() { }

	[AsyncStateMachine(typeof(<Init>d__8))]
	private Task Init() { }

	[AsyncStateMachine(typeof(<JoinLobby>d__12))]
	public void JoinLobby(Lobby lobby) { }

	[CompilerGenerated]
	private static void set_Instance(MPLobby value) { }

}

