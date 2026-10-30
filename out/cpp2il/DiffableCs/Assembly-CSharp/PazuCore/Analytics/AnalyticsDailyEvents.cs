namespace PazuCore.Analytics;

public static class AnalyticsDailyEvents
{
	internal class Keys
	{
		private const string PREFIX = "PazuCore_Analytics_Daily"; //Field offset: 0x0
		public const string SCENES = "PazuCore_Analytics_DailyScenes"; //Field offset: 0x0
		public const string WIDGET_CLICKS = "PazuCore_Analytics_DailyWidgetClicks"; //Field offset: 0x0

		public Keys() { }

	}

	private static HashSet<String> _enteredScenes; //Field offset: 0x0
	private static HashSet<String> _widgetClicks; //Field offset: 0x8
	private static readonly HashSet<EventType> _dailyEventTypes; //Field offset: 0x10

	private static AnalyticsDailyEvents() { }

	public static void AddWidgetClick(string widgetName) { }

	public static void CreateDialyEventsIfNeeded() { }

	public static bool IsDailyEvent(EventType eventType) { }

	public static void LoadData() { }

	public static void OnSceneChanged(Scene scene) { }

}

