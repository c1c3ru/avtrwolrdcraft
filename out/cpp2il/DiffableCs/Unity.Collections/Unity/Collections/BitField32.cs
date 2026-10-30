namespace Unity.Collections;

[BurstCompatible]
[DebuggerTypeProxy(typeof(BitField32DebugView))]
public struct BitField32
{
	public uint Value; //Field offset: 0x0

	public BitField32(uint initialValue = 0) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void CheckArgs(int pos, int numBits) { }

	public void Clear() { }

	public int CountBits() { }

	public int CountLeadingZeros() { }

	public int CountTrailingZeros() { }

	public uint GetBits(int pos, int numBits = 1) { }

	public bool IsSet(int pos) { }

	public void SetBits(int pos, bool value) { }

	public void SetBits(int pos, bool value, int numBits) { }

	public bool TestAll(int pos, int numBits = 1) { }

	public bool TestAny(int pos, int numBits = 1) { }

	public bool TestNone(int pos, int numBits = 1) { }

}

