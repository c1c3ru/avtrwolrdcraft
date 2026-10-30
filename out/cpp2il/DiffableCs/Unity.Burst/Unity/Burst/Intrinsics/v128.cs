namespace Unity.Burst.Intrinsics;

[DebuggerTypeProxy(typeof(V128DebugView))]
public struct v128
{
	public byte Byte0; //Field offset: 0x0
	public double Double0; //Field offset: 0x0
	public float Float0; //Field offset: 0x0
	public long SLong0; //Field offset: 0x0
	public ulong ULong0; //Field offset: 0x0
	public int SInt0; //Field offset: 0x0
	public uint UInt0; //Field offset: 0x0
	public short SShort0; //Field offset: 0x0
	public v64 Lo64; //Field offset: 0x0
	public ushort UShort0; //Field offset: 0x0
	public sbyte SByte0; //Field offset: 0x0
	public byte Byte1; //Field offset: 0x1
	public sbyte SByte1; //Field offset: 0x1
	public short SShort1; //Field offset: 0x2
	public sbyte SByte2; //Field offset: 0x2
	public ushort UShort1; //Field offset: 0x2
	public byte Byte2; //Field offset: 0x2
	public sbyte SByte3; //Field offset: 0x3
	public byte Byte3; //Field offset: 0x3
	public byte Byte4; //Field offset: 0x4
	public uint UInt1; //Field offset: 0x4
	public ushort UShort2; //Field offset: 0x4
	public int SInt1; //Field offset: 0x4
	public float Float1; //Field offset: 0x4
	public short SShort2; //Field offset: 0x4
	public sbyte SByte4; //Field offset: 0x4
	public byte Byte5; //Field offset: 0x5
	public sbyte SByte5; //Field offset: 0x5
	public byte Byte6; //Field offset: 0x6
	public sbyte SByte6; //Field offset: 0x6
	public short SShort3; //Field offset: 0x6
	public ushort UShort3; //Field offset: 0x6
	public byte Byte7; //Field offset: 0x7
	public sbyte SByte7; //Field offset: 0x7
	public int SInt2; //Field offset: 0x8
	public ulong ULong1; //Field offset: 0x8
	public uint UInt2; //Field offset: 0x8
	public double Double1; //Field offset: 0x8
	public long SLong1; //Field offset: 0x8
	public short SShort4; //Field offset: 0x8
	public float Float2; //Field offset: 0x8
	public byte Byte8; //Field offset: 0x8
	public v64 Hi64; //Field offset: 0x8
	public sbyte SByte8; //Field offset: 0x8
	public ushort UShort4; //Field offset: 0x8
	public byte Byte9; //Field offset: 0x9
	public sbyte SByte9; //Field offset: 0x9
	public short SShort5; //Field offset: 0xA
	public ushort UShort5; //Field offset: 0xA
	public sbyte SByte10; //Field offset: 0xA
	public byte Byte10; //Field offset: 0xA
	public byte Byte11; //Field offset: 0xB
	public sbyte SByte11; //Field offset: 0xB
	public byte Byte12; //Field offset: 0xC
	public float Float3; //Field offset: 0xC
	public sbyte SByte12; //Field offset: 0xC
	public int SInt3; //Field offset: 0xC
	public uint UInt3; //Field offset: 0xC
	public ushort UShort6; //Field offset: 0xC
	public short SShort6; //Field offset: 0xC
	public sbyte SByte13; //Field offset: 0xD
	public byte Byte13; //Field offset: 0xD
	public short SShort7; //Field offset: 0xE
	public ushort UShort7; //Field offset: 0xE
	public sbyte SByte14; //Field offset: 0xE
	public byte Byte14; //Field offset: 0xE
	public byte Byte15; //Field offset: 0xF
	public sbyte SByte15; //Field offset: 0xF

	public v128(byte b) { }

	public v128(ulong f) { }

	public v128(long a, long b) { }

	public v128(long f) { }

	public v128(double a, double b) { }

	public v128(double f) { }

	public v128(float a, float b, float c, float d) { }

	public v128(float f) { }

	public v128(uint a, uint b, uint c, uint d) { }

	public v128(ulong a, ulong b) { }

	public v128(uint v) { }

	public v128(int v) { }

	public v128(ushort a, ushort b, ushort c, ushort d, ushort e, ushort f, ushort g, ushort h) { }

	public v128(ushort v) { }

	public v128(short a, short b, short c, short d, short e, short f, short g, short h) { }

	public v128(short v) { }

	public v128(sbyte a, sbyte b, sbyte c, sbyte d, sbyte e, sbyte f, sbyte g, sbyte h, sbyte i, sbyte j, sbyte k, sbyte l, sbyte m, sbyte n, sbyte o, sbyte p) { }

	public v128(sbyte b) { }

	public v128(byte a, byte b, byte c, byte d, byte e, byte f, byte g, byte h, byte i, byte j, byte k, byte l, byte m, byte n, byte o, byte p) { }

	public v128(int a, int b, int c, int d) { }

	public v128(v64 lo, v64 hi) { }

}

