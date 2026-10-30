namespace Unity.Services.Qos;

internal class QosResult : IQosAnnotatedResult, IQosResult
{
	[CompilerGenerated]
	private readonly string <Region>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly int <AverageLatencyMs>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private readonly float <PacketLossPercent>k__BackingField; //Field offset: 0x1C
	[CompilerGenerated]
	private readonly Dictionary<String, List`1<String>> <Annotations>k__BackingField; //Field offset: 0x20

	public override Dictionary<String, List`1<String>> Annotations
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public override int AverageLatencyMs
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public override float PacketLossPercent
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public override string Region
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public QosResult(string region, int averageLatencyMs, float packetLossPercent, Dictionary<String, List`1<String>> annotations = null) { }

	[CompilerGenerated]
	public override Dictionary<String, List`1<String>> get_Annotations() { }

	[CompilerGenerated]
	public override int get_AverageLatencyMs() { }

	[CompilerGenerated]
	public override float get_PacketLossPercent() { }

	[CompilerGenerated]
	public override string get_Region() { }

}

