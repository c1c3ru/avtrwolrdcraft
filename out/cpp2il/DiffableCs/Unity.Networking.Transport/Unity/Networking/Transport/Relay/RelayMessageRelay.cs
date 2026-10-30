namespace Unity.Networking.Transport.Relay;

internal struct RelayMessageRelay
{
	public const int Length = 38; //Field offset: 0x0
	public RelayMessageHeader Header; //Field offset: 0x0
	public RelayAllocationId FromAllocationId; //Field offset: 0x4
	public RelayAllocationId ToAllocationId; //Field offset: 0x14
	public ushort DataLength; //Field offset: 0x24

	internal static RelayMessageRelay Create(RelayAllocationId fromAllocationId, RelayAllocationId toAllocationId, ushort dataLength) { }

}

