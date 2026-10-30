namespace Unity.Services.Authentication.Generated;

internal class PlayerNamesApi : IPlayerNamesApi, IApiAccessor
{
	[CompilerGenerated]
	private struct <GetNameAsync>d__9 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<ApiResponse`1<Player>> <>t__builder; //Field offset: 0x8
		public string playerId; //Field offset: 0x20
		public PlayerNamesApi <>4__this; //Field offset: 0x28
		public Nullable<Boolean> autoGenerate; //Field offset: 0x30
		public Nullable<Boolean> showMetadata; //Field offset: 0x32
		public CancellationToken cancellationToken; //Field offset: 0x38
		private TaskAwaiter<ApiResponse`1<Player>> <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <UpdateNameAsync>d__10 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<ApiResponse`1<Player>> <>t__builder; //Field offset: 0x8
		public string playerId; //Field offset: 0x20
		public UpdateNameRequest updateNameRequest; //Field offset: 0x28
		public PlayerNamesApi <>4__this; //Field offset: 0x30
		public CancellationToken cancellationToken; //Field offset: 0x38
		private TaskAwaiter<ApiResponse`1<Player>> <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private readonly IApiClient <Client>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly IApiConfiguration <Configuration>k__BackingField; //Field offset: 0x18

	public IApiClient Client
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public override IApiConfiguration Configuration
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public PlayerNamesApi(IApiClient apiClient) { }

	public PlayerNamesApi(IApiClient apiClient, IApiConfiguration apiConfiguration) { }

	[CompilerGenerated]
	public IApiClient get_Client() { }

	[CompilerGenerated]
	public override IApiConfiguration get_Configuration() { }

	public override string GetBasePath() { }

	[AsyncStateMachine(typeof(<GetNameAsync>d__9))]
	public override Task<ApiResponse`1<Player>> GetNameAsync(string playerId, Nullable<Boolean> autoGenerate = null, Nullable<Boolean> showMetadata = null, CancellationToken cancellationToken = null) { }

	[AsyncStateMachine(typeof(<UpdateNameAsync>d__10))]
	public override Task<ApiResponse`1<Player>> UpdateNameAsync(string playerId, UpdateNameRequest updateNameRequest, CancellationToken cancellationToken = null) { }

}

