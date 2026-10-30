namespace Game.Level.Arcade.RhythmGame;

public class LevelLineRhythmGame : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass24_0
	{
		public GameObject newNote; //Field offset: 0x10
		public LevelLineRhythmGame <>4__this; //Field offset: 0x18
		public Action <>9__1; //Field offset: 0x20

		public <>c__DisplayClass24_0() { }

		internal void <StartGameCorotine>b__0() { }

		internal void <StartGameCorotine>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <StartGameCorotine>d__24 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelLineRhythmGame <>4__this; //Field offset: 0x20
		public int songIndex; //Field offset: 0x28
		private <>c__DisplayClass24_0 <>8__1; //Field offset: 0x30
		private int <i>5__2; //Field offset: 0x38

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
		public <StartGameCorotine>d__24(int <>1__state) { }

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
	private static Action<Boolean> OnGameWon; //Field offset: 0x0
	[SerializeField]
	private Transform _startPoint; //Field offset: 0x20
	[SerializeField]
	private Transform _endPoint; //Field offset: 0x28
	[SerializeField]
	private Transform _notesParent; //Field offset: 0x30
	[SerializeField]
	private GameObject _notePrefab; //Field offset: 0x38
	[SerializeField]
	private LevelLifesRhythmGame _levelLifes; //Field offset: 0x40
	[SerializeField]
	private ArcadeSong[] _songFiles; //Field offset: 0x48
	[SerializeField]
	private bool _isLeft; //Field offset: 0x50
	[SerializeField]
	private Sprite _noteSprite; //Field offset: 0x58
	[Header("Settings")]
	[SerializeField]
	private float _notesSpeed; //Field offset: 0x60
	private bool _isTouching; //Field offset: 0x64
	private List<Single> _notes; //Field offset: 0x68
	private float _timePassed; //Field offset: 0x70
	private Coroutine _coroutine; //Field offset: 0x78
	private GameObject _currentTouchingNote; //Field offset: 0x80
	private int _noteTweenID; //Field offset: 0x88

	public static event Action<Boolean> OnGameWon
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public bool IsTouching
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public LevelLineRhythmGame() { }

	[CompilerGenerated]
	private void <DestroyCurrentNote>b__26_0() { }

	[CompilerGenerated]
	public static void add_OnGameWon(Action<Boolean> value) { }

	private void Awake() { }

	private void DestroyCurrentNote() { }

	public bool get_IsTouching() { }

	private void OnDestroy() { }

	private void OnGameOver(bool _) { }

	[CompilerGenerated]
	public static void remove_OnGameWon(Action<Boolean> value) { }

	public void set_IsTouching(bool value) { }

	public void StartGame(int songIndex) { }

	[IteratorStateMachine(typeof(<StartGameCorotine>d__24))]
	private IEnumerator StartGameCorotine(int songIndex) { }

}

