namespace Unity.Services.Authentication.Shared;

internal class ApiUtils
{
	public static readonly Regex JsonRegex; //Field offset: 0x0

	private static ApiUtils() { }

	public ApiUtils() { }

	public static string Base64Encode(string text) { }

	private static string GetEnumMemberAttrValue(object enumVal) { }

	private static bool HasEnumMemberAttrValue(object enumVal) { }

	public static bool IsJsonMime(string mime) { }

	public static Multimap<String, String> ParameterToMultiMap(IApiConfiguration configuration, string collectionFormat, string name, object value) { }

	public static string ParameterToString(IApiConfiguration configuration, object obj) { }

	public static string SelectHeaderAccept(String[] accepts) { }

	public static string SelectHeaderContentType(String[] contentTypes) { }

}

