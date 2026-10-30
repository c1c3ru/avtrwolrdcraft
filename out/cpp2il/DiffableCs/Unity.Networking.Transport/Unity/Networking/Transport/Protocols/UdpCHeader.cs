namespace Unity.Networking.Transport.Protocols;

internal struct UdpCHeader
{
	[Flags]
	internal enum HeaderFlags
	{
		HasConnectToken = 1,
		HasPipeline = 2,
	}

	public const int Length = 10; //Field offset: 0x0
	public byte Type; //Field offset: 0x0
	public HeaderFlags Flags; //Field offset: 0x1
	public SessionIdToken SessionToken; //Field offset: 0x2

}

