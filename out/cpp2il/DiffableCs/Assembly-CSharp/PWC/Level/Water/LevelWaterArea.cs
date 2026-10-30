namespace PWC.Level.Water;

public class LevelWaterArea : LevelDropArea, ILevelParentRequiresItemInit, IHasWaterSurface
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Transform, Single> <>9__28_0; //Field offset: 0x8
		public static Action <>9__39_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal void <OverrideItemFallTween>b__39_0() { }

		internal float <SortTransformsByPositionTopToBottom>b__28_0(Transform item) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass24_0
	{
		public LevelItem levelItem; //Field offset: 0x10
		public float yDestination; //Field offset: 0x18
		public LevelWaterAreaItemHandler itemHandler; //Field offset: 0x20
		public Action <>9__1; //Field offset: 0x28

		public <>c__DisplayClass24_0() { }

		internal void <OnItemEndDrop>b__0() { }

		internal void <OnItemEndDrop>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass39_0
	{
		public bool didComplete; //Field offset: 0x10
		public LevelItem levelItem; //Field offset: 0x18
		public float velocity; //Field offset: 0x20
		public LTDescr tweenInLambda; //Field offset: 0x28

		public <>c__DisplayClass39_0() { }

		internal void <OverrideItemFallTween>b__1(float value) { }

	}

	public static readonly List<LevelWaterArea> WaterList; //Field offset: 0x0
	[SerializeField]
	private float _deepWaterYPosition; //Field offset: 0xD8
	[SerializeField]
	private Color _waterColor; //Field offset: 0xDC
	[SerializeField]
	private LevelItemWaterLine _waterLinePrefab; //Field offset: 0xF0
	[SerializeField]
	private Transform _extraDeepItemsParent; //Field offset: 0xF8
	[SerializeField]
	private bool _keepItemWhileDragging; //Field offset: 0x100
	[SerializeField]
	private bool _allowCharacterSwimming; //Field offset: 0x101
	[SerializeField]
	private bool _isFloorGettingOut; //Field offset: 0x102
	private readonly List<LevelWaterAreaItemHandlerBase> _itemHandlers; //Field offset: 0x108

	public bool AllowCharacterSwimming
	{
		 get { } //Length: 8
	}

	public float DeepWaterYPosition
	{
		 get { } //Length: 8
	}

	public bool IsFloorGettingOut
	{
		 get { } //Length: 8
	}

	public Color WaterColor
	{
		 get { } //Length: 12
	}

	public LevelItemWaterLine WaterLinePrefab
	{
		 get { } //Length: 8
	}

	private static LevelWaterArea() { }

	public LevelWaterArea() { }

	public virtual bool CanConsumeCharacters() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

	private LevelWaterAreaItemHandler EnsureFloatingItemHandler(LevelItem levelItem) { }

	public float FixYPositionForWater(float fromY, LevelItem levelItem) { }

	public bool get_AllowCharacterSwimming() { }

	public float get_DeepWaterYPosition() { }

	public bool get_IsFloorGettingOut() { }

	public Color get_WaterColor() { }

	public LevelItemWaterLine get_WaterLinePrefab() { }

	public static LevelWaterArea GetClosesetWater(Vector2 point) { }

	public virtual Transform GetParentWhileDragging() { }

	public virtual Vector2 GetProperPositionToDropOnFromPosition(Vector2 fromPosition, LevelItem levelItem) { }

	public virtual void OnAllHierarchyChildrenDropAreaItemEndDrop(LevelDropArea childDropArea, LevelItem levelItem) { }

	protected virtual void OnDisable() { }

	protected virtual void OnEnable() { }

	public virtual void OnItemEndDrop(LevelItem levelItem) { }

	public virtual void OnItemPickUp(LevelItem levelItem) { }

	protected virtual void OnLevelPostInit() { }

	public virtual bool OverrideItemFallTween(LevelItem levelItem, out LTDescr tween) { }

	public virtual void OverrideItemLandDestination(LevelItem levelItem, ref Vector2 destination) { }

	private override void PWC.Level.ILevelParentRequiresItemInit.InitLevelItem(LevelItem levelItem) { }

	public void RegisterItemHandler(LevelWaterAreaItemHandlerBase itemHandler) { }

	public LevelWaterAreaItemHandler SetItemForWaterArea(LevelItem levelItem, bool createWaterLineIfNeeded = true) { }

	public void SetWaterColor(Color waterColor) { }

	public virtual bool ShouldAllowOverlappingItems() { }

	protected virtual List<Transform> SortTransformsByPositionTopToBottom(List<Transform> items) { }

	public void SyncLevelItemsHierarchy(LevelItem levelItem) { }

}

