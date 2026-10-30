namespace Unity.Services.Lobbies.Http;

internal static class CommonErrors
{
	private const string ErrorPrefix = "com.unity.services.lobby"; //Field offset: 0x0

	public static IError HttpNetworkError
	{
		 get { } //Length: 168
	}

	public static IError RequestOnSuccessNull
	{
		 get { } //Length: 168
	}

	public static IError CreateUnspecifiedHttpError(string details) { }

	public static IError get_HttpNetworkError() { }

	public static IError get_RequestOnSuccessNull() { }

}

