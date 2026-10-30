namespace Unity.Services.Qos;

internal class WrappedQosService : IQosService
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<QosResult, Int32> <>9__20_0; //Field offset: 0x8
		public static Func<QosResult, Single> <>9__20_1; //Field offset: 0x10
		public static Func<QosServer, List`1<String>> <>9__25_0; //Field offset: 0x18
		public static Func<QosServer, List`1<String>> <>9__25_1; //Field offset: 0x20
		public static Func<ValueTuple`2<QosServer, IQosMeasurements>, Int32> <>9__26_1; //Field offset: 0x28
		public static Func<ValueTuple`2<QosServer, IQosMeasurements>, Single> <>9__26_2; //Field offset: 0x30
		public static Func<QosAnnotatedResult, Boolean> <>9__28_0; //Field offset: 0x38
		public static Func<QosAnnotatedResult, String> <>9__28_1; //Field offset: 0x40
		public static Func<QosAnnotatedResult, Int32> <>9__28_5; //Field offset: 0x48
		public static Func<QosAnnotatedResult, Single> <>9__28_6; //Field offset: 0x50
		public static Func<QosAnnotatedResult, Dictionary`2<String, List`1<String>>> <>9__28_7; //Field offset: 0x58
		public static Func<IGrouping`2<String, QosAnnotatedResult>, IQosAnnotatedResult> <>9__28_2; //Field offset: 0x60
		public static Func<IQosAnnotatedResult, Int32> <>9__28_3; //Field offset: 0x68
		public static Func<IQosAnnotatedResult, Single> <>9__28_4; //Field offset: 0x70

		private static <>c() { }

		public <>c() { }

		internal List<String> <SendResultsMetricsV2>b__25_0(QosServer qs) { }

		internal List<String> <SendResultsMetricsV2>b__25_1(QosServer qs) { }

		internal int <SendResultsMetricsV2ForService>b__26_1(ValueTuple<QosServer, IQosMeasurements> t) { }

		internal float <SendResultsMetricsV2ForService>b__26_2(ValueTuple<QosServer, IQosMeasurements> t) { }

		internal int <SortResults>b__20_0(QosResult q) { }

		internal float <SortResults>b__20_1(QosResult q) { }

		internal bool <SortServiceResults>b__28_0(QosAnnotatedResult q) { }

		internal string <SortServiceResults>b__28_1(QosAnnotatedResult q) { }

		internal IQosAnnotatedResult <SortServiceResults>b__28_2(IGrouping<String, QosAnnotatedResult> q) { }

		internal int <SortServiceResults>b__28_3(IQosAnnotatedResult q) { }

		internal float <SortServiceResults>b__28_4(IQosAnnotatedResult q) { }

		internal int <SortServiceResults>b__28_5(QosAnnotatedResult x) { }

		internal float <SortServiceResults>b__28_6(QosAnnotatedResult x) { }

		internal Dictionary<String, List`1<String>> <SortServiceResults>b__28_7(QosAnnotatedResult x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass26_0
	{
		public Func<QosServer, List`1<String>> regionGetter; //Field offset: 0x10

		public <>c__DisplayClass26_0() { }

		internal bool <SendResultsMetricsV2ForService>b__0(ValueTuple<QosServer, IQosMeasurements> t) { }

	}

	[CompilerGenerated]
	private struct <GetAllServersAsync>d__23 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<IList`1<QosServer>> <>t__builder; //Field offset: 0x8
		public WrappedQosService <>4__this; //Field offset: 0x20
		private TaskAwaiter<Response`1<QosServersResponseBody>> <>u__1; //Field offset: 0x28

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <GetQosResultsAsync>d__24 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<IList`1<ValueTuple`2<QosServer, IQosMeasurements>>> <>t__builder; //Field offset: 0x8
		public WrappedQosService <>4__this; //Field offset: 0x20
		public IList<QosServer> servers; //Field offset: 0x28
		private TaskAwaiter<List`1<ValueTuple`2<QosServer, IQosMeasurements>>> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <GetSortedInternalQosResultsAsync>d__19 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<IList`1<QosResult>> <>t__builder; //Field offset: 0x8
		public WrappedQosService <>4__this; //Field offset: 0x20
		public IList<String> regions; //Field offset: 0x28
		public string service; //Field offset: 0x30
		private Response<QosServersResponseBody> <httpResp>5__2; //Field offset: 0x38
		private TaskAwaiter<Response`1<QosServersResponseBody>> <>u__1; //Field offset: 0x40
		private TaskAwaiter<List`1<QosResult>> <>u__2; //Field offset: 0x48

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <GetSortedInternalServiceQosResultsAsync>d__27 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<IList`1<IQosAnnotatedResult>> <>t__builder; //Field offset: 0x8
		public WrappedQosService <>4__this; //Field offset: 0x20
		public IList<String> regions; //Field offset: 0x28
		public IList<String> fleet; //Field offset: 0x30
		public string service; //Field offset: 0x38
		private Response<QosServiceServersResponseBody> <httpResp>5__2; //Field offset: 0x40
		private TaskAwaiter<Response`1<QosServiceServersResponseBody>> <>u__1; //Field offset: 0x48
		private TaskAwaiter<List`1<QosAnnotatedResult>> <>u__2; //Field offset: 0x50

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <GetSortedMultiplayQosResultsAsync>d__22 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<IList`1<IQosAnnotatedResult>> <>t__builder; //Field offset: 0x8
		public WrappedQosService <>4__this; //Field offset: 0x20
		public IList<String> fleet; //Field offset: 0x28
		private TaskAwaiter<IList`1<IQosAnnotatedResult>> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <GetSortedQosResultsAsync>d__18 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<IList`1<IQosResult>> <>t__builder; //Field offset: 0x8
		public WrappedQosService <>4__this; //Field offset: 0x20
		public string service; //Field offset: 0x28
		public IList<String> regions; //Field offset: 0x30
		private TaskAwaiter<IList`1<QosResult>> <>u__1; //Field offset: 0x38

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <GetSortedRelayQosResultsAsync>d__21 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<IList`1<IQosAnnotatedResult>> <>t__builder; //Field offset: 0x8
		public WrappedQosService <>4__this; //Field offset: 0x20
		public IList<String> regions; //Field offset: 0x28
		private TaskAwaiter<IList`1<IQosAnnotatedResult>> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	private const string ResultLatencyMetricName = "qos_result_latency_ms"; //Field offset: 0x0
	private const string ResultPacketLossMetricName = "qos_result_packet_loss"; //Field offset: 0x0
	private const string MetricServiceNameLabelName = "qos_service_name"; //Field offset: 0x0
	private const string MetricServiceRegionLabelName = "qos_service_region"; //Field offset: 0x0
	private const string MetricClientCountryLabelName = "qos_client_country"; //Field offset: 0x0
	private const string MetricClientRegionLabelName = "qos_client_region"; //Field offset: 0x0
	private const string MetricClientBestResultLabelName = "qos_best_result"; //Field offset: 0x0
	private const string MetricClientBestResultLabelTrueValue = "true"; //Field offset: 0x0
	private IQosDiscoveryApiClient _qosDiscoveryApiClient; //Field offset: 0x10
	private IQosDiscoveryApiClient _qosDiscoveryApiClientV2; //Field offset: 0x18
	private IQosRunner _qosRunner; //Field offset: 0x20
	private IAccessToken _accessToken; //Field offset: 0x28
	private IMetrics _metrics; //Field offset: 0x30
	private string _latestCountryForTelemetry; //Field offset: 0x38
	private string _latestRegionForTelemetry; //Field offset: 0x40
	private string _getAllServersEtag; //Field offset: 0x48
	private IList<QosServer> _getAllServersCached; //Field offset: 0x50

	internal WrappedQosService(IQosDiscoveryApiClient qosDiscoveryApiClient, IQosDiscoveryApiClient qosDiscoveryApiClientV2, IQosRunner qosRunner, IAccessToken accessToken, IMetrics metrics) { }

	[AsyncStateMachine(typeof(<GetAllServersAsync>d__23))]
	public override Task<IList`1<QosServer>> GetAllServersAsync() { }

	[AsyncStateMachine(typeof(<GetQosResultsAsync>d__24))]
	public override Task<IList`1<ValueTuple`2<QosServer, IQosMeasurements>>> GetQosResultsAsync(IList<QosServer> servers) { }

	[AsyncStateMachine(typeof(<GetSortedInternalQosResultsAsync>d__19))]
	internal Task<IList`1<QosResult>> GetSortedInternalQosResultsAsync(string service, IList<String> regions) { }

	[AsyncStateMachine(typeof(<GetSortedInternalServiceQosResultsAsync>d__27))]
	internal Task<IList`1<IQosAnnotatedResult>> GetSortedInternalServiceQosResultsAsync(string service, IList<String> regions, IList<String> fleet) { }

	[AsyncStateMachine(typeof(<GetSortedMultiplayQosResultsAsync>d__22))]
	public override Task<IList`1<IQosAnnotatedResult>> GetSortedMultiplayQosResultsAsync(IList<String> fleet) { }

	[AsyncStateMachine(typeof(<GetSortedQosResultsAsync>d__18))]
	public override Task<IList`1<IQosResult>> GetSortedQosResultsAsync(string service, IList<String> regions) { }

	[AsyncStateMachine(typeof(<GetSortedRelayQosResultsAsync>d__21))]
	public override Task<IList`1<IQosAnnotatedResult>> GetSortedRelayQosResultsAsync(IList<String> regions) { }

	private IQosResult MapToPublicQosResult(QosResult internalQosResult) { }

	private void SendResultMetrics(string service, string clientCountry, string clientRegion, string region, int averageLatencyMs, float packetLossPercent, bool isBest) { }

	private void SendResultsMetrics(IList<QosResult> sortedResults, string service, Response discoveryResponse) { }

	private void SendResultsMetrics(IList<IQosResult> sortedResults, string service, Response discoveryResponse) { }

	private void SendResultsMetricsV2(IReadOnlyCollection<ValueTuple`2<QosServer, IQosMeasurements>> qosResults) { }

	private void SendResultsMetricsV2ForService(IReadOnlyCollection<ValueTuple`2<QosServer, IQosMeasurements>> allResults, Func<QosServer, List`1<String>> regionGetter, string service) { }

	private List<QosResult> SortResults(IList<QosResult> results) { }

	private List<IQosAnnotatedResult> SortServiceResults(IList<QosAnnotatedResult> results) { }

}

