namespace Game.Level.Arcade.Dancing;

public class LevelArcadeDanceCarpet : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<GameObject> <>9__7_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <GameSetActive>b__7_0(GameObject light) { }

	}

	[CompilerGenerated]
	private sealed class <RandomLightsCoroutine>d__8 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelArcadeDanceCarpet <>4__this; //Field offset: 0x20
		private int <randomIndex>5__2; //Field offset: 0x28
		private int <secretIndex>5__3; //Field offset: 0x2C

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
		public <RandomLightsCoroutine>d__8(int <>1__state) { }

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
	private Transform _danceCarpetArea; //Field offset: 0x20
	[SerializeField]
	private List<GameObject> _randomLights; //Field offset: 0x28
	private bool _isSecretSong; //Field offset: 0x30
	private Int32[] _secretSongRhythm; //Field offset: 0x38

	public LevelArcadeDanceCarpet() { }

	private void Awake() { }

	public void GameSetActive(bool value) { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	[IteratorStateMachine(typeof(<RandomLightsCoroutine>d__8))]
	private IEnumerator RandomLightsCoroutine() { }

	private void SetSecretSong(int songIndex) { }

}

