namespace PWC.Level;

[DisallowMultipleComponent]
public class LevelItem : DragDropItemBase, ILevelEntity, IHasPersistentData, IRequirePDSceneObject, IHasMovableLightSystemObject, ILevelSpawnDuringGameplay, IInteractableItem, IMultiplayer_NetworkIdentityBase, IMultiplayer_PrepareForDrag
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action <>9__293_2; //Field offset: 0x8
		public static Predicate<LevelAreaBase> <>9__311_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal bool <CanHaveLevelItemsOnSelf>b__311_0(LevelAreaBase x) { }

		internal void <FallToPosition>b__293_2() { }

	}

	[CompilerGenerated]
	private struct <>c__DisplayClass253_0
	{
		public Bounds bounds; //Field offset: 0x0

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass293_0
	{
		public LevelItem <>4__this; //Field offset: 0x10
		public LevelDropArea dropArea; //Field offset: 0x18
		public bool useLocalTween; //Field offset: 0x20
		public float targetY; //Field offset: 0x24
		public float currentY; //Field offset: 0x28
		public Action onFinish; //Field offset: 0x30
		public Action <>9__4; //Field offset: 0x38

		public <>c__DisplayClass293_0() { }

		internal void <FallToPosition>b__4() { }

		internal void <FallToPosition>b__5() { }

		internal void <FallToPosition>g__Fall|0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass293_1
	{
		public LTDescr tween; //Field offset: 0x10
		public bool keepOnTop; //Field offset: 0x18
		public <>c__DisplayClass293_0 CS$<>8__locals1; //Field offset: 0x20

		public <>c__DisplayClass293_1() { }

		internal void <FallToPosition>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass293_2
	{
		public bool didComplete; //Field offset: 0x10
		public Transform parentOnTweenStart; //Field offset: 0x18
		public float velocity; //Field offset: 0x20
		public bool didCallOnFallToPositionFirstLandAction; //Field offset: 0x24
		public <>c__DisplayClass293_1 CS$<>8__locals2; //Field offset: 0x28

		public <>c__DisplayClass293_2() { }

		internal void <FallToPosition>b__3(float value) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass299_0
	{
		public LevelItem <>4__this; //Field offset: 0x10
		public Vector2 destination; //Field offset: 0x18
		public Action <>9__1; //Field offset: 0x20

		public <>c__DisplayClass299_0() { }

		internal void <LandNow>b__0() { }

		internal void <LandNow>b__1() { }

	}

	internal sealed class CanDropOnDropAreaDelegate : MulticastDelegate
	{

		public CanDropOnDropAreaDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(LevelDropArea dropArea, ref bool canDrop, AsyncCallback callback, object object) { }

		public override void EndInvoke(ref bool canDrop, IAsyncResult result) { }

		public override void Invoke(LevelDropArea dropArea, ref bool canDrop) { }

	}

	internal sealed class CanPutInCharacterHandDelegate : MulticastDelegate
	{

		public CanPutInCharacterHandDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(LevelCharacter character, ref bool canPutInHand, AsyncCallback callback, object object) { }

		public override void EndInvoke(ref bool canPutInHand, IAsyncResult result) { }

		public override void Invoke(LevelCharacter character, ref bool canPutInHand) { }

	}

	internal sealed class CharacterDropInteractionDelete : MulticastDelegate
	{

		public CharacterDropInteractionDelete(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(LevelCharacter character, ref bool didInteract, ref MPEventIdentifierData mpData, AsyncCallback callback, object object) { }

		public override void EndInvoke(ref bool didInteract, ref MPEventIdentifierData mpData, IAsyncResult result) { }

		public override void Invoke(LevelCharacter character, ref bool didInteract, ref MPEventIdentifierData mpData) { }

	}

	internal sealed class ConsumerDropInteractionDelete : MulticastDelegate
	{

		public ConsumerDropInteractionDelete(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(ILevelConsumer consumer, ref bool didInteract, ref MPEventIdentifierData mpData, AsyncCallback callback, object object) { }

		public override void EndInvoke(ref bool didInteract, ref MPEventIdentifierData mpData, IAsyncResult result) { }

		public override void Invoke(ILevelConsumer consumer, ref bool didInteract, ref MPEventIdentifierData mpData) { }

	}

	internal enum SortingOrderType
	{
		Default = 1,
		WithItemParent = 2,
		WithCharacterParent = 3,
		UnderDragging = 49,
		Dragging = 50,
	}

	[CompilerGenerated]
	private static Action<LevelItem, LevelDropArea> OnItemBeginLandAction; //Field offset: 0x0
	public const float SCALE_WHILE_DRAGGING = 1,1; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<LevelItem, LevelDropArea> OnItemEndLandAction; //Field offset: 0x8
	[CompilerGenerated]
	private static Action<LevelItem> OnItemBeginDragAction; //Field offset: 0x10
	[CompilerGenerated]
	private static Action<LevelItem> OnItemEndDragAction; //Field offset: 0x18
	public static List<LevelItem> CurrentlyDraggingItems; //Field offset: 0x20
	public static LevelItem LastDraggedItem; //Field offset: 0x28
	public static readonly List<LevelItem> LevelItemListIncludeInactive; //Field offset: 0x30
	[SerializeField]
	protected Renderer _renderer; //Field offset: 0x110
	[SerializeField]
	protected SortingGroup _sortingGroup; //Field offset: 0x118
	[SerializeField]
	protected float _bottomWidth; //Field offset: 0x120
	private string _cachedPointerDownSoundName; //Field offset: 0x128
	private string _cachedClickSoundName; //Field offset: 0x130
	private string _cachedPickUpSoundName; //Field offset: 0x138
	private LevelPointerDownSoundItemHandler _pointerDownSoundHander; //Field offset: 0x140
	private LevelClickSoundItemHandler _clickSoundHander; //Field offset: 0x148
	private LevelPickUpSoundItemHandler _pickUpSoundHander; //Field offset: 0x150
	private Action _internalOnLevelPostInitAction; //Field offset: 0x158
	private Vector2 _lastPointerPosition; //Field offset: 0x160
	private GameShapeNoTransform _localTouchGameShape; //Field offset: 0x168
	protected MovableLightSystemObject _movableLightSystemObject; //Field offset: 0x170
	private Transform _sortingTransform; //Field offset: 0x178
	private SortingElement _sortingElement; //Field offset: 0x180
	protected PDPrefab _pdPrefab; //Field offset: 0x188
	protected PDSceneObject _pdSceneObject; //Field offset: 0x190
	[CompilerGenerated]
	private bool <IsMoving>k__BackingField; //Field offset: 0x198
	private bool _didDetachFromParentOnSceneLoad; //Field offset: 0x199
	[CompilerGenerated]
	private int <Multiplayer_ComponentIndex>k__BackingField; //Field offset: 0x19C
	[CompilerGenerated]
	private ILevelAvatar <InAvatar>k__BackingField; //Field offset: 0x1A0
	[CompilerGenerated]
	private ItemOnAvatarType <MyItemOnAvatarType>k__BackingField; //Field offset: 0x1A8
	[CompilerGenerated]
	private string <InAvatarSceneGuid>k__BackingField; //Field offset: 0x1B0
	[CompilerGenerated]
	private bool <ShouldCallFixPositionIfNeededOnEndDrag>k__BackingField; //Field offset: 0x1B8
	[CompilerGenerated]
	private bool <ShouldCallMoveCameraIfPointerOnScreenEdgeOnSyncPosition>k__BackingField; //Field offset: 0x1B9
	[CompilerGenerated]
	private LevelUndroppableArea <MyUndroppableArea>k__BackingField; //Field offset: 0x1C0
	[CompilerGenerated]
	private Action<LevelDropArea> OnBeginLandAction; //Field offset: 0x1C8
	[CompilerGenerated]
	private Action<LevelDropArea> OnEndLandAction; //Field offset: 0x1D0
	[CompilerGenerated]
	private Action<LevelDropArea> OnFallToPositionFirstLandAction; //Field offset: 0x1D8
	[CompilerGenerated]
	private Action<LevelDropArea> OnStartFallAction; //Field offset: 0x1E0
	[CompilerGenerated]
	private Action OnKilledInKillAreaAction; //Field offset: 0x1E8
	[CompilerGenerated]
	private Action<LevelItem, LevelDropArea> OnParentBeginLandAction; //Field offset: 0x1F0
	[CompilerGenerated]
	private Action<LevelItem, LevelDropArea> OnParentEndLandAction; //Field offset: 0x1F8
	[CompilerGenerated]
	private Action<LevelItem, Single> OnParentEndDragTweenUpdateAction; //Field offset: 0x200
	[CompilerGenerated]
	private Action<LevelItem, Vector2> OnParentSyncPositionAction; //Field offset: 0x208
	[CompilerGenerated]
	private Action<LevelItem, Transform> OnBeforeDetachFromParentAction; //Field offset: 0x210
	[CompilerGenerated]
	private Action<LevelItem, Single> OnEndDragTweenUpdateAction; //Field offset: 0x218
	[CompilerGenerated]
	private Action<LevelItem> OnPostDetachFromParentIfExistsCallAction; //Field offset: 0x220
	private LevelItemOrientationHandler _orientationHandler; //Field offset: 0x228
	[CompilerGenerated]
	private bool <AllowBasicDropOnly>k__BackingField; //Field offset: 0x230
	[CompilerGenerated]
	private bool <IsPerformingBasicDrop>k__BackingField; //Field offset: 0x231
	[CompilerGenerated]
	private PDSceneObject <MyPDSceneObject>k__BackingField; //Field offset: 0x238
	private LevelItemPD _lastPDData; //Field offset: 0x240
	private Transform _parentToReturnToOnDragEnd; //Field offset: 0x248
	protected bool _didLoadPersistentData; //Field offset: 0x250
	[CompilerGenerated]
	private float <LastFallDistance>k__BackingField; //Field offset: 0x254
	private float _lastCameraMovementSpeed; //Field offset: 0x258
	protected bool _isForceSlowDragMovement; //Field offset: 0x25C
	protected bool _shouldJumpOnClick; //Field offset: 0x25D
	private LevelFlippableItemHandler _flippableItemHandler; //Field offset: 0x260
	private int _dragScaleTweenId; //Field offset: 0x268
	private int _clickJumpTweenId; //Field offset: 0x26C
	private LevelItemTouchShapeOverride _touchShapeOverride; //Field offset: 0x270
	protected LevelItem[] _childrenLevelItemsForNotifyEvents; //Field offset: 0x278
	protected bool _isFlipped; //Field offset: 0x280
	private bool _multiplayer_canSendBasicDropEvent; //Field offset: 0x281
	[CompilerGenerated]
	private bool <Multiplayer_PreventDropItemEvent>k__BackingField; //Field offset: 0x282
	[CompilerGenerated]
	private LevelDropArea <CurrentCandidateDropArea>k__BackingField; //Field offset: 0x288
	[CompilerGenerated]
	private LevelDropArea <CurrentDropArea>k__BackingField; //Field offset: 0x290
	[CompilerGenerated]
	private Func<LevelItem, Boolean> OverrideBasicDropBehaviorAction; //Field offset: 0x298
	[CompilerGenerated]
	private Func<LevelItem, Boolean> OverridePostLevelDropQueryBehaviorAction; //Field offset: 0x2A0
	[CompilerGenerated]
	private Func<LevelItem, Boolean> OverridePreFallDropBehaviorAction; //Field offset: 0x2A8
	[CompilerGenerated]
	private ConsumerDropInteractionDelete TryDropInteractionAction; //Field offset: 0x2B0
	[CompilerGenerated]
	private CharacterDropInteractionDelete TryDropInteractionWithCharacterAction; //Field offset: 0x2B8
	[CompilerGenerated]
	private CanDropOnDropAreaDelegate CanBeDroppedOnAction; //Field offset: 0x2C0
	[CompilerGenerated]
	private CanPutInCharacterHandDelegate CanPutInCharacterHandAction; //Field offset: 0x2C8
	[CompilerGenerated]
	private Action<ILevelAvatar, ItemOnAvatarType> OnBeforePlacedOnAvatarAction; //Field offset: 0x2D0
	[CompilerGenerated]
	private Action<ILevelAvatar, ItemOnAvatarType> OnPlacedOnAvatarAction; //Field offset: 0x2D8
	[CompilerGenerated]
	private Action<ILevelAvatar> OnRemovedFromAvatarAction; //Field offset: 0x2E0
	[CompilerGenerated]
	private Action<LevelDropArea, LevelItem> OnChildDropAreaItemBeginDropAction; //Field offset: 0x2E8
	[CompilerGenerated]
	private Action<LevelDropArea, LevelItem> OnChildDropAreaItemEndDropAction; //Field offset: 0x2F0
	[CompilerGenerated]
	private Action<LevelDropArea, LevelItem> OnChildDropAreaItemPickUpAction; //Field offset: 0x2F8
	[CompilerGenerated]
	private Func<ILevelAvatar, ItemOnAvatarType, LevelItem, Boolean> SnapItemToAvatarAction; //Field offset: 0x300
	[CompilerGenerated]
	private Func<Vector2, Vector2> OverrideDragPositionAciton; //Field offset: 0x308
	[CompilerGenerated]
	private Action<LevelItem> OnBeforeDestroyWhileInGameplayAction; //Field offset: 0x310
	[CompilerGenerated]
	private Action<LevelItem> OnBeforeGetPersistentDataAction; //Field offset: 0x318
	[CompilerGenerated]
	private Action<LevelItem, Boolean> OnSyncIsFlippedStateAction; //Field offset: 0x320
	[CompilerGenerated]
	private Func<LevelItem, PointerEventData, Boolean> OverrideOnDropBehaviorAction; //Field offset: 0x328
	[CompilerGenerated]
	private Action<LevelItem> Multiplayer_OnPrepareForDragAciton; //Field offset: 0x330
	[CompilerGenerated]
	private readonly List<LevelAreaBase> <MyAreas>k__BackingField; //Field offset: 0x338
	[CompilerGenerated]
	private bool <ShouldDropOnNextOnEnable>k__BackingField; //Field offset: 0x340
	[CompilerGenerated]
	private bool <ShouldDropOnNextLevelPostInit>k__BackingField; //Field offset: 0x341

	public event CanDropOnDropAreaDelegate CanBeDroppedOnAction
	{
		[CompilerGenerated]
		 add { } //Length: 160
		[CompilerGenerated]
		 remove { } //Length: 160
	}

	public event CanPutInCharacterHandDelegate CanPutInCharacterHandAction
	{
		[CompilerGenerated]
		 add { } //Length: 160
		[CompilerGenerated]
		 remove { } //Length: 160
	}

	public event Action<LevelItem> Multiplayer_OnPrepareForDragAciton
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Action<LevelItem> OnBeforeDestroyWhileInGameplayAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Action<LevelItem, Transform> OnBeforeDetachFromParentAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Action<LevelItem> OnBeforeGetPersistentDataAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Action<ILevelAvatar, ItemOnAvatarType> OnBeforePlacedOnAvatarAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Action<LevelDropArea> OnBeginLandAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Action<LevelDropArea, LevelItem> OnChildDropAreaItemBeginDropAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Action<LevelDropArea, LevelItem> OnChildDropAreaItemEndDropAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Action<LevelDropArea, LevelItem> OnChildDropAreaItemPickUpAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Action<LevelItem, Single> OnEndDragTweenUpdateAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Action<LevelDropArea> OnEndLandAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Action<LevelDropArea> OnFallToPositionFirstLandAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public static event Action<LevelItem> OnItemBeginDragAction
	{
		[CompilerGenerated]
		 add { } //Length: 244
		[CompilerGenerated]
		 remove { } //Length: 244
	}

	public static event Action<LevelItem, LevelDropArea> OnItemBeginLandAction
	{
		[CompilerGenerated]
		 add { } //Length: 240
		[CompilerGenerated]
		 remove { } //Length: 240
	}

	public static event Action<LevelItem> OnItemEndDragAction
	{
		[CompilerGenerated]
		 add { } //Length: 244
		[CompilerGenerated]
		 remove { } //Length: 244
	}

	public static event Action<LevelItem, LevelDropArea> OnItemEndLandAction
	{
		[CompilerGenerated]
		 add { } //Length: 244
		[CompilerGenerated]
		 remove { } //Length: 244
	}

	public event Action OnKilledInKillAreaAction
	{
		[CompilerGenerated]
		 add { } //Length: 160
		[CompilerGenerated]
		 remove { } //Length: 160
	}

	public event Action<LevelItem, LevelDropArea> OnParentBeginLandAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Action<LevelItem, Single> OnParentEndDragTweenUpdateAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Action<LevelItem, LevelDropArea> OnParentEndLandAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Action<LevelItem, Vector2> OnParentSyncPositionAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Action<ILevelAvatar, ItemOnAvatarType> OnPlacedOnAvatarAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Action<LevelItem> OnPostDetachFromParentIfExistsCallAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Action<ILevelAvatar> OnRemovedFromAvatarAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Action<LevelDropArea> OnStartFallAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Action<LevelItem, Boolean> OnSyncIsFlippedStateAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Func<LevelItem, Boolean> OverrideBasicDropBehaviorAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Func<Vector2, Vector2> OverrideDragPositionAciton
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Func<LevelItem, PointerEventData, Boolean> OverrideOnDropBehaviorAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Func<LevelItem, Boolean> OverridePostLevelDropQueryBehaviorAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Func<LevelItem, Boolean> OverridePreFallDropBehaviorAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Func<ILevelAvatar, ItemOnAvatarType, LevelItem, Boolean> SnapItemToAvatarAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event ConsumerDropInteractionDelete TryDropInteractionAction
	{
		[CompilerGenerated]
		 add { } //Length: 160
		[CompilerGenerated]
		 remove { } //Length: 160
	}

	public event CharacterDropInteractionDelete TryDropInteractionWithCharacterAction
	{
		[CompilerGenerated]
		 add { } //Length: 160
		[CompilerGenerated]
		 remove { } //Length: 160
	}

	public private bool AllowBasicDropOnly
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public float BottomWidth
	{
		 get { } //Length: 8
	}

	public private LevelDropArea CurrentCandidateDropArea
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 16
	}

	public private LevelDropArea CurrentDropArea
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 16
	}

	public LevelFlippableItemHandler FlippableItemHandler
	{
		 get { } //Length: 8
	}

	public private ILevelAvatar InAvatar
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 16
	}

	public private string InAvatarSceneGuid
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 16
	}

	public bool IsFlipped
	{
		 get { } //Length: 8
	}

	public override bool IsMoving
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public private bool IsPerformingBasicDrop
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public private float LastFallDistance
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public override int Multiplayer_ComponentIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public bool Multiplayer_PreventDropItemEvent
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public override List<LevelAreaBase> MyAreas
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public ItemOnAvatarType MyItemOnAvatarType
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public private PDSceneObject MyPDSceneObject
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 16
	}

	public Renderer MyRenderer
	{
		 get { } //Length: 8
	}

	public private LevelUndroppableArea MyUndroppableArea
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 16
	}

	public LevelItemOrientationHandler OrientationHandler
	{
		 get { } //Length: 8
	}

	public bool ShouldCallFixPositionIfNeededOnEndDrag
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public bool ShouldCallMoveCameraIfPointerOnScreenEdgeOnSyncPosition
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public bool ShouldDropOnNextLevelPostInit
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public bool ShouldDropOnNextOnEnable
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	private static LevelItem() { }

	public LevelItem() { }

	[CompilerGenerated]
	private void <DropAwayFromUndroppableArea>b__322_0() { }

	[CompilerGenerated]
	private void <FallFromUndroppableArea>b__303_0() { }

	[CompilerGenerated]
	internal static void <GetWorldBoundsIncludeChildren>g__EncapsulateRenderers|253_0(Transform root, ref <>c__DisplayClass253_0 unnamed_param_1) { }

	[CompilerGenerated]
	private void <OnPointerClickInternal>b__336_0() { }

	[CompilerGenerated]
	private void <PlayScaleTween>b__265_0() { }

	[CompilerGenerated]
	private bool <SetItemOrientationForDropAreaIfPossible>g__ItemsOnSelfTest|292_0() { }

	[CompilerGenerated]
	private void <TweenToProperPositionOnDropArea>b__291_0() { }

	[CompilerGenerated]
	public void add_CanBeDroppedOnAction(CanDropOnDropAreaDelegate value) { }

	[CompilerGenerated]
	public void add_CanPutInCharacterHandAction(CanPutInCharacterHandDelegate value) { }

	[CompilerGenerated]
	public void add_Multiplayer_OnPrepareForDragAciton(Action<LevelItem> value) { }

	[CompilerGenerated]
	public void add_OnBeforeDestroyWhileInGameplayAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public void add_OnBeforeDetachFromParentAction(Action<LevelItem, Transform> value) { }

	[CompilerGenerated]
	public void add_OnBeforeGetPersistentDataAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public void add_OnBeforePlacedOnAvatarAction(Action<ILevelAvatar, ItemOnAvatarType> value) { }

	[CompilerGenerated]
	public void add_OnBeginLandAction(Action<LevelDropArea> value) { }

	[CompilerGenerated]
	public void add_OnChildDropAreaItemBeginDropAction(Action<LevelDropArea, LevelItem> value) { }

	[CompilerGenerated]
	public void add_OnChildDropAreaItemEndDropAction(Action<LevelDropArea, LevelItem> value) { }

	[CompilerGenerated]
	public void add_OnChildDropAreaItemPickUpAction(Action<LevelDropArea, LevelItem> value) { }

	[CompilerGenerated]
	public void add_OnEndDragTweenUpdateAction(Action<LevelItem, Single> value) { }

	[CompilerGenerated]
	public void add_OnEndLandAction(Action<LevelDropArea> value) { }

	[CompilerGenerated]
	public void add_OnFallToPositionFirstLandAction(Action<LevelDropArea> value) { }

	[CompilerGenerated]
	public static void add_OnItemBeginDragAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public static void add_OnItemBeginLandAction(Action<LevelItem, LevelDropArea> value) { }

	[CompilerGenerated]
	public static void add_OnItemEndDragAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public static void add_OnItemEndLandAction(Action<LevelItem, LevelDropArea> value) { }

	[CompilerGenerated]
	public void add_OnKilledInKillAreaAction(Action value) { }

	[CompilerGenerated]
	public void add_OnParentBeginLandAction(Action<LevelItem, LevelDropArea> value) { }

	[CompilerGenerated]
	public void add_OnParentEndDragTweenUpdateAction(Action<LevelItem, Single> value) { }

	[CompilerGenerated]
	public void add_OnParentEndLandAction(Action<LevelItem, LevelDropArea> value) { }

	[CompilerGenerated]
	public void add_OnParentSyncPositionAction(Action<LevelItem, Vector2> value) { }

	[CompilerGenerated]
	public void add_OnPlacedOnAvatarAction(Action<ILevelAvatar, ItemOnAvatarType> value) { }

	[CompilerGenerated]
	public void add_OnPostDetachFromParentIfExistsCallAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public void add_OnRemovedFromAvatarAction(Action<ILevelAvatar> value) { }

	[CompilerGenerated]
	public void add_OnStartFallAction(Action<LevelDropArea> value) { }

	[CompilerGenerated]
	public void add_OnSyncIsFlippedStateAction(Action<LevelItem, Boolean> value) { }

	[CompilerGenerated]
	public void add_OverrideBasicDropBehaviorAction(Func<LevelItem, Boolean> value) { }

	[CompilerGenerated]
	public void add_OverrideDragPositionAciton(Func<Vector2, Vector2> value) { }

	[CompilerGenerated]
	public void add_OverrideOnDropBehaviorAction(Func<LevelItem, PointerEventData, Boolean> value) { }

	[CompilerGenerated]
	public void add_OverridePostLevelDropQueryBehaviorAction(Func<LevelItem, Boolean> value) { }

	[CompilerGenerated]
	public void add_OverridePreFallDropBehaviorAction(Func<LevelItem, Boolean> value) { }

	[CompilerGenerated]
	public void add_SnapItemToAvatarAction(Func<ILevelAvatar, ItemOnAvatarType, LevelItem, Boolean> value) { }

	[CompilerGenerated]
	public void add_TryDropInteractionAction(ConsumerDropInteractionDelete value) { }

	[CompilerGenerated]
	public void add_TryDropInteractionWithCharacterAction(CharacterDropInteractionDelete value) { }

	public override void AddToCustomRestoreDataBeforeDestroyWhileInGameplay() { }

	public void AssignCurrentDropAreaifExists() { }

	protected virtual void Awake() { }

	protected override void CacheLevelItemsUnderSelfForNotifyEvents() { }

	protected float CalculateCameraMovementSpeedFactor() { }

	public override bool CanBeDroppedOn(LevelDropArea dropArea) { }

	public void CancelAllTweens() { }

	protected bool CanHaveLevelItemsOnSelf() { }

	public override bool CanPutInCharacterHand(LevelCharacter character) { }

	private bool CheckForBlockedAreas(Vector2 position) { }

	public void ClearInAvatarData() { }

	private Transform CreateSortingTransform() { }

	protected override CShapeModel CreateTouchCShapeModel() { }

	public override void DetachFromParentIfExists(bool callDetachEvent = true) { }

	public void DisableUndroppableArea() { }

	public void DisposeSortingTransformIfExists() { }

	private void DropAwayFromUndroppableArea(LevelUndroppableArea undroppableArea) { }

	private void DropInLevel() { }

	public override void DropOnDropArea(LevelDropArea dropArea, bool useJumpTween = true, Nullable<Vector2> overrideLocalPositionDestination = null) { }

	protected override void EnsureFlippableItemHandler() { }

	protected void EnsureLevelPostInitAciton(Action action) { }

	public void EnsureSortingGroup() { }

	private void FallFromUndroppableArea(Vector2 position, LevelUndroppableArea undroppableArea) { }

	public void FallOnClosestFloorArea(float desiredY = 3,4028235E+38) { }

	public override void FallOnDropArea(LevelDropArea dropArea, Nullable<Vector2> overrideLocalPositionDestination = null) { }

	public void FallOnLowestPointOfDropArea(LevelDropArea dropArea) { }

	public void FallStraightDownOnClosestFloorArea() { }

	protected void FallToPosition(float currentY, float targetY, bool useLocalTween, float xToFallFrom, LevelDropArea dropArea, Action onFinish = null, bool considerBlockedAreas = true) { }

	public void FallToPositionOnDropArea(LevelDropArea dropAreaToFallOn, Vector2 fromPosition, float xToFallFrom, float targetY, bool considerBlockedAreas = true) { }

	private bool FixPositionIfNeeded(ref Vector2 position) { }

	private void FixRotationIfNeeded(LevelDropArea dropArea, float duration) { }

	private LevelDropArea FixSortingOrderForLanding(Transform transformToConsider) { }

	public void ForceSlowSpeedFactorCameraMovement(bool isOn) { }

	[CompilerGenerated]
	public bool get_AllowBasicDropOnly() { }

	public float get_BottomWidth() { }

	[CompilerGenerated]
	public LevelDropArea get_CurrentCandidateDropArea() { }

	[CompilerGenerated]
	public LevelDropArea get_CurrentDropArea() { }

	public LevelFlippableItemHandler get_FlippableItemHandler() { }

	[CompilerGenerated]
	public ILevelAvatar get_InAvatar() { }

	[CompilerGenerated]
	public string get_InAvatarSceneGuid() { }

	public bool get_IsFlipped() { }

	[CompilerGenerated]
	public override bool get_IsMoving() { }

	[CompilerGenerated]
	public bool get_IsPerformingBasicDrop() { }

	[CompilerGenerated]
	public float get_LastFallDistance() { }

	[CompilerGenerated]
	public override int get_Multiplayer_ComponentIndex() { }

	[CompilerGenerated]
	public bool get_Multiplayer_PreventDropItemEvent() { }

	[CompilerGenerated]
	public override List<LevelAreaBase> get_MyAreas() { }

	[CompilerGenerated]
	public ItemOnAvatarType get_MyItemOnAvatarType() { }

	[CompilerGenerated]
	public PDSceneObject get_MyPDSceneObject() { }

	public Renderer get_MyRenderer() { }

	[CompilerGenerated]
	public LevelUndroppableArea get_MyUndroppableArea() { }

	public LevelItemOrientationHandler get_OrientationHandler() { }

	[CompilerGenerated]
	public bool get_ShouldCallFixPositionIfNeededOnEndDrag() { }

	[CompilerGenerated]
	public bool get_ShouldCallMoveCameraIfPointerOnScreenEdgeOnSyncPosition() { }

	[CompilerGenerated]
	public bool get_ShouldDropOnNextLevelPostInit() { }

	[CompilerGenerated]
	public bool get_ShouldDropOnNextOnEnable() { }

	public Bounds1D GetBottomXLocalBounds() { }

	public Bounds1D GetBottomXWorldBounds() { }

	protected override float GetCameraMovementSpeedFactor() { }

	protected override float GetCameraMovementThreshold() { }

	public override Vector3 GetDefaultScaleForCurrentFlipState() { }

	private LevelUndroppableArea GetDownmostUndroppableArea(float xPosition, ref float targetY, ILevelEntity ignoreOwner) { }

	protected virtual Vector2 GetDragPositionForThisFramePostModifications(Vector2 position) { }

	public override float GetLandTweenDuration(float distanceToTarget) { }

	protected override LeanTweenType GetLandTweenEaseType() { }

	public string GetLevelItemName() { }

	private LevelDropArea GetMostRelevantDropAreaToFallOn(Vector2 position, out Vector2 hitPointToUse, List<LevelDropArea> dropAreas = null, bool shouldAlwaysConsiderRaycastStartInsideShape = false) { }

	public LevelDropArea GetMostRelevantDropAreaUnderPosition(Vector2 position, out bool isTouchingOnly) { }

	private LevelUndroppableArea GetMostRelevantUndroppableAreaUnderPosition(Vector2 position, ILevelEntity ignoreOwner) { }

	private Transform GetParentWhileDragging(out Transform parentToReturnTo) { }

	public override PDPrefab GetPDPrefab() { }

	public string GetPDPrefabGuid() { }

	public PDSceneObject GetPDSceneObject() { }

	public string GetPDSceneObjectGuid() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override SortingElement GetSortingElement() { }

	public override int GetSortingOrder() { }

	private int GetSortingOrderTypeToUseForDropArea(LevelDropArea dropArea) { }

	public Bounds GetSpriteLocalBounds() { }

	public Bounds GetWorldBoundsIncludeChildren() { }

	public GameShapeNoTransform GetWorldTouchGameShapeNoTransform() { }

	public bool HasLevelItemsOnSelf() { }

	public bool HasTouchShapeOverride() { }

	public bool IsAboutToBeDestroyed() { }

	public void LandNow(LevelDropArea dropArea, bool callOnBeginLand = true) { }

	private void LandOnInsideDropArea(Vector2 position, LevelDropArea insideDropArea, bool shouldMoveToProperPositionIfUseInsideDropArea) { }

	public bool Multiplayer_CanSendDropItemEvent() { }

	protected virtual bool Multiplayer_CanSendTransformEvent() { }

	public override void Multiplayer_DropInteractWithCharacter(LevelCharacter character, MPEventIdentifierData idData) { }

	private string Multiplayer_GetKey() { }

	public override void Multiplayer_PrepareForDrag() { }

	protected void Multiplayer_TryDropOnDropArea(LevelDropArea dropArea, Type type, Vector2 position) { }

	private void NotifyChildrenLevelItemOnBeginLand(LevelDropArea dropArea) { }

	private void NotifyChildrenLevelItemOnEndDragTweenUpdate(float value) { }

	private void NotifyChildrenLevelItemOnEndLand(LevelDropArea dropArea) { }

	private void NotifyChildrenLevelItemOnSyncPosition(Vector2 pointerPosition) { }

	public void NotifyKilledInKillArea() { }

	public override void OnBeforeDestroyDueToItemsCountClamp() { }

	private void OnBeforeDestroyOnSceneLoad() { }

	public override void OnBeforeDestroyWhileInGameplay() { }

	protected override void OnBeforeDetachFromParent(Transform parent) { }

	public override void OnBeforePlacedOnAvatar(ILevelAvatar avatar, ItemOnAvatarType itemOnAvatarType) { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	protected override void OnBeginLand(LevelDropArea dropArea) { }

	public override void OnChildDropAreaItemBeginDrop(LevelDropArea childDropArea, LevelItem levelItem) { }

	public override void OnChildDropAreaItemEndDrop(LevelDropArea childDropArea, LevelItem levelItem) { }

	public override void OnChildDropAreaItemPickUp(LevelDropArea childDropArea, LevelItem levelItem) { }

	protected virtual void OnCShapeSynced() { }

	protected virtual void OnDestroy() { }

	protected virtual void OnEnable() { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

	protected override void OnEndDragTweenUpdate(float value) { }

	protected override LevelDropArea OnEndLand() { }

	protected override void OnLevelPostInit() { }

	protected override void OnLevelPrePostInit() { }

	protected override void OnParentBeginLand(LevelItem parentLevelItem, LevelDropArea dropArea) { }

	protected override void OnParentEndDragTweenUpdate(LevelItem parentLevelItem, float value) { }

	protected override void OnParentEndLand(LevelItem parentLevelItem, LevelDropArea dropArea) { }

	protected override void OnParentSyncPosition(LevelItem parentLevelItem, Vector2 pointerPosition) { }

	public override void OnPlacedOnAvatar(ILevelAvatar avatar, ItemOnAvatarType itemOnAvatarType) { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	public virtual void OnPointerDown(PointerEventData eventData) { }

	public override void OnRemovedFromAvatar(ILevelAvatar avatar) { }

	public override void OnSpawnDuringGameplay() { }

	protected virtual void OnSyncPosition(Vector2 pointerPosition) { }

	public override bool OverrideBasicDropBehavior() { }

	protected override bool OverrideItemFallTween(LevelDropArea dropArea, out LTDescr tween) { }

	public override bool OverridePostLevelDropQueryBehavior(ILevelConsumer consumer) { }

	public override bool OverridePreFallDropBehavior() { }

	public void PerformBasicDrop(bool includeBeginDrag = false, bool allowMultiplayerEvent = true) { }

	public void PerformBasicDropFromInspector() { }

	protected override void PlayActionSound(LevelSoundItemHandlerBase handler, string fallbackName) { }

	protected override void PlayClickSound() { }

	protected override void PlayPickUpSound() { }

	protected override void PlayPointerDownSound() { }

	private void PlayScaleTween(Vector3 scale, float duration) { }

	private override Transform PWC.Level.ILevelEntity.GetTransform() { }

	private override MovableLightSystemObject PWC.LightSystem.IHasMovableLightSystemObject.GetMovableLightSystemObject() { }

	public void ReleaseCurrentDropAreaIfExists() { }

	[CompilerGenerated]
	public void remove_CanBeDroppedOnAction(CanDropOnDropAreaDelegate value) { }

	[CompilerGenerated]
	public void remove_CanPutInCharacterHandAction(CanPutInCharacterHandDelegate value) { }

	[CompilerGenerated]
	public void remove_Multiplayer_OnPrepareForDragAciton(Action<LevelItem> value) { }

	[CompilerGenerated]
	public void remove_OnBeforeDestroyWhileInGameplayAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public void remove_OnBeforeDetachFromParentAction(Action<LevelItem, Transform> value) { }

	[CompilerGenerated]
	public void remove_OnBeforeGetPersistentDataAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public void remove_OnBeforePlacedOnAvatarAction(Action<ILevelAvatar, ItemOnAvatarType> value) { }

	[CompilerGenerated]
	public void remove_OnBeginLandAction(Action<LevelDropArea> value) { }

	[CompilerGenerated]
	public void remove_OnChildDropAreaItemBeginDropAction(Action<LevelDropArea, LevelItem> value) { }

	[CompilerGenerated]
	public void remove_OnChildDropAreaItemEndDropAction(Action<LevelDropArea, LevelItem> value) { }

	[CompilerGenerated]
	public void remove_OnChildDropAreaItemPickUpAction(Action<LevelDropArea, LevelItem> value) { }

	[CompilerGenerated]
	public void remove_OnEndDragTweenUpdateAction(Action<LevelItem, Single> value) { }

	[CompilerGenerated]
	public void remove_OnEndLandAction(Action<LevelDropArea> value) { }

	[CompilerGenerated]
	public void remove_OnFallToPositionFirstLandAction(Action<LevelDropArea> value) { }

	[CompilerGenerated]
	public static void remove_OnItemBeginDragAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public static void remove_OnItemBeginLandAction(Action<LevelItem, LevelDropArea> value) { }

	[CompilerGenerated]
	public static void remove_OnItemEndDragAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public static void remove_OnItemEndLandAction(Action<LevelItem, LevelDropArea> value) { }

	[CompilerGenerated]
	public void remove_OnKilledInKillAreaAction(Action value) { }

	[CompilerGenerated]
	public void remove_OnParentBeginLandAction(Action<LevelItem, LevelDropArea> value) { }

	[CompilerGenerated]
	public void remove_OnParentEndDragTweenUpdateAction(Action<LevelItem, Single> value) { }

	[CompilerGenerated]
	public void remove_OnParentEndLandAction(Action<LevelItem, LevelDropArea> value) { }

	[CompilerGenerated]
	public void remove_OnParentSyncPositionAction(Action<LevelItem, Vector2> value) { }

	[CompilerGenerated]
	public void remove_OnPlacedOnAvatarAction(Action<ILevelAvatar, ItemOnAvatarType> value) { }

	[CompilerGenerated]
	public void remove_OnPostDetachFromParentIfExistsCallAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public void remove_OnRemovedFromAvatarAction(Action<ILevelAvatar> value) { }

	[CompilerGenerated]
	public void remove_OnStartFallAction(Action<LevelDropArea> value) { }

	[CompilerGenerated]
	public void remove_OnSyncIsFlippedStateAction(Action<LevelItem, Boolean> value) { }

	[CompilerGenerated]
	public void remove_OverrideBasicDropBehaviorAction(Func<LevelItem, Boolean> value) { }

	[CompilerGenerated]
	public void remove_OverrideDragPositionAciton(Func<Vector2, Vector2> value) { }

	[CompilerGenerated]
	public void remove_OverrideOnDropBehaviorAction(Func<LevelItem, PointerEventData, Boolean> value) { }

	[CompilerGenerated]
	public void remove_OverridePostLevelDropQueryBehaviorAction(Func<LevelItem, Boolean> value) { }

	[CompilerGenerated]
	public void remove_OverridePreFallDropBehaviorAction(Func<LevelItem, Boolean> value) { }

	[CompilerGenerated]
	public void remove_SnapItemToAvatarAction(Func<ILevelAvatar, ItemOnAvatarType, LevelItem, Boolean> value) { }

	[CompilerGenerated]
	public void remove_TryDropInteractionAction(ConsumerDropInteractionDelete value) { }

	[CompilerGenerated]
	public void remove_TryDropInteractionWithCharacterAction(CharacterDropInteractionDelete value) { }

	public void ResetLightWithStartColor(Color color) { }

	public void SerRenderer(Renderer renderer) { }

	[CompilerGenerated]
	private void set_AllowBasicDropOnly(bool value) { }

	[CompilerGenerated]
	private void set_CurrentCandidateDropArea(LevelDropArea value) { }

	[CompilerGenerated]
	private void set_CurrentDropArea(LevelDropArea value) { }

	[CompilerGenerated]
	private void set_InAvatar(ILevelAvatar value) { }

	[CompilerGenerated]
	private void set_InAvatarSceneGuid(string value) { }

	[CompilerGenerated]
	public override void set_IsMoving(bool value) { }

	[CompilerGenerated]
	private void set_IsPerformingBasicDrop(bool value) { }

	[CompilerGenerated]
	private void set_LastFallDistance(float value) { }

	[CompilerGenerated]
	public override void set_Multiplayer_ComponentIndex(int value) { }

	[CompilerGenerated]
	public void set_Multiplayer_PreventDropItemEvent(bool value) { }

	[CompilerGenerated]
	public void set_MyItemOnAvatarType(ItemOnAvatarType value) { }

	[CompilerGenerated]
	private void set_MyPDSceneObject(PDSceneObject value) { }

	[CompilerGenerated]
	private void set_MyUndroppableArea(LevelUndroppableArea value) { }

	[CompilerGenerated]
	public void set_ShouldCallFixPositionIfNeededOnEndDrag(bool value) { }

	[CompilerGenerated]
	public void set_ShouldCallMoveCameraIfPointerOnScreenEdgeOnSyncPosition(bool value) { }

	[CompilerGenerated]
	public void set_ShouldDropOnNextLevelPostInit(bool value) { }

	[CompilerGenerated]
	public void set_ShouldDropOnNextOnEnable(bool value) { }

	public void SetDraggingOffset() { }

	public void SetFlipped(bool isFlipped, bool force = false) { }

	private void SetItemOrientationForDropAreaIfPossible(LevelDropArea dropArea) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetShouldJumpOnClick(bool shouldJumpOnClick) { }

	public void SetSortingLayer(string sortingLayer) { }

	public void SetSortingOrder(int sortingOrder) { }

	public void SetSortingOrder(SortingOrderType sortingOrderType) { }

	private void SetSortingTransform(Vector2 position) { }

	public void SetSprite(Sprite sprite) { }

	protected override bool ShouldTryFixFlippedStateOnFlippedDropAreaBeginLand() { }

	protected override void SnapItemToAvatar(ILevelAvatar avatar, ItemOnAvatarType itemOnAvatarType) { }

	public override void SnapToDropArea(LevelDropArea dropArea, Nullable<Vector2> overrideLocalPositionDestination = null) { }

	public void StopScaleTween() { }

	public override void SyncIsFlippedState() { }

	private void SyncUndroppableArea() { }

	public override bool TryDragInteraction(ILevelConsumer consumer) { }

	public override bool TryDropInteraction(ILevelConsumer consumer, out MPEventIdentifierData mpData) { }

	public override bool TryDropInteractionWithCharacter(LevelCharacter character, out MPEventIdentifierData mpData) { }

	public bool TryPutInCharacterHand(LevelCharacter character) { }

	protected override void TweenToProperPositionOnDropArea(Vector2 position, LevelDropArea dropArea, bool useJumpTween = true, Nullable<Vector2> overrideLocalPositionDestination = null) { }

}

