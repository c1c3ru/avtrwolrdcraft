namespace PWC.Level.Maker;

public class LevelMakerItem : DragDropItemBase, ILevelEntity, IHasPersistentData, IRequirePDSceneObject, IHasMovableLightSystemObject, ILevelSpawnDuringGameplay, ILevelMakerDeletableByUIItem, IMultiplayer_TransformChange
{
	[CompilerGenerated]
	private static Action<LevelMakerItem> OnItemBeginDragAction; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<LevelMakerItem> OnItemEndDragAction; //Field offset: 0x8
	[CompilerGenerated]
	private static Action<LevelMakerItem> OnItemClickAction; //Field offset: 0x10
	public static readonly List<LevelMakerItem> List; //Field offset: 0x18
	[CompilerGenerated]
	private static int <LastPointerDownFrameCount>k__BackingField; //Field offset: 0x20
	[FormerlySerializedAs("_spriteRenderer")]
	[SerializeField]
	protected Renderer _renderer; //Field offset: 0x110
	private SortingGroup _sortingGroup; //Field offset: 0x118
	private SortingElement _sortingElement; //Field offset: 0x120
	private Vector2 _lastPointerPosition; //Field offset: 0x128
	protected MovableLightSystemObject _movableLightSystemObject; //Field offset: 0x130
	protected LitSpriteRenderer _litSpriteRenderer; //Field offset: 0x138
	private PDPrefab _pdPrefab; //Field offset: 0x140
	[CompilerGenerated]
	private Action OnEnterMakerModeAction; //Field offset: 0x148
	[CompilerGenerated]
	private Action OnExitMakerModeAction; //Field offset: 0x150
	[CompilerGenerated]
	private Action<LevelMakerItem, Boolean> OnSyncIsFlippedStateAction; //Field offset: 0x158
	[CompilerGenerated]
	private Action<LevelMakerItem> OnBeforeDestroyWhileInGameplayAction; //Field offset: 0x160
	private ILevelMakerDisabledWhileInEditMode[] _componentsDisabledWhileInEditMode; //Field offset: 0x168
	[CompilerGenerated]
	private readonly List<LevelAreaBase> <MyAreas>k__BackingField; //Field offset: 0x170
	protected bool _isInMakerMode; //Field offset: 0x178
	[CompilerGenerated]
	private bool <ShouldCallMoveCameraIfPointerOnScreenEdgeOnSyncPosition>k__BackingField; //Field offset: 0x179
	protected LevelWallArea _currentWallArea; //Field offset: 0x180

	public event Action<LevelMakerItem> OnBeforeDestroyWhileInGameplayAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Action OnEnterMakerModeAction
	{
		[CompilerGenerated]
		 add { } //Length: 160
		[CompilerGenerated]
		 remove { } //Length: 160
	}

	public event Action OnExitMakerModeAction
	{
		[CompilerGenerated]
		 add { } //Length: 160
		[CompilerGenerated]
		 remove { } //Length: 160
	}

	public static event Action<LevelMakerItem> OnItemBeginDragAction
	{
		[CompilerGenerated]
		 add { } //Length: 240
		[CompilerGenerated]
		 remove { } //Length: 240
	}

