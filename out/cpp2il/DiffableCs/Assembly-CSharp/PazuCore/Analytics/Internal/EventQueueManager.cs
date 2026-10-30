namespace PazuCore.Analytics.Internal;

public class EventQueueManager
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<String, Int32> <>9__27_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal int <LoadEventFilesNames>b__27_0(string fileName) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass19_0
	{
		public EventQueueManager <>4__this; //Field offset: 0x10
		public string time; //Field offset: 0x18

		public <>c__DisplayClass19_0() { }

		internal void <UpdateLastEventTime>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass30_0
	{
		public HashSet<String> fileNames; //Field offset: 0x10
		public EventQueueManager <>4__this; //Field offset: 0x18

		public <>c__DisplayClass30_0() { }

		internal bool <DeleteEventItems>b__0(QueueItem item) { }

		internal void <DeleteEventItems>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass32_0
	{
		public EventQueueManager <>4__this; //Field offset: 0x10
		public List<QueueItem> itemsFromFiles; //Field offset: 0x18
		public String[] filesNamesToUse; //Field offset: 0x20
		public List<String> missingEventFiles; //Field offset: 0x28
		public bool isDone; //Field offset: 0x30

		public <>c__DisplayClass32_0() { }

		internal void <LoadNextBatch>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <LoadNextBatch>d__32 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public EventQueueManager <>4__this; //Field offset: 0x20
		public int maxEvents; //Field offset: 0x28
		public bool shouldLoadEventsOnMainThread; //Field offset: 0x2C
		private <>c__DisplayClass32_0 <>8__1; //Field offset: 0x30
		public int applicationPauseCount; //Field offset: 0x38
		public Action<List`1<QueueItem>> useItems; //Field offset: 0x40
		private Dictionary<String, QueueItem> <itemsDictionary>5__2; //Field offset: 0x48

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
		public <LoadNextBatch>d__32(int <>1__state) { }

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

	internal class Keys
	{
		private const string VERSION = "1"; //Field offset: 0x0
		public const string BASE_DIRECTORY = "PazuCore_Analytics_1/"; //Field offset: 0x0
		public const string GLOBAL_STATE = "PazuCore_Analytics_1/State_Global"; //Field offset: 0x0
		public const string GAME_STATE_PREFIX = "PazuCore_Analytics_1/State_Game_"; //Field offset: 0x0
		public const string LAST_EVENT_TIME = "PazuCore_Analytics_1/LastEventTime"; //Field offset: 0x0

		public Keys() { }

	}

	private sealed class SaveFileDelegate : MulticastDelegate
	{

		public SaveFileDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(string name, string content, AsyncCallback callback, object object) { }

		public override bool EndInvoke(IAsyncResult result) { }

		public override bool Invoke(string name, string content) { }

	}

	private sealed class TryLoadDelegate : MulticastDelegate
	{

		public TryLoadDelegate`1(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(string name, out T classInstance, AsyncCallback callback, object object) { }

		public override bool EndInvoke(out T classInstance, IAsyncResult result) { }

		public override bool Invoke(string name, out T classInstance) { }

	}

	private const int MAX_FILES = 1000; //Field offset: 0x0
	private QueueGlobalState _globalState; //Field offset: 0x10
	private QueueGameState _gameState; //Field offset: 0x18
	private string _baseFolder; //Field offset: 0x20
	private string _itemsFolder; //Field offset: 0x28
	private long _lastEventUpdateTime; //Field offset: 0x30
	private List<String> _eventfilesNames; //Field offset: 0x38
	private SaveFileDelegate _saveFile; //Field offset: 0x40
	private TryLoadDelegate<String> _tryLoadFile; //Field offset: 0x48
	private TryLoadDelegate<QueueGameState> _tryLoadGameState; //Field offset: 0x50
	private TryLoadDelegate<QueueGlobalState> _tryLoadGlobalState; //Field offset: 0x58
	private readonly List<QueueItem> _queueItems; //Field offset: 0x60

	public EventQueueManager() { }

	private void AddItemImplement(EventDataBase eventData) { }

	public void AddItemToQueue(EventDataBase eventData) { }

	private void CreateDirectoryIfNeeded(string path) { }

	public void DeleteAllData() { }

	public void DeleteEventItems(List<QueueItem> items) { }

	private void DeleteItems(HashSet<String> fileNames) { }

	private void EnsureState() { }

	public string GetConfigGuid() { }

	private string GetEventDataKey(int eventId) { }

	private string GetGameStateKey() { }

	private string GetKey(string key) { }

	public long GetLastEventTimestamp() { }

	public string GetLog() { }

	public int GetNextEventID() { }

	public bool HasItemsToSend() { }

	public void Init() { }

	public void LoadEventFilesNames() { }

	private List<QueueItem> LoadEvents(String[] filesNames, List<String> missingEventFilesToFill) { }

	[IteratorStateMachine(typeof(<LoadNextBatch>d__32))]
	public IEnumerator LoadNextBatch(bool shouldLoadEventsOnMainThread, int maxEvents, int applicationPauseCount, Action<List`1<QueueItem>> useItems) { }

	private void LoadState() { }

	private void SaveGameState() { }

	private bool SaveTextFileForAnalytics(string fileName, string content) { }

	private bool ShouldSaveMoveFiles() { }

	private bool TryLoadTextFileForAnalytics(string fileName, out string content) { }

	private void UpdateLastEventTime(long eventTime, bool forceMainThread) { }

}

