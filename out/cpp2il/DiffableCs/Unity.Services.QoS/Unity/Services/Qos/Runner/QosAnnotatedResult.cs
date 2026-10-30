namespace Unity.Services.Qos.Runner;

public struct QosAnnotatedResult
{
	public string Region; //Field offset: 0x0
	public int AverageLatencyMs; //Field offset: 0x8
	public float PacketLossPercent; //Field offset: 0xC
	public Dictionary<String, List`1<String>> Annotations; //Field offset: 0x10

}

