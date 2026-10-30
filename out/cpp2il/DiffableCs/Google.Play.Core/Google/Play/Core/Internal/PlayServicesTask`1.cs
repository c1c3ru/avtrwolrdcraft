namespace Google.Play.Core.Internal;

public class PlayServicesTask : IDisposable
{
	private readonly AndroidJavaObject _javaTask; //Field offset: 0x0

	public PlayServicesTask`1(AndroidJavaObject javaTask) { }

	private void AddOnFailureListener(AndroidJavaProxy listenerProxy) { }

	private void AddOnSuccessListener(AndroidJavaProxy listenerProxy) { }

	public override void Dispose() { }

	public void RegisterOnFailureCallback(Action<String, Int32> onFailure) { }

	public void RegisterOnSuccessCallback(Action<TAndroidJava> onSuccess) { }

}

