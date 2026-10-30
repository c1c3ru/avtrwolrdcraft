namespace PazuCore;

public static class LocalizationInfo
{
	private static string _cachedLanguageCode; //Field offset: 0x0
	private static string _cachedCountryCode; //Field offset: 0x8

	public static void GetLanguageCodeAndCountryCode(out string languageCode, out string countryCode) { }

	private static void GetLanguageCodeAndCountryCodeInternal(out string languageCode, out string countryCode) { }

	private static string GetLanguageCodeFromSystemLanguage() { }

	private static string GetLanguageCodeFromSystemLanguage(SystemLanguage systemLanguage) { }

	public static void OnGameResume() { }

}

