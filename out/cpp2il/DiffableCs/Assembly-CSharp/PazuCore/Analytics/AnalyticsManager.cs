namespace PazuCore.Analytics;

public class AnalyticsManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Boolean> <>9__27_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <Start>b__27_0() { }

	}

	[CompilerGenerated]
	private struct <>c__DisplayClass46_0
	{
		public string key; //Field offset: 0x0

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass49_0
	{
		public AnalyticsManager <>4__this; //Field offset: 0x10
		public int applicationPauseCount; //Field offset: 0x18

		public <>c__DisplayClass49_0() { }

		internal void <SendNextEventBatch>b__0(List<QueueItem> items) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass49_1
	{
		public List<QueueItem> items; //Field offset: 0x10
		public string op; //Field offset: 0x18
		public <>c__DisplayClass49_0 CS$<>8__locals1; //Field offset: 0x20

		public <>c__DisplayClass49_1() { }

		internal void <SendNextEventBatch>b__1(string responseText) { }

	}

	[CompilerGenerated]
	private sealed class <Start>d__27 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public AnalyticsManager <>4__this; //Field offset: 0x20

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
		public <Start>d__27(int <>1__state) { }

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

	public const string EDITOR_LOG_ANALYTICS_EVENTS_KEY = "PazuCore_Editor_LogAnalyticsEvents"; //Field offset: 0x0
	[CompilerGenerated]
	private static AnalyticsManager <Instance>k__BackingField; //Field offset: 0x0
	private SceneName _currentSceneName; //Field offset: 0x20
	private string _currentGameSceneName; //Field offset: 0x28
	private LoadSceneMode _lastLoadSceneMode; //Field offset: 0x30
	[CompilerGenerated]
	private SceneName <PreviousSceneName>k__BackingField; //Field offset: 0x34
	private long _timeOnSceneChange; //Field offset: 0x38
	private readonly EventQueueManager _queueManager; //Field offset: 0x40
	private AnalyticsAliveTracker _aliveTracker; //Field offset: 0x48
	private AnalyticsIdleTracker _idleTracker; //Field offset: 0x50
	private bool _isSendingToServerInProgress; //Field offset: 0x58
	[CompilerGenerated]
	private bool <IsBadClientVersion>k__BackingField; //Field offset: 0x59
	private int _failuresCount; //Field offset: 0x5C

	public SceneName CurrentSceneName
	{
		 get { } //Length: 8
	}

	public private static AnalyticsManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public private bool IsBadClientVersion
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public private SceneName PreviousSceneName
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public EventQueueManager QueueManager
	{
		 get { } //Length: 8
	}

	public AnalyticsManager() { }

	[CompilerGenerated]
	internal static void <AddDailyActiveEventIfNeeded>g__AddEvent|46_0(ref <>c__DisplayClass46_0 unnamed_param_0) { }

	[CompilerGenerated]
	private void <SetDeviceCloudDiagnosticsData>g__SetValueAsSHA1|28_0(string key, string value) { }

	private void AddAliveEventIfNeeded() { }

	private void AddChangeEventsIfNeeded() { }

	public void AddDailyActiveEventIfNeeded() { }

	public void AddEventToBatch(EventDataBase eventData) { }

	private void Awake() { }

	public bool CanCurrentSceneHaveCreative() { }

	public void DeleteAllData() { }

	public SceneName get_CurrentSceneName() { }

	[CompilerGenerated]
	public static AnalyticsManager get_Instance() { }

	[CompilerGenerated]
	public bool get_IsBadClientVersion() { }

	[CompilerGenerated]
	public SceneName get_PreviousSceneName() { }

	public EventQueueManager get_QueueManager() { }

	public double GetActiveTime() { }

	public static string GetDailyActiveSavedTimeKey() { }

	public string GetLog() { }

	private int GetNextBatchCount(bool isAboutToPauseGame) { }

	private long GetTimeNow() { }

	public bool IsAnalyticsClientEnabled() { }

	private void OnDestroy() { }

	public void OnGamePause() { }

	public void OnGameResume() { }

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) { }

	private void OnSceneUnloaded(Scene scene) { }

	public void SendNextEventBatch(bool isGameAboutToPause = false) { }

	private void SendSceneOpenEvent(SceneName sceneName, string gameSceneName) { }

	public void SendSceneOpenEventIfNeeded(string gameSceneName) { }

	public void SendSceneOpenEventIfNeeded(SceneName sceneName, string gameSceneName) { }

	[CompilerGenerated]
	private static void set_Instance(AnalyticsManager value) { }

	[CompilerGenerated]
	private void set_IsBadClientVersion(bool value) { }

	[CompilerGenerated]
	private void set_PreviousSceneName(SceneName value) { }

	private void SetBackgroundEventData(int gamePauseEventId) { }

	public void SetDeviceCloudDiagnosticsData() { }

	public void SetUnityCloudDiagnosticsValue(string key, string value) { }

	[IteratorStateMachine(typeof(<Start>d__27))]
	private IEnumerator Start() { }

}

