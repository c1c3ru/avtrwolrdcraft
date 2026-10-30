namespace Unity.Networking.Transport.Relay;

internal struct RelayMessageError
{
	public const int Length = 21; //Field offset: 0x0
	public RelayMessageHeader Header; //Field offset: 0x0
	public RelayAllocationId AllocationId; //Field offset: 0x4
	public byte ErrorCode; //Field offset: 0x14

	internal static RelayMessageError Create(RelayAllocationId allocationId, byte errorCode) { }

}

