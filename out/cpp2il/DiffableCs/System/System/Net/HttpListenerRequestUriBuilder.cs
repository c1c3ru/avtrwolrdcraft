namespace System.Net;

internal sealed class HttpListenerRequestUriBuilder
{
	private enum EncodingType
	{
		Primary = 0,
		Secondary = 1,
	}

	private enum ParsingResult
	{
		Success = 0,
		InvalidString = 1,
		EncodingError = 2,
	}

	private static readonly bool useCookedRequestUrl; //Field offset: 0x0
	private static readonly Encoding utf8Encoding; //Field offset: 0x8
	private static readonly Encoding ansiEncoding; //Field offset: 0x10
	private readonly string rawUri; //Field offset: 0x10
	private readonly string cookedUriScheme; //Field offset: 0x18
	private readonly string cookedUriHost; //Field offset: 0x20
	private readonly string cookedUriPath; //Field offset: 0x28
	private readonly string cookedUriQuery; //Field offset: 0x30
	private StringBuilder requestUriString; //Field offset: 0x38
	private List<Byte> rawOctets; //Field offset: 0x40
	private string rawPath; //Field offset: 0x48
	private Uri requestUri; //Field offset: 0x50

	private static HttpListenerRequestUriBuilder() { }

	private HttpListenerRequestUriBuilder(string rawUri, string cookedUriScheme, string cookedUriHost, string cookedUriPath, string cookedUriQuery) { }

	private bool AddPercentEncodedOctetToRawOctetsList(Encoding encoding, string escapedCharacter) { }

	private static string AddSlashToAsteriskOnlyPath(string path) { }

	private static void AppendOctetsPercentEncoded(StringBuilder target, IEnumerable<Byte> octets) { }

	private bool AppendUnicodeCodePointValuePercentEncoded(string codePoint) { }

	private Uri Build() { }

	private void BuildRequestUriUsingCookedPath() { }

	private void BuildRequestUriUsingRawPath() { }

	private ParsingResult BuildRequestUriUsingRawPath(Encoding encoding) { }

	private bool EmptyDecodeAndAppendRawOctetsList(Encoding encoding) { }

	private static Encoding GetEncoding(EncodingType type) { }

	private static string GetOctetsAsString(IEnumerable<Byte> octets) { }

	private static string GetPath(string uriString) { }

	public static Uri GetRequestUri(string rawUri, string cookedUriScheme, string cookedUriHost, string cookedUriPath, string cookedUriQuery) { }

	private void LogWarning(string methodName, string message, Object[] args) { }

	private ParsingResult ParseRawPath(Encoding encoding) { }

}

