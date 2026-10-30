namespace Game.Level;

[AddComponentMenu(null)]
public class LevelPerfume : LevelItem
{
	[CompilerGenerated]
	private sealed class <PlayParticlesAndSound>d__5 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelPerfume <>4__this; //Field offset: 0x20

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
		public <PlayParticlesAndSound>d__5(int <>1__state) { }

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
	private ParticleSystem _cloudsParticleSystem; //Field offset: 0x348
	[SerializeField]
	private ParticleSystem _sparklesParticleSystem; //Field offset: 0x350
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x358

	public LevelPerfume() { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

	public void ParticlesSetActive(bool value) { }

	[IteratorStateMachine(typeof(<PlayParticlesAndSound>d__5))]
	private IEnumerator PlayParticlesAndSound() { }

	private void PlaySound(string soundName) { }

}

