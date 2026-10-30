namespace UnityEngine.Purchasing;

[Extension]
internal static class LoggerExtensions
{
	private const string IAPLogTag = "Unity IAP"; //Field offset: 0x0

	[Extension]
	public static void LogIAPError(ILogger logger, string message) { }

	[Extension]
	public static void LogIAPWarning(ILogger logger, string message) { }

}

