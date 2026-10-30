namespace Unity.Services.Qos.Apis.QosDiscovery;

internal class QosDiscoveryApiClient : BaseApiClient, IQosDiscoveryApiClient
{
	[CompilerGenerated]
	private struct <GetServersAsync>d__7 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Response`1<QosServersResponseBody>> <>t__builder; //Field offset: 0x8
		public Configuration operationConfiguration; //Field offset: 0x20
		public QosDiscoveryApiClient <>4__this; //Field offset: 0x28
		public GetServersRequest request; //Field offset: 0x30
		private Dictionary<String, Type> <statusCodeToTypeMap>5__2; //Field offset: 0x38
		private TaskAwaiter<HttpClientResponse> <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <GetServiceServersAsync>d__8 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Response`1<QosServiceServersResponseBody>> <>t__builder; //Field offset: 0x8
		public Configuration operationConfiguration; //Field offset: 0x20
		public QosDiscoveryApiClient <>4__this; //Field offset: 0x28
		public GetServiceServersRequest request; //Field offset: 0x30
		private Dictionary<String, Type> <statusCodeToTypeMap>5__2; //Field offset: 0x38
		private TaskAwaiter<HttpClientResponse> <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	private const int _baseTimeout = 10; //Field offset: 0x0
	private IAccessToken _accessToken; //Field offset: 0x18
	private Configuration _configuration; //Field offset: 0x20

	public Configuration Configuration
	{
		 get { } //Length: 208
		 set { } //Length: 8
	}

	public QosDiscoveryApiClient(IHttpClient httpClient, IAccessToken accessToken, Configuration configuration = null) { }

	public Configuration get_Configuration() { }

	[AsyncStateMachine(typeof(<GetServersAsync>d__7))]
	public override Task<Response`1<QosServersResponseBody>> GetServersAsync(GetServersRequest request, Configuration operationConfiguration = null) { }

	[AsyncStateMachine(typeof(<GetServiceServersAsync>d__8))]
	public override Task<Response`1<QosServiceServersResponseBody>> GetServiceServersAsync(GetServiceServersRequest request, Configuration operationConfiguration = null) { }

	public void set_Configuration(Configuration value) { }

}

