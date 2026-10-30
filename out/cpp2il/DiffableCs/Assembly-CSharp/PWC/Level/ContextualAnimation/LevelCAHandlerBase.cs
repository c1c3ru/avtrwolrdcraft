namespace PWC.Level.ContextualAnimation;

public abstract class LevelCAHandlerBase : MonoBehaviour, ILevelSpawnDuringGameplay
{
	[CompilerGenerated]
	private static Action<ICATarget, LevelCAConfig, String> OnAnimationBeginStaticAction; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<ICATarget, LevelCAConfig, String> OnAnimationEndStaticAction; //Field offset: 0x8
	[CompilerGenerated]
	private static Action<ICATarget, LevelCAConfig, String> OnAnimationCycleFullEndStaticAction; //Field offset: 0x10
	[SerializeField]
	private List<LevelCAConditionalFieldHandlerBase> _conditionalFields; //Field offset: 0x20
	[CompilerGenerated]
	private int <HudPageIndex>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private Action<LevelCAHandlerBase, ICATarget> OnAddedToTargetAction; //Field offset: 0x30
	[CompilerGenerated]
	private Action<LevelCAHandlerBase, ICATarget> OnRemovedFromTargetAction; //Field offset: 0x38
	[CompilerGenerated]
	private Action<LevelCAHandlerBase, ICATarget, LevelCAConfig> OnAnimationBeginAction; //Field offset: 0x40
	[CompilerGenerated]
	private Action<LevelCAHandlerBase, ICATarget, LevelCAConfig> OnAnimationEndAction; //Field offset: 0x48
	[CompilerGenerated]
	private Action<LevelCAHandlerBase, ICATarget, TrackEntry, Event> OnAnimationEventAction; //Field offset: 0x50
	[CompilerGenerated]
	private Action<LevelCAHandlerBase, ICATarget, LevelCAConfig, TrackEntry> OnAnimationPostBeginAction; //Field offset: 0x58
	[CompilerGenerated]
	private Action<LevelCAHandlerBase, ICATarget, LevelItem> OnItemDetachedFromTargetAction; //Field offset: 0x60
	[CompilerGenerated]
	private Action<LevelCAHandlerBase, ICATarget, LevelItem> OnItemAddedToTargetAction; //Field offset: 0x68
	private bool _didOnReadyPostLoad; //Field offset: 0x70
	private MPDataGeneratorHandle _mpDataGeneratorHandle; //Field offset: 0x78

	public event Action<LevelCAHandlerBase, ICATarget> OnAddedToTargetAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<LevelCAHandlerBase, ICATarget, LevelCAConfig> OnAnimationBeginAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public static event Action<ICATarget, LevelCAConfig, String> OnAnimationBeginStaticAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public static event Action<ICATarget, LevelCAConfig, String> OnAnimationCycleFullEndStaticAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public event Action<LevelCAHandlerBase, ICATarget, LevelCAConfig> OnAnimationEndAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public static event Action<ICATarget, LevelCAConfig, String> OnAnimationEndStaticAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public event Action<LevelCAHandlerBase, ICATarget, TrackEntry, Event> OnAnimationEventAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<LevelCAHandlerBase, ICATarget, LevelCAConfig, TrackEntry> OnAnimationPostBeginAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<LevelCAHandlerBase, ICATarget, LevelItem> OnItemAddedToTargetAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<LevelCAHandlerBase, ICATarget, LevelItem> OnItemDetachedFromTargetAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<LevelCAHandlerBase, ICATarget> OnRemovedFromTargetAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public int HudPageIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	protected LevelCAHandlerBase() { }

	[CompilerGenerated]
	public void add_OnAddedToTargetAction(Action<LevelCAHandlerBase, ICATarget> value) { }

	[CompilerGenerated]
	public void add_OnAnimationBeginAction(Action<LevelCAHandlerBase, ICATarget, LevelCAConfig> value) { }

	[CompilerGenerated]
	public static void add_OnAnimationBeginStaticAction(Action<ICATarget, LevelCAConfig, String> value) { }

	[CompilerGenerated]
	public static void add_OnAnimationCycleFullEndStaticAction(Action<ICATarget, LevelCAConfig, String> value) { }

	[CompilerGenerated]
	public void add_OnAnimationEndAction(Action<LevelCAHandlerBase, ICATarget, LevelCAConfig> value) { }

	[CompilerGenerated]
	public static void add_OnAnimationEndStaticAction(Action<ICATarget, LevelCAConfig, String> value) { }

	[CompilerGenerated]
	public void add_OnAnimationEventAction(Action<LevelCAHandlerBase, ICATarget, TrackEntry, Event> value) { }

	[CompilerGenerated]
	public void add_OnAnimationPostBeginAction(Action<LevelCAHandlerBase, ICATarget, LevelCAConfig, TrackEntry> value) { }

	[CompilerGenerated]
	public void add_OnItemAddedToTargetAction(Action<LevelCAHandlerBase, ICATarget, LevelItem> value) { }

	[CompilerGenerated]
	public void add_OnItemDetachedFromTargetAction(Action<LevelCAHandlerBase, ICATarget, LevelItem> value) { }

	[CompilerGenerated]
	public void add_OnRemovedFromTargetAction(Action<LevelCAHandlerBase, ICATarget> value) { }

	public override bool AllowReturnToIdleAnimationWhenRemovedFromTarget() { }

	protected override void Awake() { }

	public override bool CanPlayContextualAnimations(ICATarget target) { }

	public override bool CanSitWhileLocked() { }

