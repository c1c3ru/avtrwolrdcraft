namespace PWC.Level.Maker;

public class LevelMakerSnappableFloorLine : LevelAreaBase, IRequirePDSceneObject, ILevelConsumer
{
	public static readonly List<LevelMakerSnappableFloorLine> FrontFloorLinesList; //Field offset: 0x0
	public static readonly List<LevelMakerSnappableFloorLine> SideFloorLinesList; //Field offset: 0x8
	[SerializeField]
	private WallAngleType _angleType; //Field offset: 0x38
	[SerializeField]
	private LevelWallArea _wallArea; //Field offset: 0x40
	private bool _isStatic; //Field offset: 0x48
	private bool _isChildrenListDirty; //Field offset: 0x49
	private readonly List<ILevelMakerSnappableFloorLineObject> _objects; //Field offset: 0x50
	private Nullable<Int32> _rootSortingOrder; //Field offset: 0x58

	public bool IsStatic
	{
		 get { } //Length: 8
	}

	private static LevelMakerSnappableFloorLine() { }

	public LevelMakerSnappableFloorLine() { }

	protected virtual void Awake() { }

	public bool get_IsStatic() { }

	public static LevelMakerSnappableFloorLine GetClosestLine(LevelMakerSnappableItemHandler itemHandler, bool isSide, List<LevelMakerSnappableFloorLine> selfFloorLines, out float xOffsetToLine, bool ignoreDynamicLines) { }

	public override ILevelEntity GetEntity() { }

	public override GameShape GetGameShape() { }

	public static LevelMakerSnappableFloorLine GetLineInItemXBounds(LevelMakerSnappableItemHandler itemHandler, bool isSide, List<LevelMakerSnappableFloorLine> selfFloorLinesList, bool ignoreDynamic = false, Nullable<Vector3> positionOverride = null) { }

	public static LevelMakerSnappableFloorLine GetLineInXBounds(GameObject gameObject, LevelMakerItemWithArea item, Bounds1D worldXBounds, bool isSide, List<LevelMakerSnappableFloorLine> selfFloorLinesList, bool ignoreDynamic = false, Nullable<Vector3> positionOverride = null) { }

	public static LevelMakerSnappableFloorLine GetLineInXBounds(GameObject obj, Bounds1D worldXBounds, bool isSide, List<LevelMakerSnappableFloorLine> selfFloorLinesList, bool ignoreDynamic = false, Nullable<Vector3> positionOverride = null) { }

	public List<ILevelMakerSnappableFloorLineObject> GetObjects() { }

	public int GetRootSortingOrder() { }

	public LevelWallArea GetWallArea() { }

	public bool IsFlipped() { }

	public bool IsXPoisitionInRange(float xPosition) { }

	protected virtual void OnDestroy() { }

	private void OnTransformChildrenChanged() { }

}

