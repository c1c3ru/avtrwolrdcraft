namespace Unity.Collections.LowLevel.Unsafe;

[BurstCompatible]
public struct UnsafeAtomicCounter64
{
	public Int64* Counter; //Field offset: 0x0

	public UnsafeAtomicCounter64(Void* ptr) { }

	public long Add(long value) { }

	public long AddSat(long value, long max = 9223372036854775807) { }

	public void Reset(long value = 0) { }

	public long Sub(long value) { }

	public long SubSat(long value, long min = -9223372036854775808) { }

}

