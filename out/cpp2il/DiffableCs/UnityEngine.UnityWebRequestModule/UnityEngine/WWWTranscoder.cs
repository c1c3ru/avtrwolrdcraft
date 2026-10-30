namespace UnityEngine;

[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UnityWebRequestWWWModule"})]
internal class WWWTranscoder
{
	private static Byte[] ucHexChars; //Field offset: 0x0
	private static Byte[] lcHexChars; //Field offset: 0x8
	private static byte urlEscapeChar; //Field offset: 0x10
	private static Byte[] urlSpace; //Field offset: 0x18
	private static Byte[] dataSpace; //Field offset: 0x20
	private static Byte[] urlForbidden; //Field offset: 0x28
	private static byte qpEscapeChar; //Field offset: 0x30
	private static Byte[] qpSpace; //Field offset: 0x38
	private static Byte[] qpForbidden; //Field offset: 0x40

	private static WWWTranscoder() { }

	private static void Byte2Hex(byte b, Byte[] hexChars, out byte byte0, out byte byte1) { }

	private static bool ByteArrayContains(Byte[] array, byte b) { }

	private static bool ByteSubArrayEquals(Byte[] array, int index, Byte[] comperand) { }

	public static string DataEncode(string toEncode, Encoding e) { }

	public static Byte[] DataEncode(Byte[] toEncode) { }

	public static Byte[] Decode(Byte[] input, byte escapeChar, Byte[] space) { }

	public static Byte[] Encode(Byte[] input, byte escapeChar, Byte[] space, Byte[] forbidden, bool uppercase) { }

	private static byte Hex2Byte(Byte[] b, int offset) { }

	public static string QPEncode(string toEncode, Encoding e) { }

	public static bool SevenBitClean(string s, Encoding e) { }

	public static bool SevenBitClean(Byte* input, int inputLength) { }

	public static Byte[] URLDecode(Byte[] toEncode) { }

	public static Byte[] URLEncode(Byte[] toEncode) { }

}

