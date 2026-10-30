namespace UnityEngine;

internal static class SpookyHash
{
	private struct U
	{
		public Byte* p8; //Field offset: 0x0
		public UInt32* p32; //Field offset: 0x0
		public UInt64* p64; //Field offset: 0x0
		public ulong i; //Field offset: 0x0

		public U(UInt16* p8) { }

	}


	private static void End(UInt64* data, ref ulong h0, ref ulong h1, ref ulong h2, ref ulong h3, ref ulong h4, ref ulong h5, ref ulong h6, ref ulong h7, ref ulong h8, ref ulong h9, ref ulong h10, ref ulong h11) { }

	private static void EndPartial(ref ulong h0, ref ulong h1, ref ulong h2, ref ulong h3, ref ulong h4, ref ulong h5, ref ulong h6, ref ulong h7, ref ulong h8, ref ulong h9, ref ulong h10, ref ulong h11) { }

	public static void Hash(Void* message, ulong length, UInt64* hash1, UInt64* hash2) { }

	private static void Mix(UInt64* data, ref ulong s0, ref ulong s1, ref ulong s2, ref ulong s3, ref ulong s4, ref ulong s5, ref ulong s6, ref ulong s7, ref ulong s8, ref ulong s9, ref ulong s10, ref ulong s11) { }

	private static void Rot64(ref ulong x, int k) { }

	private static void Short(Void* message, ulong length, UInt64* hash1, UInt64* hash2) { }

	private static void ShortEnd(ref ulong h0, ref ulong h1, ref ulong h2, ref ulong h3) { }

	private static void ShortMix(ref ulong h0, ref ulong h1, ref ulong h2, ref ulong h3) { }

}

