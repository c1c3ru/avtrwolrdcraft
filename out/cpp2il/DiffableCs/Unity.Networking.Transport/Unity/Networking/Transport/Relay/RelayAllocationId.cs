namespace Unity.Networking.Transport.Relay;

public struct RelayAllocationId : IEquatable<RelayAllocationId>, IComparable<RelayAllocationId>
{
	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <Value>e__FixedBuffer
	{
		public byte FixedElementField; //Field offset: 0x0

	}

	public const int k_Length = 16; //Field offset: 0x0
	[FixedBuffer(typeof(byte), 16)]
	public <Value>e__FixedBuffer Value; //Field offset: 0x0

	private int Compare(RelayAllocationId other) { }

	public override int CompareTo(RelayAllocationId other) { }

	public override bool Equals(RelayAllocationId other) { }

	public virtual bool Equals(object other) { }

	public static RelayAllocationId FromByteArray(Byte[] data) { }

	public static RelayAllocationId FromBytePointer(Byte* dataPtr, int length) { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(RelayAllocationId lhs, RelayAllocationId rhs) { }

	public static bool op_Inequality(RelayAllocationId lhs, RelayAllocationId rhs) { }

}

