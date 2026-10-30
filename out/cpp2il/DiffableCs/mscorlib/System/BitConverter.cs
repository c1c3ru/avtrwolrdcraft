namespace System;

public static class BitConverter
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		[TupleElementNames(new IL2CPP_TYPE_STRING[] {"value", "startIndex", "length"})]
		public static SpanAction<Char, ValueTuple`3<Byte[], Int32, Int32>> <>9__38_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <ToString>b__38_0(Span<Char> dst, ValueTuple<Byte[], Int32, Int32> state) { }

	}

	[Intrinsic]
	public static readonly bool IsLittleEndian; //Field offset: 0x0

	private static BitConverter() { }

	public static long DoubleToInt64Bits(double value) { }

	public static Byte[] GetBytes(double value) { }

	public static Byte[] GetBytes(float value) { }

	[CLSCompliant(False)]
	public static Byte[] GetBytes(ulong value) { }

	[CLSCompliant(False)]
	public static Byte[] GetBytes(uint value) { }

	public static Byte[] GetBytes(bool value) { }

	public static Byte[] GetBytes(long value) { }

	public static Byte[] GetBytes(int value) { }

	public static Byte[] GetBytes(short value) { }

	public static Byte[] GetBytes(char value) { }

	[CLSCompliant(False)]
	public static Byte[] GetBytes(ushort value) { }

	public static float Int32BitsToSingle(int value) { }

	public static double Int64BitsToDouble(long value) { }

	public static int SingleToInt32Bits(float value) { }

	public static bool ToBoolean(Byte[] value, int startIndex) { }

	public static char ToChar(Byte[] value, int startIndex) { }

	public static double ToDouble(Byte[] value, int startIndex) { }

	public static short ToInt16(Byte[] value, int startIndex) { }

	public static int ToInt32(Byte[] value, int startIndex) { }

	public static long ToInt64(Byte[] value, int startIndex) { }

	public static float ToSingle(Byte[] value, int startIndex) { }

	public static string ToString(Byte[] value, int startIndex, int length) { }

	public static string ToString(Byte[] value) { }

	[CLSCompliant(False)]
	public static ushort ToUInt16(Byte[] value, int startIndex) { }

	[CLSCompliant(False)]
	public static uint ToUInt32(Byte[] value, int startIndex) { }

	[CLSCompliant(False)]
	public static ulong ToUInt64(Byte[] value, int startIndex) { }

	[CLSCompliant(False)]
	public static bool TryWriteBytes(Span<Byte> destination, uint value) { }

}

