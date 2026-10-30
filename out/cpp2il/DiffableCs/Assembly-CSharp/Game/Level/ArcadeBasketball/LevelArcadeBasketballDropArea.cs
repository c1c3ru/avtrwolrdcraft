namespace Game.Level.ArcadeBasketball;

public class LevelArcadeBasketballDropArea : LevelSingleItemCharactersOnlyDropArea, IArcadePlayable
{
	[CompilerGenerated]
	private sealed class <SpawnTickets>d__51 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelArcadeBasketballDropArea <>4__this; //Field offset: 0x20
		public int score; //Field offset: 0x28
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
		public <SpawnTickets>d__51(int <>1__state) { }

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

	[SerializeField]
	private LevelSpawner _levelSpawnerBall; //Field offset: 0xE0
	[SerializeField]
	private LevelSpawn _ballSpawn; //Field offset: 0xE8
	[SerializeField]
	private LevelSpawner _levelSpawnerTicket; //Field offset: 0xF0
	[SerializeField]
	private LevelSpawn _ticketSpawn; //Field offset: 0xF8
	[SerializeField]
	private Transform _ticketsSpawnPoint; //Field offset: 0x100
	[SerializeField]
	private SpriteRenderer _range; //Field offset: 0x108
	[SerializeField]
	private SpriteRenderer _winningMark; //Field offset: 0x110
	[SerializeField]
	private GameObject _marker; //Field offset: 0x118
	[SerializeField]
	private SpriteRenderer _buttonSP; //Field offset: 0x120
	[SerializeField]
	private CShape _buttonCShape; //Field offset: 0x128
	[SerializeField]
	private Sprite _onButton; //Field offset: 0x130
	[SerializeField]
	private Sprite _offButton; //Field offset: 0x138
	[SerializeField]
	private Transform _buttonPoint; //Field offset: 0x140
	[SerializeField]
	private LevelArcadeBasketballScoreBoard _scoreBoard; //Field offset: 0x148
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x150
	[Header("Settings")]
	[SerializeField]
	private float _pointerMarkerSpeed; //Field offset: 0x158
	[SerializeField]
	private float _greenMarkerSpeed; //Field offset: 0x15C
	[SerializeField]
	private int _numberOfShotsEachRound; //Field offset: 0x160
	[SerializeField]
	private int _numberOfRoundsEachLevel; //Field offset: 0x164
	[SerializeField]
	private int _pointsPerTicket; //Field offset: 0x168
	[SerializeField]
	private Sprite[] _winningMarks; //Field offset: 0x170
	private LevelCharacter _levelCharacter; //Field offset: 0x178
	private LevelArcadeBasketballItemHandler _arcadeBasketballHandler; //Field offset: 0x180
	private LevelItem _currentBall; //Field offset: 0x188
	private Vector3 _winningMarkInitialLocalPosition; //Field offset: 0x190
	private int _markerTweenID; //Field offset: 0x19C
	private int _winningTweenID; //Field offset: 0x1A0
	private int _score; //Field offset: 0x1A4
	private bool _isGameOver; //Field offset: 0x1A8
	private int _currentShotCount; //Field offset: 0x1AC
	private int _roundNumber; //Field offset: 0x1B0
	private bool _isLevel2; //Field offset: 0x1B4
	private float _initalPointerSpeed; //Field offset: 0x1B8
	private Vector3 _initialWinningMarkPosition; //Field offset: 0x1BC

	public LevelArcadeBasketballDropArea() { }

	protected virtual void Awake() { }

	private float CalculateScoreChance(float markerPosition) { }

	private void CancelTweens() { }

	private void CheckIfLevelChanged() { }

	private void CheckIfRoundChanged() { }

	private void DisableRange() { }

	private void EnableRange() { }

	private void GameOver() { }

	private void OnAnimationEnd(TrackEntry trackEntry) { }

	public void OnButtonClick() { }

	protected virtual void OnDestroy() { }

	private void OnFailedToScoreAfterHitGroundAction(LevelBSBasketballItemHandler _, LevelBSHoop __) { }

	public virtual void OnItemPickUp(LevelItem levelItem) { }

	protected virtual void OnLevelPostInit() { }

	private void PickUpBall() { }

	public override void Play() { }

	private void ResetGame() { }

	private void SpawnBall(TrackEntry trackEntry, Event spineEvent) { }

	[IteratorStateMachine(typeof(<SpawnTickets>d__51))]
	private IEnumerator SpawnTickets(int score) { }

	private void StartRound(TrackEntry trackEntry) { }

	private void UpdateWinningMark() { }

}

