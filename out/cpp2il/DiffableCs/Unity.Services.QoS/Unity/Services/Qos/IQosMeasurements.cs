namespace Unity.Services.Qos;

public interface IQosMeasurements
{

	public int AverageLatencyMs
	{
		 get { } //Length: 0
	}

	public float PacketLossPercent
	{
		 get { } //Length: 0
	}

	public int get_AverageLatencyMs() { }

	public float get_PacketLossPercent() { }

}

