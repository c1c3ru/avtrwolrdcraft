namespace Unity.Collections;

[BurstCompatible]
[DebuggerTypeProxy(typeof(BitField64DebugView))]
public struct BitField64
{
	public ulong Value; //Field offset: 0x0

	public BitField64(ulong initialValue = 0) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void CheckArgs(int pos, int numBits) { }

	public void Clear() { }

	public int CountBits() { }

	public int CountLeadingZeros() { }

	public int CountTrailingZeros() { }

	public ulong GetBits(int pos, int numBits = 1) { }

	public bool IsSet(int pos) { }

	public void SetBits(int pos, bool value) { }

	public void SetBits(int pos, bool value, int numBits = 1) { }

	public bool TestAll(int pos, int numBits = 1) { }

	public bool TestAny(int pos, int numBits = 1) { }

	public bool TestNone(int pos, int numBits = 1) { }

}

