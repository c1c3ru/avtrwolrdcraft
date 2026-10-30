namespace PazuCore.PazuGameMode;

public class PazuGameModeManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass34_0
	{
		public string op; //Field offset: 0x10
		public PazuGameModeManager <>4__this; //Field offset: 0x18

		public <>c__DisplayClass34_0() { }

		internal void <GetGameModeIfPossible>b__0(string responseText) { }

	}

	[CompilerGenerated]
	private sealed class <GetGameModeIfPossible>d__34 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public PazuGameModeManager <>4__this; //Field offset: 0x20
		private <>c__DisplayClass34_0 <>8__1; //Field offset: 0x28

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
		public <GetGameModeIfPossible>d__34(int <>1__state) { }

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
		public const string IS_GAME_IN_REVIEW = "PazuCore_PazuGameMode_IsGameInReview"; //Field offset: 0x0
		public const string GAME_MARKETING_MODE = "PazuCore_PazuGameMode_GameMarketingMode"; //Field offset: 0x0
		public const string SHOULD_SEND_ANALYTICS_EVENTS = "PazuCore_PazuGameMode_ShouldSendAnalyticsEvents"; //Field offset: 0x0

	}

	private const GameMarketingMode DEFAULT_MARKETING_MODE_ANDROID = 0; //Field offset: 0x0
	private const GameMarketingMode DEFAULT_MARKETING_MODE_IOS = 0; //Field offset: 0x0
	[CompilerGenerated]
	private static bool <IsReceivcedGameMode>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private static PazuGameModeManager <Instance>k__BackingField; //Field offset: 0x8
	[CompilerGenerated]
	private bool <IsGameInReview>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private GameMarketingMode <CurrentGameMarketingMode>k__BackingField; //Field offset: 0x24
	[CompilerGenerated]
	private bool <ShouldSendAnalyticsEvents>k__BackingField; //Field offset: 0x28
	private bool _isGettingGameModeInProgress; //Field offset: 0x29
	[CompilerGenerated]
	private Config <CurrentConfig>k__BackingField; //Field offset: 0x30

	public private Config CurrentConfig
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private GameMarketingMode CurrentGameMarketingMode
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private static PazuGameModeManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public private bool IsGameInReview
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public private static bool IsReceivcedGameMode
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public private bool ShouldSendAnalyticsEvents
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public PazuGameModeManager() { }

	private void Awake() { }

	[CompilerGenerated]
	public Config get_CurrentConfig() { }

	[CompilerGenerated]
	public GameMarketingMode get_CurrentGameMarketingMode() { }

	[CompilerGenerated]
	public static PazuGameModeManager get_Instance() { }

	[CompilerGenerated]
	public bool get_IsGameInReview() { }

	[CompilerGenerated]
	public static bool get_IsReceivcedGameMode() { }

	[CompilerGenerated]
	public bool get_ShouldSendAnalyticsEvents() { }

	public static GameMarketingMode GetDefaultMarketingMode() { }

	[IteratorStateMachine(typeof(<GetGameModeIfPossible>d__34))]
	private IEnumerator GetGameModeIfPossible() { }

	private void LoadCachedOrDefaultData() { }

	private void OnDestroy() { }

	public void OnGameResume() { }

	private void OnReceivceGameMode(PazuGameModeResponse response) { }

	private void PrintGameModeInfo(bool isLocal) { }

	[CompilerGenerated]
	private void set_CurrentConfig(Config value) { }

	[CompilerGenerated]
	private void set_CurrentGameMarketingMode(GameMarketingMode value) { }

	[CompilerGenerated]
	private static void set_Instance(PazuGameModeManager value) { }

	[CompilerGenerated]
	private void set_IsGameInReview(bool value) { }

	[CompilerGenerated]
	private static void set_IsReceivcedGameMode(bool value) { }

	[CompilerGenerated]
	private void set_ShouldSendAnalyticsEvents(bool value) { }

	private void Start() { }

}

