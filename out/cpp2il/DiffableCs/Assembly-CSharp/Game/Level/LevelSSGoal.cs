namespace Game.Level;

public class LevelSSGoal : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass26_0
	{
		public LevelCharacter character; //Field offset: 0x10
		public LevelSSGoal <>4__this; //Field offset: 0x18
		public int index; //Field offset: 0x20

		public <>c__DisplayClass26_0() { }

		internal void <SetGoalKeeperAnimation>b__0() { }

	}

	public const float MAX_KICK_THE_BALL_DISTANCE = 40; //Field offset: 0x0
	public static readonly List<LevelSSGoal> List; //Field offset: 0x0
	[SerializeField]
	private string _weakScoreAnimation; //Field offset: 0x20
	[SerializeField]
	private string _strongScoreAnimation; //Field offset: 0x28
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x30
	[SerializeField]
	private Transform _fallPoint; //Field offset: 0x38
	[SerializeField]
	private Transform _scorePoint; //Field offset: 0x40
	[SerializeField]
	private Transform[] _goalKeeperPoints; //Field offset: 0x48
	[SerializeField]
	private Transform[] _scorePoints; //Field offset: 0x50
	[SerializeField]
	private Transform[] _lowerMissPoints; //Field offset: 0x58
	[SerializeField]
	private Transform[] _upperMissPoints; //Field offset: 0x60
	[SerializeField]
	private RectTransform[] _groundAreas; //Field offset: 0x68
	[SerializeField]
	private LevelRunningAreaSingleItemCharactersOnlyDropArea _goalKeeperArea; //Field offset: 0x70
	private readonly List<String> _goalKeeperAnimations; //Field offset: 0x78
	private readonly List<Single> _goalKeeperAnimationsSaveMomentInSeconds; //Field offset: 0x80
	private Bounds[] _allGroundBounds; //Field offset: 0x88
	private Bounds[] _topGroundBounds; //Field offset: 0x90
	private Bounds[] _bottomGroundBounds; //Field offset: 0x98

	private static LevelSSGoal() { }

	public LevelSSGoal() { }

	private void Awake() { }

	public Vector2 GetGoalKeeperPoint(int index) { }

	public Vector2 GetPointPosition(TargetType pointType, bool isUpper = false) { }

	public static LevelSSGoal GetProperGoal(Vector2 ballPosition, float ballDirection) { }

	public bool HasAGoalKeeper() { }

	private void Init() { }

	private void OnDisable() { }

	private void OnEnable() { }

	public void PlayStrongScoreAnimation() { }

	public void PlayWeakScoreAnimation() { }

	public int SetGoalKeeperAnimation(TargetType pointType, Vector2 target, float timeForBallToReachTarget) { }

}

