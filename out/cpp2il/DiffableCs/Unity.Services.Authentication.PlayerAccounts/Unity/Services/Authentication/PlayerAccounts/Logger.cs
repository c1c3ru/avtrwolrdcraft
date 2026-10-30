namespace Unity.Services.Authentication.PlayerAccounts;

internal static class Logger
{
	private const string k_Tag = "[PlayerAccounts]"; //Field offset: 0x0
	internal const string k_GlobalVerboseLoggingDefine = "ENABLE_UNITY_SERVICES_VERBOSE_LOGGING"; //Field offset: 0x0
	internal const string k_AuthenticationVerboseLoggingDefine = "ENABLE_UNITY_AUTHENTICATION_VERBOSE_LOGGING"; //Field offset: 0x0

	public static void Log(object message) { }

	[Conditional("UNITY_ASSERTIONS")]
	public static void LogAssertion(object message) { }

	public static void LogError(object message) { }

	public static void LogException(Exception exception) { }

	[Conditional("ENABLE_UNITY_SERVICES_VERBOSE_LOGGING")]
	[Conditional("ENABLE_UNITY_AUTHENTICATION_VERBOSE_LOGGING")]
	public static void LogVerbose(object message) { }

	public static void LogWarning(object message) { }

}

