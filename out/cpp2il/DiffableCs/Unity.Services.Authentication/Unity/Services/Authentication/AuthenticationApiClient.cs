namespace Unity.Services.Authentication;

internal class AuthenticationApiClient : IApiClient
{
	[CompilerGenerated]
	private struct <SendAsync>d__18 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<ApiResponse> <>t__builder; //Field offset: 0x8
		public AuthenticationApiClient <>4__this; //Field offset: 0x20
		public string path; //Field offset: 0x28
		public WebRequestVerb method; //Field offset: 0x30
		public ApiRequestOptions options; //Field offset: 0x38
		public IApiConfiguration configuration; //Field offset: 0x40
		private int <attempts>5__2; //Field offset: 0x48
		private UnityWebRequest <request>5__3; //Field offset: 0x50
		private TaskAwaiter<ApiResponse> <>u__1; //Field offset: 0x58

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <SendAsync>d__19 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<ApiResponse`1<T>> <>t__builder; //Field offset: 0x0
		public AuthenticationApiClient <>4__this; //Field offset: 0x0
		public string path; //Field offset: 0x0
		public WebRequestVerb method; //Field offset: 0x0
		public ApiRequestOptions options; //Field offset: 0x0
		public IApiConfiguration configuration; //Field offset: 0x0
		public CancellationToken cancellationToken; //Field offset: 0x0
		private int <attempts>5__2; //Field offset: 0x0
		private UnityWebRequest <request>5__3; //Field offset: 0x0
		private TaskAwaiter<ApiResponse`1<T>> <>u__1; //Field offset: 0x0

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private readonly INetworkConfiguration <Configuration>k__BackingField; //Field offset: 0x10

	private INetworkConfiguration Configuration
	{
		[CompilerGenerated]
		private get { } //Length: 8
	}

	public AuthenticationApiClient(INetworkConfiguration configuration) { }

	internal UnityWebRequest BuildWebRequest(string path, WebRequestVerb method, ApiRequestOptions options, IApiConfiguration configuration) { }

	public override Task<ApiResponse> DeleteAsync(string path, ApiRequestOptions options, IApiConfiguration configuration, CancellationToken cancellationToken = null) { }

	public override Task<ApiResponse`1<T>> DeleteAsync(string path, ApiRequestOptions options, IApiConfiguration configuration, CancellationToken cancellationToken = null) { }

	[CompilerGenerated]
	private INetworkConfiguration get_Configuration() { }

	public override Task<ApiResponse> GetAsync(string path, ApiRequestOptions options, IApiConfiguration configuration, CancellationToken cancellationToken = null) { }

	public override Task<ApiResponse`1<T>> GetAsync(string path, ApiRequestOptions options, IApiConfiguration configuration, CancellationToken cancellationToken = null) { }

	public override Task<ApiResponse> HeadAsync(string path, ApiRequestOptions options, IApiConfiguration configuration, CancellationToken cancellationToken = null) { }

	public override Task<ApiResponse`1<T>> HeadAsync(string path, ApiRequestOptions options, IApiConfiguration configuration, CancellationToken cancellationToken = null) { }

	public override Task<ApiResponse> OptionsAsync(string path, ApiRequestOptions options, IApiConfiguration configuration, CancellationToken cancellationToken = null) { }

	public override Task<ApiResponse`1<T>> OptionsAsync(string path, ApiRequestOptions options, IApiConfiguration configuration, CancellationToken cancellationToken = null) { }

	public override Task<ApiResponse> PatchAsync(string path, ApiRequestOptions options, IApiConfiguration configuration, CancellationToken cancellationToken = null) { }

	public override Task<ApiResponse`1<T>> PatchAsync(string path, ApiRequestOptions options, IApiConfiguration configuration, CancellationToken cancellationToken = null) { }

	public override Task<ApiResponse> PostAsync(string path, ApiRequestOptions options, IApiConfiguration configuration, CancellationToken cancellationToken = null) { }

	public override Task<ApiResponse`1<T>> PostAsync(string path, ApiRequestOptions options, IApiConfiguration configuration, CancellationToken cancellationToken = null) { }

	public override Task<ApiResponse> PutAsync(string path, ApiRequestOptions options, IApiConfiguration configuration, CancellationToken cancellationToken = null) { }

	public override Task<ApiResponse`1<T>> PutAsync(string path, ApiRequestOptions options, IApiConfiguration configuration, CancellationToken cancellationToken = null) { }

	[AsyncStateMachine(typeof(<SendAsync>d__19`1))]
	private Task<ApiResponse`1<T>> SendAsync(string path, WebRequestVerb method, ApiRequestOptions options, IApiConfiguration configuration, CancellationToken cancellationToken = null) { }

	[AsyncStateMachine(typeof(<SendAsync>d__18))]
	private Task<ApiResponse> SendAsync(string path, WebRequestVerb method, ApiRequestOptions options, IApiConfiguration configuration, CancellationToken cancellationToken = null) { }

}

