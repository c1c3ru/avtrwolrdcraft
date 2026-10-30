namespace Unity.Services.Qos;

public interface IQosResult
{

	public int AverageLatencyMs
	{
		 get { } //Length: 0
	}

	public float PacketLossPercent
	{
		 get { } //Length: 0
	}

	public string Region
	{
		 get { } //Length: 0
	}

	public int get_AverageLatencyMs() { }

	public float get_PacketLossPercent() { }

	public string get_Region() { }

}

