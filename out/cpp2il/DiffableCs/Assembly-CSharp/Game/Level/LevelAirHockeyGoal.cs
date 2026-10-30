namespace Game.Level;

public class LevelAirHockeyGoal : MonoBehaviour
{
	public static readonly List<LevelAirHockeyGoal> List; //Field offset: 0x0
	public const float MAX_SHOOT_DISTANCE = 10; //Field offset: 0x0
	[SerializeField]
	private Transform _fallPoint; //Field offset: 0x20
	[SerializeField]
	private Transform _scorePoint; //Field offset: 0x28
	[SerializeField]
	private Transform[] _scorePoints; //Field offset: 0x30
	[SerializeField]
	private Transform[] _lowerMissPoints; //Field offset: 0x38
	[SerializeField]
	private RectTransform[] _groundAreas; //Field offset: 0x40
	[SerializeField]
	private LevelSingleItemCharactersOnlyDropArea _playerDropArea; //Field offset: 0x48
	private readonly List<Single> _goalKeeperAnimationsSaveMomentInSeconds; //Field offset: 0x50
	private Bounds[] _allGroundBounds; //Field offset: 0x58

	private static LevelAirHockeyGoal() { }

	public LevelAirHockeyGoal() { }

	private void Awake() { }

	public Vector2 GetPointPosition(TargetType pointType) { }

	public static LevelAirHockeyGoal GetProperGoal(Vector2 ballPosition, float ballDirection) { }

	public bool HasAGoalKeeper() { }

	private void Init() { }

	private void OnDisable() { }

	private void OnEnable() { }

}

