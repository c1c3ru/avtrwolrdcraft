namespace Google.Play.Integrity.Internal;

internal class PlayCoreStandardIntegrityManager : IDisposable
{
	private readonly AndroidJavaObject _javaStandardIntegrityManager; //Field offset: 0x10

	internal PlayCoreStandardIntegrityManager() { }

	public override void Dispose() { }

	internal PlayServicesTask<AndroidJavaObject> PrepareIntegrityToken(AndroidJavaObject prepareIntegrityTokenRequest) { }

}

