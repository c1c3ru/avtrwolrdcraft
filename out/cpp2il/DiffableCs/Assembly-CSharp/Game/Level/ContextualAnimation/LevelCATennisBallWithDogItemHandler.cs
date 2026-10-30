namespace Game.Level.ContextualAnimation;

public class LevelCATennisBallWithDogItemHandler : LevelCATennisballItemHandler
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_0
	{
		public Vector2 src; //Field offset: 0x10
		public Vector2 dst; //Field offset: 0x18
		public float dogArcFactor; //Field offset: 0x20
		public LevelCATennisBallWithDogItemHandler <>4__this; //Field offset: 0x28
		public float flightTime; //Field offset: 0x30
		public bool caught; //Field offset: 0x34

		public <>c__DisplayClass12_0() { }

		internal void <ThrowDogBall>b__0(float t) { }

		internal void <ThrowDogBall>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <ThrowDogBall>d__12 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelCATennisBallWithDogItemHandler <>4__this; //Field offset: 0x20

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
		public <ThrowDogBall>d__12(int <>1__state) { }

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
	private static Action<LevelDog, LevelItem> OnCatchAction; //Field offset: 0x0
	[Header("Dog Related")]
	[SerializeField]
	private bool _canThrowToDog; //Field offset: 0xE0
	[SerializeField]
	private float _dogThrowFlightSpeed; //Field offset: 0xE4
	[SerializeField]
	private float _catchOffset; //Field offset: 0xE8
	private LevelDog _closestDog; //Field offset: 0xF0
	private float _minDistanceToDog; //Field offset: 0xF8

	public static event Action<LevelDog, LevelItem> OnCatchAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public LevelCATennisBallWithDogItemHandler() { }

	[CompilerGenerated]
	public static void add_OnCatchAction(Action<LevelDog, LevelItem> value) { }

	private void CatchDogBall() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	[CompilerGenerated]
	public static void remove_OnCatchAction(Action<LevelDog, LevelItem> value) { }

	[IteratorStateMachine(typeof(<ThrowDogBall>d__12))]
	private IEnumerator ThrowDogBall() { }

	private void TryThrowBallTowardsDog(ICATarget target) { }

}

