namespace PazuCore.PazuCloud;

public static class GamesPackUtils
{
	private const string PACK_PREFIX = "pack"; //Field offset: 0x0
	private const string FULLVERSION_PREFIX = "fullversion_"; //Field offset: 0x0
	private const string TRUE = "1"; //Field offset: 0x0

	public static void FillFullVersionGamesFromNonConsumables(List<String> productNames) { }

	private static string GetKeyFromGameId(int gameId) { }

	public static List<Int32> GetPurchasedGameIds() { }

	public static bool IsThisGameFullVersionExistInKeychain() { }

	private static bool TryGetGameIdFromProductName(string productName, out int gameId) { }

}