	public override bool CanTargetHoldItems() { }

	public override bool CanTargetHoldSpecificItem(LevelItem item) { }

	protected override void EnsureOnReadyPostLoad() { }

	[CompilerGenerated]
	public int get_HudPageIndex() { }

	public abstract List<LevelCAConfig> GetAnimations() { }

	public override string GetAnimationSuffix() { }

	public override CACategoryType GetCategoryType() { }

	public abstract string GetFolderName() { }

	public override string GetForcedToSitAnimation(ICATarget target) { }

	public override string GetHandlerName() { }

	public override string GetLockedAnimationName() { }

	public Sprite GetPanelMainThumb() { }

	public override int GetPriority() { }

	public Random GetRandom() { }

	public override string GetSpacialTrackAnimationName() { }

	public abstract SpineType GetSpineType() { }

	protected override bool IsAllowedInWaterArea() { }

	public override bool IsForceToSitWhenPossible() { }

	public override bool IsLockedToTarget() { }

	public override bool isMainThumbFullSize() { }

	public override bool IsRelevantForTarget(ICATarget target) { }

	public override bool IsSilent() { }

	public override bool IsSingleCAInMenu() { }

	public override bool IsSpacialTrackToTarget() { }

	public override bool IsValidForTarget(ICATarget target) { }

	public void Multiplayer_SetOneCallGeneratorData(MPDataGeneratorHandle dataGeneratorHandler) { }

	public override void OnAddedToTarget(ICATarget target) { }

	public override void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public override void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public override void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	public override void OnAnimationFullCycleEnd(ICATarget target, LevelCAConfig config) { }

	public override void OnAnimationInterrupt(TrackEntry trackEntry) { }

	public override void OnAnimationPostBegin(ICATarget target, LevelCAConfig config, TrackEntry trackEntry) { }

	protected override void OnDestroy() { }

	protected override void OnDisable() { }

	protected override void OnEnable() { }

	public override void OnItemAddedToTarget(ICATarget target, LevelItem levelItem) { }

	public override void OnItemDetachedFromTarget(ICATarget target, LevelItem levelItem) { }

	protected override void OnLevelPostInit() { }

	protected void OnPostSpawnDuringAnimation() { }

	protected void OnPreSpawnDuringAnimation() { }

	protected override void OnReadyPostLoad() { }

	public override void OnRemovedFromTarget(ICATarget target) { }

	public override void OnSpawnDuringGameplay() { }

	protected override void OnTargetBeginDrag(DragDropItemBase dragDropItem, PointerEventData eventData) { }

	private void OnTargetBeginDragInternal(DragDropItemBase dragDropItem, PointerEventData eventData) { }

	protected override void OnTargetClick(DragDropItemBase dragDropItem, PointerEventData eventData) { }

	private void OnTargetClickInternal(DragDropItemBase dragDropItem, PointerEventData eventData) { }

	protected override void OnTargetEndDrag(DragDropItemBase dragDropItem, PointerEventData eventData) { }

	private void OnTargetEndDragInternal(DragDropItemBase dragDropItem, PointerEventData eventData) { }

	[CompilerGenerated]
	public void remove_OnAddedToTargetAction(Action<LevelCAHandlerBase, ICATarget> value) { }

	[CompilerGenerated]
	public void remove_OnAnimationBeginAction(Action<LevelCAHandlerBase, ICATarget, LevelCAConfig> value) { }

	[CompilerGenerated]
	public static void remove_OnAnimationBeginStaticAction(Action<ICATarget, LevelCAConfig, String> value) { }

	[CompilerGenerated]
	public static void remove_OnAnimationCycleFullEndStaticAction(Action<ICATarget, LevelCAConfig, String> value) { }

	[CompilerGenerated]
	public void remove_OnAnimationEndAction(Action<LevelCAHandlerBase, ICATarget, LevelCAConfig> value) { }

	[CompilerGenerated]
	public static void remove_OnAnimationEndStaticAction(Action<ICATarget, LevelCAConfig, String> value) { }

	[CompilerGenerated]
	public void remove_OnAnimationEventAction(Action<LevelCAHandlerBase, ICATarget, TrackEntry, Event> value) { }

	[CompilerGenerated]
	public void remove_OnAnimationPostBeginAction(Action<LevelCAHandlerBase, ICATarget, LevelCAConfig, TrackEntry> value) { }

	[CompilerGenerated]
	public void remove_OnItemAddedToTargetAction(Action<LevelCAHandlerBase, ICATarget, LevelItem> value) { }

	[CompilerGenerated]
	public void remove_OnItemDetachedFromTargetAction(Action<LevelCAHandlerBase, ICATarget, LevelItem> value) { }

	[CompilerGenerated]
	public void remove_OnRemovedFromTargetAction(Action<LevelCAHandlerBase, ICATarget> value) { }

	[CompilerGenerated]
	public void set_HudPageIndex(int value) { }

	public override bool ShouldPlayPreAnimation(LevelCAConfig config) { }

	protected override bool ShouldRegisterToEventSystemTargetEvents() { }

	public override bool ShouldReturnToIdleAnimationAtEndOfAnimation() { }

	private bool TryForceToFloat(ICATarget target) { }

	private bool TryForceToSit(ICATarget target) { }

	public override bool TryOverrideConfigThumb(int configIndex, out Sprite sprite) { }

	public override bool TryOverrideMainThumb(out Sprite sprite) { }

	public override bool TryOverridePanelSprite(out Sprite sprite) { }

}

