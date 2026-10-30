namespace Unity.Collections;

[BurstCompatible]
[BurstCompatible]
[BurstCompatible]
[BurstCompatible]
[Extension]
public static class FixedStringMethods
{

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	[Extension]
	public static FormatError Append(ref T fs, Rune rune) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	[Extension]
	internal static FormatError Append(ref T fs, char a, char b, char c, char d, char e, char f, char g, char h) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	[Extension]
	internal static FormatError Append(ref T fs, char a, char b) { }

	[Extension]
	[NotBurstCompatible]
	public static FormatError Append(ref T fs, string s) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	[Extension]
	public static FormatError Append(ref T fs, Byte* utf8Bytes, int utf8BytesLength) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	[Extension]
	public static FormatError Append(ref T fs, in T2 input) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	[Extension]
	public static FormatError Append(ref T fs, float input, char decimalSeparator = .) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	[Extension]
	internal static FormatError Append(ref T fs, char a, char b, char c) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	[Extension]
	public static FormatError Append(ref T fs, ulong input) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	[Extension]
	public static FormatError Append(ref T fs, int input) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	[Extension]
	public static FormatError Append(ref T fs, uint input) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	[Extension]
	public static FormatError Append(ref T fs, long input) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	[Extension]
	public static FormatError Append(ref T fs, Rune rune, int count) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	[Extension]
	public static FormatError Append(ref T fs, char ch) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	[Extension]
	public static void AppendFormat(ref T dest, in U format, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8, in T9 arg9) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	[Extension]
	public static void AppendFormat(ref T dest, in U format, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	[Extension]
	public static void AppendFormat(ref T dest, in U format, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, in T5 arg5, in T6 arg6) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	[Extension]
	public static void AppendFormat(ref T dest, in U format, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, in T5 arg5) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	[Extension]
	public static void AppendFormat(ref T dest, in U format, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	[Extension]
	public static void AppendFormat(ref T dest, in U format, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, in T5 arg5, in T6 arg6, in T7 arg7) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	[Extension]
	public static void AppendFormat(ref T dest, in U format, in T0 arg0, in T1 arg1, in T2 arg2) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	[Extension]
	public static void AppendFormat(ref T dest, in U format, in T0 arg0, in T1 arg1) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	[Extension]
	public static void AppendFormat(ref T dest, in U format, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	[Extension]
	public static void AppendFormat(ref T dest, in U format, in T0 arg0) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	[Extension]
	public static FormatError AppendRawByte(ref T fs, byte a) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	[Extension]
	internal static FormatError AppendScientific(ref T fs, Char* source, int sourceLength, int decimalExponent, char decimalSeparator = .) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	[Extension]
	public static int CompareTo(ref T fs, in T2 other) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	[Extension]
	public static int CompareTo(ref T fs, Byte* bytes, int bytesLen) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	[Extension]
	public static int ComputeHashCode(ref T fs) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	[Extension]
	public static bool Contains(ref T fs, in T2 other) { }

	[Extension]
	[NotBurstCompatible]
	public static string ConvertToString(ref T fs) { }

	[Extension]
	[NotBurstCompatible]
	public static CopyError CopyFrom(ref T fs, string s) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	[Extension]
	public static CopyError CopyFrom(ref T fs, in T2 input) { }

	[Extension]
	[NotBurstCompatible]
	public static void CopyFromTruncated(ref T fs, string s) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	[Extension]
	public static int EffectiveSizeOf(ref T fs) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	[Extension]
	public static bool Equals(ref T fs, in T2 other) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	[Extension]
	public static bool Equals(ref T fs, Byte* bytes, int bytesLen) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	[Extension]
	internal static bool Found(ref T fs, ref int offset, char a, char b, char c, char d, char e, char f, char g, char h) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	[Extension]
	internal static bool Found(ref T fs, ref int offset, char a, char b, char c) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	[Extension]
	public static int IndexOf(ref T fs, in T2 other, int startIndex, int distance = 2147483647) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	[Extension]
	public static int IndexOf(ref T fs, in T2 other) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	[Extension]
	public static int IndexOf(ref T fs, Byte* bytes, int bytesLen, int startIndex, int distance = 2147483647) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	[Extension]
	public static int IndexOf(ref T fs, Byte* bytes, int bytesLen) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	[Extension]
	public static int LastIndexOf(ref T fs, in T2 other) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	[Extension]
	public static int LastIndexOf(ref T fs, in T2 other, int startIndex, int distance = 2147483647) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	[Extension]
	public static int LastIndexOf(ref T fs, Byte* bytes, int bytesLen) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	[Extension]
	public static int LastIndexOf(ref T fs, Byte* bytes, int bytesLen, int startIndex, int distance = 2147483647) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	[Extension]
	public static ParseError Parse(ref T fs, ref int offset, ref uint output) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	[Extension]
	public static ParseError Parse(ref T fs, ref int offset, ref int output) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	[Extension]
	public static ParseError Parse(ref T fs, ref int offset, ref float output, char decimalSeparator = .) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	internal static bool ParseLongInternal(ref T fs, ref int offset, out long value) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	[Extension]
	public static Rune Peek(ref T fs, int index) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	[Extension]
	public static Rune Read(ref T fs, ref int index) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	[Extension]
	public static FormatError Write(ref T fs, ref int index, Rune rune) { }

}

