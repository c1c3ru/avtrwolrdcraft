namespace Unity.Services.Lobbies;

internal class Logger
{
	private const string k_Tag = "[Lobby]"; //Field offset: 0x0
	private const string k_VerboseLoggingDefine = "ENABLE_UNITY_LOBBY_VERBOSE_LOGGING"; //Field offset: 0x0

	public Logger() { }

	public static void Log(object message) { }

	[Conditional("UNITY_ASSERTIONS")]
	public static void LogAssertion(object message) { }

	public static void LogError(object message) { }

	public static void LogException(Exception exception) { }

	[Conditional("ENABLE_UNITY_LOBBY_VERBOSE_LOGGING")]
	public static void LogVerbose(object message) { }

	public static void LogWarning(object message) { }

}

