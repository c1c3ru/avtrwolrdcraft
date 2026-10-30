namespace Google.Play.Common.LoadingScreen;

public class LoadingScreen : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <AttemptAssetBundleDownloadsCo>d__11 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LoadingScreen <>4__this; //Field offset: 0x20
		public int numberOfAttempts; //Field offset: 0x28
		private int <i>5__2; //Field offset: 0x2C

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <AttemptAssetBundleDownloadsCo>d__11(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <GetAssetBundle>d__12 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public string assetBundleUrl; //Field offset: 0x20
		public LoadingScreen <>4__this; //Field offset: 0x28
		private UnityWebRequest <webRequest>5__2; //Field offset: 0x30

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <GetAssetBundle>d__12(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private const int InitialAttemptCount = 3; //Field offset: 0x0
	[Tooltip("The URL used to fetch the AssetBundle on Start.")]
	public string AssetBundleUrl; //Field offset: 0x20
	[Tooltip("The LoadingBar used to indicated download and install progress.")]
	public LoadingBar LoadingBar; //Field offset: 0x28
	[Tooltip("The button displayed when a download error occurs. Should call ButtonEventRetryDownload in its onClick() event.")]
	public Button RetryButton; //Field offset: 0x30
	private AssetBundle _bundle; //Field offset: 0x38
	private int _assetBundleRetrievalAttemptCount; //Field offset: 0x40
	private float _maxLoadingBarProgress; //Field offset: 0x44
	private bool _downloading; //Field offset: 0x48

	public LoadingScreen() { }

	private void AttemptAssetBundleDownload(int numberOfAttempts) { }

	[IteratorStateMachine(typeof(<AttemptAssetBundleDownloadsCo>d__11))]
	private IEnumerator AttemptAssetBundleDownloadsCo(int numberOfAttempts) { }

	public void ButtonEventRetryDownload() { }

	[IteratorStateMachine(typeof(<GetAssetBundle>d__12))]
	private IEnumerator GetAssetBundle(string assetBundleUrl) { }

	private void HideRetryButton() { }

	private static bool IsNetworkError(UnityWebRequest request) { }

	private void ShowRetryButton() { }

	private void Start() { }

	private static AsyncOperation StartAssetBundleDownload(string assetBundleUrl, out UnityWebRequest webRequest) { }

}

