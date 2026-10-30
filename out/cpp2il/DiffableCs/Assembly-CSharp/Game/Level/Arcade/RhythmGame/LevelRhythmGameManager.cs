namespace Game.Level.Arcade.RhythmGame;

public class LevelRhythmGameManager : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass26_0
	{
		public LevelRhythmGameManager <>4__this; //Field offset: 0x10
		public GameObject currentPanel; //Field offset: 0x18

		public <>c__DisplayClass26_0() { }

		internal void <ResetGame>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <CountdownToGame>d__23 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelRhythmGameManager <>4__this; //Field offset: 0x20

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
		public <CountdownToGame>d__23(int <>1__state) { }

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

	private const float _COUNTDOWNTIME = 0,5; //Field offset: 0x0
	[SerializeField]
	private CShape _screenCShape; //Field offset: 0x20
	[SerializeField]
	private TextMesh _countText; //Field offset: 0x28
	[SerializeField]
	private TextMesh _startGameHighScoreText; //Field offset: 0x30
	[SerializeField]
	private TextMesh _endGameScoreText; //Field offset: 0x38
	[SerializeField]
	private GameObject[] _Stages; //Field offset: 0x40
	[SerializeField]
	private GameObject[] _songs; //Field offset: 0x48
	[SerializeField]
	private GameObject _highScoreText; //Field offset: 0x50
	[SerializeField]
	private GameObject _GameWonGame; //Field offset: 0x58
	[SerializeField]
	private String[] _soundNames; //Field offset: 0x60
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x68
	[SerializeField]
	private LevelLineRhythmGame[] _lines; //Field offset: 0x70
	[SerializeField]
	private TextMesh _scoreText; //Field offset: 0x78
	[SerializeField]
	private TextMesh _wonText; //Field offset: 0x80
	private Int32[] _highScores; //Field offset: 0x88
	private int _currentStage; //Field offset: 0x90
	private int _currentScore; //Field offset: 0x94
	private int _SongIndex; //Field offset: 0x98

	public LevelRhythmGameManager() { }

	private void Awake() { }

	private void ChangeStage() { }

	[IteratorStateMachine(typeof(<CountdownToGame>d__23))]
	private IEnumerator CountdownToGame() { }

	private void DecreaseCurrentScore() { }

	private void GameWon(bool islost) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnEnable() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void ResetGame(GameObject currentPanel) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void StartGame() { }

	private void UpdateCurrentScore() { }

	private void UpdateHighScoreText() { }

}

