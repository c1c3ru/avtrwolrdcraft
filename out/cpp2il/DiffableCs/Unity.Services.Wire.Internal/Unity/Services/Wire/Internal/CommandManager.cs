namespace Unity.Services.Wire.Internal;

internal class CommandManager
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public TaskCompletionSource<Reply> commandTCS; //Field offset: 0x10

		public <>c__DisplayClass5_0() { }

		internal void <RegisterCommand>b__0() { }

	}

	[CompilerGenerated]
	private struct <WaitForCommandAsync>d__6 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Reply> <>t__builder; //Field offset: 0x8
		public CommandManager <>4__this; //Field offset: 0x20
		public uint id; //Field offset: 0x28
		private TaskAwaiter<Reply> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	private readonly ConcurrentDictionary<UInt32, TaskCompletionSource`1<Reply>> m_Commands; //Field offset: 0x10
	public Configuration Config; //Field offset: 0x18
	private readonly IActionScheduler m_ActionScheduler; //Field offset: 0x20

	public CommandManager(Configuration configuration, IActionScheduler actionScheduler) { }

	private Exception CentrifugeErrorToException(Error error) { }

	public void Clear() { }

	public void OnCommandReplyReceived(Reply reply) { }

	public void OnDisconnect(Exception exceptionToThrow) { }

	public void RegisterCommand(uint id) { }

	[AsyncStateMachine(typeof(<WaitForCommandAsync>d__6))]
	public Task<Reply> WaitForCommandAsync(uint id) { }

}

