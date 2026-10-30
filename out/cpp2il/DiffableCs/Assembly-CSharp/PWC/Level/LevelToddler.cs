namespace PWC.Level;

public class LevelToddler : LevelSimpleConsumerItemBase, ILevelLivingBeing, ICATarget, ILevelAvatar, ILevelHasClothingHandler, ILevelAnimatable, ILevelEater, ILevelDrinker, ILevelHasHands, ILevelHasMouth, ILevelCanRest, IHasSpineType, IInteractableItem, IMultiplayer_NetworkIdentityBase, IMultiplayer_PrepareForDrop, IMultiplayer_TransformChange
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass147_0
	{
		public LevelItem levelItem; //Field offset: 0x10
		public LevelToddler <>4__this; //Field offset: 0x18
		public Vector2 mouthWorldPosition; //Field offset: 0x20
		public LevelEatableItemHandler eatableItemHandler; //Field offset: 0x28

		public <>c__DisplayClass147_0() { }

		internal void <PWC.Level.ILevelEater.Eat>b__1(TrackEntry x) { }

		internal void <PWC.Level.ILevelEater.Eat>b__2() { }

		internal void <PWC.Level.ILevelEater.Eat>b__3() { }

		internal void <PWC.Level.ILevelEater.Eat>g__RestoreAddCAHandlers|0(LevelDropArea dropArea) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass150_0
	{
		public LevelItem levelItem; //Field offset: 0x10
		public LevelToddler <>4__this; //Field offset: 0x18
		public Action <>9__3; //Field offset: 0x20

		public <>c__DisplayClass150_0() { }

		internal void <PWC.Level.ILevelDrinker.Drink>b__1(TrackEntry x) { }

		internal void <PWC.Level.ILevelDrinker.Drink>b__2() { }

		internal void <PWC.Level.ILevelDrinker.Drink>b__3() { }

		internal void <PWC.Level.ILevelDrinker.Drink>g__RestoreAddCAHandlers|0(LevelDropArea dropArea) { }

	}

	internal enum MovementType
	{
		None = 0,
		Stand = 1,
		Walk = 2,
		Run = 3,
	}

	[CompilerGenerated]
	private static Action<LevelToddler, Boolean> OnIsHeldByCharacterChangedStatic; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<LevelToddler, PostureType> OnPostureTypeChangedStatic; //Field offset: 0x8
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x348
	[SerializeField]
	private ToddlerSpineSkinsManager _skinsManager; //Field offset: 0x350
	[SerializeField]
	private LevelAvatarMouthDropArea _mouthDropArea; //Field offset: 0x358
	[SerializeField]
	private LevelDropArea _leftHand; //Field offset: 0x360
	[SerializeField]
	private LevelDropArea _rightHand; //Field offset: 0x368
	[SerializeField]
	private CShape _sitTouchArea; //Field offset: 0x370
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x378
	private MovementType _movementType; //Field offset: 0x380
	private bool _didOnReadyPostLoad; //Field offset: 0x384
	private bool _shouldAddCAHandlersFromHandItem; //Field offset: 0x385
	private bool _didChangeSpineType; //Field offset: 0x386
	private bool _shouldTweenDrinkableOnItemEndDrop; //Field offset: 0x387
	private bool _forceNormalDragging; //Field offset: 0x388
	private bool _canForceNormalDragging; //Field offset: 0x389
	private LevelHintBubble _hintBubble; //Field offset: 0x390
	private bool _isLockedAnimationWhenWalking; //Field offset: 0x398
	private string _currentAnimationName; //Field offset: 0x3A0
	private float _walkTrackStartTime; //Field offset: 0x3A8
	private bool _walkStartLoop; //Field offset: 0x3AC
	private Vector2 _positionOnBeginDrag; //Field offset: 0x3B0
	private Nullable<Vector2> _lastMovementPosition; //Field offset: 0x3B8
	private int _lastUpdateCShapeFrame; //Field offset: 0x3C4
	private Config[] _generatedCShapeConfigs; //Field offset: 0x3C8
	[CompilerGenerated]
	private LevelToddlerClothingHandler <ClothingHandler>k__BackingField; //Field offset: 0x3D0
	[CompilerGenerated]
	private CAPlayType <CurrentCAPlayType>k__BackingField; //Field offset: 0x3D8
	[CompilerGenerated]
	private LevelCAConfig <PWC.Level.ContextualAnimation.ICATarget.CurrentCAConfig>k__BackingField; //Field offset: 0x3E0
	[CompilerGenerated]
	private LevelCAHandlerBase <CurrentCAHandler>k__BackingField; //Field offset: 0x3E8
	[CompilerGenerated]
	private int <PWC.Level.ContextualAnimation.ICATarget.ContexualAnimationCounter>k__BackingField; //Field offset: 0x3F0
	[CompilerGenerated]
	private LevelCAHandlerBase <LockedCAHandler>k__BackingField; //Field offset: 0x3F8
	[CompilerGenerated]
	private readonly List<LevelCAHandlerBase> <CAHandlers>k__BackingField; //Field offset: 0x400
	[CompilerGenerated]
	private Action<LevelAvatarRestAreaBase> OnBeginDropOnRestAreaAction; //Field offset: 0x408
	[CompilerGenerated]
	private Action<LevelAvatarRestAreaBase> OnEndDropOnRestAreaAction; //Field offset: 0x410
	[CompilerGenerated]
	private LevelAvatarRestAreaBase <CurrentRestArea>k__BackingField; //Field offset: 0x418
	[CompilerGenerated]
	private Action<LevelItem> <OnPutItemInBoneAction>k__BackingField; //Field offset: 0x420
	[CompilerGenerated]
	private Action<Event> OnSpineEventAction; //Field offset: 0x428
	[CompilerGenerated]
	private int <ID>k__BackingField; //Field offset: 0x430
	[CompilerGenerated]
	private bool <IsNewAvatar>k__BackingField; //Field offset: 0x434
	[CompilerGenerated]
	private string <PDAnimationName>k__BackingField; //Field offset: 0x438
	[CompilerGenerated]
	private PostureType <PostureType>k__BackingField; //Field offset: 0x440
	private bool _isHeldByCharacter; //Field offset: 0x444
	[CompilerGenerated]
	private Action<LevelToddler, Event> OnStepContact; //Field offset: 0x448
	private bool wasStepContactEventAdded; //Field offset: 0x450
	private TrackEntryEventDelegate _stepEventHandler; //Field offset: 0x458

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

	public static event Action<LevelToddler, Boolean> OnIsHeldByCharacterChangedStatic
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public static event Action<LevelToddler, PostureType> OnPostureTypeChangedStatic
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public override event Action<Event> OnSpineEventAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Action<LevelToddler, Event> OnStepContact
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

	public private LevelToddlerClothingHandler ClothingHandler
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

	public bool IsHeldByCharacter
	{
		 get { } //Length: 8
		 set { } //Length: 148
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

	public private PostureType PostureType
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
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

	public LevelToddler() { }

	[CompilerGenerated]
	private Bone <InitGeneratedCShape>g__GetBone|99_0(string boneName) { }

	[CompilerGenerated]
	private void <OnMovement>b__109_0(TrackEntry trackEntry, Event spineEvent) { }

	[CompilerGenerated]
	public override void add_OnBeginDropOnRestAreaAction(Action<LevelAvatarRestAreaBase> value) { }

	[CompilerGenerated]
	public override void add_OnEndDropOnRestAreaAction(Action<LevelAvatarRestAreaBase> value) { }

	[CompilerGenerated]
	public static void add_OnIsHeldByCharacterChangedStatic(Action<LevelToddler, Boolean> value) { }

	[CompilerGenerated]
	public static void add_OnPostureTypeChangedStatic(Action<LevelToddler, PostureType> value) { }

	[CompilerGenerated]
	public override void add_OnSpineEventAction(Action<Event> value) { }

	[CompilerGenerated]
	public void add_OnStepContact(Action<LevelToddler, Event> value) { }

	public TrackEntry AddAnimation(string animationName, bool loop = false, int trackIndex = 0) { }

	private void AddCAHandlersFromHandItemIfNeeded(LevelItem levelItem) { }

	protected virtual void Awake() { }

	public virtual bool CanBeDroppedOn(LevelDropArea dropArea) { }

	public bool CanEatOrDrink() { }

	public override void DestroyAvatar(bool releaseChildrenItems) { }

	public virtual void DetachFromParentIfExists(bool callDetachEvent = true) { }

	private void EnsureOnReadyPostLoad() { }

	public override void FreeHand(AvatarHandType handType) { }

	private void FreeHand(LevelDropArea dropArea) { }

	public void FreeHands() { }

	public override void FreeMouth() { }

	[CompilerGenerated]
	public override List<LevelCAHandlerBase> get_CAHandlers() { }

	[CompilerGenerated]
	public LevelToddlerClothingHandler get_ClothingHandler() { }

	[CompilerGenerated]
	public override LevelCAHandlerBase get_CurrentCAHandler() { }

	[CompilerGenerated]
	public override CAPlayType get_CurrentCAPlayType() { }

	[CompilerGenerated]
	public override LevelAvatarRestAreaBase get_CurrentRestArea() { }

	[CompilerGenerated]
	public override int get_ID() { }

	public bool get_IsHeldByCharacter() { }

	[CompilerGenerated]
	public override bool get_IsNewAvatar() { }

	[CompilerGenerated]
	public override LevelCAHandlerBase get_LockedCAHandler() { }

	[CompilerGenerated]
	public override Action<LevelItem> get_OnPutItemInBoneAction() { }

	[CompilerGenerated]
	public string get_PDAnimationName() { }

	[CompilerGenerated]
	public PostureType get_PostureType() { }

	protected virtual float GetCameraMovementSpeedFactor() { }

	protected virtual float GetCameraMovementThreshold() { }

	public override string GetCurrentAnimationName() { }

	public override EaterType GetEaterType() { }

	public LevelDropArea GetHandDropArea(AvatarHandType handType) { }

	public ItemOnAvatarType GetHandTypeForDropArea(LevelDropArea dropArea) { }

	public LevelHintBubble GetHintBubble() { }

	private string GetIdleAnimationName() { }

	public virtual float GetLandTweenDuration(float distanceToTarget) { }

	protected virtual LeanTweenType GetLandTweenEaseType() { }

	public override LevelItem GetLevelItem() { }

	public override Transform GetMouthTransform() { }

	public MovementType GetMovementType() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	public override SkeletonAnimation GetSkeletonAnimation() { }

	public override SpineType GetSpineType() { }

	private void HandleSpineAnimationEvent(TrackEntry trackEntry, Event spineEvent) { }

	public void HandsSetActive(bool value) { }

	public void HideHintBubbleIfVisible() { }

	public override void Init(int id = -1) { }

	private void InitGeneratedCShape() { }

	private bool IsLevelRestAreaTouchingAreaVisibleToUser(LevelAvatarRestAreaBase levelRestArea) { }

	private string Multiplayer_GetKey() { }

	public virtual void Multiplayer_PrepareForDrag() { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	public void OnBeginMovement() { }

	public void OnCARemoved() { }

	private void OnCShapeUpdateTransformDataIfNeeded() { }

	protected virtual void OnDestroy() { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

	protected virtual LevelDropArea OnEndLand() { }

	public void OnEndMovement() { }

	private void OnItemBeginDropInLeftHand(LevelItem levelItem) { }

	private void OnItemBeginDropInRightHand(LevelItem levelItem) { }

	private void OnItemEndDropInHand(LevelItem levelItem) { }

	private void OnItemPickUpFromHand(LevelItem levelItem) { }

	public override void OnItemPutInBone(LevelItem levelItem) { }

	protected virtual void OnLevelPostInit() { }

	protected virtual void OnLevelPrePostInit() { }

	public void OnMovement() { }

	public virtual void OnPointerClick(PointerEventData eventData) { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	private void OnReadyPostLoad() { }

	public virtual void OnSpawnDuringGameplay() { }

	protected virtual void OnSyncPosition(Vector2 pointerPosition) { }

	public void PlayProperIdleAnimation() { }

	public override void PutInHand(LevelItem levelItem, AvatarHandType handType, bool snap = false) { }

	[CompilerGenerated]
	private override int PWC.Level.ContextualAnimation.ICATarget.get_ContexualAnimationCounter() { }

	[CompilerGenerated]
	private override LevelCAConfig PWC.Level.ContextualAnimation.ICATarget.get_CurrentCAConfig() { }

	private override Transform PWC.Level.ContextualAnimation.ICATarget.GetTransform() { }

	private override void PWC.Level.ContextualAnimation.ICATarget.OnAddedCAHandlerWithLockedAnimation(LevelCAHandlerBase handler) { }

	private override void PWC.Level.ContextualAnimation.ICATarget.OnCARemoved() { }

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

	private override void PWC.Level.ILevelDrinker.Drink(LevelDrinkableItemHandler drinkableItemHandler) { }

	private override bool PWC.Level.ILevelDrinker.TryDrink(LevelDrinkableItemHandler drinkableItemHandler) { }

	private override void PWC.Level.ILevelEater.Eat(LevelEatableItemHandler eatableItemHandler) { }

	private override bool PWC.Level.ILevelEater.TryEat(LevelEatableItemHandler eatableItemHandler) { }

	private override LevelAvatarClothingHandler PWC.Level.ILevelHasClothingHandler.GetLevelAvatarClothingHandler() { }

	private override void PWC.Multiplayer.IMultiplayer_PrepareForDrop.Multiplayer_PrepareForDrop(MPDataType _) { }

	private override void PWC.Multiplayer.IMultiplayer_TransformChange.Multiplayer_OnTransformChange() { }

	private override void PWC.Multiplayer.MPDataHelper_ItemDropInteraction.IInteractableItem.Multiplayer_DropInteract(ILevelConsumer consumer, MPEventIdentifierData idData) { }

	[CompilerGenerated]
	public override void remove_OnBeginDropOnRestAreaAction(Action<LevelAvatarRestAreaBase> value) { }

	[CompilerGenerated]
	public override void remove_OnEndDropOnRestAreaAction(Action<LevelAvatarRestAreaBase> value) { }

	[CompilerGenerated]
	public static void remove_OnIsHeldByCharacterChangedStatic(Action<LevelToddler, Boolean> value) { }

	[CompilerGenerated]
	public static void remove_OnPostureTypeChangedStatic(Action<LevelToddler, PostureType> value) { }

	[CompilerGenerated]
	public override void remove_OnSpineEventAction(Action<Event> value) { }

	[CompilerGenerated]
	public void remove_OnStepContact(Action<LevelToddler, Event> value) { }

	private void RemoveCAHAndlersFromHandItemIfNeeded(LevelItem levelItem) { }

	public override void ReturnToIdleAnimation() { }

	[CompilerGenerated]
	private void set_ClothingHandler(LevelToddlerClothingHandler value) { }

	[CompilerGenerated]
	public override void set_CurrentCAHandler(LevelCAHandlerBase value) { }

	[CompilerGenerated]
	public override void set_CurrentCAPlayType(CAPlayType value) { }

	[CompilerGenerated]
	public override void set_CurrentRestArea(LevelAvatarRestAreaBase value) { }

	[CompilerGenerated]
	private void set_ID(int value) { }

	public void set_IsHeldByCharacter(bool value) { }

	[CompilerGenerated]
	public override void set_IsNewAvatar(bool value) { }

	[CompilerGenerated]
	public override void set_LockedCAHandler(LevelCAHandlerBase value) { }

	[CompilerGenerated]
	public override void set_OnPutItemInBoneAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public void set_PDAnimationName(string value) { }

	[CompilerGenerated]
	private void set_PostureType(PostureType value) { }

	private TrackEntry SetAddAnimationInternal(string animationName, bool loop, int trackIndex, bool add) { }

	public TrackEntry SetAnimation(string animationName, bool loop = false, int trackIndex = 0) { }

	public void SetEmtyAnimation(int trackIndex, float mixDuration = 0) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetPostureType(PostureType postureType) { }

	public void SitOn(LevelSitArea levelSitArea, bool snap) { }

	public virtual bool TryDropInteraction(ILevelConsumer consumer, out MPEventIdentifierData mpData) { }

	public override bool TryGetHandItem(AvatarHandType handType, out LevelItem levelitem) { }

	private bool TrySitOn(LevelSitArea levelSitArea) { }

	public void TweenDrinkableToDesiredPositionIfNeeded(LevelItem levelItem, bool value) { }

}

