namespace Unity.Services.Wire.Internal;

internal class Logger
{
	private const string k_Tag = "[Wire]"; //Field offset: 0x0
	private const string k_VerboseLoggingDefine = "ENABLE_UNITY_WIRE_VERBOSE_LOGGING"; //Field offset: 0x0

	public Logger() { }

	[Conditional("ENABLE_UNITY_WIRE_VERBOSE_LOGGING")]
	public static void Log(object message) { }

	[Conditional("UNITY_ASSERTIONS")]
	public static void LogAssertion(object message) { }

	[Conditional("ENABLE_UNITY_WIRE_VERBOSE_LOGGING")]
	public static void LogError(object message) { }

	[Conditional("ENABLE_UNITY_WIRE_VERBOSE_LOGGING")]
	public static void LogException(Exception exception) { }

	[Conditional("ENABLE_UNITY_WIRE_VERBOSE_LOGGING")]
	public static void LogWarning(object message) { }

}

