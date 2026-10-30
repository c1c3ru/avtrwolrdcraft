namespace Unity.Networking.Transport.Utilities;

public struct ReliableUtility
{
	internal struct Context
	{
		public int Capacity; //Field offset: 0x0
		public long Resume; //Field offset: 0x8
		public long Delivered; //Field offset: 0x10
		public int IndexStride; //Field offset: 0x18
		public int IndexPtrOffset; //Field offset: 0x1C
		public int DataStride; //Field offset: 0x20
		public int DataPtrOffset; //Field offset: 0x24
		public long LastSentTime; //Field offset: 0x28
		public long PreviousTimestamp; //Field offset: 0x30

	}

	internal enum ErrorCodes
	{
		Stale_Packet = -1,
		Duplicated_Packet = -2,
		OutgoingQueueIsFull = -7,
		InsufficientMemory = -8,
	}

	[Obsolete("Will be removed in Unity Transport 2.0.")]
	internal struct Packet
	{
		[CompilerGenerated]
		[UnsafeValueType]
		internal struct <Buffer>e__FixedBuffer
		{
			public byte FixedElementField; //Field offset: 0x0

		}

		internal const int Length = 1472; //Field offset: 0x0
		public PacketHeader Header; //Field offset: 0x0
		[FixedBuffer(typeof(byte), 1472)]
		public <Buffer>e__FixedBuffer Buffer; //Field offset: 0x0

	}

	[Obsolete("Will be removed in Unity Transport 2.0.")]
	internal struct PacketHeader
	{
		public ushort Type; //Field offset: 0x0
		public ushort ProcessingTime; //Field offset: 0x2
		public ushort SequenceId; //Field offset: 0x4
		public ushort AckedSequenceId; //Field offset: 0x6
		public uint AckMask; //Field offset: 0x8

	}

	internal struct PacketInformation
	{
		public long SequenceId; //Field offset: 0x0
		public ushort Size; //Field offset: 0x8
		public ushort HeaderPadding; //Field offset: 0xA
		public long SendTime; //Field offset: 0x10

	}

	internal struct PacketTimers
	{
		public ushort ProcessingTime; //Field offset: 0x0
		public ushort Padding; //Field offset: 0x2
		public long SequenceId; //Field offset: 0x8
		public long SentTime; //Field offset: 0x10
		public long ReceiveTime; //Field offset: 0x18

	}

	internal enum PacketType
	{
		Payload = 0,
		Ack = 1,
	}

	internal struct ParameterConstants
	{
		public const int WindowSize = 32; //Field offset: 0x0

	}

	internal struct Parameters : INetworkParameter
	{
		public int WindowSize; //Field offset: 0x0

		public override bool Validate() { }

	}

	public struct ReliableHeader
	{
		public ushort Type; //Field offset: 0x0
		public ushort ProcessingTime; //Field offset: 0x2
		public ushort SequenceId; //Field offset: 0x4
		public ushort AckedSequenceId; //Field offset: 0x6
		public ulong AckedMask; //Field offset: 0x8

	}

	public struct ReliablePacket
	{
		[CompilerGenerated]
		[UnsafeValueType]
		internal struct <Buffer>e__FixedBuffer
		{
			public byte FixedElementField; //Field offset: 0x0

		}

		internal const int Length = 1476; //Field offset: 0x0
		public ReliableHeader Header; //Field offset: 0x0
		[FixedBuffer(typeof(byte), 1476)]
		public <Buffer>e__FixedBuffer Buffer; //Field offset: 0x0

	}

	internal struct RTTInfo
	{
		public int LastRtt; //Field offset: 0x0
		public float SmoothedRtt; //Field offset: 0x4
		public float SmoothedVariance; //Field offset: 0x8
		public int ResendTimeout; //Field offset: 0xC

	}

	internal struct SharedContext
	{
		public int WindowSize; //Field offset: 0x0
		public int MinimumResendTime; //Field offset: 0x4
		public SequenceBufferContext SentPackets; //Field offset: 0x8
		public SequenceBufferContext ReceivedPackets; //Field offset: 0x38
		internal int DuplicatesSinceLastAck; //Field offset: 0x68
		public Statistics stats; //Field offset: 0x6C
		public ErrorCodes errorCode; //Field offset: 0x88
		public RTTInfo RttInfo; //Field offset: 0x8C
		public int TimerDataOffset; //Field offset: 0x9C
		public int TimerDataStride; //Field offset: 0xA0
		public int RemoteTimerDataOffset; //Field offset: 0xA4
		public int RemoteTimerDataStride; //Field offset: 0xA8

	}

	internal struct Statistics
	{
		public int PacketsReceived; //Field offset: 0x0
		public int PacketsSent; //Field offset: 0x4
		public int PacketsDropped; //Field offset: 0x8
		public int PacketsOutOfOrder; //Field offset: 0xC
		public int PacketsDuplicated; //Field offset: 0x10
		public int PacketsStale; //Field offset: 0x14
		public int PacketsResent; //Field offset: 0x18

	}

