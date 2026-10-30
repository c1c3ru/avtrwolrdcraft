namespace PWC.Level.BasketballSystem;

public class LevelBSHoop : MonoBehaviour
{
	internal enum HoopType
	{
		None = 0,
		Basketball = 1,
		Football = 2,
	}

	public static readonly List<LevelBSHoop> List; //Field offset: 0x0
	[SerializeField]
	private string _scoreAnimation; //Field offset: 0x20
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x28
	[SerializeField]
	private Transform _scorePoint; //Field offset: 0x30
	[SerializeField]
	private Transform _fallPoint; //Field offset: 0x38
	[SerializeField]
	private Transform _bouncingChairFallPoint; //Field offset: 0x40
	[SerializeField]
	private Transform[] _squarePoints; //Field offset: 0x48
	[SerializeField]
	private Transform[] _ringPoints; //Field offset: 0x50
	[SerializeField]
	private RectTransform[] _groundAreas; //Field offset: 0x58
	[SerializeField]
	private bool _canInitOnRuntime; //Field offset: 0x60
	[SerializeField]
	private LevelSingleItemDropArea _levelSingleItemDropArea; //Field offset: 0x68
	[SerializeField]
	private HoopType _hoopType; //Field offset: 0x70
	[SerializeField]
	private UnityEvent _onScoreAction; //Field offset: 0x78
	private Bounds[] _allGroundBounds; //Field offset: 0x80
	private Bounds[] _bottomGroundBounds; //Field offset: 0x88

	public HoopType hoopType
	{
		 get { } //Length: 8
	}

	public LevelSingleItemDropArea LevelSingleItemDropArea
	{
		 get { } //Length: 8
	}

	private static LevelBSHoop() { }

	public LevelBSHoop() { }

	private void Awake() { }

	public HoopType get_hoopType() { }

	public LevelSingleItemDropArea get_LevelSingleItemDropArea() { }

	public Vector2 GetPointPosition(TargetType pointType, Random random) { }

	public static LevelBSHoop GetProperHoop(Vector2 ballPosition, float ballDirection, HoopType hoopType) { }

	public void Init() { }

	private void OnDisable() { }

	private void OnEnable() { }

	public void PlayScoreAnimation() { }

}

