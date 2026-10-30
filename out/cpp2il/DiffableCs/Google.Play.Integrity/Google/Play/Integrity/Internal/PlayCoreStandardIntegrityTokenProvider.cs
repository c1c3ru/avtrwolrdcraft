namespace Google.Play.Integrity.Internal;

internal class PlayCoreStandardIntegrityTokenProvider : IDisposable
{
	private readonly AndroidJavaObject _javaStandardIntegrityTokenProvider; //Field offset: 0x10

	internal PlayCoreStandardIntegrityTokenProvider(AndroidJavaObject javaTokenProvider) { }

	public override void Dispose() { }

	internal PlayServicesTask<AndroidJavaObject> Request(AndroidJavaObject standardIntegrityTokenRequest) { }

}

