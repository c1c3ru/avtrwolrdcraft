namespace Google.Play.Integrity.Internal;

internal class PlayCoreIntegrityManager : IDisposable
{
	private readonly AndroidJavaObject _javaIntegrityManager; //Field offset: 0x10

	internal PlayCoreIntegrityManager() { }

	public override void Dispose() { }

	public PlayServicesTask<AndroidJavaObject> RequestIntegrityToken(AndroidJavaObject integrityTokenRequest) { }

}

