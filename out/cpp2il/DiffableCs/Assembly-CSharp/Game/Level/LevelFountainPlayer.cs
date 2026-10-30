namespace Game.Level;

public class LevelFountainPlayer : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <PlayCorutine>d__8 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelFountainPlayer <>4__this; //Field offset: 0x20
		private int <i>5__2; //Field offset: 0x28
		private int <j>5__3; //Field offset: 0x2C

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
		public <PlayCorutine>d__8(int <>1__state) { }

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
	private LevelParticleSystemSetEmission[] _setEmissionParticleSystems; //Field offset: 0x20
	[SerializeField]
	private LevelParticleSystemSetEmission[] _setEmissionBigParticleSystems; //Field offset: 0x28
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x30
	private bool _isPlaying; //Field offset: 0x38

	public LevelFountainPlayer() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnLevelPostInint() { }

	public void Play() { }

	[IteratorStateMachine(typeof(<PlayCorutine>d__8))]
	private IEnumerator PlayCorutine() { }

}

