namespace Unity.Networking.Transport.Relay;

internal struct RelayMessagePing
{
	public const int Length = 22; //Field offset: 0x0
	public RelayMessageHeader Header; //Field offset: 0x0
	public RelayAllocationId FromAllocationId; //Field offset: 0x4
	public ushort SequenceNumber; //Field offset: 0x14

	internal static RelayMessagePing Create(RelayAllocationId fromAllocationId, ushort dataLength) { }

}

