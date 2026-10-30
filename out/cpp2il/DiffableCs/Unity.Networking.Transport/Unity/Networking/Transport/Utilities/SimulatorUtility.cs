namespace Unity.Networking.Transport.Utilities;

public struct SimulatorUtility
{
	internal struct Context
	{
		public int MaxPacketCount; //Field offset: 0x0
		public int MaxPacketSize; //Field offset: 0x4
		public int PacketDelayMs; //Field offset: 0x8
		public int PacketJitterMs; //Field offset: 0xC
		public int PacketDrop; //Field offset: 0x10
		public int FuzzOffset; //Field offset: 0x14
		public int FuzzFactor; //Field offset: 0x18
		public uint RandomSeed; //Field offset: 0x1C
		public Random Random; //Field offset: 0x20
		public int PacketCount; //Field offset: 0x24
		public int PacketDropCount; //Field offset: 0x28
		public int ReadyPackets; //Field offset: 0x2C
		public int WaitingPackets; //Field offset: 0x30
		public long NextPacketTime; //Field offset: 0x38
		public long StatsTime; //Field offset: 0x40

	}

	internal struct DelayedPacket
	{
		public int processBufferOffset; //Field offset: 0x0
		public ushort packetSize; //Field offset: 0x4
		public ushort packetHeaderPadding; //Field offset: 0x6
		public long delayUntil; //Field offset: 0x8

	}

	internal struct Parameters : INetworkParameter
	{
		public int MaxPacketCount; //Field offset: 0x0
		public int MaxPacketSize; //Field offset: 0x4
		public int PacketDelayMs; //Field offset: 0x8
		public int PacketJitterMs; //Field offset: 0xC
		public int PacketDropInterval; //Field offset: 0x10
		public int PacketDropPercentage; //Field offset: 0x14
		public int FuzzFactor; //Field offset: 0x18
		public int FuzzOffset; //Field offset: 0x1C
		public uint RandomSeed; //Field offset: 0x20

		public override bool Validate() { }

	}

	private int m_PacketCount; //Field offset: 0x0
	private int m_MaxPacketSize; //Field offset: 0x4
	private int m_PacketDelayMs; //Field offset: 0x8
	private int m_PacketJitterMs; //Field offset: 0xC

	public SimulatorUtility(int packetCount, int maxPacketSize, int packetDelayMs, int packetJitterMs) { }

	public bool DelayPacket(ref NetworkPipelineContext ctx, InboundSendBuffer inboundBuffer, ref Requests requests, long timestamp) { }

	public void FuzzPacket(Context* ctx, ref InboundSendBuffer inboundBuffer) { }

	public bool GetDelayedPacket(ref NetworkPipelineContext ctx, ref InboundSendBuffer delayedPacket, ref Requests requests, long currentTimestamp) { }

	public bool GetEmptyDataSlot(Byte* processBufferPtr, ref int packetPayloadOffset, ref int packetDataOffset) { }

	public static void InitializeContext(Parameters param, Byte* sharedProcessBuffer) { }

	public bool ShouldDropPacket(Context* ctx, Parameters param, long timestamp) { }

}

