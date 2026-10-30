namespace Game.Level.ContextualAnimation;

public class LevelCABeachBallItemHandler : LevelCAItemHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public Vector2 src; //Field offset: 0x10
		public Vector2 dst; //Field offset: 0x18
		public float arcFactor; //Field offset: 0x20
		public LevelCABeachBallItemHandler <>4__this; //Field offset: 0x28
		public float flightTime; //Field offset: 0x30
		public bool didOtherCatchAnimation; //Field offset: 0x34
		public bool didOtherCatchingSucceeded; //Field offset: 0x35

		public <>c__DisplayClass9_0() { }

		internal void <ThrowBeachBall>b__0(float t) { }

		internal void <ThrowBeachBall>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <ThrowBeachBall>d__9 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelCABeachBallItemHandler <>4__this; //Field offset: 0x20
		private <>c__DisplayClass9_0 <>8__1; //Field offset: 0x28

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
		public <ThrowBeachBall>d__9(int <>1__state) { }

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
	protected float _flightSpeed; //Field offset: 0x88
	protected LevelCharacter _currentCharacter; //Field offset: 0x90
	protected LevelCharacter _closestCharacter; //Field offset: 0x98
	protected int _throwTweenID; //Field offset: 0xA0
	protected bool _isThrowing; //Field offset: 0xA4
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA8

	public LevelCABeachBallItemHandler() { }

	protected void CatchBeachBall(bool didOtherCatchingSucceeded) { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	[IteratorStateMachine(typeof(<ThrowBeachBall>d__9))]
	protected override IEnumerator ThrowBeachBall() { }

}

