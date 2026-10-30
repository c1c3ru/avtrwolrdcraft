namespace Unity.Collections;

internal class ConcurrentMask
{
	internal const int ErrorFailedToFree = -1; //Field offset: 0x0
	internal const int ErrorFailedToAllocate = -2; //Field offset: 0x0
	internal const int EmptyBeforeAllocation = 0; //Field offset: 0x0
	internal const int EmptyAfterFree = 0; //Field offset: 0x0

	public ConcurrentMask() { }

	internal static bool foundAtLeastThisManyConsecutiveOnes(long value, int minimum, out int offset, out int count) { }

	internal static bool foundAtLeastThisManyConsecutiveZeroes(long value, int minimum, out int offset, out int count) { }

	internal static void longestConsecutiveOnes(long value, out int offset, out int count) { }

	internal static long MakeMask(int offset, int bits) { }

	internal static bool Succeeded(int error) { }

	internal static int TryAllocate(ref long l, int offset, int bits) { }

	internal static int TryAllocate(ref long l, out int offset, int bits) { }

	internal static int TryAllocate(ref T t, int offset, int bits) { }

	internal static int TryAllocate(ref T t, out int offset, int begin, int end, int bits) { }

	internal static int TryAllocate(ref T t, out int offset, int bits) { }

	internal static int TryFree(ref long l, int offset, int bits) { }

	internal static int TryFree(ref T t, int offset, int bits) { }

}

