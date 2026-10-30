namespace System.IO.Compression;

internal static class Crc32Helper
{
	private static readonly UInt32[] s_crcTable_0; //Field offset: 0x0
	private static readonly UInt32[] s_crcTable_1; //Field offset: 0x8
	private static readonly UInt32[] s_crcTable_2; //Field offset: 0x10
	private static readonly UInt32[] s_crcTable_3; //Field offset: 0x18
	private static readonly UInt32[] s_crcTable_4; //Field offset: 0x20
	private static readonly UInt32[] s_crcTable_5; //Field offset: 0x28
	private static readonly UInt32[] s_crcTable_6; //Field offset: 0x30
	private static readonly UInt32[] s_crcTable_7; //Field offset: 0x38

	private static Crc32Helper() { }

	private static uint ManagedCrc32(uint crc32, Byte[] buffer, int offset, int length) { }

	public static uint UpdateCrc32(uint crc32, Byte[] buffer, int offset, int length) { }

}

