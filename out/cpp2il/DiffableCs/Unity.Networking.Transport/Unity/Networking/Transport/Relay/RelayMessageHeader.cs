namespace Unity.Networking.Transport.Relay;

internal struct RelayMessageHeader
{
	public const int Length = 4; //Field offset: 0x0
	public ushort Signature; //Field offset: 0x0
	public byte Version; //Field offset: 0x2
	public RelayMessageType Type; //Field offset: 0x3

	internal static RelayMessageHeader Create(RelayMessageType type) { }

	public bool IsValid() { }

}

