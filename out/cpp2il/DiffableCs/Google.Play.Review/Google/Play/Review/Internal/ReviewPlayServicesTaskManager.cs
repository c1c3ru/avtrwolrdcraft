namespace Google.Play.Review.Internal;

internal class ReviewPlayServicesTaskManager : IDisposable
{
	private readonly AndroidJavaObject _javaReviewManager; //Field offset: 0x10

	internal ReviewPlayServicesTaskManager() { }

	public override void Dispose() { }

	public PlayServicesTask<AndroidJavaObject> LaunchReviewFlow(AndroidJavaObject reviewInfo) { }

	public PlayServicesTask<AndroidJavaObject> RequestReviewFlow() { }

}

