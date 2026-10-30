namespace Unity.Networking.Transport.Utilities;

public struct SequenceBufferContext
{
	public long Sequence; //Field offset: 0x0
	public long Acked; //Field offset: 0x8
	internal ulong AckedMask; //Field offset: 0x10
	internal ulong LastAckedMask; //Field offset: 0x18
	internal long NumberOfOverflowsDetected; //Field offset: 0x20
	public uint AckMask; //Field offset: 0x28
	public uint LastAckMask; //Field offset: 0x2C

	internal ushort LastReceivedOverflowCycle
	{
		internal get { } //Length: 12
	}

	internal ushort get_LastReceivedOverflowCycle() { }

}

