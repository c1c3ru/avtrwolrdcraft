namespace Game.Level.RacingGame;

public class LevelRacingGameInfoCover : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <InstructionsAnimation>d__7 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelRacingGameInfoCover <>4__this; //Field offset: 0x20

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
		public <InstructionsAnimation>d__7(int <>1__state) { }

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
	private TextMesh[] _scoreTexts; //Field offset: 0x20
	[SerializeField]
	private GameObject _panel; //Field offset: 0x28
	private Coroutine _coroutine; //Field offset: 0x30

	public LevelRacingGameInfoCover() { }

	[IteratorStateMachine(typeof(<InstructionsAnimation>d__7))]
	private IEnumerator InstructionsAnimation() { }

	private void OnDisable() { }

	private void OnEnable() { }

	public void SetCores(Single[] scores) { }

	public void SetVisible(bool visible) { }

}

