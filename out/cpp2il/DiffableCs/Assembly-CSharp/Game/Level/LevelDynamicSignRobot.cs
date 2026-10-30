namespace Game.Level;

public class LevelDynamicSignRobot : LevelItem, ICATarget, ILevelLivingBeing
{
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x348
	[SerializeField]
	[SpineAnimation(null, "_skeletonAnimation", True, False, False)]
	private string _PopOutAnimationName; //Field offset: 0x350
	[SerializeField]
	[SpineAnimation(null, "_skeletonAnimation", True, False, False)]
	private string _idleAnimation; //Field offset: 0x358
	[SerializeField]
	private string _popOutClipName; //Field offset: 0x360
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x368
	[CompilerGenerated]
	private CAPlayType <CurrentCAPlayType>k__BackingField; //Field offset: 0x370
	[CompilerGenerated]
	private LevelCAConfig <PWC.Level.ContextualAnimation.ICATarget.CurrentCAConfig>k__BackingField; //Field offset: 0x378
	[CompilerGenerated]
	private LevelCAHandlerBase <CurrentCAHandler>k__BackingField; //Field offset: 0x380
	[CompilerGenerated]
	private int <PWC.Level.ContextualAnimation.ICATarget.ContexualAnimationCounter>k__BackingField; //Field offset: 0x388
	[CompilerGenerated]
	private LevelCAHandlerBase <PWC.Level.ContextualAnimation.ICATarget.LockedCAHandler>k__BackingField; //Field offset: 0x390
	[CompilerGenerated]
	private readonly List<LevelCAHandlerBase> <CAHandlers>k__BackingField; //Field offset: 0x398
	private bool _isInit; //Field offset: 0x3A0

	public override List<LevelCAHandlerBase> CAHandlers
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public override LevelCAHandlerBase CurrentCAHandler
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 16
	}

	public override CAPlayType CurrentCAPlayType
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	private override int PWC.Level.ContextualAnimation.ICATarget.ContexualAnimationCounter
	{
		[CompilerGenerated]
		private get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	private override LevelCAConfig PWC.Level.ContextualAnimation.ICATarget.CurrentCAConfig
	{
		[CompilerGenerated]
		private get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 16
	}

	private override LevelCAHandlerBase PWC.Level.ContextualAnimation.ICATarget.LockedCAHandler
	{
		[CompilerGenerated]
		private get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 16
	}

	public LevelDynamicSignRobot() { }

	public TrackEntry AddAnimation(string animationName, bool loop = false, int trackIndex = 0) { }

	protected virtual void Awake() { }

	private void CanBePutInCharacterHand(LevelCharacter character, ref bool canPutInHand) { }

	[CompilerGenerated]
	public override List<LevelCAHandlerBase> get_CAHandlers() { }

	[CompilerGenerated]
	public override LevelCAHandlerBase get_CurrentCAHandler() { }

	[CompilerGenerated]
	public override CAPlayType get_CurrentCAPlayType() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected override void HandleSpineAnimationEvent(TrackEntry trackEntry, Event spineEvent) { }

	public void Init(bool isJumpOutOfFrame) { }

	public override void OnAddedCAHandlerWithLockedAnimation(LevelCAHandlerBase handler) { }

	public override void OnBeforePlayContextualAnimation() { }

	public override void OnCARemoved() { }

	protected virtual void OnDestroy() { }

	protected virtual void OnLevelPostInit() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	public virtual void OnSpawnDuringGameplay() { }

	[CompilerGenerated]
	private override int PWC.Level.ContextualAnimation.ICATarget.get_ContexualAnimationCounter() { }

	[CompilerGenerated]
	private override LevelCAConfig PWC.Level.ContextualAnimation.ICATarget.get_CurrentCAConfig() { }

	[CompilerGenerated]
	private override LevelCAHandlerBase PWC.Level.ContextualAnimation.ICATarget.get_LockedCAHandler() { }

	private override Transform PWC.Level.ContextualAnimation.ICATarget.GetTransform() { }

	[CompilerGenerated]
	private override void PWC.Level.ContextualAnimation.ICATarget.set_ContexualAnimationCounter(int value) { }

	[CompilerGenerated]
	private override void PWC.Level.ContextualAnimation.ICATarget.set_CurrentCAConfig(LevelCAConfig value) { }

	[CompilerGenerated]
	private override void PWC.Level.ContextualAnimation.ICATarget.set_LockedCAHandler(LevelCAHandlerBase value) { }

	private override TrackEntry PWC.Level.ContextualAnimation.ICATarget.SetAnimation(string animationName, bool loop, bool ensureRequiredTextures, int trackIndex) { }

	private override bool PWC.Level.ContextualAnimation.ICATarget.ShouldIncludeInEnsureCheck(LevelCAHandlerBase handler) { }

	public override void ReturnToIdleAnimation() { }

	[CompilerGenerated]
	public override void set_CurrentCAHandler(LevelCAHandlerBase value) { }

	[CompilerGenerated]
	public override void set_CurrentCAPlayType(CAPlayType value) { }

	private TrackEntry SetAddAnimationInternal(string animationName, bool loop, int trackIndex, bool add) { }

	public TrackEntry SetAnimation(string animationName, bool loop = false, int trackIndex = 0) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

