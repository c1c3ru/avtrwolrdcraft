namespace PazuCore;

public class CompanySplashManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <TransitAfterAnimationEnd>d__8 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public CompanySplashManager <>4__this; //Field offset: 0x20

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
		public <TransitAfterAnimationEnd>d__8(int <>1__state) { }

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

	public static Action OverrideNextSceneAction; //Field offset: 0x0
	[SerializeField]
	private Image _banner; //Field offset: 0x20
	[SerializeField]
	private SkeletonGraphic _skeletonGraphic; //Field offset: 0x28
	private bool _didCallLoadNextScene; //Field offset: 0x30
	private bool _isSaidPazu; //Field offset: 0x31

	public CompanySplashManager() { }

	private void LoadNextScene() { }

	public void MoveToTheNextScreen() { }

	private void SetBannerSprite() { }

	private void SetLogoOrientation() { }

	private void Start() { }

	[IteratorStateMachine(typeof(<TransitAfterAnimationEnd>d__8))]
	private IEnumerator TransitAfterAnimationEnd() { }

}

