namespace Unity.Services.Wire.Protocol.Internal;

[JsonObject(ItemNullValueHandling = NullValueHandling::Ignore (1))]
internal class SubscribeRequest
{
	[CompilerGenerated]
	private struct <getRequestFromRepo>d__6 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Dictionary`2<String, SubscribeRequest>> <>t__builder; //Field offset: 0x8
		public ISubscriptionRepository repository; //Field offset: 0x20
		private Dictionary<String, SubscribeRequest> <subscriptionRequests>5__2; //Field offset: 0x28
		private IEnumerator<KeyValuePair`2<String, Subscription>> <>7__wrap2; //Field offset: 0x30
		private KeyValuePair<String, Subscription> <subIterator>5__4; //Field offset: 0x38
		private TaskAwaiter<String> <>u__1; //Field offset: 0x48

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	public string channel; //Field offset: 0x10
	public string token; //Field offset: 0x18
	public bool recover; //Field offset: 0x20
	public ulong offset; //Field offset: 0x28
	public string epoch; //Field offset: 0x30

	[Preserve]
	public SubscribeRequest() { }

	[AsyncStateMachine(typeof(<getRequestFromRepo>d__6))]
	public static Task<Dictionary`2<String, SubscribeRequest>> getRequestFromRepo(ISubscriptionRepository repository) { }

}

