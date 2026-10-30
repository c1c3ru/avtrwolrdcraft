namespace Google.Play.Integrity;

public class StandardIntegrityTokenProvider
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_0
	{
		public StandardIntegrityAsyncOperation<StandardIntegrityToken> operation; //Field offset: 0x10
		public PlayServicesTask<AndroidJavaObject> standardIntegrityTokenTask; //Field offset: 0x18
		public AndroidJavaObject javaStandardIntegrityTokenRequest; //Field offset: 0x20

		public <>c__DisplayClass3_0() { }

		internal void <Request>b__0(AndroidJavaObject tokenResponse) { }

		internal void <Request>b__1(string reason, int errorCode) { }

	}

	private const string StandardIntegrityTokenRequestClassName = "com.google.android.play.core.integrity.StandardIntegrityManager$StandardIntegrityTokenRequest"; //Field offset: 0x0
	private readonly PlayCoreStandardIntegrityTokenProvider _playCoreStandardIntegrityTokenProvider; //Field offset: 0x10

	internal StandardIntegrityTokenProvider(PlayCoreStandardIntegrityTokenProvider tokenProvider) { }

	public PlayAsyncOperation<StandardIntegrityToken, StandardIntegrityErrorCode> Request(StandardIntegrityTokenRequest request) { }

}

