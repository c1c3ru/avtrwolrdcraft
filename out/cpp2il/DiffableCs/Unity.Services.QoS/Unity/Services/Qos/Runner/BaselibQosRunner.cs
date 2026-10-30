namespace Unity.Services.Qos.Runner;

internal class BaselibQosRunner : IQosRunner
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static QosJobProvider <>9__2_0; //Field offset: 0x8
		public static Func<Nullable`1<UcgQosServer>, Boolean> <>9__3_0; //Field offset: 0x10
		public static Func<Nullable`1<UcgQosServer>, UcgQosServer> <>9__3_1; //Field offset: 0x18
		public static Func<Nullable`1<UcgQosServer>, Boolean> <>9__4_0; //Field offset: 0x20
		public static Func<Nullable`1<UcgQosServer>, UcgQosServer> <>9__4_1; //Field offset: 0x28
		public static Converter<QosServer, QosServer> <>9__6_0; //Field offset: 0x30
		public static Converter<QosResult, QosMeasurementImpl> <>9__6_1; //Field offset: 0x38

		private static <>c() { }

		public <>c() { }

		internal IQosJob <.ctor>b__2_0(IList<UcgQosServer> servers, string title) { }

		internal bool <MeasureQosAsync>b__3_0(Nullable<UcgQosServer> s) { }

		internal UcgQosServer <MeasureQosAsync>b__3_1(Nullable<UcgQosServer> s) { }

		internal bool <MeasureQosAsync>b__4_0(Nullable<UcgQosServer> s) { }

		internal UcgQosServer <MeasureQosAsync>b__4_1(Nullable<UcgQosServer> s) { }

		internal QosServer <MeasureQosV2Async>b__6_0(QosServer q) { }

		internal QosMeasurementImpl <MeasureQosV2Async>b__6_1(QosResult qr) { }

	}

	[CompilerGenerated]
	private struct <MeasureQosAsync>d__3 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<List`1<QosResult>> <>t__builder; //Field offset: 0x8
		public IList<QosServer> servers; //Field offset: 0x20
		public BaselibQosRunner <>4__this; //Field offset: 0x28
		private List<QosResult> <results>5__2; //Field offset: 0x30
		private TaskAwaiter<Nullable`1<UcgQosServer>[]> <>u__1; //Field offset: 0x38
		private TaskAwaiter<IQosJob> <>u__2; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <MeasureQosAsync>d__4 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<List`1<QosAnnotatedResult>> <>t__builder; //Field offset: 0x8
		public IList<QosServiceServer> servers; //Field offset: 0x20
		public BaselibQosRunner <>4__this; //Field offset: 0x28
		private List<QosAnnotatedResult> <results>5__2; //Field offset: 0x30
		private TaskAwaiter<Nullable`1<UcgQosServer>[]> <>u__1; //Field offset: 0x38
		private TaskAwaiter<IQosJob> <>u__2; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <MeasureQosV2Async>d__6 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<List`1<ValueTuple`2<QosServer, IQosMeasurements>>> <>t__builder; //Field offset: 0x8
		public IList<QosServer> servers; //Field offset: 0x20
		public BaselibQosRunner <>4__this; //Field offset: 0x28
		private TaskAwaiter<List`1<QosResult>> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <RunQosJob>d__7 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<IQosJob> <>t__builder; //Field offset: 0x8
		public BaselibQosRunner <>4__this; //Field offset: 0x20
		public List<UcgQosServer> convertedServers; //Field offset: 0x28
		private IQosJob <job>5__2; //Field offset: 0x30
		private JobHandle <handle>5__3; //Field offset: 0x38
		private YieldAwaiter <>u__1; //Field offset: 0x48

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <ToUcgFormat>d__10 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Nullable`1<UcgQosServer>> <>t__builder; //Field offset: 0x8
		public string serverEndpoint; //Field offset: 0x20
		public BaselibQosRunner <>4__this; //Field offset: 0x28
		public string serverRegion; //Field offset: 0x30
		private Uri <uri>5__2; //Field offset: 0x38
		private TaskAwaiter<IPAddress[]> <>u__1; //Field offset: 0x40

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <ToUcgFormat>d__8 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Nullable`1<UcgQosServer>> <>t__builder; //Field offset: 0x8
		public QosServer server; //Field offset: 0x20
		public BaselibQosRunner <>4__this; //Field offset: 0x28
		private TaskAwaiter<Nullable`1<UcgQosServer>> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <ToUcgFormat>d__9 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Nullable`1<UcgQosServer>> <>t__builder; //Field offset: 0x8
		public QosServiceServer server; //Field offset: 0x20
		public BaselibQosRunner <>4__this; //Field offset: 0x28
		private TaskAwaiter<Nullable`1<UcgQosServer>> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	public struct QosMeasurementImpl : IQosMeasurements
	{
		[CompilerGenerated]
		private readonly int <AverageLatencyMs>k__BackingField; //Field offset: 0x0
		[CompilerGenerated]
		private readonly float <PacketLossPercent>k__BackingField; //Field offset: 0x4

		public override int AverageLatencyMs
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 8
		}

		public override float PacketLossPercent
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 8
		}

		public QosMeasurementImpl(int averageLatencyMs, float packetLossPercent) { }

		[CompilerGenerated]
		[IsReadOnly]
		public override int get_AverageLatencyMs() { }

		[CompilerGenerated]
		[IsReadOnly]
		public override float get_PacketLossPercent() { }

	}

	private QosJobProvider _qosJobProvider; //Field offset: 0x10
	private DnsResolver _dnsResolver; //Field offset: 0x18

	public BaselibQosRunner(QosJobProvider qosJobProvider = null, DnsResolver dnsResolver = null) { }

	[AsyncStateMachine(typeof(<MeasureQosAsync>d__3))]
	public override Task<List`1<QosResult>> MeasureQosAsync(IList<QosServer> servers) { }

	[AsyncStateMachine(typeof(<MeasureQosAsync>d__4))]
	public override Task<List`1<QosAnnotatedResult>> MeasureQosAsync(IList<QosServiceServer> servers) { }

	[AsyncStateMachine(typeof(<MeasureQosV2Async>d__6))]
	public override Task<List`1<ValueTuple`2<QosServer, IQosMeasurements>>> MeasureQosV2Async(IList<QosServer> servers) { }

	private static List<QosResult> ParseResults(IEnumerable<InternalQosResult> ucgResults, IEnumerable<QosServer> servers) { }

	private static List<QosAnnotatedResult> ParseResults(IEnumerable<InternalQosResult> ucgResults, IEnumerable<QosServiceServer> servers) { }

	[AsyncStateMachine(typeof(<RunQosJob>d__7))]
	private Task<IQosJob> RunQosJob(List<UcgQosServer> convertedServers) { }

	[AsyncStateMachine(typeof(<ToUcgFormat>d__8))]
	private Task<Nullable`1<UcgQosServer>> ToUcgFormat(QosServer server) { }

	[AsyncStateMachine(typeof(<ToUcgFormat>d__9))]
	private Task<Nullable`1<UcgQosServer>> ToUcgFormat(QosServiceServer server) { }

	[AsyncStateMachine(typeof(<ToUcgFormat>d__10))]
	private Task<Nullable`1<UcgQosServer>> ToUcgFormat(string serverEndpoint, string serverRegion) { }

}

