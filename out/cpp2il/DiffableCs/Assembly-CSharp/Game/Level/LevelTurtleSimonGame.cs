namespace Game.Level;

public class LevelTurtleSimonGame : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass43_0
	{
		public LevelTurtleSimonGame <>4__this; //Field offset: 0x10
		public int index; //Field offset: 0x18

		public <>c__DisplayClass43_0() { }

		internal void <OnClickSimonGameButton>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass47_0
	{
		public LevelItem levelItem; //Field offset: 0x10
		public int loopCount; //Field offset: 0x18
		public bool waitingForGiftAnimation; //Field offset: 0x1C

		public <>c__DisplayClass47_0() { }

		internal void <AnimateGivingGifts>b__0() { }

		internal bool <AnimateGivingGifts>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <AnimateGivingGifts>d__47 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelTurtleSimonGame <>4__this; //Field offset: 0x20
		private <>c__DisplayClass47_0 <>8__1; //Field offset: 0x28
		private LevelItem[] <>7__wrap1; //Field offset: 0x30
		private int <>7__wrap2; //Field offset: 0x38

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
		public <AnimateGivingGifts>d__47(int <>1__state) { }

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
	private sealed class <GameOver>d__46 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelTurtleSimonGame <>4__this; //Field offset: 0x20
		public int falseIndex; //Field offset: 0x28

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
		public <GameOver>d__46(int <>1__state) { }

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
	private sealed class <LightButton>d__41 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public bool withButtonSound; //Field offset: 0x20
		public LevelTurtleSimonGame <>4__this; //Field offset: 0x28
		public int index; //Field offset: 0x30
		public float time; //Field offset: 0x34

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
		public <LightButton>d__41(int <>1__state) { }

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
	private sealed class <PlayIdleState>d__36 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelTurtleSimonGame <>4__this; //Field offset: 0x20
		private int <i>5__2; //Field offset: 0x28

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
		public <PlayIdleState>d__36(int <>1__state) { }

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
	private sealed class <StartGamePlay>d__39 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelTurtleSimonGame <>4__this; //Field offset: 0x20
		private List<Int32> <randromIndexes>5__2; //Field offset: 0x28
		private int <i>5__3; //Field offset: 0x30
		private int <randromIndex>5__4; //Field offset: 0x34
		private Sprite[] <>7__wrap4; //Field offset: 0x38

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
		public <StartGamePlay>d__39(int <>1__state) { }

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
	private sealed class <StartRound>d__40 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelTurtleSimonGame <>4__this; //Field offset: 0x20
		private int <i>5__2; //Field offset: 0x28

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
		public <StartRound>d__40(int <>1__state) { }

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
	private sealed class <Unpress>d__44 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelTurtleSimonGame <>4__this; //Field offset: 0x20
		public int index; //Field offset: 0x28
		private float <wait>5__2; //Field offset: 0x2C

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
		public <Unpress>d__44(int <>1__state) { }

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
	private LevelButton _playButton; //Field offset: 0x20
	[SerializeField]
	private LevelButton[] _simonGameButtons; //Field offset: 0x28
	[SerializeField]
	private Sprite[] _simonGameButtonOnSprites; //Field offset: 0x30
	[SerializeField]
	private Sprite[] _countdownSprites; //Field offset: 0x38
	[SerializeField]
	private Sprite _scoreSprite; //Field offset: 0x40
	[SerializeField]
	private Sprite _emptySprite; //Field offset: 0x48
	[SerializeField]
	private SpriteRenderer[] _progressionLights; //Field offset: 0x50
	[SerializeField]
	private Sprite _progressionLightOn; //Field offset: 0x58
	[SerializeField]
	private Sprite _progressionLightOff; //Field offset: 0x60
	[SerializeField]
	private PDPrefabReference[] _gifts; //Field offset: 0x68
	[SerializeField]
	[Tooltip("Match the Event index with the corresponding gift index")]
	private List<UnityEvent> _onGiftSpawnedEvent; //Field offset: 0x70
	[SerializeField]
	private Transform _giftSpawnPoint; //Field offset: 0x78
	[SerializeField]
	private GameObject _simonHead; //Field offset: 0x80
	[SerializeField]
	private GameObject[] _simonArms; //Field offset: 0x88
	[SerializeField]
	private TextMesh _score; //Field offset: 0x90
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x98
	private int _sequenceSuccessCount; //Field offset: 0xA0
	private int _currentRound; //Field offset: 0xA4
	private int _indexChecking; //Field offset: 0xA8
	private readonly List<Int32> _sequence; //Field offset: 0xB0
	private readonly Int32[] _giftsSequenceSuccessCheckpoints; //Field offset: 0xB8
	private int _giftTweenId; //Field offset: 0xC0
	private int _gameOverTweenId; //Field offset: 0xC4
	private Int32[] _gameStartTweenIds; //Field offset: 0xC8
	private int _givenTopGift; //Field offset: 0xD0
	private int _highestScore; //Field offset: 0xD4
	private float _simonHeadStartX; //Field offset: 0xD8
	private bool _isPrassing; //Field offset: 0xDC
	private bool _prassingInterapte; //Field offset: 0xDD
	private readonly Color _redColor; //Field offset: 0xE0
	private readonly Color _yellowColor; //Field offset: 0xF0
	private readonly Color _purpleColor; //Field offset: 0x100
	private Random _random; //Field offset: 0x110

	public LevelTurtleSimonGame() { }

	[CompilerGenerated]
	private void <GameOver>b__46_0() { }

	[CompilerGenerated]
	private void <GameOver>b__46_1() { }

	[IteratorStateMachine(typeof(<AnimateGivingGifts>d__47))]
	private IEnumerator AnimateGivingGifts() { }

	private void Awake() { }

	[IteratorStateMachine(typeof(<GameOver>d__46))]
	private IEnumerator GameOver(int falseIndex) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	[IteratorStateMachine(typeof(<LightButton>d__41))]
	private IEnumerator LightButton(int index, float time, bool withButtonSound = false) { }

	private void Multiplayer_OnRandomGeneratorInit(int seed, string guidPrefix) { }

	public void OnClickPlay() { }

	public void OnClickSimonGameButton(int index) { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	[IteratorStateMachine(typeof(<PlayIdleState>d__36))]
	private IEnumerator PlayIdleState() { }

	private void SetAllSimonGameButtonsState(bool newState) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	[IteratorStateMachine(typeof(<StartGamePlay>d__39))]
	private IEnumerator StartGamePlay() { }

	[IteratorStateMachine(typeof(<StartRound>d__40))]
	private IEnumerator StartRound() { }

	private void StopIdleState() { }

	private void TrySpawnGift(int giftIndex) { }

	[IteratorStateMachine(typeof(<Unpress>d__44))]
	private IEnumerator Unpress(int index) { }

	private void UpdateScoreText() { }

}

