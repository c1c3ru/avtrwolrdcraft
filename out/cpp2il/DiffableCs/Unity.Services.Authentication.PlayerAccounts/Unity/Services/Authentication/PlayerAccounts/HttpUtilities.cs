namespace Unity.Services.Authentication.PlayerAccounts;

internal static class HttpUtilities
{
	private const int k_MinPort = 49215; //Field offset: 0x0
	private const int k_MaxPort = 65535; //Field offset: 0x0

	public static string EncodeQueryString(IDictionary<String, String> queryParams) { }

	private static string EscapeUrlString(string rawString) { }

	public static IDictionary<String, String> ParseQueryString(string queryString) { }

	public static bool TryBindListenerOnFreePort(out HttpListener httpListener, out int port) { }

	private static string UnescapeUrlString(string urlString) { }

}

