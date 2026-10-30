namespace Google.Play.Integrity;

public class IntegrityManager
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_0
	{
		public IntegrityAsyncOperation<IntegrityTokenResponse> operation; //Field offset: 0x10
		public PlayServicesTask<AndroidJavaObject> requestIntegrityTokenTask; //Field offset: 0x18
		public AndroidJavaObject javaIntegrityTokenRequest; //Field offset: 0x20

		public <>c__DisplayClass3_0() { }

		internal void <RequestIntegrityToken>b__0(AndroidJavaObject tokenResponse) { }

		internal void <RequestIntegrityToken>b__1(string reason, int errorCode) { }

	}

	private const string IntegrityTokenRequestClassName = "com.google.android.play.core.integrity.IntegrityTokenRequest"; //Field offset: 0x0
	private readonly PlayCoreIntegrityManager _playCoreIntegrityManager; //Field offset: 0x10

	public IntegrityManager() { }

	public PlayAsyncOperation<IntegrityTokenResponse, IntegrityErrorCode> RequestIntegrityToken(IntegrityTokenRequest integrityTokenRequest) { }

}

