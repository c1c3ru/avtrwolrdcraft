namespace Game.Level.ContextualAnimation;

public abstract class LevelCAWaterCannonDropAreaHandlerBase : LevelCADropAreaHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_0
	{
		public string previousAnimationName; //Field offset: 0x10
		public LevelCAWaterCannonDropAreaHandlerBase <>4__this; //Field offset: 0x18

		public <>c__DisplayClass13_0() { }

		internal void <WaitForRain>b__0(TrackEntry track) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_1
	{
		public LevelToddler <toddler>5__2; //Field offset: 0x10
		public bool loop; //Field offset: 0x18
		public <>c__DisplayClass13_0 CS$<>8__locals2; //Field offset: 0x20

		public <>c__DisplayClass13_1() { }

		internal void <WaitForRain>b__1(TrackEntry track) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass14_0
	{
		public LevelCAWaterCannonDropAreaHandlerBase <>4__this; //Field offset: 0x10
		public string previousAnimationName; //Field offset: 0x18

		public <>c__DisplayClass14_0() { }

		internal void <WaitForReaction>b__0(TrackEntry track) { }

		internal void <WaitForReaction>b__1(TrackEntry track) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass14_1
	{
		public LevelToddler <toddler>5__2; //Field offset: 0x10
		public bool loop; //Field offset: 0x18
		public <>c__DisplayClass14_0 CS$<>8__locals2; //Field offset: 0x20

		public <>c__DisplayClass14_1() { }

		internal void <WaitForReaction>b__2(TrackEntry track) { }

		internal void <WaitForReaction>b__3(TrackEntry track) { }

	}

	[CompilerGenerated]
	private sealed class <WaitForRain>d__13 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelCAWaterCannonDropAreaHandlerBase <>4__this; //Field offset: 0x20

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
		public <WaitForRain>d__13(int <>1__state) { }

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
	private sealed class <WaitForReaction>d__14 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelCAWaterCannonDropAreaHandlerBase <>4__this; //Field offset: 0x20
		private <>c__DisplayClass14_0 <>8__1; //Field offset: 0x28

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
		public <WaitForReaction>d__14(int <>1__state) { }

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

	protected const string DUCK = "CA/Water_Cannon/Duck"; //Field offset: 0x0
	private const string HUPPY_ACCIDENT_FACE = "CA/Water_Cannon/Happy_Accident_Face"; //Field offset: 0x0
	private const string HUPPY_ACCIDENT_CHEST = "CA/Water_Cannon/Happy_Accident_Chest"; //Field offset: 0x0
	[SerializeField]
	private SkeletonAnimation _waterCannon; //Field offset: 0x80
	[SerializeField]
	private LevelSingleItemDropArea _otherWaterCannonDropArea; //Field offset: 0x88
	[SerializeField]
	private ParticleSystem _waterCannonParticaleSystem; //Field offset: 0x90
	[SerializeField]
	private ParticleSystem _rainParticaleSystem; //Field offset: 0x98
	protected string _currentPlayAnimationName; //Field offset: 0xA0
	private GameSoundPlayer _waterCannonSound; //Field offset: 0xA8
	private ILevelAvatar _currentAvatar; //Field offset: 0xB0

	protected LevelCAWaterCannonDropAreaHandlerBase() { }

	protected virtual void Awake() { }

	protected override void GetCurrentPlayAnimationName(LevelCAConfig config) { }

	public virtual string GetFolderName() { }

	private bool IsAnimationInConfig(string animationName) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	private void PlayWaterCannon() { }

	private void StopWaterCannon() { }

	[IteratorStateMachine(typeof(<WaitForRain>d__13))]
	private IEnumerator WaitForRain() { }

	[IteratorStateMachine(typeof(<WaitForReaction>d__14))]
	private IEnumerator WaitForReaction() { }

}

