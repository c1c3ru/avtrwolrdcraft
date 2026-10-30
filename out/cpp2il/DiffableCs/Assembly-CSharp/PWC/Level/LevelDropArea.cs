namespace PWC.Level;

public class LevelDropArea : LevelConsumerAreaBase, IItemsHolderArea, ILevelSpawnDuringGameplay, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Comparison<Transform> <>9__75_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal int <SortTransformsByPositionTopToBottom>b__75_0(Transform lhs, Transform rhs) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass82_0
	{
		public LevelDropArea <>4__this; //Field offset: 0x10
		public LevelItem levelItem; //Field offset: 0x18

		public <>c__DisplayClass82_0() { }

		internal void <OnItemBeginDrop>b__0(LevelDropArea dropArea) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass83_0
	{
		public LevelDropArea <>4__this; //Field offset: 0x10
		public LevelItem levelItem; //Field offset: 0x18

		public <>c__DisplayClass83_0() { }

		internal void <OnItemEndDrop>b__0(LevelDropArea dropArea) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass84_0
	{
		public LevelDropArea <>4__this; //Field offset: 0x10
		public LevelItem levelItem; //Field offset: 0x18

		public <>c__DisplayClass84_0() { }

		internal void <OnItemPickUp>b__0(LevelDropArea dropArea) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass85_0
	{
		public LevelDropArea <>4__this; //Field offset: 0x10
		public LevelItem levelItem; //Field offset: 0x18

		public <>c__DisplayClass85_0() { }

		internal void <OnItemDropInterrupt>b__0(LevelDropArea dropArea) { }

	}

	internal sealed class OverrideItemFallTweenDelegate : MulticastDelegate
	{

		public OverrideItemFallTweenDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(LevelItem levelItem, out LTDescr tween, AsyncCallback callback, object object) { }

		public override bool EndInvoke(out LTDescr tween, IAsyncResult result) { }

		public override bool Invoke(LevelItem levelItem, out LTDescr tween) { }

	}

	internal sealed class OverrideItemLendDestinationDelegate : MulticastDelegate
	{

		public OverrideItemLendDestinationDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(LevelItem levelItem, Vector2 destination, out Vector2 destinationOverride, AsyncCallback callback, object object) { }

		public override bool EndInvoke(out Vector2 destinationOverride, IAsyncResult result) { }

		public override bool Invoke(LevelItem levelItem, Vector2 destination, out Vector2 destinationOverride) { }

	}

	internal sealed class OverridTweenToProperPositionOnDropAreaDestinationDelegate : MulticastDelegate
	{

		public OverridTweenToProperPositionOnDropAreaDestinationDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(Vector2 fromPosition, LevelItem levelItem, out Nullable<Vector2>& overrideLocalPositionDestination, AsyncCallback callback, object object) { }

		public override bool EndInvoke(out Nullable<Vector2>& overrideLocalPositionDestination, IAsyncResult result) { }

		public override bool Invoke(Vector2 fromPosition, LevelItem levelItem, out Nullable<Vector2>& overrideLocalPositionDestination) { }

	}

	public static readonly List<LevelDropArea> List; //Field offset: 0x0
	[SerializeField]
	protected ItemOrientationType _itemOrientationType; //Field offset: 0x54
	[SerializeField]
	protected bool _allowOverlappingItems; //Field offset: 0x58
	[SerializeField]
	protected bool _canConsumeCharacters; //Field offset: 0x59
	[SerializeField]
	private bool _centerItems; //Field offset: 0x5A
	[SerializeField]
	private float _maxItemsHeight; //Field offset: 0x5C
	[SerializeField]
	private float _maxItemsWidth; //Field offset: 0x60
	[CompilerGenerated]
	private Nullable<Single> <CustomItemWidthForXPosition>k__BackingField; //Field offset: 0x64
	[CompilerGenerated]
	private Action<LevelItem> OnItemBeginDropAction; //Field offset: 0x70
	[CompilerGenerated]
	private Action<LevelItem> OnItemDropInterruptAction; //Field offset: 0x78
	[CompilerGenerated]
	private Action<LevelItem> OnItemEndDropAction; //Field offset: 0x80
	[CompilerGenerated]
	private Action<LevelItem> OnItemPickUpAction; //Field offset: 0x88
	[CompilerGenerated]
	private Func<ILevelAvatar, Boolean> OverrideCharacterEndDropAnimationAction; //Field offset: 0x90
	[CompilerGenerated]
	private OverrideItemLendDestinationDelegate OverrideItemLendDestinationAction; //Field offset: 0x98
	[CompilerGenerated]
	private OverrideItemFallTweenDelegate OverrideItemFallTweenAction; //Field offset: 0xA0
	[CompilerGenerated]
	private OverridTweenToProperPositionOnDropAreaDestinationDelegate OverridTweenToProperPositionOnDropAreaDestinationAction; //Field offset: 0xA8
	[CompilerGenerated]
	private Action<LevelItem> OnItemsHolderItemEndDropAction; //Field offset: 0xB0
	[CompilerGenerated]
	private Action<LevelDropArea, LevelItem> OnAllHierarchyChildrenDropAreaItemBeginDropAction; //Field offset: 0xB8
	[CompilerGenerated]
	private Action<LevelDropArea, LevelItem> OnAllHierarchyChildrenDropAreaItemInterruptDropAction; //Field offset: 0xC0
	[CompilerGenerated]
	private Action<LevelDropArea, LevelItem> OnAllHierarchyChildrenDropAreaItemEndDropAction; //Field offset: 0xC8
	[CompilerGenerated]
	private Action<LevelDropArea, LevelItem> OnAllHierarchyChildrenDropAreaItemPickUpAction; //Field offset: 0xD0

	public event Action<LevelDropArea, LevelItem> OnAllHierarchyChildrenDropAreaItemBeginDropAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<LevelDropArea, LevelItem> OnAllHierarchyChildrenDropAreaItemEndDropAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<LevelDropArea, LevelItem> OnAllHierarchyChildrenDropAreaItemInterruptDropAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<LevelDropArea, LevelItem> OnAllHierarchyChildrenDropAreaItemPickUpAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<LevelItem> OnItemBeginDropAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<LevelItem> OnItemDropInterruptAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<LevelItem> OnItemEndDropAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<LevelItem> OnItemPickUpAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public override event Action<LevelItem> OnItemsHolderItemEndDropAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Func<ILevelAvatar, Boolean> OverrideCharacterEndDropAnimationAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event OverrideItemFallTweenDelegate OverrideItemFallTweenAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public event OverrideItemLendDestinationDelegate OverrideItemLendDestinationAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public event OverridTweenToProperPositionOnDropAreaDestinationDelegate OverridTweenToProperPositionOnDropAreaDestinationAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public Nullable<Single> CustomItemWidthForXPosition
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public float MaxItemsHeight
	{
		 get { } //Length: 8
	}

	public override float MaxItemsWidth
	{
		 get { } //Length: 8
	}

	public ItemOrientationType MyItemOrientationType
	{
		 get { } //Length: 8
	}

	private static LevelDropArea() { }

	public LevelDropArea() { }

	[CompilerGenerated]
	public void add_OnAllHierarchyChildrenDropAreaItemBeginDropAction(Action<LevelDropArea, LevelItem> value) { }

	[CompilerGenerated]
	public void add_OnAllHierarchyChildrenDropAreaItemEndDropAction(Action<LevelDropArea, LevelItem> value) { }

	[CompilerGenerated]
	public void add_OnAllHierarchyChildrenDropAreaItemInterruptDropAction(Action<LevelDropArea, LevelItem> value) { }

	[CompilerGenerated]
	public void add_OnAllHierarchyChildrenDropAreaItemPickUpAction(Action<LevelDropArea, LevelItem> value) { }

	[CompilerGenerated]
	public void add_OnItemBeginDropAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public void add_OnItemDropInterruptAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public void add_OnItemEndDropAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public void add_OnItemPickUpAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public override void add_OnItemsHolderItemEndDropAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public void add_OverrideCharacterEndDropAnimationAction(Func<ILevelAvatar, Boolean> value) { }

	[CompilerGenerated]
	public void add_OverrideItemFallTweenAction(OverrideItemFallTweenDelegate value) { }

	[CompilerGenerated]
	public void add_OverrideItemLendDestinationAction(OverrideItemLendDestinationDelegate value) { }

	[CompilerGenerated]
	public void add_OverridTweenToProperPositionOnDropAreaDestinationAction(OverridTweenToProperPositionOnDropAreaDestinationDelegate value) { }

	protected virtual void Awake() { }

	public override bool CanConsumeCharacters() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

	public override bool CanItemFallOnSelf(LevelItem levelItem) { }

	private bool EnsureLivingBeingProtection(LevelItem levelItem) { }

	[CompilerGenerated]
	public Nullable<Single> get_CustomItemWidthForXPosition() { }

	public float get_MaxItemsHeight() { }

	public override float get_MaxItemsWidth() { }

	public ItemOrientationType get_MyItemOrientationType() { }

	public Vector2 GetBottomPositionOnDropAreaAtX(float worldXPosition, LevelItem levelItem) { }

	public Vector2 GetBottomProperPoisitoinOnDropAreaFromPosition(Vector2 fromPosition, LevelItem levelItem) { }

	public override Transform GetParentWhileDragging() { }

	public override Vector2 GetProperPositionToDropOnFromPosition(Vector2 fromPosition, LevelItem levelItem) { }

	public Vector2 GetRandomPositionForItem(LevelItem levelItem, Nullable<Single> forceX = null, Nullable<Single> forceY = null) { }

	protected override Bounds1D GetWorldXBoundsForItemPositionCalculation() { }

	public override float GetXPositionOnDropArea(float fromXPosition, LevelItem levelItem, Nullable<Single> optionalYPosition = null) { }

	public override bool HasSpecialItemPosition() { }

	public override bool IsAvailableForItems() { }

	public override bool IsCentering() { }

	private void NotifyAllHierarchyParents(Action<LevelDropArea> notify) { }

	public override void OnAllHierarchyChildrenDropAreaItemBeginDrop(LevelDropArea childDropArea, LevelItem levelItem) { }

	public override void OnAllHierarchyChildrenDropAreaItemEndDrop(LevelDropArea childDropArea, LevelItem levelItem) { }

	public override void OnAllHierarchyChildrenDropAreaItemInterruptDrop(LevelDropArea childDropArea, LevelItem levelItem) { }

	public override void OnAllHierarchyChildrenDropAreaItemPickUp(LevelDropArea childDropArea, LevelItem levelItem) { }

	protected virtual void OnDestroy() { }

	protected virtual void OnDisable() { }

	protected virtual void OnEnable() { }

	public override void OnItemBeginDrop(LevelItem levelItem) { }

	public override void OnItemDropInterrupt(LevelItem levelItem) { }

	public override void OnItemEndDrop(LevelItem levelItem) { }

	public override void OnItemPickUp(LevelItem levelItem) { }

	protected override void OnLevelPostInit() { }

	protected override void OnReadyPostLoad() { }

	public override bool OverrideAvatarEndDropAnimation(ILevelAvatar avatar) { }

	public override bool OverrideItemFallTween(LevelItem levelItem, out LTDescr tween) { }

	public override void OverrideItemLandDestination(LevelItem levelItem, ref Vector2 destination) { }

	public override Nullable<Vector2> OverridTweenToProperPositionOnDropAreaDestination(Vector2 fromPosition, LevelItem levelItem) { }

	private override bool PWC.Level.IItemsHolderArea.HasItemsOnSelf() { }

	private override void PWC.Level.IItemsHolderArea.ReleaseItems() { }

	private override void PWC.Level.ILevelSpawnDuringGameplay.OnSpawnDuringGameplay() { }

	public void ReleaseAllItems() { }

	[CompilerGenerated]
	public void remove_OnAllHierarchyChildrenDropAreaItemBeginDropAction(Action<LevelDropArea, LevelItem> value) { }

	[CompilerGenerated]
	public void remove_OnAllHierarchyChildrenDropAreaItemEndDropAction(Action<LevelDropArea, LevelItem> value) { }

	[CompilerGenerated]
	public void remove_OnAllHierarchyChildrenDropAreaItemInterruptDropAction(Action<LevelDropArea, LevelItem> value) { }

	[CompilerGenerated]
	public void remove_OnAllHierarchyChildrenDropAreaItemPickUpAction(Action<LevelDropArea, LevelItem> value) { }

	[CompilerGenerated]
	public void remove_OnItemBeginDropAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public void remove_OnItemDropInterruptAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public void remove_OnItemEndDropAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public void remove_OnItemPickUpAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public override void remove_OnItemsHolderItemEndDropAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public void remove_OverrideCharacterEndDropAnimationAction(Func<ILevelAvatar, Boolean> value) { }

	[CompilerGenerated]
	public void remove_OverrideItemFallTweenAction(OverrideItemFallTweenDelegate value) { }

	[CompilerGenerated]
	public void remove_OverrideItemLendDestinationAction(OverrideItemLendDestinationDelegate value) { }

	[CompilerGenerated]
	public void remove_OverridTweenToProperPositionOnDropAreaDestinationAction(OverridTweenToProperPositionOnDropAreaDestinationDelegate value) { }

	[CompilerGenerated]
	public void set_CustomItemWidthForXPosition(Nullable<Single> value) { }

	public void SetCanConsumeCharacters(bool value) { }

	public override bool ShouldAllowOverlappingItems() { }

	public static void SortDropAreas() { }

	protected override List<Transform> SortTransformsByPositionTopToBottom(List<Transform> items) { }

	public bool TryGetBottomPositionOnDropAreaAtX(float worldXPosition, LevelItem levelItem, out Vector2 position) { }

	public bool TrySortChildren() { }

}

