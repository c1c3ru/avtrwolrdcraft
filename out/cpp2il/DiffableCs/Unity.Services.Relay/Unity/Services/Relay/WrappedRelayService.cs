namespace Unity.Services.Relay;

internal class WrappedRelayService : IRelayService, IRelayServiceSDK, IRelayServiceSDKConfiguration
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Region, String> <>9__6_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal string <CreateAllocationAsync>b__6_0(Region r) { }

	}

	[CompilerGenerated]
	private struct <CreateAllocationAsync>d__6 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Allocation> <>t__builder; //Field offset: 0x8
		public WrappedRelayService <>4__this; //Field offset: 0x20
		public int maxConnections; //Field offset: 0x28
		public string region; //Field offset: 0x30
		private TaskAwaiter<List`1<Region>> <>u__1; //Field offset: 0x38
		private TaskAwaiter<IList`1<QosResult>> <>u__2; //Field offset: 0x40
		private TaskAwaiter<Response`1<AllocateResponseBody>> <>u__3; //Field offset: 0x48

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <GetJoinCodeAsync>d__7 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<String> <>t__builder; //Field offset: 0x8
		public WrappedRelayService <>4__this; //Field offset: 0x20
		public Guid allocationId; //Field offset: 0x28
		private TaskAwaiter<Response`1<JoinCodeResponseBody>> <>u__1; //Field offset: 0x38

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <JoinAllocationAsync>d__8 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<JoinAllocation> <>t__builder; //Field offset: 0x8
		public WrappedRelayService <>4__this; //Field offset: 0x20
		public string joinCode; //Field offset: 0x28
		private TaskAwaiter<Response`1<JoinResponseBody>> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <ListRegionsAsync>d__9 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<List`1<Region>> <>t__builder; //Field offset: 0x8
		public WrappedRelayService <>4__this; //Field offset: 0x20
		private TaskAwaiter<Response`1<RegionsResponseBody>> <>u__1; //Field offset: 0x28

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	private const string QosRelayServiceName = "relay"; //Field offset: 0x0
	[CompilerGenerated]
	private IRelayServiceSdk <m_RelayService>k__BackingField; //Field offset: 0x10

	internal IRelayServiceSdk m_RelayService
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	internal WrappedRelayService(IRelayServiceSdk relayService) { }

	[AsyncStateMachine(typeof(<CreateAllocationAsync>d__6))]
	public override Task<Allocation> CreateAllocationAsync(int maxConnections, string region = null) { }

	private void EnsureSignedIn() { }

	[CompilerGenerated]
	internal IRelayServiceSdk get_m_RelayService() { }

	[AsyncStateMachine(typeof(<GetJoinCodeAsync>d__7))]
	public override Task<String> GetJoinCodeAsync(Guid allocationId) { }

	[AsyncStateMachine(typeof(<JoinAllocationAsync>d__8))]
	public override Task<JoinAllocation> JoinAllocationAsync(string joinCode) { }

	[AsyncStateMachine(typeof(<ListRegionsAsync>d__9))]
	public override Task<List`1<Region>> ListRegionsAsync() { }

	[CompilerGenerated]
	internal void set_m_RelayService(IRelayServiceSdk value) { }

	public override void SetAllocationsServiceBasePath(string allocationsBasePath) { }

}

