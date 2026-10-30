namespace Game.Level.RacingGame;

public class LevelRacingGamePlayerCar : MonoBehaviour
{
	internal enum MoveType
	{
		None = 0,
		Left = 1,
		Right = 2,
	}

	[SerializeField]
	private SpriteRenderer _carSpriteRenderer; //Field offset: 0x20
	[SerializeField]
	private Sprite[] _carSprites; //Field offset: 0x28
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x30
	private readonly Single[] _positions; //Field offset: 0x38
	private int _currentPositionIndex; //Field offset: 0x40
	private LevelRacingGameManager _manager; //Field offset: 0x48
	private int _tweenId; //Field offset: 0x50
	private bool _isMoving; //Field offset: 0x54

	public LevelRacingGamePlayerCar() { }

	[CompilerGenerated]
	private void <Move>b__16_0() { }

	private void Crash() { }

	private void GetGift(LevelRacingGameObstacle gift) { }

	private float GetXOnY(Vector2 start, Vector2 end, float y) { }

	public void Init(LevelRacingGameManager manager, Vector2[][] _lanes) { }

	public void Move(MoveType moveType) { }

	public void SnapToMiddle() { }

	private void StopTween() { }

	public void UpdateGame() { }

}

