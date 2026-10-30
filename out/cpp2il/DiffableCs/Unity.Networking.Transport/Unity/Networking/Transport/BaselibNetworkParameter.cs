namespace Unity.Networking.Transport;

public struct BaselibNetworkParameter : INetworkParameter
{
	public int receiveQueueCapacity; //Field offset: 0x0
	public int sendQueueCapacity; //Field offset: 0x4
	public uint maximumPayloadSize; //Field offset: 0x8

	public override bool Validate() { }

}

