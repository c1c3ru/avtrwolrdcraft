namespace Unity.Collections;

[BurstCompatible]
public struct Unicode
{
	[BurstCompatible]
	internal struct Rune
	{
		public int value; //Field offset: 0x0

		public Rune(int codepoint) { }

		public static bool IsDigit(Rune r) { }

		public int LengthInUtf8Bytes() { }

		public static Rune op_Explicit(char codepoint) { }

	}

	public const int kMaximumValidCodePoint = 1114111; //Field offset: 0x0

	public static Rune BadRune
	{
		 get { } //Length: 8
	}

	public static Rune ReplacementCharacter
	{
		 get { } //Length: 8
	}

	public static Rune get_BadRune() { }

	public static Rune get_ReplacementCharacter() { }

	private static bool IsLeadingSurrogate(char c) { }

	private static bool IsTrailingSurrogate(char c) { }

	public static bool IsValidCodePoint(int codepoint) { }

	public static bool NotTrailer(byte b) { }

	public static ConversionError UcsToUtf16(Char* buffer, ref int index, int capacity, Rune rune) { }

	public static ConversionError UcsToUtf8(Byte* buffer, ref int index, int capacity, Rune rune) { }

	public static ConversionError Utf16ToUcs(out Rune rune, Char* buffer, ref int index, int capacity) { }

	public static ConversionError Utf16ToUtf8(Char* utf16Buffer, int utf16Length, Byte* utf8Buffer, out int utf8Length, int utf8Capacity) { }

	public static ConversionError Utf8ToUcs(out Rune rune, Byte* buffer, ref int index, int capacity) { }

	public static ConversionError Utf8ToUtf16(Byte* utf8Buffer, int utf8Length, Char* utf16Buffer, out int utf16Length, int utf16Capacity) { }

	public static ConversionError Utf8ToUtf8(Byte* srcBuffer, int srcLength, Byte* destBuffer, out int destLength, int destCapacity) { }

}

