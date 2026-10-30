namespace PWC.Level;

public class LevelCharacter : LevelSimpleConsumerItemBase, ICATarget, ILevelLivingBeing, ILevelAvatar, ILevelHasClothingHandler, ILevelAnimatable, ILevelHasHands, ILevelCanRest, IHasSpineType, IInteractableItem, IMultiplayer_NetworkIdentityBase, IMultiplayer_PrepareForDrop, IMultiplayer_TransformChange, IMultiplayer_Messageable
{
	[CompilerGenerated]
	private struct <>c__DisplayClass145_0
	{
		public LevelCharacter <>4__this; //Field offset: 0x0
		public LevelCAHandlerBase handler; //Field offset: 0x8

	}

	internal enum CShapeType
	{
		Stand = 0,
		SitOnChair = 1,
		Sleep = 2,
	}

	public static readonly List<LevelCharacter> ListIncludeInactive; //Field offset: 0x0
	private const string MULTIPLAYER_DRAG_OUT_CLOTHING_KEY = "DragOutClothing"; //Field offset: 0x0
	public static readonly List<LevelCharacter> List; //Field offset: 0x8
	[SerializeField]
	private bool _useManualInit; //Field offset: 0x342
	[SerializeField]
	private int _sceneCharacterId; //Field offset: 0x344
	[SerializeField]
	private bool _isCharacterLockedToPlace; //Field offset: 0x348
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x350
	[SerializeField]
	private AvatarSpineSkinsManagerBase _avatarSpineSkinsManager; //Field offset: 0x358
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x360
	[SerializeField]
	private LevelCharacterDropActionArea _pairInteractionDropArea; //Field offset: 0x368
	private Config[] _generatedCShapeConfigs; //Field offset: 0x370
	private bool _isDisplayInPhone; //Field offset: 0x378
	private bool _didChangeSpineType; //Field offset: 0x379
	private int _lastUpdateCShapeFrame; //Field offset: 0x37C
	private LevelHintBubble _hintBubble; //Field offset: 0x380
	[CompilerGenerated]
	private LevelCharacterInteractionHandler <InteractionHandler>k__BackingField; //Field offset: 0x388
	[CompilerGenerated]
	private LevelCharacterAnimator <Animator>k__BackingField; //Field offset: 0x390
	[CompilerGenerated]
	private LevelCharacterClothingHandler <ClothingHandler>k__BackingField; //Field offset: 0x398
	[CompilerGenerated]
	private bool <CanPairWithActionArea>k__BackingField; //Field offset: 0x3A0
	[CompilerGenerated]
	private Action<LevelAvatarRestAreaBase> OnBeginDropOnRestAreaAction; //Field offset: 0x3A8
	[CompilerGenerated]
	private Action<LevelAvatarRestAreaBase> OnEndDropOnRestAreaAction; //Field offset: 0x3B0
	[CompilerGenerated]
	private LevelAvatarRestAreaBase <CurrentRestArea>k__BackingField; //Field offset: 0x3B8
	[CompilerGenerated]
	private Action<LevelItem> <OnPutItemInBoneAction>k__BackingField; //Field offset: 0x3C0
	[CompilerGenerated]
	private int <ID>k__BackingField; //Field offset: 0x3C8
	[CompilerGenerated]
	private bool <IsNewAvatar>k__BackingField; //Field offset: 0x3CC
	[CompilerGenerated]
	private AvatarSizeType <MyCharacterSizeType>k__BackingField; //Field offset: 0x3D0
	[CompilerGenerated]
	private Action<Event> OnSpineEventAction; //Field offset: 0x3D8
	[CompilerGenerated]
	private LevelCAHandlerBase <LockedCAHandler>k__BackingField; //Field offset: 0x3E0
	[CompilerGenerated]
	private LevelCAHandlerBase <CurrentCAHandler>k__BackingField; //Field offset: 0x3E8
	[CompilerGenerated]
	private LevelCAConfig <CurrentCAConfig>k__BackingField; //Field offset: 0x3F0
	[CompilerGenerated]
	private CAPlayType <CurrentCAPlayType>k__BackingField; //Field offset: 0x3F8
	[CompilerGenerated]
	private int <ContexualAnimationCounter>k__BackingField; //Field offset: 0x3FC
	[CompilerGenerated]
	private LevelCAConfig <AlternateIdleCAConfig>k__BackingField; //Field offset: 0x400
	[CompilerGenerated]
	private LevelCAHandlerBase <AlternateIdleCAHandler>k__BackingField; //Field offset: 0x408
	[CompilerGenerated]
	private readonly List<LevelCAHandlerBase> <CAHandlers>k__BackingField; //Field offset: 0x410
	[CompilerGenerated]
	private bool <IsDynamicSpawn>k__BackingField; //Field offset: 0x418
	[CompilerGenerated]
	private string <PDAnimationName>k__BackingField; //Field offset: 0x420

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

