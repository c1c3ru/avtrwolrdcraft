namespace System.Net;

public static class WebUtility
{
	private class UrlDecoder
	{
		private int _bufferSize; //Field offset: 0x10
		private int _numChars; //Field offset: 0x14
		private Char[] _charBuffer; //Field offset: 0x18
		private int _numBytes; //Field offset: 0x20
		private Byte[] _byteBuffer; //Field offset: 0x28
		private Encoding _encoding; //Field offset: 0x30

		internal UrlDecoder(int bufferSize, Encoding encoding) { }

		internal void AddByte(byte b) { }

		internal void AddChar(char ch) { }

		private void FlushBytes() { }

		internal string GetString() { }

	}

	private static readonly Char[] _htmlEntityEndingChars; //Field offset: 0x0
	private static UnicodeDecodingConformance _htmlDecodeConformance; //Field offset: 0x8
	private static UnicodeEncodingConformance _htmlEncodeConformance; //Field offset: 0xC

	private static UnicodeEncodingConformance HtmlEncodeConformance
	{
		private get { } //Length: 228
	}

	private static WebUtility() { }

	private static UnicodeEncodingConformance get_HtmlEncodeConformance() { }

	private static int GetNextUnicodeScalarValueFromUtf16Surrogate(ref Char* pch, ref int charsRemaining) { }

	private static int HexToInt(char h) { }

	public static string HtmlEncode(string value) { }

	public static void HtmlEncode(string value, TextWriter output) { }

	private static int IndexOfHtmlEncodingChars(string s, int startPos) { }

	private static char IntToHex(int n) { }

	private static bool IsUrlSafeChar(char ch) { }

	public static string UrlDecode(string encodedValue) { }

	private static string UrlDecodeInternal(string value, Encoding encoding) { }

	private static Byte[] UrlEncode(Byte[] bytes, int offset, int count, bool alwaysCreateNewReturnValue) { }

	private static Byte[] UrlEncode(Byte[] bytes, int offset, int count) { }

	public static string UrlEncode(string value) { }

	private static bool ValidateUrlEncodingParameters(Byte[] bytes, int offset, int count) { }

}

