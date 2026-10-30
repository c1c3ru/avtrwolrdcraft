namespace Unity.Services.Relay;

[Extension]
internal static class ApiErrorExtender
{

	[Extension]
	public static string GetExceptionMessage(ErrorResponseBody error) { }

	[Extension]
	public static RelayExceptionReason GetExceptionReason(HttpClientResponse error) { }

	[Extension]
	public static RelayExceptionReason GetExceptionReason(ErrorResponseBody error) { }

}

