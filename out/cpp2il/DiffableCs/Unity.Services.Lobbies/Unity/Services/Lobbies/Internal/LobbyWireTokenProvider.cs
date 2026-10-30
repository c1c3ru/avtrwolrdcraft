namespace Unity.Services.Lobbies.Internal;

internal class LobbyWireTokenProvider : IChannelTokenProvider
{
	[CompilerGenerated]
	private struct <GetTokenAsync>d__3 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<ChannelToken> <>t__builder; //Field offset: 0x8
		public LobbyWireTokenProvider <>4__this; //Field offset: 0x20
		private TaskAwaiter<Dictionary`2<String, TokenData>> <>u__1; //Field offset: 0x28

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	private string lobbyId; //Field offset: 0x10
	private WrappedLobbyService lobbyService; //Field offset: 0x18

	internal LobbyWireTokenProvider(string lobbyId, WrappedLobbyService lobbyService) { }

	[AsyncStateMachine(typeof(<GetTokenAsync>d__3))]
	public override Task<ChannelToken> GetTokenAsync() { }

}

