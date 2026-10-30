namespace PWC.Level;

public class LevelBaby : LevelSimpleConsumerItemBase, ICATarget, ILevelAvatar, ILevelLivingBeing, ILevelHasClothingHandler, ILevelAnimatable, ILevelHasMouth, ILevelCanRest, IHasSpineType
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<LevelItem> <>9__97_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <FreeMouth>b__97_0(LevelItem item) { }

	}

	[SerializeField]
	private LevelAvatarMouthDropArea _mouthDropArea; //Field offset: 0x348
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x350
	[SerializeField]
	private CShape _wrapArea; //Field offset: 0x358
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x360
	private bool _didChangeSpineType; //Field offset: 0x368
	private BabySpineSkinsManager _skinsManager; //Field offset: 0x370
	[CompilerGenerated]
	private LevelAvatarClothingHandler <ClothingHandler>k__BackingField; //Field offset: 0x378
	[CompilerGenerated]
	private CAPlayType <CurrentCAPlayType>k__BackingField; //Field offset: 0x380
	[CompilerGenerated]
	private LevelCAConfig <PWC.Level.ContextualAnimation.ICATarget.CurrentCAConfig>k__BackingField; //Field offset: 0x388
	[CompilerGenerated]
	private LevelCAHandlerBase <CurrentCAHandler>k__BackingField; //Field offset: 0x390
	[CompilerGenerated]
	private int <PWC.Level.ContextualAnimation.ICATarget.ContexualAnimationCounter>k__BackingField; //Field offset: 0x398
	[CompilerGenerated]
	private LevelCAHandlerBase <LockedCAHandler>k__BackingField; //Field offset: 0x3A0
	[CompilerGenerated]
	private readonly List<LevelCAHandlerBase> <CAHandlers>k__BackingField; //Field offset: 0x3A8
	[CompilerGenerated]
	private Action<LevelAvatarRestAreaBase> OnBeginDropOnRestAreaAction; //Field offset: 0x3B0
	[CompilerGenerated]
	private Action<LevelAvatarRestAreaBase> OnEndDropOnRestAreaAction; //Field offset: 0x3B8
	[CompilerGenerated]
	private LevelAvatarRestAreaBase <CurrentRestArea>k__BackingField; //Field offset: 0x3C0
	[CompilerGenerated]
	private Action<LevelItem> <OnPutItemInBoneAction>k__BackingField; //Field offset: 0x3C8
	[CompilerGenerated]
	private Action<Event> OnSpineEventAction; //Field offset: 0x3D0
	[CompilerGenerated]
	private int <ID>k__BackingField; //Field offset: 0x3D8
	[CompilerGenerated]
	private bool <IsNewAvatar>k__BackingField; //Field offset: 0x3DC
	[CompilerGenerated]
	private string <PDAnimationName>k__BackingField; //Field offset: 0x3E0

	public override event Action<LevelAvatarRestAreaBase> OnBeginDropOnRestAreaAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public override event Action<LevelAvatarRestAreaBase> OnEndDropOnRestAreaAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public override event Action<Event> OnSpineEventAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public override List<LevelCAHandlerBase> CAHandlers
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public private LevelAvatarClothingHandler ClothingHandler
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 16
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

	public override LevelAvatarRestAreaBase CurrentRestArea
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 16
	}

	public private override int ID
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public override bool IsNewAvatar
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

	public override Action<LevelItem> OnPutItemInBoneAction
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

	public LevelBaby() { }

	[CompilerGenerated]
	public override void add_OnBeginDropOnRestAreaAction(Action<LevelAvatarRestAreaBase> value) { }

	[CompilerGenerated]
	public override void add_OnEndDropOnRestAreaAction(Action<LevelAvatarRestAreaBase> value) { }

	[CompilerGenerated]
	public override void add_OnSpineEventAction(Action<Event> value) { }

	public TrackEntry AddAnimation(string animationName, bool loop = false, int trackIndex = 0) { }

	protected virtual void Awake() { }

	public virtual bool CanBeDroppedOn(LevelDropArea dropArea) { }

	public override void DestroyAvatar(bool releaseChildrenItems) { }

	public virtual void DetachFromParentIfExists(bool callDetachEvent = true) { }

	public override void FreeMouth() { }

	[CompilerGenerated]
	public override List<LevelCAHandlerBase> get_CAHandlers() { }

	[CompilerGenerated]
	public LevelAvatarClothingHandler get_ClothingHandler() { }

	[CompilerGenerated]
	public override LevelCAHandlerBase get_CurrentCAHandler() { }

	[CompilerGenerated]
	public override CAPlayType get_CurrentCAPlayType() { }

	[CompilerGenerated]
	public override LevelAvatarRestAreaBase get_CurrentRestArea() { }

	[CompilerGenerated]
	public override int get_ID() { }

	[CompilerGenerated]
	public override bool get_IsNewAvatar() { }

	[CompilerGenerated]
	public override LevelCAHandlerBase get_LockedCAHandler() { }

	[CompilerGenerated]
	public override Action<LevelItem> get_OnPutItemInBoneAction() { }

	[CompilerGenerated]
	public string get_PDAnimationName() { }

	public override string GetCurrentAnimationName() { }

	public virtual float GetLandTweenDuration(float distanceToTarget) { }

	protected virtual LeanTweenType GetLandTweenEaseType() { }

	public override LevelItem GetLevelItem() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	public override SkeletonAnimation GetSkeletonAnimation() { }

	public override SpineType GetSpineType() { }

	protected override void HandleSpineAnimationEvent(TrackEntry trackEntry, Event spineEvent) { }

	public override void Init(int id = -1) { }

	private bool IsLevelRestAreaTouchingAreaVisibleToUser(LevelAvatarRestAreaBase levelRestArea) { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	public override void OnCARemoved() { }

	protected virtual void OnDestroy() { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

	protected virtual LevelDropArea OnEndLand() { }

	protected virtual void OnLevelPrePostInit() { }

	public virtual void OnPointerClick(PointerEventData eventData) { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	[CompilerGenerated]
	private override int PWC.Level.ContextualAnimation.ICATarget.get_ContexualAnimationCounter() { }

	[CompilerGenerated]
	private override LevelCAConfig PWC.Level.ContextualAnimation.ICATarget.get_CurrentCAConfig() { }

	private override Transform PWC.Level.ContextualAnimation.ICATarget.GetTransform() { }

	private override void PWC.Level.ContextualAnimation.ICATarget.OnAddedCAHandlerWithLockedAnimation(LevelCAHandlerBase handler) { }

	[CompilerGenerated]
	private override void PWC.Level.ContextualAnimation.ICATarget.set_ContexualAnimationCounter(int value) { }

	[CompilerGenerated]
	private override void PWC.Level.ContextualAnimation.ICATarget.set_CurrentCAConfig(LevelCAConfig value) { }

	private override TrackEntry PWC.Level.ContextualAnimation.ICATarget.SetAnimation(string animationName, bool loop, bool ensureRequiredTextures, int trackIndex) { }

	private override bool PWC.Level.ContextualAnimation.ICATarget.ShouldIncludeInEnsureCheck(LevelCAHandlerBase handler) { }

	private override TrackEntry PWC.Level.ILevelAnimatable.AddAnimation(string animationName, bool loop, int trackIndex) { }

	private override TrackEntry PWC.Level.ILevelAnimatable.SetAnimation(string animationName, bool loop, int trackIndex) { }

	private override AvatarSpineSkinsManagerBase PWC.Level.ILevelAvatar.GetSkinsManager() { }

	private override void PWC.Level.ILevelAvatar.PlayProperIdleAnimation() { }

	private override LevelAvatarClothingHandler PWC.Level.ILevelHasClothingHandler.GetLevelAvatarClothingHandler() { }

	[CompilerGenerated]
	public override void remove_OnBeginDropOnRestAreaAction(Action<LevelAvatarRestAreaBase> value) { }

	[CompilerGenerated]
	public override void remove_OnEndDropOnRestAreaAction(Action<LevelAvatarRestAreaBase> value) { }

	[CompilerGenerated]
	public override void remove_OnSpineEventAction(Action<Event> value) { }

	public override void ReturnToIdleAnimation() { }

	[CompilerGenerated]
	private void set_ClothingHandler(LevelAvatarClothingHandler value) { }

	[CompilerGenerated]
	public override void set_CurrentCAHandler(LevelCAHandlerBase value) { }

	[CompilerGenerated]
	public override void set_CurrentCAPlayType(CAPlayType value) { }

	[CompilerGenerated]
	public override void set_CurrentRestArea(LevelAvatarRestAreaBase value) { }

	[CompilerGenerated]
	private void set_ID(int value) { }

	[CompilerGenerated]
	public override void set_IsNewAvatar(bool value) { }

	[CompilerGenerated]
	public override void set_LockedCAHandler(LevelCAHandlerBase value) { }

	[CompilerGenerated]
	public override void set_OnPutItemInBoneAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public void set_PDAnimationName(string value) { }

	private TrackEntry SetAddAnimationInternal(string animationName, bool loop, int trackIndex, bool add) { }

	public TrackEntry SetAnimation(string animationName, bool loop = false, int trackIndex = 0) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SitOn(LevelSitArea levelSitArea, bool snap) { }

	public virtual bool TryDropInteraction(ILevelConsumer consumer, out MPEventIdentifierData mpData) { }

	private bool TrySitOn(LevelSitArea levelSitArea) { }

}

