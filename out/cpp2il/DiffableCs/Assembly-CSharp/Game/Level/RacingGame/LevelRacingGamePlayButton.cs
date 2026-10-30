namespace Game.Level.RacingGame;

public class LevelRacingGamePlayButton : MonoBehaviour, IArcadePlayable
{
	internal struct OnGameStartedEvent
	{
		[Tooltip("-1 = any avatar")]
		public int avatarID; //Field offset: 0x0
		public UnityEvent gameStartedEvent; //Field offset: 0x8

	}

	[SerializeField]
	private LevelSitArea _sitArea; //Field offset: 0x20
	[SerializeField]
	private List<OnGameStartedEvent> _gameStartedEvents; //Field offset: 0x28
	private LevelRacingGameManager _manager; //Field offset: 0x30
	private Coroutine _coroutine; //Field offset: 0x38

	public LevelRacingGamePlayButton() { }

	[CompilerGenerated]
	private void <Play>b__6_0() { }

	public void Init(LevelRacingGameManager manager) { }

	public override void Play() { }

	public void SetCharacterAnimation(string animationName, bool _isLoop) { }

}

