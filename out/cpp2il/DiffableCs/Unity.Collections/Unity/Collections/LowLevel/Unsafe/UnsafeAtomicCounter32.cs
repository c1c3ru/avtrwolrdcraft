namespace Unity.Collections.LowLevel.Unsafe;

[BurstCompatible]
public struct UnsafeAtomicCounter32
{
	public Int32* Counter; //Field offset: 0x0

	public UnsafeAtomicCounter32(Void* ptr) { }

	public int Add(int value) { }

	public int AddSat(int value, int max = 2147483647) { }

	public void Reset(int value = 0) { }

	public int Sub(int value) { }

	public int SubSat(int value, int min = -2147483648) { }

}

