namespace Game.Level.WaterSlide;

public class LevelSlidePhotobooth : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public LevelSlidePhotobooth <>4__this; //Field offset: 0x10
		public int photoID; //Field offset: 0x18

		public <>c__DisplayClass8_0() { }

		internal void <DelayTakePhoto>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public Color color; //Field offset: 0x10
		public SpriteRenderer explosionParticles; //Field offset: 0x20

		public <>c__DisplayClass9_0() { }

		internal void <AnimateExplosion>b__0(float alphaValue) { }

	}

	[CompilerGenerated]
	private sealed class <AnimateExplosion>d__9 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelSlidePhotobooth <>4__this; //Field offset: 0x20
		private int <i>5__2; //Field offset: 0x28

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
		public <AnimateExplosion>d__9(int <>1__state) { }

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

	[SerializeField]
	private SpriteRenderer _flashParticles; //Field offset: 0x20
	private LevelSecretSolveBroadcaster _broadcaster; //Field offset: 0x28
	private LevelScreenCaptureHandler _screenCaptureHandler; //Field offset: 0x30
	private int _tweenID; //Field offset: 0x38

	public LevelSlidePhotobooth() { }

	[CompilerGenerated]
	private void <AnimateExplosion>b__9_1() { }

	[IteratorStateMachine(typeof(<AnimateExplosion>d__9))]
	private IEnumerator AnimateExplosion() { }

	private void Awake() { }

	public void DelayTakePhoto(int photoID) { }

	private string GetImagesDirectory() { }

	private void OnDestroy() { }

	private void ResetParticles() { }

	public void TakePhoto(int photoID) { }

}

