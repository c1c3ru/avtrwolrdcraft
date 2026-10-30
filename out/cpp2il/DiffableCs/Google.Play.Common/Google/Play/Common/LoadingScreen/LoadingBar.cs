namespace Google.Play.Common.LoadingScreen;

[ExecuteInEditMode]
public class LoadingBar : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <FillUntilDone>d__12 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public float startingFillProportion; //Field offset: 0x20
		public AsyncOperation operation; //Field offset: 0x28
		public float endingFillProportion; //Field offset: 0x30
		public LoadingBar <>4__this; //Field offset: 0x38
		public bool skipFinalUpdate; //Field offset: 0x40
		private float <previousFillProportion>5__2; //Field offset: 0x44
		private bool <isDone>5__3; //Field offset: 0x48

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
		public <FillUntilDone>d__12(int <>1__state) { }

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

	public float OutlineWidth; //Field offset: 0x20
	public float InnerBorderWidth; //Field offset: 0x24
	[Tooltip("If true, the Outline and Background RectTransforms will update to match the outline and border width.")]
	public bool ResizeAutomatically; //Field offset: 0x28
	[Range(0, 1)]
	[Tooltip("AssetBundle download and install progress. The value set in the Editor is ignored at runtime.")]
	public float Progress; //Field offset: 0x2C
	public RectTransform Background; //Field offset: 0x30
	public RectTransform Outline; //Field offset: 0x38
	public RectTransform ProgressHolder; //Field offset: 0x40
	public RectTransform ProgressFill; //Field offset: 0x48
	[Range(0, 1)]
	[Tooltip("Proportion of the loading bar allocated to AssetBundle download progress. The remainder of the loading bar is allocated to install progress.")]
	public float AssetBundleDownloadToInstallRatio; //Field offset: 0x50

	public LoadingBar() { }

	public void ApplyBorderWidth() { }

	[IteratorStateMachine(typeof(<FillUntilDone>d__12))]
	public IEnumerator FillUntilDone(AsyncOperation operation, float startingFillProportion, float endingFillProportion, bool skipFinalUpdate) { }

	public void SetProgress(float proportionOfLoadingBar) { }

	private void Update() { }

}

