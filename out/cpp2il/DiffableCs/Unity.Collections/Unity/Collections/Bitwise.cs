namespace Unity.Collections;

[BurstCompatible]
internal struct Bitwise
{

	internal static int AlignDown(int value, int alignPow2) { }

	internal static int AlignUp(int value, int alignPow2) { }

	internal static ulong ExtractBits(ulong input, int pos, ulong mask) { }

	internal static uint ExtractBits(uint input, int pos, uint mask) { }

	internal static int Find(UInt64* ptr, int pos, int count, int numBits) { }

	private static int FindByte(UInt64* ptr, int beginBit, int endBit, int numBits) { }

	private static int FindUint(UInt64* ptr, int beginBit, int endBit, int numBits) { }

	private static int FindUlong(UInt64* ptr, int beginBit, int endBit, int numBits) { }

	private static int FindUpto14bits(UInt64* ptr, int beginBit, int endBit, int numBits) { }

	private static int FindUpto6bits(UInt64* ptr, int beginBit, int endBit, int numBits) { }

	private static int FindUshort(UInt64* ptr, int beginBit, int endBit, int numBits) { }

	internal static int FindWithBeginEnd(UInt64* ptr, int beginBit, int endBit, int numBits) { }

	internal static int FromBool(bool value) { }

	internal static int lzcnt(byte value) { }

	internal static int lzcnt(ushort value) { }

	internal static ulong ReplaceBits(ulong input, int pos, ulong mask, ulong value) { }

	internal static uint ReplaceBits(uint input, int pos, uint mask, uint value) { }

	internal static uint SetBits(uint input, int pos, uint mask, bool value) { }

	internal static ulong SetBits(ulong input, int pos, ulong mask, bool value) { }

	internal static int tzcnt(ushort value) { }

	internal static int tzcnt(byte value) { }

}

