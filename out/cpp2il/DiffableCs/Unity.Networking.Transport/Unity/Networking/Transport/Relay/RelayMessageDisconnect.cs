namespace Unity.Networking.Transport.Relay;

internal struct RelayMessageDisconnect
{
	public const int Length = 36; //Field offset: 0x0
	public RelayMessageHeader Header; //Field offset: 0x0
	public RelayAllocationId FromAllocationId; //Field offset: 0x4
	public RelayAllocationId ToAllocationId; //Field offset: 0x14

	internal static RelayMessageDisconnect Create(RelayAllocationId fromAllocationId, RelayAllocationId toAllocationId) { }

}

