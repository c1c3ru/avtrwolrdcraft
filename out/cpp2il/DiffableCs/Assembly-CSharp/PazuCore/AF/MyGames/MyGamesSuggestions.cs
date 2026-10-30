namespace PazuCore.AF.MyGames;

public class MyGamesSuggestions : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <ShowGameSuggestions>d__26 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MyGamesSuggestions <>4__this; //Field offset: 0x20

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
		public <ShowGameSuggestions>d__26(int <>1__state) { }

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
	private static MyGamesSuggestions <Instance>k__BackingField; //Field offset: 0x0
	[SerializeField]
	private GameOnDevice _gameOnDevicePrefab; //Field offset: 0x20
	[SerializeField]
	private Transform _gamesHolder; //Field offset: 0x28
	[SerializeField]
	private SuggestedGameBar _suggestedGameBarPrefab; //Field offset: 0x30
	[SerializeField]
	private Transform _sameGamesHolder; //Field offset: 0x38
	[SerializeField]
	private ListPositionCtrl _listPositionCtrl; //Field offset: 0x40
	[SerializeField]
	private UnityEvent _OnStartScroll; //Field offset: 0x48
	[SerializeField]
	private Sprite _downloadSprite; //Field offset: 0x50
	[SerializeField]
	private Sprite _playSprite; //Field offset: 0x58
	private bool _isUserScrolled; //Field offset: 0x60
	private List<Int32> _gamesIdOnDevice; //Field offset: 0x68
	private ListBox _lastFocusedListBox; //Field offset: 0x70
	private GameOnDevice _currentSelectButton; //Field offset: 0x78
	private int _currentGameID; //Field offset: 0x80
	private Coroutine _showSuggestionsCoroutine; //Field offset: 0x88
	private int _contentBaseChildCount; //Field offset: 0x90
	private GameObject _listTemp; //Field offset: 0x98

	public private static MyGamesSuggestions Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public MyGamesSuggestions() { }

	private void Awake() { }

	private void CreateDeviceGamesScrollItems() { }

	private void DeactivateAllSuggestedGames() { }

	[CompilerGenerated]
	public static MyGamesSuggestions get_Instance() { }

	private void OnDestroy() { }

	private void OnFocus(ListBox listBox) { }

	private void OnGameResume() { }

	public void OnStartScroll() { }

	private void ScaleGameDevice(ListBox listBox, Vector3 scale, float time) { }

	[CompilerGenerated]
	private static void set_Instance(MyGamesSuggestions value) { }

	[IteratorStateMachine(typeof(<ShowGameSuggestions>d__26))]
	private IEnumerator ShowGameSuggestions() { }

	private void ShowSimilarGames(MyGamesSuggestionsData data) { }

	private void Start() { }

	private void UpdateInstalledGames() { }

}

