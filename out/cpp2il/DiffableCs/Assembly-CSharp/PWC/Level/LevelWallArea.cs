namespace PWC.Level;

public class LevelWallArea : LevelAreaBase, IRequirePDSceneObject, ILevelConsumer
{
	internal enum WallAngleType
	{
		None = 0,
		Front = 1,
		Side = 2,
	}

	internal enum WallType
	{
		None = 0,
		Static = 1,
		Dynamic = 2,
	}

	public static readonly List<LevelWallArea> List; //Field offset: 0x0
	[SerializeField]
	private WallAngleType _wallAngle; //Field offset: 0x38
	[SerializeField]
	private SortingGroup _sortingGroup; //Field offset: 0x40
	private WallType _wallType; //Field offset: 0x48

	public WallType MyWallType
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public SortingGroup SortingGroup
	{
		 get { } //Length: 8
	}

	public WallAngleType WallAngle
	{
		 get { } //Length: 8
	}

	private static LevelWallArea() { }

	public LevelWallArea() { }

	protected virtual void Awake() { }

	public WallType get_MyWallType() { }

	public SortingGroup get_SortingGroup() { }

	public WallAngleType get_WallAngle() { }

	public override ILevelEntity GetEntity() { }

	public override GameShape GetGameShape() { }

	protected virtual void OnDisable() { }

	protected virtual void OnEnable() { }

	public void set_MyWallType(WallType value) { }

}

