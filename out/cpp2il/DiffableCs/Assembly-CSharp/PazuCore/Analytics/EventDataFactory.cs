namespace PazuCore.Analytics;

public static class EventDataFactory
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<String, Object> <>9__33_0; //Field offset: 0x8
		public static Func<String, Object> <>9__34_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal object <CreateDailyScenesEvent>b__33_0(string x) { }

		internal object <CreateDailyWidgetClicksEvent>b__34_0(string x) { }

	}

	private static bool _isBatchDebuggingMode; //Field offset: 0x0
	private static long _timeDebuggingMode; //Field offset: 0x8

	public static void AddBaseData(EventDataBase eventData) { }

	public static void CreateAlive(int gameId, long timestamp) { }

	public static void CreateDailyActiveEvent() { }

	public static void CreateDailyScenesEvent(HashSet<String> sceneNames) { }

	public static void CreateDailyWidgetClicksEvent(HashSet<String> widgetClicks) { }

	public static void CreateDeviceModified() { }

	public static void CreateDeviceNew() { }

	public static void CreateDownloadInstall() { }

	public static void CreateDownloadReinstall() { }

	public static void CreateDownloadUpdate() { }

	public static void CreateGameEvent(String[] items) { }

	public static void CreateGamePause() { }

	public static void CreateGameResume() { }

	public static void CreateGameStart() { }

	public static void CreateIdleEnded() { }

	public static void CreateIdleStarted() { }

	public static void CreateParentalGateClosed(ParentalGateType gateType, string context) { }

	public static void CreateParentalGateFailed(ParentalGateType gateType, string context) { }

	public static void CreateParentalGateOpened(ParentalGateType gateType, string context) { }

	public static void CreateParentalGateSucceeded(ParentalGateType gateType, string context) { }

	public static void CreatePurchaseCancelled(string productId) { }

	public static void CreatePurchaseFailed(string productId) { }

	public static void CreatePurchaseStarted(string productId) { }

	public static void CreatePurchaseSucceeded(string productId, string receipt) { }

	public static void CreatePurchaseVerifyReceiptFailed(string productId) { }

	public static void CreatePurchaseVerifyReceiptSucceeded(string productId) { }

	public static void CreateRestorePurchaseEnded(string receipt, string result) { }

	public static void CreateRestorePurchaseStarted() { }

	public static void CreateSceneOpen(SceneName sceneName, string gameSceneName) { }

	public static void CreateUserInteraction(String[] items) { }

	public static int CreateUseTimeEnd(UseTimeEventType useTimeEventType) { }

	public static void CreateUseTimeStart(UseTimeEventType useTimeEventType) { }

	public static void StartBatchDebuggingMode() { }

	public static void StopBatchDebuggingMode() { }

}

