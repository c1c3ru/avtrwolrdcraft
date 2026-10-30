namespace Unity.Services.Authentication;

[Extension]
internal static class AuthenticationWebRequestUtils
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass0_0
	{
		public TaskCompletionSource<ApiResponse> tcs; //Field offset: 0x10
		public UnityWebRequest request; //Field offset: 0x18

		public <>c__DisplayClass0_0() { }

		internal void <SendWebRequestAsync>b__0(AsyncOperation asyncOperation) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass1_0
	{
		public TaskCompletionSource<ApiResponse`1<T>> tcs; //Field offset: 0x0
		public UnityWebRequest request; //Field offset: 0x0

		public <>c__DisplayClass1_0`1() { }

		internal void <SendWebRequestAsync>b__0() { }

		internal void <SendWebRequestAsync>b__1(AsyncOperation asyncOperation) { }

	}


	public static bool IsHttpError(UnityWebRequest request) { }

	public static bool IsNetworkError(UnityWebRequest request) { }

	private static void ProcessResponse(TaskCompletionSource<ApiResponse> tcs, UnityWebRequest request) { }

	private static void ProcessResponse(TaskCompletionSource<ApiResponse`1<T>> tcs, UnityWebRequest request) { }

	[Extension]
	public static Task<ApiResponse> SendWebRequestAsync(UnityWebRequest request) { }

	[Extension]
	public static Task<ApiResponse`1<T>> SendWebRequestAsync(UnityWebRequest request, CancellationToken cancellationToken) { }

}

