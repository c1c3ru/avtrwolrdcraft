namespace Unity.Networking.QoS;

internal class QosRequest
{
	private const int MinPacketLen = 15; //Field offset: 0x0
	private const int MaxPacketLen = 1500; //Field offset: 0x0
	private const byte RequestMagic = 89; //Field offset: 0x0
	private const int ConstructedPacketLen = 14; //Field offset: 0x0
	private byte m_Magic; //Field offset: 0x10
	private byte m_VerAndFlow; //Field offset: 0x11
	private byte m_TitleLen; //Field offset: 0x12
	private Byte[] m_Title; //Field offset: 0x18
	private byte m_Sequence; //Field offset: 0x20
	private ushort m_Identifier; //Field offset: 0x22
	private ulong m_Timestamp; //Field offset: 0x28
	private ushort m_PacketLength; //Field offset: 0x30

	internal byte FlowControl
	{
		internal get { } //Length: 12
	}

	internal ushort Identifier
	{
		internal get { } //Length: 8
		internal set { } //Length: 8
	}

	internal int Length
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
		internal set { } //Length: 8
	}

	internal ulong Timestamp
	{
		internal get { } //Length: 8
		internal set { } //Length: 8
	}

	internal Byte[] Title
	{
		internal get { } //Length: 8
		internal set { } //Length: 260
	}

	internal byte Version
	{
		internal get { } //Length: 12
	}

	public QosRequest() { }

	internal byte get_FlowControl() { }

	internal ushort get_Identifier() { }

	internal int get_Length() { }

	internal byte get_Magic() { }

	internal byte get_Sequence() { }

	internal ulong get_Timestamp() { }

	internal Byte[] get_Title() { }

	internal byte get_Version() { }

	internal ValueTuple<UInt32, Int32> Send(IntPtr socketHandle, NetworkEndPoint endPoint, DateTime expireTimeUtc) { }

	internal UnsafeAppendBuffer Serialize() { }

	internal void set_Identifier(ushort value) { }

	internal void set_Sequence(byte value) { }

	internal void set_Timestamp(ulong value) { }

	internal void set_Title(Byte[] value) { }

}

