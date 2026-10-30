namespace Unity.Services.Qos.V2.Http;

internal class HttpClient : IHttpClient
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		private struct <<CreateHttpClientResponse>b__0>d : IAsyncStateMachine
		{
			public int <>1__state; //Field offset: 0x0
			public AsyncTaskMethodBuilder<HttpClientResponse> <>t__builder; //Field offset: 0x8
			public <>c__DisplayClass4_0 <>4__this; //Field offset: 0x20
			private UnityWebRequest <request>5__2; //Field offset: 0x28
			private TaskAwaiter<HttpClientResponse> <>u__1; //Field offset: 0x30

			private override void MoveNext() { }

			[DebuggerHidden]
			private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

		}

		public string url; //Field offset: 0x10
		public string method; //Field offset: 0x18
		public IDictionary<String, String> headers; //Field offset: 0x20
		public int requestTimeout; //Field offset: 0x28
		public Byte[] body; //Field offset: 0x30
		public HttpClient <>4__this; //Field offset: 0x38

		public <>c__DisplayClass4_0() { }

		[AsyncStateMachine(typeof(<<CreateHttpClientResponse>b__0>d))]
		internal Task<HttpClientResponse> <CreateHttpClientResponse>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		private struct <<CreateWebRequestAsync>b__0>d : IAsyncStateMachine
		{
			public int <>1__state; //Field offset: 0x0
			public AsyncTaskMethodBuilder<HttpClientResponse> <>t__builder; //Field offset: 0x8
			public <>c__DisplayClass5_0 <>4__this; //Field offset: 0x20
			private TaskAwaiter<HttpClientResponse> <>u__1; //Field offset: 0x28

			private override void MoveNext() { }

			[DebuggerHidden]
			private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

		}

		public string boundary; //Field offset: 0x10
		public string url; //Field offset: 0x18
		public string method; //Field offset: 0x20
		public IDictionary<String, String> headers; //Field offset: 0x28
		public int requestTimeout; //Field offset: 0x30
		public List<IMultipartFormSection> body; //Field offset: 0x38
		public HttpClient <>4__this; //Field offset: 0x40

		public <>c__DisplayClass5_0() { }

		[AsyncStateMachine(typeof(<<CreateWebRequestAsync>b__0>d))]
		internal Task<HttpClientResponse> <CreateWebRequestAsync>b__0() { }

	}

	[CompilerGenerated]
	private struct <CreateHttpClientResponse>d__4 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<HttpClientResponse> <>t__builder; //Field offset: 0x8
		public string url; //Field offset: 0x20
		public string method; //Field offset: 0x28
		public IDictionary<String, String> headers; //Field offset: 0x30
		public int requestTimeout; //Field offset: 0x38
		public Byte[] body; //Field offset: 0x40
		public HttpClient <>4__this; //Field offset: 0x48
		private TaskAwaiter<Task`1<HttpClientResponse>> <>u__1; //Field offset: 0x50
		private TaskAwaiter<HttpClientResponse> <>u__2; //Field offset: 0x58

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <CreateWebRequestAsync>d__3 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<HttpClientResponse> <>t__builder; //Field offset: 0x8
		public HttpClient <>4__this; //Field offset: 0x20
		public string method; //Field offset: 0x28
		public string url; //Field offset: 0x30
		public Byte[] body; //Field offset: 0x38
		public IDictionary<String, String> headers; //Field offset: 0x40
		public int requestTimeout; //Field offset: 0x48
		private TaskAwaiter<HttpClientResponse> <>u__1; //Field offset: 0x50

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <CreateWebRequestAsync>d__5 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<HttpClientResponse> <>t__builder; //Field offset: 0x8
		public string boundary; //Field offset: 0x20
		public string url; //Field offset: 0x28
		public string method; //Field offset: 0x30
		public IDictionary<String, String> headers; //Field offset: 0x38
		public int requestTimeout; //Field offset: 0x40
		public List<IMultipartFormSection> body; //Field offset: 0x48
		public HttpClient <>4__this; //Field offset: 0x50
		private TaskAwaiter<Task`1<HttpClientResponse>> <>u__1; //Field offset: 0x58
		private TaskAwaiter<HttpClientResponse> <>u__2; //Field offset: 0x60

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <MakeRequestAsync>d__1 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<HttpClientResponse> <>t__builder; //Field offset: 0x8
		public HttpClient <>4__this; //Field offset: 0x20
		public string method; //Field offset: 0x28
		public string url; //Field offset: 0x30
		public Byte[] body; //Field offset: 0x38
		public Dictionary<String, String> headers; //Field offset: 0x40
		public int requestTimeout; //Field offset: 0x48
		private TaskAwaiter<HttpClientResponse> <>u__1; //Field offset: 0x50

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <MakeRequestAsync>d__2 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<HttpClientResponse> <>t__builder; //Field offset: 0x8
		public HttpClient <>4__this; //Field offset: 0x20
		public string method; //Field offset: 0x28
		public string url; //Field offset: 0x30
		public List<IMultipartFormSection> body; //Field offset: 0x38
		public Dictionary<String, String> headers; //Field offset: 0x40
		public int requestTimeout; //Field offset: 0x48
		public string boundary; //Field offset: 0x50
		private TaskAwaiter<HttpClientResponse> <>u__1; //Field offset: 0x58

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}


	public HttpClient() { }

	[AsyncStateMachine(typeof(<CreateHttpClientResponse>d__4))]
	private Task<HttpClientResponse> CreateHttpClientResponse(string method, string url, Byte[] body, IDictionary<String, String> headers, int requestTimeout) { }

	[AsyncStateMachine(typeof(<CreateWebRequestAsync>d__3))]
	private Task<HttpClientResponse> CreateWebRequestAsync(string method, string url, Byte[] body, IDictionary<String, String> headers, int requestTimeout) { }

	[AsyncStateMachine(typeof(<CreateWebRequestAsync>d__5))]
	private Task<HttpClientResponse> CreateWebRequestAsync(string method, string url, List<IMultipartFormSection> body, IDictionary<String, String> headers, int requestTimeout, string boundary = null) { }

	[AsyncStateMachine(typeof(<MakeRequestAsync>d__1))]
	public override Task<HttpClientResponse> MakeRequestAsync(string method, string url, Byte[] body, Dictionary<String, String> headers, int requestTimeout) { }

	[AsyncStateMachine(typeof(<MakeRequestAsync>d__2))]
	public override Task<HttpClientResponse> MakeRequestAsync(string method, string url, List<IMultipartFormSection> body, Dictionary<String, String> headers, int requestTimeout, string boundary = null) { }

	private UnityWebRequestAsyncOperation SendWebRequest(UnityWebRequest request) { }

	private static UnityWebRequest SetupMultipartRequest(UnityWebRequest request, List<IMultipartFormSection> multipartFormSections, Byte[] boundary) { }

}

