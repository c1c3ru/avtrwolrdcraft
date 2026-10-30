namespace Unity.Collections;

[BurstCompatible]
public static class UTF8ArrayUnsafeUtility
{
	public struct Comparison
	{
		public bool terminates; //Field offset: 0x0
		public int result; //Field offset: 0x4

		public Comparison(Rune runeA, ConversionError errorA, Rune runeB, ConversionError errorB) { }

	}


	public static CopyError Append(Byte* dest, ref ushort destLength, ushort destUTF8MaxLengthInBytes, Byte* src, ushort srcLength) { }

	public static CopyError Append(Byte* dest, ref ushort destLength, ushort destUTF8MaxLengthInBytes, Char* src, int srcLength) { }

	public static CopyError Append(Char* dest, ref ushort destLength, ushort destUCS2MaxLengthInChars, Byte* src, ushort srcLength) { }

	public static FormatError AppendUTF8Bytes(Byte* dest, ref int destLength, int destCapacity, Byte* src, int srcLength) { }

	public static CopyError Copy(Byte* dest, out int destLength, int destUTF8MaxLengthInBytes, Char* src, int srcLength) { }

	public static CopyError Copy(Byte* dest, out ushort destLength, ushort destUTF8MaxLengthInBytes, Char* src, int srcLength) { }

	public static CopyError Copy(Byte* dest, out int destLength, int destUTF8MaxLengthInBytes, Byte* src, int srcLength) { }

	public static CopyError Copy(Byte* dest, out ushort destLength, ushort destUTF8MaxLengthInBytes, Byte* src, ushort srcLength) { }

	public static CopyError Copy(Char* dest, out int destLength, int destUCS2MaxLengthInChars, Byte* src, int srcLength) { }

	public static CopyError Copy(Char* dest, out ushort destLength, ushort destUCS2MaxLengthInChars, Byte* src, ushort srcLength) { }

	public static bool EqualsUTF8Bytes(Byte* aBytes, int aLength, Byte* bBytes, int bLength) { }

	public static int StrCmp(Byte* utf8BufferA, int utf8LengthInBytesA, Byte* utf8BufferB, int utf8LengthInBytesB) { }

	public static int StrCmp(Char* utf16BufferA, int utf16LengthInCharsA, Char* utf16BufferB, int utf16LengthInCharsB) { }

	public static int StrCmp(Byte* utf8Buffer, int utf8LengthInBytes, Char* utf16Buffer, int utf16LengthInChars) { }

	public static int StrCmp(Char* utf16Buffer, int utf16LengthInChars, Byte* utf8Buffer, int utf8LengthInBytes) { }

}

