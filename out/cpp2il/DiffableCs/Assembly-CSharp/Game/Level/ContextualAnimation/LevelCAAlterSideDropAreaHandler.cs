namespace Game.Level.ContextualAnimation;

public class LevelCAAlterSideDropAreaHandler : LevelCADropAreaHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<LevelCAConfig> <>9__26_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <Awake>b__26_0(LevelCAConfig x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass34_0
	{
		public LevelCAAlterSideDropAreaHandler <>4__this; //Field offset: 0x10
		public BoneFollower hand; //Field offset: 0x18

		public <>c__DisplayClass34_0() { }

		internal void <PutRing>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass42_0
	{
		public LevelCharacter character; //Field offset: 0x10

		public <>c__DisplayClass42_0() { }

		internal void <StopCrowdReactions>b__0() { }

	}

	internal enum WeddingTheme
	{
		Wedding = 0,
		Beach = 1,
	}

	private const string SMOOCH_ANIMATION_NAME = "Smooch"; //Field offset: 0x0
	private const string CLAPPING_ANIMATION_NAME = "CA/Audience/Clapping_2"; //Field offset: 0x0
	private const string WISTLE_ANIMATION_NAME = "CA/Audience/Clapping_With_Whistle"; //Field offset: 0x0
	[SerializeField]
	private LevelCAAlterSideDropAreaHandler _otherPerson; //Field offset: 0x80
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x88
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x90
	[SerializeField]
	private WeddingTheme _weddingTheme; //Field offset: 0x98
	[CompilerGenerated]
	private Action<Int32> OnEventTriggerAction; //Field offset: 0xA0
	[CompilerGenerated]
	private Action<Boolean> OnSpotStateChangeAction; //Field offset: 0xA8
	private LevelCharacter _currentCharacter; //Field offset: 0xB0
	private bool _isInitiator; //Field offset: 0xB8
	private int _weddingRoutineTweenID; //Field offset: 0xBC
	private int _putRingTweenID; //Field offset: 0xC0
	private bool _isPuttingRing; //Field offset: 0xC4
	private Dictionary<Int32, Int32> _tweenIdByCharacterId; //Field offset: 0xC8
	private LevelCAConfig _smoochConfig; //Field offset: 0xD0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xD8

	public event Action<Int32> OnEventTriggerAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<Boolean> OnSpotStateChangeAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public LevelCharacter CurrentCharacter
	{
		 get { } //Length: 8
	}

	public bool IsInitiator
	{
		 get { } //Length: 8
	}

	public LevelCAAlterSideDropAreaHandler() { }

	[CompilerGenerated]
	private void <StartWeddingRoutine>b__39_0() { }

	[CompilerGenerated]
	private void <StartWeddingRoutine>b__39_1() { }

	[CompilerGenerated]
	public void add_OnEventTriggerAction(Action<Int32> value) { }

	[CompilerGenerated]
	public void add_OnSpotStateChangeAction(Action<Boolean> value) { }

	protected virtual void Awake() { }

	private int ChooseRingID() { }

	public LevelCharacter get_CurrentCharacter() { }

	public bool get_IsInitiator() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	private void InitIfNeeded() { }

	public virtual bool IsRelevantForTarget(ICATarget target) { }

	private bool IsWhistle() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	protected virtual void OnDestroy() { }

	private void OnEventTrigger(int eventId) { }

	protected virtual void OnLevelPostInit() { }

	private void OnOtherSpotStateChange(bool isOtherPersonReady) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	private void PutRing() { }

	[CompilerGenerated]
	public void remove_OnEventTriggerAction(Action<Int32> value) { }

	[CompilerGenerated]
	public void remove_OnSpotStateChangeAction(Action<Boolean> value) { }

	private void ShowCrowdReactions() { }

	private void StartWeddingRoutine() { }

	private void StopCrowdReactions() { }

	private void UpdateCharacterOnDropArea(LevelCharacter character) { }

}

