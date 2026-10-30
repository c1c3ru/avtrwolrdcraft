namespace Google.Play.Review;

public class ReviewManager
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public ReviewAsyncOperation<PlayReviewInfo> operation; //Field offset: 0x10
		public PlayServicesTask<AndroidJavaObject> requestFlowTask; //Field offset: 0x18

		public <>c__DisplayClass5_0() { }

		internal void <RequestReviewFlowInternal>b__0(AndroidJavaObject reviewInfo) { }

		internal void <RequestReviewFlowInternal>b__1(string reason, int errorCode) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public ReviewAsyncOperation<VoidResult> operation; //Field offset: 0x10
		public PlayServicesTask<AndroidJavaObject> requestFlowTask; //Field offset: 0x18

		public <>c__DisplayClass6_0() { }

		internal void <LaunchReviewFlowInternal>b__0(AndroidJavaObject result) { }

		internal void <LaunchReviewFlowInternal>b__1(string reason, int errorCode) { }

	}

	private const int JavaReviewErrorCodePlayNotFound = -1; //Field offset: 0x0
	private readonly ReviewPlayServicesTaskManager _reviewPlayServicesTaskManager; //Field offset: 0x10

	public ReviewManager() { }

	public PlayAsyncOperation<VoidResult, ReviewErrorCode> LaunchReviewFlow(PlayReviewInfo reviewInfo) { }

	private PlayAsyncOperation<VoidResult, ReviewErrorCode> LaunchReviewFlowInternal(PlayReviewInfo reviewInfo) { }

	public PlayAsyncOperation<PlayReviewInfo, ReviewErrorCode> RequestReviewFlow() { }

	private PlayAsyncOperation<PlayReviewInfo, ReviewErrorCode> RequestReviewFlowInternal() { }

}

