namespace Game.Level.RacingGame;

public class LevelRacingGameManager : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <CountdownToRace>d__62 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelRacingGameManager <>4__this; //Field offset: 0x20
		public Action onCountdownEnd; //Field offset: 0x28
		private int <i>5__2; //Field offset: 0x30

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <CountdownToRace>d__62(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <PrintTickets>d__71 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelRacingGameManager <>4__this; //Field offset: 0x20
		public float timer; //Field offset: 0x28
		private int <i>5__2; //Field offset: 0x2C

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <PrintTickets>d__71(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private const float _ROADCHANGETIME = 10; //Field offset: 0x0
	[SerializeField]
	private LevelRacingGameObstacle _obstaclePrefab; //Field offset: 0x20
	[SerializeField]
	private LevelRacingGameObstacle _carPrefab; //Field offset: 0x28
	[SerializeField]
	private LevelRacingGameObstacle _backgroundItemPrefab; //Field offset: 0x30
	[SerializeField]
	private LevelRacingGamePlayerCar _playerCar; //Field offset: 0x38
	[SerializeField]
	private LevelRacingGameRoad _road; //Field offset: 0x40
	[SerializeField]
	private LevelRacingGamePlayButton _playButton; //Field offset: 0x48
	[SerializeField]
	private LevelRacingGameInfoCover _gameInfo; //Field offset: 0x50
	[SerializeField]
	private TextMesh _countToRaceText; //Field offset: 0x58
	[SerializeField]
	private LevelRacingGameMoveButton[] _moveButtons; //Field offset: 0x60
	[SerializeField]
	private Transform _gameplayParent; //Field offset: 0x68
	[SerializeField]
	private TextMesh _timerText; //Field offset: 0x70
	[SerializeField]
	private Transform _bottomLeftPoint; //Field offset: 0x78
	[SerializeField]
	private Transform _bottomMiddlePoint; //Field offset: 0x80
	[SerializeField]
	private Transform _bottomRightPoint; //Field offset: 0x88
	[SerializeField]
	private Transform _topLeftPoint; //Field offset: 0x90
	[SerializeField]
	private Transform _topMiddlePoint; //Field offset: 0x98
	[SerializeField]
	private Transform _topRightPoint; //Field offset: 0xA0
	[SerializeField]
	private Transform _bottomBackgroundRightPoint; //Field offset: 0xA8
	[SerializeField]
	private Transform _bottomBackgroundLeftPoint; //Field offset: 0xB0
	[SerializeField]
	private Transform _topBackgroundRightPoint; //Field offset: 0xB8
	[SerializeField]
	private Transform _topBackgroundLeftPoint; //Field offset: 0xC0
	[SerializeField]
	private LevelRacingGameStartingObsticle[] _startingObsticles; //Field offset: 0xC8
	[SerializeField]
	private LevelRacingGameCloud[] _clouds; //Field offset: 0xD0
	[SerializeField]
	private LevelCamera _LevelCamera; //Field offset: 0xD8
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0xE0
	[SerializeField]
	private LevelSpawner _levelSpawnerTicket; //Field offset: 0xE8
	[SerializeField]
	private LevelSpawn _ticketSpawn; //Field offset: 0xF0
	[SerializeField]
	private Transform _ticketsSpawnPoint; //Field offset: 0xF8
	[SerializeField]
	private PDPrefab[] _giftsPrefabs; //Field offset: 0x100
	[SerializeField]
	private Transform _giftSpawnPoint; //Field offset: 0x108
	private readonly Vector2[] _leftPoints; //Field offset: 0x110
	private readonly Vector2[] _middlePoints; //Field offset: 0x118
	private readonly Vector2[] _rightPoints; //Field offset: 0x120
	private readonly Vector2[][] _lanes; //Field offset: 0x128
	private readonly Vector2[][] _backgroundLanes; //Field offset: 0x130
	public readonly List<LevelRacingGameObstacle> Obstacles; //Field offset: 0x138
	private readonly List<LevelRacingGameObstacle> _gifts; //Field offset: 0x140
	private float _nextObstacleSpawnTime; //Field offset: 0x148
	private float _nextBackgroundItemSpawnTime; //Field offset: 0x14C
	private float _nextRoadTextureSpawnTime; //Field offset: 0x150
	private float _nextAutoPlayMoveTime; //Field offset: 0x154
	private float _lastCarSpawnTime; //Field offset: 0x158
	private int _speedIndex; //Field offset: 0x15C
	private int _currentRoadIndex; //Field offset: 0x160
	private readonly Single[] _speeds; //Field offset: 0x168
	private readonly Single[] _speedChangeTimes; //Field offset: 0x170
	private float _timer; //Field offset: 0x178
	private Single[] _scores; //Field offset: 0x180
	private Boolean[] _spawnedGifts; //Field offset: 0x188
	private Boolean[] _givenGifts; //Field offset: 0x190
	[CompilerGenerated]
	private bool <IsGameRunning>k__BackingField; //Field offset: 0x198
	private bool _isAutoPlayRunning; //Field offset: 0x199
	private int _lanesOccupiedMask; //Field offset: 0x19C
	private int _tweenId; //Field offset: 0x1A0

	public private bool IsGameRunning
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public LevelRacingGameManager() { }

	[CompilerGenerated]
	private void <GameOver>b__69_0() { }

	[CompilerGenerated]
	private void <GameOver>b__69_1() { }

	[CompilerGenerated]
	internal static void <InitBackgroundPoints>g__DestroyPoint|65_0(ref Transform point) { }

	[CompilerGenerated]
	internal static void <InitPoints>g__DestroyPoint|64_0(ref Transform point) { }

	public void AddGift(LevelRacingGameObstacle gift) { }

	private void Awake() { }

	private void ChangeRoadTexture(bool isNewGame) { }

	[IteratorStateMachine(typeof(<CountdownToRace>d__62))]
	public IEnumerator CountdownToRace(Action onCountdownEnd) { }

	private void DestroyObsticles() { }

	private void GameOver() { }

	[CompilerGenerated]
	public bool get_IsGameRunning() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public int GetSortingOrderFromYPosition(float yPosition) { }

	private void Init() { }

	private void InitBackgroundPoints(bool destroyTransforms) { }

	private void InitGift(PDPrefab spawn) { }

	private void InitPoints(bool destroyTransforms) { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	public void OnObstacleDestroy(LevelRacingGameObstacle obstacle) { }

	public void OnPlayerCrashed() { }

	[IteratorStateMachine(typeof(<PrintTickets>d__71))]
	private IEnumerator PrintTickets(float timer) { }

	private void ResetGame() { }

	public void RestartGame(bool isAutoPlay) { }

	[CompilerGenerated]
	private void set_IsGameRunning(bool value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private bool TrySpawnBackgroundItem() { }

	private bool TrySpawnObstacle(bool isCar, int giftIndex) { }

	private void Update() { }

}

