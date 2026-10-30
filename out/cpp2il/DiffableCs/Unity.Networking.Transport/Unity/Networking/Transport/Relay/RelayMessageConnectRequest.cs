namespace Unity.Networking.Transport.Relay;

internal struct RelayMessageConnectRequest
{
	public const int Length = 276; //Field offset: 0x0
	public RelayMessageHeader Header; //Field offset: 0x0
	public RelayAllocationId AllocationId; //Field offset: 0x4
	public byte ToConnectionDataLength; //Field offset: 0x14
	public RelayConnectionData ToConnectionData; //Field offset: 0x15

	internal static RelayMessageConnectRequest Create(RelayAllocationId allocationId, RelayConnectionData toConnectionData) { }

}

