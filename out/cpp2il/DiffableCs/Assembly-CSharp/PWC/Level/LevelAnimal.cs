namespace PWC.Level;

public abstract class LevelAnimal : LevelSimpleConsumerItemBase, ILevelEater, ICATarget, ILevelLivingBeing, ILevelAnimatable, IHasSpineType, IMultiplayer_PrepareForDrop, IMultiplayer_TransformChange
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass95_0
	{
		public LevelAnimal <>4__this; //Field offset: 0x10
		public LevelItem levelItem; //Field offset: 0x18

		public <>c__DisplayClass95_0() { }

		internal void <PWC.Level.ILevelEater.Eat>b__0(TrackEntry x) { }

		internal void <PWC.Level.ILevelEater.Eat>b__1() { }

	}

	internal enum MovementType
	{
		None = 0,
		Stand = 1,
		Walk = 2,
		Run = 3,
	}

	private const float FIXED_X_MOVEMENT_OFFSET = 0,6; //Field offset: 0x0
	[SerializeField]
	private AnimalType _animalType; //Field offset: 0x344
	[SerializeField]
	private Transform _mouthPoint; //Field offset: 0x348
	[SerializeField]
	protected SkeletonAnimation _skeletonAnimation; //Field offset: 0x350
	[SerializeField]
	protected GameSoundPlayer _soundPlayer; //Field offset: 0x358
	private MovementType _movementType; //Field offset: 0x360
	private int _idleRandomAnimationTweenId; //Field offset: 0x364
	private float _walkTrackStartTime; //Field offset: 0x368
	private string _currentAnimationName; //Field offset: 0x370
	private bool _isPlayingIdleRandomAnimation; //Field offset: 0x378
	private bool _canForceNormalDragging; //Field offset: 0x379
	private bool _isLockedAnimationWhenWalking; //Field offset: 0x37A
	private bool _walkStartLoop; //Field offset: 0x37B
	private bool _forceNormalDragging; //Field offset: 0x37C
	private bool _lockAfterFirstMovement; //Field offset: 0x37D
	private Vector2 _positionOnBeginDrag; //Field offset: 0x380
	private Nullable<Vector2> _lastMovementPosition; //Field offset: 0x388
	[CompilerGenerated]
	private CAPlayType <CurrentCAPlayType>k__BackingField; //Field offset: 0x394
	[CompilerGenerated]
	private LevelCAConfig <PWC.Level.ContextualAnimation.ICATarget.CurrentCAConfig>k__BackingField; //Field offset: 0x398
	[CompilerGenerated]
	private LevelCAHandlerBase <CurrentCAHandler>k__BackingField; //Field offset: 0x3A0
	[CompilerGenerated]
	private int <PWC.Level.ContextualAnimation.ICATarget.ContexualAnimationCounter>k__BackingField; //Field offset: 0x3A8
	[CompilerGenerated]
	private LevelCAHandlerBase <LockedCAHandler>k__BackingField; //Field offset: 0x3B0
	[CompilerGenerated]
	private LevelCAConfig <AlternateIdleCAConfig>k__BackingField; //Field offset: 0x3B8
	[CompilerGenerated]
	private LevelCAHandlerBase <AlternateIdleCAHandler>k__BackingField; //Field offset: 0x3C0
	[CompilerGenerated]
	private readonly List<LevelCAHandlerBase> <CAHandlers>k__BackingField; //Field offset: 0x3C8
	[CompilerGenerated]
	private PostureType <PostureType>k__BackingField; //Field offset: 0x3D0
	[CompilerGenerated]
	private bool <HasSpecificPersistentData>k__BackingField; //Field offset: 0x3D4
	[CompilerGenerated]
	private string <PDAnimationName>k__BackingField; //Field offset: 0x3D8
	[CompilerGenerated]
	private Action<Event> OnSpineEventAction; //Field offset: 0x3E0
	[CompilerGenerated]
	private Action<LevelAnimal, Event> OnStepContact; //Field offset: 0x3E8
	private bool wasStepContactEventAdded; //Field offset: 0x3F0
	private TrackEntryEventDelegate _stepEventHandler; //Field offset: 0x3F8

	public override event Action<Event> OnSpineEventAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Action<LevelAnimal, Event> OnStepContact
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public LevelCAConfig AlternateIdleCAConfig
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 16
	}

	public LevelCAHandlerBase AlternateIdleCAHandler
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 16
	}

	public AnimalType AnimalType
	{
		 get { } //Length: 8
	}

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

	public bool HasSpecificPersistentData
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public override LevelCAHandlerBase LockedCAHandler
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 16
	}

	public string PDAnimationName
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 16
	}

	public PostureType PostureType
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

	protected LevelAnimal() { }

	[CompilerGenerated]
	private void <OnMovement>b__88_0(TrackEntry trackEntry, Event spineEvent) { }

	[CompilerGenerated]
	private void <PlaySittingIdle>b__104_0(TrackEntry _) { }

	[CompilerGenerated]
	private void <PlayStandingIdle>b__105_0(TrackEntry _) { }

	[CompilerGenerated]
	private void <TryPlayIdleRandomAnimation>b__107_0() { }

	[CompilerGenerated]
	private void <TryPlayIdleRandomAnimation>b__107_1(TrackEntry _) { }

	[CompilerGenerated]
	public override void add_OnSpineEventAction(Action<Event> value) { }

	[CompilerGenerated]
	public void add_OnStepContact(Action<LevelAnimal, Event> value) { }

	public TrackEntry AddAnimation(string animationName, bool loop = false, int trackIndex = 0) { }

	protected virtual void Awake() { }

	protected override bool CanEat() { }

	protected override bool CanSit() { }

	public void ForceNormalDragging(bool value) { }

	public void ForceSyncPosition(Vector2 pointerPosition) { }

	[CompilerGenerated]
	public LevelCAConfig get_AlternateIdleCAConfig() { }

	[CompilerGenerated]
	public LevelCAHandlerBase get_AlternateIdleCAHandler() { }

	public AnimalType get_AnimalType() { }

	[CompilerGenerated]
	public override List<LevelCAHandlerBase> get_CAHandlers() { }

	[CompilerGenerated]
	public override LevelCAHandlerBase get_CurrentCAHandler() { }

	[CompilerGenerated]
	public override CAPlayType get_CurrentCAPlayType() { }

	[CompilerGenerated]
	public bool get_HasSpecificPersistentData() { }

	[CompilerGenerated]
	public override LevelCAHandlerBase get_LockedCAHandler() { }

	[CompilerGenerated]
	public string get_PDAnimationName() { }

	[CompilerGenerated]
	public PostureType get_PostureType() { }

	protected virtual float GetCameraMovementSpeedFactor() { }

	protected virtual float GetCameraMovementThreshold() { }

	public override string GetCurrentAnimationName() { }

	public override EaterType GetEaterType() { }

	protected abstract String[] GetIdleAnimations() { }

	public override Transform GetMouthTransform() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected override string GetPickUpLoopAnimationName() { }

	protected override string GetRandomIdleAnimation() { }

	protected override string GetRunningAnimationName() { }

	protected override string GetSittingDownAnimationName() { }

	protected override string GetSittingIdleAnimationName() { }

	public override SkeletonAnimation GetSkeletonAnimation() { }

	public override SpineType GetSpineType() { }

	protected override string GetStandingIdleAnimationName() { }

	protected override string GetWalkingAnimationName() { }

	private void HandleSpineAnimationEvent(TrackEntry trackEntry, Event spineEvent) { }

	protected override bool HasRunningAnimations() { }

	public override bool HasSwimmingAnimations() { }

	protected override bool HasWalkingAnimations() { }

	private bool IsAboutToLandOnFloor() { }

	protected override bool IsSleeping() { }

	public virtual void Multiplayer_PrepareForDrag() { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	protected virtual void OnBeginLand(LevelDropArea dropArea) { }

	public void OnBeginMovement() { }

	public override void OnCARemoved() { }

	protected virtual void OnDestroy() { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

	protected virtual LevelDropArea OnEndLand() { }

	public void OnEndMovement() { }

	public void OnMovement() { }

	public virtual void OnPlacedOnAvatar(ILevelAvatar avatar, ItemOnAvatarType itemOnAvatarType) { }

	protected override void OnPlayRandomIdleAnimation(string randomIdleAnimation) { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	protected virtual void OnSyncPosition(Vector2 pointerPosition) { }

	public void PlayPickedUpLoopAnimation() { }

	private void PlayProperIdleAnimation(bool smooth = false) { }

	private void PlaySittingIdle(bool smooth) { }

	private void PlayStandingIdle() { }

	[CompilerGenerated]
	private override int PWC.Level.ContextualAnimation.ICATarget.get_ContexualAnimationCounter() { }

	[CompilerGenerated]
	private override LevelCAConfig PWC.Level.ContextualAnimation.ICATarget.get_CurrentCAConfig() { }

	private override Transform PWC.Level.ContextualAnimation.ICATarget.GetTransform() { }

	private override void PWC.Level.ContextualAnimation.ICATarget.OnAddedCAHandlerWithLockedAnimation(LevelCAHandlerBase handler) { }

	private override void PWC.Level.ContextualAnimation.ICATarget.OnBeforePlayContextualAnimation() { }

	[CompilerGenerated]
	private override void PWC.Level.ContextualAnimation.ICATarget.set_ContexualAnimationCounter(int value) { }

	[CompilerGenerated]
	private override void PWC.Level.ContextualAnimation.ICATarget.set_CurrentCAConfig(LevelCAConfig value) { }

	private override TrackEntry PWC.Level.ContextualAnimation.ICATarget.SetAnimation(string animationName, bool loop, bool ensureRequiredTextures, int trackIndex) { }

	private override bool PWC.Level.ContextualAnimation.ICATarget.ShouldIncludeInEnsureCheck(LevelCAHandlerBase handler) { }

	private override TrackEntry PWC.Level.ILevelAnimatable.AddAnimation(string animationName, bool loop, int trackIndex) { }

	private override TrackEntry PWC.Level.ILevelAnimatable.SetAnimation(string animationName, bool loop, int trackIndex) { }

	private override void PWC.Level.ILevelEater.Eat(LevelEatableItemHandler eatableItemHandler) { }

	private override bool PWC.Level.ILevelEater.TryEat(LevelEatableItemHandler eatableItemHandler) { }

	private override void PWC.Multiplayer.IMultiplayer_PrepareForDrop.Multiplayer_PrepareForDrop(MPDataType _) { }

	private override void PWC.Multiplayer.IMultiplayer_TransformChange.Multiplayer_OnTransformChange() { }

	[CompilerGenerated]
	public override void remove_OnSpineEventAction(Action<Event> value) { }

	[CompilerGenerated]
	public void remove_OnStepContact(Action<LevelAnimal, Event> value) { }

	public override void ReturnToIdleAnimation() { }

	[CompilerGenerated]
	public void set_AlternateIdleCAConfig(LevelCAConfig value) { }

	[CompilerGenerated]
	public void set_AlternateIdleCAHandler(LevelCAHandlerBase value) { }

	[CompilerGenerated]
	public override void set_CurrentCAHandler(LevelCAHandlerBase value) { }

	[CompilerGenerated]
	public override void set_CurrentCAPlayType(CAPlayType value) { }

	[CompilerGenerated]
	protected void set_HasSpecificPersistentData(bool value) { }

	[CompilerGenerated]
	public override void set_LockedCAHandler(LevelCAHandlerBase value) { }

	[CompilerGenerated]
	public void set_PDAnimationName(string value) { }

	[CompilerGenerated]
	protected void set_PostureType(PostureType value) { }

	private TrackEntry SetAddAnimationInternal(string animationName, bool loop, int trackIndex, bool add) { }

	public TrackEntry SetAnimation(string animationName, bool loop = false, int trackIndex = 0) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	protected void StopIdleRandomAnimations() { }

	protected void TryPlayIdleRandomAnimation() { }

}

