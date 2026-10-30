namespace Unity.Networking.QoS;

internal struct InternalQosResult
{
	internal const uint InvalidLatencyValue = 4294967295; //Field offset: 0x0
	internal const float InvalidPacketLossValue = 3,4028235E+38; //Field offset: 0x0
	internal uint RequestsSent; //Field offset: 0x0
	internal uint ResponsesReceived; //Field offset: 0x4
	internal uint InvalidRequests; //Field offset: 0x8
	internal uint InvalidResponses; //Field offset: 0xC
	internal uint DuplicateResponses; //Field offset: 0x10
	internal FcType FcType; //Field offset: 0x14
	internal byte FcUnits; //Field offset: 0x18
	internal uint AggregateLatencyMs; //Field offset: 0x1C

	internal uint AverageLatencyMs
	{
		internal get { } //Length: 28
	}

	internal float PacketLoss
	{
		internal get { } //Length: 56
	}

	internal void AddAggregateLatency(uint amountMs) { }

	internal uint get_AverageLatencyMs() { }

	internal float get_PacketLoss() { }

}

