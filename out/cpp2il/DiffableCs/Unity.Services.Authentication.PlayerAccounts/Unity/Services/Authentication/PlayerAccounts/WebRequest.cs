namespace Unity.Services.Authentication.PlayerAccounts;

internal class WebRequest
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass16_0
	{
		public WebRequest <>4__this; //Field offset: 0x10
		public TaskCompletionSource<String> tcs; //Field offset: 0x18
		public UnityWebRequest request; //Field offset: 0x20

		public <>c__DisplayClass16_0() { }

		internal void <SendAttemptAsync>b__0(AsyncOperation operation) { }

	}

	[CompilerGenerated]
	private struct <SendAsync>d__15 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<T> <>t__builder; //Field offset: 0x0
		public WebRequest <>4__this; //Field offset: 0x0
		private TaskAwaiter<String> <>u__1; //Field offset: 0x0

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	private readonly WebRequestVerb m_Verb; //Field offset: 0x10
	private readonly string m_Url; //Field offset: 0x18
	private readonly IDictionary<String, String> m_Headers; //Field offset: 0x20
	private readonly string m_Payload; //Field offset: 0x28
	private readonly string m_PayloadContentType; //Field offset: 0x30
	private readonly JsonSerializerSettings m_JsonSerializerSettings; //Field offset: 0x38
	[CompilerGenerated]
	private readonly INetworkConfiguration <Configuration>k__BackingField; //Field offset: 0x40
	[CompilerGenerated]
	private int <Retries>k__BackingField; //Field offset: 0x48

	internal INetworkConfiguration Configuration
	{
		[CompilerGenerated]
		internal get { } //Length: 8
	}

	internal int Retries
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	internal WebRequest(INetworkConfiguration configuration, WebRequestVerb verb, string url, IDictionary<String, String> headers, string payload, string payloadContentType) { }

	internal UnityWebRequest Build() { }

	[CompilerGenerated]
	internal INetworkConfiguration get_Configuration() { }

	[CompilerGenerated]
	internal int get_Retries() { }

	internal void RequestCompleted(TaskCompletionSource<String> tcs, long responseCode, bool isNetworkError, bool isServerError, string errorText, string bodyText, IDictionary<String, String> headers) { }

	private bool RequestHasNetworkError(UnityWebRequest request) { }

	private bool RequestHasServerError(UnityWebRequest request) { }

	internal Task SendAsync() { }

	[AsyncStateMachine(typeof(<SendAsync>d__15`1))]
	internal Task<T> SendAsync() { }

	private Task<String> SendAttemptAsync(TaskCompletionSource<String> tcs) { }

	[CompilerGenerated]
	private void set_Retries(int value) { }

}

