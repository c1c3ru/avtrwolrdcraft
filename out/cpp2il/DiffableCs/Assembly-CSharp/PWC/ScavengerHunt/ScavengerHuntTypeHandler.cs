namespace PWC.ScavengerHunt;

public class ScavengerHuntTypeHandler
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<PDPrefabReference, String> <>9__35_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal string <StartNextGame>b__35_0(PDPrefabReference x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass39_0
	{
		public string prefabGuid; //Field offset: 0x10

		public <>c__DisplayClass39_0() { }

		internal bool <OnBeforeDestroyPDPrefabInstance>b__0(SpawnState x) { }

	}

	[CompilerGenerated]
	private sealed class <Timer>d__43 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ScavengerHuntTypeHandler <>4__this; //Field offset: 0x20
		private WaitForSeconds <wait>5__2; //Field offset: 0x28

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
		public <Timer>d__43(int <>1__state) { }

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

	private static class Keys
	{
		public const string STATE = "State"; //Field offset: 0x0

	}

	private readonly ScavengerHuntType _type; //Field offset: 0x10
	private readonly ScavengerHuntManager _manager; //Field offset: 0x18
	private ScavengerHuntTypeState _state; //Field offset: 0x20
	private Coroutine _timerCoroutine; //Field offset: 0x28
	private readonly Dictionary<Int32, ScavengerHuntTypeData> _dataDict; //Field offset: 0x30
	private ScavengerHuntTypeData _currentData; //Field offset: 0x38
	[CompilerGenerated]
	private Action OnGameStartAction; //Field offset: 0x40
	[CompilerGenerated]
	private Action<Int32> OnTimeLeftChangedAction; //Field offset: 0x48
	[CompilerGenerated]
	private Action OnTimeUpAction; //Field offset: 0x50
	[CompilerGenerated]
	private Action<String> OnBeforeDestroyGameItemAction; //Field offset: 0x58
	[CompilerGenerated]
	private Action OnGameCompletedAction; //Field offset: 0x60

	public event Action<String> OnBeforeDestroyGameItemAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action OnGameCompletedAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public event Action OnGameStartAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public event Action<Int32> OnTimeLeftChangedAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action OnTimeUpAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public ScavengerHuntTypeData CurrentData
	{
		 get { } //Length: 8
	}

	public string GameGuid
	{
		 get { } //Length: 28
	}

	public bool IsGameRunning
	{
		 get { } //Length: 28
	}

	public ScavengerHuntTypeState State
	{
		 get { } //Length: 8
	}

	public int TimeLeft
	{
		 get { } //Length: 28
	}

	public ScavengerHuntTypeHandler(ScavengerHuntManager manager, ScavengerHuntType type, Dictionary<Int32, ScavengerHuntTypeData> dataDict) { }

	[CompilerGenerated]
	public void add_OnBeforeDestroyGameItemAction(Action<String> value) { }

	[CompilerGenerated]
	public void add_OnGameCompletedAction(Action value) { }

	[CompilerGenerated]
	public void add_OnGameStartAction(Action value) { }

	[CompilerGenerated]
	public void add_OnTimeLeftChangedAction(Action<Int32> value) { }

	[CompilerGenerated]
	public void add_OnTimeUpAction(Action value) { }

	public void ClearData() { }

	public void CompleteGame() { }

	public ScavengerHuntTypeData get_CurrentData() { }

	public string get_GameGuid() { }

	public bool get_IsGameRunning() { }

	public ScavengerHuntTypeState get_State() { }

	public int get_TimeLeft() { }

	private string GetKey(string key) { }

	public bool HasNextGameToPlay() { }

	private void LoadState() { }

	public void OnActiveSceneChanged(string gameSceneName) { }

	public void OnAppStart() { }

	public void OnBeforeDestroyPDPrefabInstance(string prefabGuid) { }

	private void OnTimeUp() { }

	[CompilerGenerated]
	public void remove_OnBeforeDestroyGameItemAction(Action<String> value) { }

	[CompilerGenerated]
	public void remove_OnGameCompletedAction(Action value) { }

	[CompilerGenerated]
	public void remove_OnGameStartAction(Action value) { }

	[CompilerGenerated]
	public void remove_OnTimeLeftChangedAction(Action<Int32> value) { }

	[CompilerGenerated]
	public void remove_OnTimeUpAction(Action value) { }

	public void SaveProgress() { }

	public void StartNextGame() { }

	private void StartTimerIfNeeded() { }

	private void StopTimerIfNeeded() { }

	private void SyncStateToFile() { }

	[IteratorStateMachine(typeof(<Timer>d__43))]
	private IEnumerator Timer() { }

}

