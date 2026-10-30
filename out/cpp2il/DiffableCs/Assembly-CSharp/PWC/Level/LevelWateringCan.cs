namespace PWC.Level;

public class LevelWateringCan : LevelSimpleDragActionItemBase
{
	[CompilerGenerated]
	private sealed class <TryIrrigate>d__13 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelWateringCan <>4__this; //Field offset: 0x20

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
		public <TryIrrigate>d__13(int <>1__state) { }

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
	private GameObject _can; //Field offset: 0x358
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x360
	[SerializeField]
	private string _soundName; //Field offset: 0x368
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x370
	private readonly List<ILevelPlant> _plants; //Field offset: 0x378
	private int _tweenID; //Field offset: 0x380

	public LevelWateringCan() { }

	[CompilerGenerated]
	private void <StartIrrigating>b__9_0() { }

	private void CancelTweenIfNeeded() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

	protected virtual void OnTargetExit(ILevelConsumer consumer) { }

	public void SetEmitEffectsEnabled(bool enabled) { }

	private void SetEmitParticles(bool shouldEmit) { }

	private void StartIrrigating() { }

	private void StopIrrigating() { }

	[IteratorStateMachine(typeof(<TryIrrigate>d__13))]
	private IEnumerator TryIrrigate() { }

}

