//Type is in global namespace

public class LevelCADogBallHandler : LevelCAItemHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass11_0
	{
		public Vector2 src; //Field offset: 0x10
		public Vector2 dst; //Field offset: 0x18
		public float arcFactor; //Field offset: 0x20
		public LevelCADogBallHandler <>4__this; //Field offset: 0x28
		public float flightTime; //Field offset: 0x30
		public bool caught; //Field offset: 0x34

		public <>c__DisplayClass11_0() { }

		internal void <ThrowDogBall>b__0(float t) { }

		internal void <ThrowDogBall>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <ThrowDogBall>d__11 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelCADogBallHandler <>4__this; //Field offset: 0x20

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
		public <ThrowDogBall>d__11(int <>1__state) { }

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
	private float _flightSpeed; //Field offset: 0x88
	[SerializeField]
	private float _catchOffset; //Field offset: 0x8C
	protected LevelCharacter _currentCharacter; //Field offset: 0x90
	private LevelDog _closestDog; //Field offset: 0x98
	private float _minDistance; //Field offset: 0xA0
	protected int _throwTweenID; //Field offset: 0xA4
	protected bool _isThrowing; //Field offset: 0xA8
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xB0

	public LevelCADogBallHandler() { }

	protected void CatchDogBall() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	[IteratorStateMachine(typeof(<ThrowDogBall>d__11))]
	protected IEnumerator ThrowDogBall() { }

}