	public const long NullEntry = -1; //Field offset: 0x0
	public const int DefaultMinimumResendTime = 64; //Field offset: 0x0
	public const int MaximumResendTime = 200; //Field offset: 0x0
	internal const int MaxDuplicatesSinceLastAck = 3; //Field offset: 0x0

	private static int AlignedSizeOf() { }

	public static ushort CalculateProcessingTime(Byte* sharedBuffer, long sequenceId, long timestamp) { }

	private static int CurrentResendTime(Byte* sharedBuffer) { }

	private static long GetIndex(Byte* self, long index) { }

	public static PacketTimers* GetLocalPacketTimer(Byte* sharedBuffer, long sequenceId) { }

	internal static long GetNextSendResumeSequence(NetworkPipelineContext context) { }

	[Obsolete("Internal API that shouldn't be used. Will be removed in Unity Transport 2.0.")]
	public static Packet* GetPacket(Byte* self, long sequence) { }

	public static PacketInformation* GetPacketInformation(Byte* self, long sequence) { }

	internal static ReliablePacket* GetReliablePacket(Byte* self, long sequence) { }

	public static PacketTimers* GetRemotePacketTimer(Byte* sharedBuffer, long sequenceId) { }

	internal static long GetSequenceId64Bits(ref SequenceBufferContext context, ushort sequenceId16Bits) { }

	public static SharedContext InitializeContext(Byte* sharedBuffer, int sharedBufferLength, Byte* sendBuffer, int sendBufferLength, Byte* recvBuffer, int recvBufferLength, Parameters param) { }

	public static int InitializeProcessContext(Byte* buffer, int bufferLength, Parameters param) { }

	internal static bool NeedResumeReceive(NetworkPipelineContext context) { }

	internal static int PacketHeaderWireSize(int windowSize) { }

	internal static int PacketHeaderWireSize(NetworkPipelineContext ctx) { }

	public static int ProcessCapacityNeeded(Parameters param) { }

	internal static long Read(NetworkPipelineContext context, ReliableHeader header) { }

	[Obsolete("Will be removed in Unity Transport 2.0.")]
	public static int Read(NetworkPipelineContext context, PacketHeader header) { }

	[Obsolete("Will be removed in Unity Transport 2.0.")]
	public static void ReadAckPacket(NetworkPipelineContext context, PacketHeader header) { }

	internal static void ReadAckPacket(NetworkPipelineContext context, ReliableHeader header) { }

	public static void Release(Byte* self, long start_sequence, int count) { }

	public static void Release(Byte* self, long sequence) { }

	internal static void ReleaseAcknowledgedPackets(NetworkPipelineContext context) { }

	[Obsolete("Internal API that shouldn't be used. Will be removed in Unity Transport 2.0.")]
	public static bool ReleaseOrResumePackets(NetworkPipelineContext context) { }

	public static InboundRecvBuffer ResumeReceive(NetworkPipelineContext context, int startSequence, ref bool needsResume) { }

	[Obsolete("Will be removed in Unity Transport 2.0.")]
	public static InboundSendBuffer ResumeSend(NetworkPipelineContext context, out PacketHeader header, ref bool needsResume) { }

	internal static InboundSendBuffer ResumeSend(NetworkPipelineContext context, out ReliableHeader header, ref bool needsResume) { }

	[Obsolete("Internal API that shouldn't be used. Will be removed in Unity Transport 2.0.")]
	public static void SetHeaderAndPacket(Byte* self, long sequence, PacketHeader header, InboundSendBuffer data, long timestamp) { }

	internal static void SetHeaderAndPacket(Byte* self, long sequence, ReliableHeader header, InboundSendBuffer data, long timestamp) { }

	private static void SetIndex(Byte* self, long index, long sequence) { }

	public static void SetMinimumResendTime(int value, NetworkDriver driver, NetworkPipeline pipeline, NetworkConnection con) { }

	public static void SetPacket(Byte* self, long sequence, InboundRecvBuffer data) { }

	public static void SetPacket(Byte* self, long sequence, Void* data, int length) { }

	public static int SharedCapacityNeeded(Parameters param) { }

	public static bool ShouldSendAck(NetworkPipelineContext ctx) { }

	public static void StoreReceiveTimestamp(Byte* sharedBuffer, long sequenceId, long timestamp, ushort processingTime) { }

	public static void StoreRemoteReceiveTimestamp(Byte* sharedBuffer, long sequenceId, long timestamp) { }

	public static void StoreTimestamp(Byte* sharedBuffer, long sequenceId, long timestamp) { }

	public static bool TryAquire(Byte* self, long sequence) { }

	[Obsolete("Will be removed in Unity Transport 2.0.")]
	public static int Write(NetworkPipelineContext context, InboundSendBuffer inboundBuffer, ref PacketHeader header) { }

	internal static long Write(NetworkPipelineContext context, InboundSendBuffer inboundBuffer, ref ReliableHeader header) { }

	internal static void WriteAckPacket(NetworkPipelineContext context, ref ReliableHeader header) { }

	[Obsolete("Will be removed in Unity Transport 2.0.")]
	public static void WriteAckPacket(NetworkPipelineContext context, ref PacketHeader header) { }

}

