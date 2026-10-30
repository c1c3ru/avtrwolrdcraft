namespace Google.Play.Integrity;

public class StandardIntegrityManager
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_0
	{
		public StandardIntegrityAsyncOperation<StandardIntegrityTokenProvider> operation; //Field offset: 0x10
		public PlayServicesTask<AndroidJavaObject> prepareIntegrityTokenTask; //Field offset: 0x18
		public AndroidJavaObject javaPrepareIntegrityTokenRequest; //Field offset: 0x20

		public <>c__DisplayClass3_0() { }

		internal void <PrepareIntegrityToken>b__0(AndroidJavaObject tokenProvider) { }

		internal void <PrepareIntegrityToken>b__1(string reason, int errorCode) { }

	}

	private const string PrepareIntegrityTokenRequestClassName = "com.google.android.play.core.integrity.StandardIntegrityManager$PrepareIntegrityTokenRequest"; //Field offset: 0x0
	private readonly PlayCoreStandardIntegrityManager _playCoreStandardIntegrityManager; //Field offset: 0x10

	public StandardIntegrityManager() { }

	public PlayAsyncOperation<StandardIntegrityTokenProvider, StandardIntegrityErrorCode> PrepareIntegrityToken(PrepareIntegrityTokenRequest request) { }

}

