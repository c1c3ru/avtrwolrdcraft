namespace Game.Level.ContextualAnimation;

public class LevelCAVollyballItemHandler : LevelCAItemHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass17_0
	{
		public Vector2 src; //Field offset: 0x10
		public Vector2 dst; //Field offset: 0x18
		public float arcFactor; //Field offset: 0x20
		public LevelCAVollyballItemHandler <>4__this; //Field offset: 0x28
		public bool useUnderhand; //Field offset: 0x30
		public float flightTime; //Field offset: 0x34
		public bool didOtherCatchAnimation; //Field offset: 0x38
		public bool didOtherCatchingSucceeded; //Field offset: 0x39

		public <>c__DisplayClass17_0() { }

		internal void <ThrowBeachBall>b__0(float t) { }

		internal void <ThrowBeachBall>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass19_0
	{
		public LevelCharacter friendly; //Field offset: 0x10

		public <>c__DisplayClass19_0() { }

		internal void <CatchBeachBall>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass19_1
	{
		public LevelCharacter opponent; //Field offset: 0x10

		public <>c__DisplayClass19_1() { }

		internal void <CatchBeachBall>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <ThrowBeachBall>d__17 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelCAVollyballItemHandler <>4__this; //Field offset: 0x20
		public float delay; //Field offset: 0x28
		private <>c__DisplayClass17_0 <>8__1; //Field offset: 0x30

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
		public <ThrowBeachBall>d__17(int <>1__state) { }

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
	private LevelCharacter _currentCharacter; //Field offset: 0x90
	private LevelCharacter _targetCharacter; //Field offset: 0x98
	private int _throwTweenID; //Field offset: 0xA0
	private bool _isThrowing; //Field offset: 0xA4
	private bool _isPracticing; //Field offset: 0xA5
	private int _passNumber; //Field offset: 0xA8
	private Random _random; //Field offset: 0xB0

	public LevelCAVollyballItemHandler() { }

	protected virtual void Awake() { }

	private void CatchBeachBall(bool didOtherCatchingSucceeded) { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsSilent() { }

	private void Multiplayer_OnRandomGeneratorInit(int seed, string guidPrefix) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	private void OnBeginDrag(DragDropItemBase dragDropItem, PointerEventData pointerEventData) { }

	protected virtual void OnDestroy() { }

	private void OnPreSaveProgress(Scene scene) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	[IteratorStateMachine(typeof(<ThrowBeachBall>d__17))]
	private IEnumerator ThrowBeachBall(float delay) { }

	private float UpdateClosesCharacter() { }

}

