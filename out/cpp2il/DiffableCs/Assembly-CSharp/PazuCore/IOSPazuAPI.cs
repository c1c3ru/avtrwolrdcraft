namespace PazuCore;

public static class IOSPazuAPI
{
	public static bool SuppressPlatformError; //Field offset: 0x0

	public static void BuyProduct(string productName) { }

	private static bool CheckCall(string info) { }

	public static void ContactUs() { }

	public static bool FinishCompletedTransactionsIfNeeded() { }

	public static bool FinishTransaction(string transactionId) { }

	public static string GetAppGroupSharedFolder() { }

	public static string GetCountryCode() { }

	public static string GetCultureInfo() { }

	public static string GetFirstPurchasedTransactionInQueueReceipt() { }

	public static string GetIdentifierForVendor() { }

	public static string GetKeychainString(string key) { }

	public static string GetLatestReceipt() { }

	public static string GetProductLocalCurrencyCode(string productName) { }

	public static string GetProductLocalPrice(string productName) { }

	public static float GetProductLocalPriceNumber(string productName) { }

	public static string GetProductLocalPriceWithPriceOverride(string productName, float price) { }

	public static string GetTrialPeriodForProduct(string productName) { }

	public static bool IsFullVersionLegacy() { }

	public static bool IsGameInstalled(string urlScheme) { }

	public static bool IsProductsValidationInProgress() { }

	public static bool IsProductValid(string productName) { }

	public static void OnGameResume() { }

	public static void OpenGameWithInfo(string urlScheme, string itunesLink) { }

	public static void OpenUrl(string url) { }

	public static void PrepareProducts(string json) { }

	public static void RateApp(string fallbackRateUrl) { }

	public static bool RemoveKeychain(string key) { }

	public static void RestorePurchase() { }

	public static bool SetKeychainString(string key, string value) { }

}

