namespace Game.Level.ContextualAnimation;

public class LevelCATennisballItemHandler : LevelCAItemHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass35_0
	{
		public Vector2 src; //Field offset: 0x10
		public Vector2 dst; //Field offset: 0x18
		public LevelCATennisballItemHandler <>4__this; //Field offset: 0x20
		public bool hasOpponent; //Field offset: 0x28
		public LevelTennisCourtArea tennisCourtArea; //Field offset: 0x30
		public float flightTime; //Field offset: 0x38
		public bool didOtherCatchAnimation; //Field offset: 0x3C
		public bool didOtherCatchingSucceeded; //Field offset: 0x3D
		public Action<Single> <>9__3; //Field offset: 0x40
		public Action <>9__4; //Field offset: 0x48

		public <>c__DisplayClass35_0() { }

		internal void <LobTennisBall>b__0(float t) { }

		internal void <LobTennisBall>b__1() { }

		internal void <LobTennisBall>b__3(float t) { }

		internal void <LobTennisBall>b__4() { }

		internal void <LobTennisBall>b__6() { }

		internal void <LobTennisBall>g__PlayerReaction|2() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass35_1
	{
		public bool useBackhand; //Field offset: 0x10
		public <>c__DisplayClass35_0 CS$<>8__locals1; //Field offset: 0x18

		public <>c__DisplayClass35_1() { }

		internal void <LobTennisBall>b__5(float t) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass37_0
	{
		public LevelCharacter friendly; //Field offset: 0x10

		public <>c__DisplayClass37_0() { }

		internal void <ReactToTennisBall>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass37_1
	{
		public LevelCharacter opponent; //Field offset: 0x10

		public <>c__DisplayClass37_1() { }

		internal void <ReactToTennisBall>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <LobTennisBall>d__35 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelCATennisballItemHandler <>4__this; //Field offset: 0x20
		public float delay; //Field offset: 0x28
		private <>c__DisplayClass35_0 <>8__1; //Field offset: 0x30

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
		public <LobTennisBall>d__35(int <>1__state) { }

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
	private static Action<LevelCATennisballItemHandler> OnServeAction; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<LevelCATennisballItemHandler> OnOpponentServeAction; //Field offset: 0x8
	[SerializeField]
	private float _flightSpeed; //Field offset: 0x88
	[SerializeField]
	private float arcFactor; //Field offset: 0x8C
	[SerializeField]
	private float forehandTime; //Field offset: 0x90
	[SerializeField]
	private float backhandTime; //Field offset: 0x94
	[Range(0, 10)]
	[SerializeField]
	private int backhandChance; //Field offset: 0x98
	[SerializeField]
	private bool canGameEnd; //Field offset: 0x9C
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0xA0
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0xA8
	[SerializeField]
	private PartcileSpawnLogic _particleSpawnLogic; //Field offset: 0xB0
	[SerializeField]
	private CourtType _requiredCourtType; //Field offset: 0xB4
	protected LevelCharacter _currentCharacter; //Field offset: 0xB8
	private LevelCharacter _targetCharacter; //Field offset: 0xC0
	protected int _throwTweenID; //Field offset: 0xC8
	protected bool _isThrowing; //Field offset: 0xCC
	private bool _isPracticing; //Field offset: 0xCD
	private int _passNumber; //Field offset: 0xD0
	private Random _random; //Field offset: 0xD8

	public static event Action<LevelCATennisballItemHandler> OnOpponentServeAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public static event Action<LevelCATennisballItemHandler> OnServeAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public LevelCATennisballItemHandler() { }

	[CompilerGenerated]
	public static void add_OnOpponentServeAction(Action<LevelCATennisballItemHandler> value) { }

	[CompilerGenerated]
	public static void add_OnServeAction(Action<LevelCATennisballItemHandler> value) { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	private LevelTennisCourtArea GetCourtArea(LevelCharacter character) { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsSilent() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	[IteratorStateMachine(typeof(<LobTennisBall>d__35))]
	private IEnumerator LobTennisBall(float delay) { }

	public void LobTennisBall() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	private void OnBeginDrag(DragDropItemBase dragDropItem, PointerEventData pointerEventData) { }

	protected virtual void OnDestroy() { }

	private void OnPreSaveProgress(Scene scene) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	private void PlayParticleEffect() { }

	private void ReactToTennisBall(bool didOtherCatchingSucceeded) { }

	[CompilerGenerated]
	public static void remove_OnOpponentServeAction(Action<LevelCATennisballItemHandler> value) { }

	[CompilerGenerated]
	public static void remove_OnServeAction(Action<LevelCATennisballItemHandler> value) { }

	private void StopParticleEffect() { }

	private float UpdateClosesCharacter() { }

}

