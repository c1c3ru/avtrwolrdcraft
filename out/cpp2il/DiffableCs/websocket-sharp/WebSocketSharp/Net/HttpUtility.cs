namespace WebSocketSharp.Net;

internal static class HttpUtility
{
	private static Dictionary<String, Char> _entities; //Field offset: 0x0
	private static Char[] _hexChars; //Field offset: 0x8
	private static object _sync; //Field offset: 0x10

	private static HttpUtility() { }

	internal static Uri CreateRequestUrl(string requestUri, string host, bool websocketRequest, bool secure) { }

	internal static IPrincipal CreateUser(string response, AuthenticationSchemes scheme, string realm, string method, Func<IIdentity, NetworkCredential> credentialsFinder) { }

	internal static Encoding GetEncoding(string contentType) { }

	private static Dictionary<String, Char> getEntities() { }

	private static int getNumber(char c) { }

	private static int getNumber(Byte[] bytes, int offset, int count) { }

	private static int getNumber(string s, int offset, int count) { }

	public static void HtmlAttributeEncode(string s, TextWriter output) { }

	public static string HtmlAttributeEncode(string s) { }

	private static string htmlDecode(string s) { }

	public static void HtmlDecode(string s, TextWriter output) { }

	public static string HtmlDecode(string s) { }

	private static string htmlEncode(string s, bool minimal) { }

	public static void HtmlEncode(string s, TextWriter output) { }

	public static string HtmlEncode(string s) { }

	private static void initEntities() { }

	private static bool isAlphabet(char c) { }

	private static bool isNumeric(char c) { }

	private static bool isUnreserved(char c) { }

	private static bool isUnreservedInRfc2396(char c) { }

	private static bool isUnreservedInRfc3986(char c) { }

	internal static bool TryGetEncoding(string contentType, out Encoding result) { }

	public static string UrlDecode(string s, Encoding encoding) { }

	public static string UrlDecode(string s) { }

	public static string UrlDecode(Byte[] bytes, Encoding encoding) { }

	public static string UrlDecode(Byte[] bytes, int offset, int count, Encoding encoding) { }

	private static Byte[] urlDecodeToBytes(Byte[] bytes, int offset, int count) { }

	public static Byte[] UrlDecodeToBytes(Byte[] bytes, int offset, int count) { }

	public static Byte[] UrlDecodeToBytes(string s) { }

	public static Byte[] UrlDecodeToBytes(Byte[] bytes) { }

	private static void urlEncode(byte b, Stream output) { }

	public static string UrlEncode(Byte[] bytes) { }

	public static string UrlEncode(string s) { }

	public static string UrlEncode(string s, Encoding encoding) { }

	public static string UrlEncode(Byte[] bytes, int offset, int count) { }

	private static Byte[] urlEncodeToBytes(Byte[] bytes, int offset, int count) { }

	public static Byte[] UrlEncodeToBytes(string s) { }

	public static Byte[] UrlEncodeToBytes(string s, Encoding encoding) { }

	public static Byte[] UrlEncodeToBytes(Byte[] bytes) { }

	public static Byte[] UrlEncodeToBytes(Byte[] bytes, int offset, int count) { }

}