	public private LevelCharacterAnimator Animator
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 16
	}

	public override List<LevelCAHandlerBase> CAHandlers
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public private bool CanPairWithActionArea
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public private LevelCharacterClothingHandler ClothingHandler
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 16
	}

	public override int ContexualAnimationCounter
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public override LevelCAConfig CurrentCAConfig
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 16
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

	public private LevelCharacterInteractionHandler InteractionHandler
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 16
	}

	public bool IsDisplayInPhone
	{
		 get { } //Length: 8
	}

	public bool IsDynamicSpawn
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
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

	public AvatarSpineSkinsManagerBase MyAvatarSpineSkinsManager
	{
		 get { } //Length: 8
	}

	public private AvatarSizeType MyCharacterSizeType
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public SkeletonAnimation MySkeletonAnimation
	{
		 get { } //Length: 8
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

	public bool UseManualInit
	{
		 get { } //Length: 8
	}

	private static LevelCharacter() { }

	public LevelCharacter() { }

	[CompilerGenerated]
	private Bone <InitGeneratedCShape>g__GetBone|117_0(string boneName) { }

	[CompilerGenerated]
	private void <PWC.Level.ContextualAnimation.ICATarget.OnAddedCAHandlerWithLockedAnimation>g__FreeHandIfHasOtherItem|145_0(AvatarHandType type, ref <>c__DisplayClass145_0 unnamed_param_1) { }

	[CompilerGenerated]
	private void <TryDragOutClothingInternal>b__127_0(int categoryType, string skinName) { }

	[CompilerGenerated]
	public override void add_OnBeginDropOnRestAreaAction(Action<LevelAvatarRestAreaBase> value) { }

	[CompilerGenerated]
	public override void add_OnEndDropOnRestAreaAction(Action<LevelAvatarRestAreaBase> value) { }

	[CompilerGenerated]
	public override void add_OnSpineEventAction(Action<Event> value) { }

	protected virtual void Awake() { }

	protected virtual void CacheLevelItemsUnderSelfForNotifyEvents() { }

	public void CallOnBeginDropOnRestAreaAction(LevelAvatarRestAreaBase restArea) { }

	public void CallOnEndDropOnRestAreaAction(LevelAvatarRestAreaBase restArea) { }

	public bool CanPickUpClothingFromCharacter(int clothingType, Vector2 pointerPosition) { }

	protected virtual GameShape CreateGameShape() { }

	public override void DestroyAvatar(bool releaseChildrenItems) { }

	public void DestroyCharacterAndReleaseLevelFromIt() { }

	public virtual void DetachFromParentIfExists(bool callDetachEvent = true) { }

	public void DropFromRestAreaIfExists() { }

	public override void FreeHand(AvatarHandType handType) { }

	[CompilerGenerated]
	public LevelCAConfig get_AlternateIdleCAConfig() { }

	[CompilerGenerated]
	public LevelCAHandlerBase get_AlternateIdleCAHandler() { }

	[CompilerGenerated]
	public LevelCharacterAnimator get_Animator() { }

	[CompilerGenerated]
	public override List<LevelCAHandlerBase> get_CAHandlers() { }

	[CompilerGenerated]
	public bool get_CanPairWithActionArea() { }

	[CompilerGenerated]
	public LevelCharacterClothingHandler get_ClothingHandler() { }

	[CompilerGenerated]
	public override int get_ContexualAnimationCounter() { }

	[CompilerGenerated]
	public override LevelCAConfig get_CurrentCAConfig() { }

	[CompilerGenerated]
	public override LevelCAHandlerBase get_CurrentCAHandler() { }

	[CompilerGenerated]
	public override CAPlayType get_CurrentCAPlayType() { }

	[CompilerGenerated]
	public override LevelAvatarRestAreaBase get_CurrentRestArea() { }

	[CompilerGenerated]
	public override int get_ID() { }

	[CompilerGenerated]
	public LevelCharacterInteractionHandler get_InteractionHandler() { }

	public bool get_IsDisplayInPhone() { }

	[CompilerGenerated]
	public bool get_IsDynamicSpawn() { }

	[CompilerGenerated]
	public override bool get_IsNewAvatar() { }

	[CompilerGenerated]
	public override LevelCAHandlerBase get_LockedCAHandler() { }

	public AvatarSpineSkinsManagerBase get_MyAvatarSpineSkinsManager() { }

	[CompilerGenerated]
	public AvatarSizeType get_MyCharacterSizeType() { }

	public SkeletonAnimation get_MySkeletonAnimation() { }

	[CompilerGenerated]
	public override Action<LevelItem> get_OnPutItemInBoneAction() { }

	[CompilerGenerated]
	public string get_PDAnimationName() { }

	public bool get_UseManualInit() { }

	protected virtual float GetCameraMovementSpeedFactor() { }

	protected virtual float GetCameraMovementThreshold() { }

	public override string GetCurrentAnimationName() { }

	public override Vector2 GetDefaultPositionInHand(LevelItem levelItem, Transform parent) { }

	public LevelHintBubble GetHintBubble() { }

	public virtual float GetLandTweenDuration(float distanceToTarget) { }

	protected virtual LeanTweenType GetLandTweenEaseType() { }

	public override LevelItem GetLevelItem() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	public override SpineType GetSpineType() { }

	protected override void HandleSpineAnimationEvent(TrackEntry trackEntry, Event spineEvent) { }

	public void HideHintBubbleIfVisible() { }

	public override void Init(int id = -1) { }

	private void InitGeneratedCShape() { }

	private string Multiplayer_GetKey() { }

	public virtual void Multiplayer_PrepareForDrag() { }

	public virtual void OnBeginDrag(PointerEventData eventData) { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	public override void OnCARemoved() { }

	private void OnCShapeUpdateTransformDataIfNeeded() { }

	protected virtual void OnDestroy() { }

	protected virtual void OnDisable() { }

	protected virtual void OnEnable() { }

	public virtual void OnEndDrag(PointerEventData eventData) { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

	protected virtual LevelDropArea OnEndLand() { }

	public override void OnItemPutInBone(LevelItem levelItem) { }

	protected virtual void OnLevelPrePostInit() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	protected virtual void OnSyncPosition(Vector2 mousePosition) { }

	public override void PutInHand(LevelItem levelItem, AvatarHandType handType, bool snap = false) { }

	private override Transform PWC.Level.ContextualAnimation.ICATarget.GetTransform() { }

	private override void PWC.Level.ContextualAnimation.ICATarget.OnAddedCAHandlerWithLockedAnimation(LevelCAHandlerBase handler) { }

	private override void PWC.Level.ContextualAnimation.ICATarget.OnBeforePlayContextualAnimation() { }

	private override void PWC.Level.ContextualAnimation.ICATarget.ReturnToIdleAnimation() { }

	private override TrackEntry PWC.Level.ContextualAnimation.ICATarget.SetAnimation(string animationName, bool loop, bool ensureRequiredTextures, int trackIndex) { }

	private override bool PWC.Level.ContextualAnimation.ICATarget.ShouldIncludeInEnsureCheck(LevelCAHandlerBase handler) { }

	private override TrackEntry PWC.Level.ILevelAnimatable.AddAnimation(string animationName, bool loop, int trackIndex) { }

	private override SkeletonAnimation PWC.Level.ILevelAnimatable.GetSkeletonAnimation() { }

	private override TrackEntry PWC.Level.ILevelAnimatable.SetAnimation(string animationName, bool loop, int trackIndex) { }

	private override SkeletonAnimation PWC.Level.ILevelAvatar.GetSkeletonAnimation() { }

	private override AvatarSpineSkinsManagerBase PWC.Level.ILevelAvatar.GetSkinsManager() { }

	private override void PWC.Level.ILevelAvatar.PlayProperIdleAnimation() { }

	private override LevelAvatarClothingHandler PWC.Level.ILevelHasClothingHandler.GetLevelAvatarClothingHandler() { }

	private override void PWC.Multiplayer.IMultiplayer_Messageable.Multiplayer_ReceiveMessage(MPEventIdentifierData idData, object objectData) { }

	private override void PWC.Multiplayer.IMultiplayer_PrepareForDrop.Multiplayer_PrepareForDrop(MPDataType _) { }

	private override void PWC.Multiplayer.IMultiplayer_TransformChange.Multiplayer_OnTransformChange() { }

	private override void PWC.Multiplayer.MPDataHelper_ItemDropInteraction.IInteractableItem.Multiplayer_DropInteract(ILevelConsumer consumer, MPEventIdentifierData idData) { }

	[CompilerGenerated]
	public override void remove_OnBeginDropOnRestAreaAction(Action<LevelAvatarRestAreaBase> value) { }

	[CompilerGenerated]
	public override void remove_OnEndDropOnRestAreaAction(Action<LevelAvatarRestAreaBase> value) { }

	[CompilerGenerated]
	public override void remove_OnSpineEventAction(Action<Event> value) { }

	[CompilerGenerated]
	public void set_AlternateIdleCAConfig(LevelCAConfig value) { }

	[CompilerGenerated]
	public void set_AlternateIdleCAHandler(LevelCAHandlerBase value) { }

	[CompilerGenerated]
	private void set_Animator(LevelCharacterAnimator value) { }

	[CompilerGenerated]
	private void set_CanPairWithActionArea(bool value) { }

	[CompilerGenerated]
	private void set_ClothingHandler(LevelCharacterClothingHandler value) { }

	[CompilerGenerated]
	public override void set_ContexualAnimationCounter(int value) { }

	[CompilerGenerated]
	public override void set_CurrentCAConfig(LevelCAConfig value) { }

	[CompilerGenerated]
	public override void set_CurrentCAHandler(LevelCAHandlerBase value) { }

	[CompilerGenerated]
	public override void set_CurrentCAPlayType(CAPlayType value) { }

	[CompilerGenerated]
	public override void set_CurrentRestArea(LevelAvatarRestAreaBase value) { }

	[CompilerGenerated]
	private void set_ID(int value) { }

	[CompilerGenerated]
	private void set_InteractionHandler(LevelCharacterInteractionHandler value) { }

	[CompilerGenerated]
	public void set_IsDynamicSpawn(bool value) { }

	[CompilerGenerated]
	public override void set_IsNewAvatar(bool value) { }

	[CompilerGenerated]
	public override void set_LockedCAHandler(LevelCAHandlerBase value) { }

	[CompilerGenerated]
	private void set_MyCharacterSizeType(AvatarSizeType value) { }

	[CompilerGenerated]
	public override void set_OnPutItemInBoneAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public void set_PDAnimationName(string value) { }

	public void SetLayer(string layerName) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public static void SortCharacters() { }

	public void TogglePairInteraction(bool value) { }

	public bool TryDragOutClothing(PointerEventData eventData, Vector2 pointerPosition) { }

	private bool TryDragOutClothingInternal(CharacterCategoryType characterCategoryType, PointerEventData eventData, Vector2 pointerPosition) { }

	public virtual bool TryDropInteraction(ILevelConsumer consumer, out MPEventIdentifierData mpData) { }

	public virtual bool TryDropInteractionWithCharacter(LevelCharacter character, out MPEventIdentifierData mpData) { }

	public override bool TryGetHandItem(AvatarHandType handType, out LevelItem levelItem) { }

}

