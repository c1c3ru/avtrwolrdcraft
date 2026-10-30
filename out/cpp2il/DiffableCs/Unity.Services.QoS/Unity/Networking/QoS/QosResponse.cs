namespace Unity.Networking.QoS;

internal class QosResponse
{
	private const int MinPacketLen = 13; //Field offset: 0x0
	private const int MaxPacketLen = 1500; //Field offset: 0x0
	private const byte ResponseMagic = 149; //Field offset: 0x0
	private const byte ResponseVersion = 0; //Field offset: 0x0
	private byte m_Magic; //Field offset: 0x10
	private byte m_VerAndFlow; //Field offset: 0x11
	private byte m_Sequence; //Field offset: 0x12
	private ushort m_Identifier; //Field offset: 0x14
	private ulong m_Timestamp; //Field offset: 0x18
	private int m_LatencyMs; //Field offset: 0x20
	private ushort m_PacketLength; //Field offset: 0x24

	internal byte FlowControl
	{
		internal get { } //Length: 12
	}

	internal ushort Identifier
	{
		internal get { } //Length: 8
	}

	internal int LatencyMs
	{
		internal get { } //Length: 8
	}

	internal ushort Length
	{
		internal get { } //Length: 8
	}

	internal byte Magic
	{
		internal get { } //Length: 8
	}

	internal byte Sequence
	{
		internal get { } //Length: 8
	}

	internal ulong Timestamp
	{
		internal get { } //Length: 8
	}

	internal byte Version
	{
		internal get { } //Length: 12
	}

	public QosResponse() { }

	internal void Deserialize(IntPtr msgData) { }

	internal byte get_FlowControl() { }

	internal ushort get_Identifier() { }

	internal int get_LatencyMs() { }

	internal ushort get_Length() { }

	internal byte get_Magic() { }

	internal byte get_Sequence() { }

	internal ulong get_Timestamp() { }

	internal byte get_Version() { }

	internal ValueTuple<FcType, Byte> ParseFlowControl() { }

	internal ValueTuple<Int32, Int32> Recv(IntPtr socketHandle, bool wait, DateTime expireTimeUtc, ref NetworkEndPoint endPoint) { }

	internal bool Verify(uint maxSequence, ref string error) { }

}