	public static event Action<LevelMakerItem> OnItemClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 244
		[CompilerGenerated]
		 remove { } //Length: 244
	}

	public static event Action<LevelMakerItem> OnItemEndDragAction
	{
		[CompilerGenerated]
		 add { } //Length: 244
		[CompilerGenerated]
		 remove { } //Length: 244
	}

	public event Action<LevelMakerItem, Boolean> OnSyncIsFlippedStateAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public LevelWallArea CurrentWallArea
	{
		 get { } //Length: 8
	}

	public private static int LastPointerDownFrameCount
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		private set { } //Length: 92
	}

	public override List<LevelAreaBase> MyAreas
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public bool ShouldCallMoveCameraIfPointerOnScreenEdgeOnSyncPosition
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	private static LevelMakerItem() { }

	public LevelMakerItem() { }

	[CompilerGenerated]
	public void add_OnBeforeDestroyWhileInGameplayAction(Action<LevelMakerItem> value) { }

	[CompilerGenerated]
	public void add_OnEnterMakerModeAction(Action value) { }

	[CompilerGenerated]
	public void add_OnExitMakerModeAction(Action value) { }

	[CompilerGenerated]
	public static void add_OnItemBeginDragAction(Action<LevelMakerItem> value) { }

	[CompilerGenerated]
	public static void add_OnItemClickAction(Action<LevelMakerItem> value) { }

	[CompilerGenerated]
	public static void add_OnItemEndDragAction(Action<LevelMakerItem> value) { }

	[CompilerGenerated]
	public void add_OnSyncIsFlippedStateAction(Action<LevelMakerItem, Boolean> value) { }

	protected virtual void Awake() { }

	public override void DestroyAndReleaseItems() { }

	private void EnsureUndroppableAreaIfNeeded() { }

	public LevelWallArea get_CurrentWallArea() { }

	[CompilerGenerated]
	public static int get_LastPointerDownFrameCount() { }

	[CompilerGenerated]
	public override List<LevelAreaBase> get_MyAreas() { }

	[CompilerGenerated]
	public bool get_ShouldCallMoveCameraIfPointerOnScreenEdgeOnSyncPosition() { }

	protected override int GetDefaultSortingOrder() { }

	public PDPrefab GetPDPrefab() { }

	public string GetPDPrefabGuid() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override SortingElement GetSortingElement() { }

	public override int GetSortingOrder() { }

	public SpriteRenderer GetSpriteRenderer() { }

	protected override bool IsFlippedStateBoundToPositionInLevel() { }

	protected override bool IsOnStaticWall() { }

	public override void Multiplayer_OnTransformChange() { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	protected virtual void OnDestroy() { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

	protected override void OnEnterMakerMode() { }

	protected override void OnExitMakerMode() { }

	private void OnLevelPostInit() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	public virtual void OnPointerDown(PointerEventData eventData) { }

	protected override void OnReadyPostLoad() { }

	protected virtual void OnSyncPosition(Vector2 pointerPosition) { }

	private override Transform PWC.Level.ILevelEntity.GetTransform() { }

	private override void PWC.Level.ILevelSpawnDuringGameplay.OnSpawnDuringGameplay() { }

	private override bool PWC.Level.Maker.ILevelMakerDeletableByUIItem.CanBeDestroyedByUIButton() { }

	private override void PWC.Level.Maker.ILevelMakerDeletableByUIItem.DestoryByUIBUtton() { }

	private override MovableLightSystemObject PWC.LightSystem.IHasMovableLightSystemObject.GetMovableLightSystemObject() { }

	[CompilerGenerated]
	public void remove_OnBeforeDestroyWhileInGameplayAction(Action<LevelMakerItem> value) { }

	[CompilerGenerated]
	public void remove_OnEnterMakerModeAction(Action value) { }

	[CompilerGenerated]
	public void remove_OnExitMakerModeAction(Action value) { }

	[CompilerGenerated]
	public static void remove_OnItemBeginDragAction(Action<LevelMakerItem> value) { }

	[CompilerGenerated]
	public static void remove_OnItemClickAction(Action<LevelMakerItem> value) { }

	[CompilerGenerated]
	public static void remove_OnItemEndDragAction(Action<LevelMakerItem> value) { }

	[CompilerGenerated]
	public void remove_OnSyncIsFlippedStateAction(Action<LevelMakerItem, Boolean> value) { }

	[CompilerGenerated]
	private static void set_LastPointerDownFrameCount(int value) { }

	[CompilerGenerated]
	public void set_ShouldCallMoveCameraIfPointerOnScreenEdgeOnSyncPosition(bool value) { }

	protected override void SetFlipped(bool isFlipped) { }

	public void SetMakerMode(bool isMakerMode, bool force = false) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetSortingOrder(int sortingOrder) { }

	protected override bool ShouldUpdateLight() { }

	protected virtual void StartSyncPosition() { }

	public override void SyncFlippedState() { }

}

