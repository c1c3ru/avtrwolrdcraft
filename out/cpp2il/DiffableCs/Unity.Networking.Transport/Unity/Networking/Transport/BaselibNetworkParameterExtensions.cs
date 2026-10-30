namespace Unity.Networking.Transport;

[Extension]
public static class BaselibNetworkParameterExtensions
{
	internal const int k_defaultRxQueueSize = 64; //Field offset: 0x0
	internal const int k_defaultTxQueueSize = 64; //Field offset: 0x0
	internal const uint k_defaultMaximumPayloadSize = 2000; //Field offset: 0x0

	[Extension]
	public static BaselibNetworkParameter GetBaselibNetworkInterfaceParameters(ref NetworkSettings settings) { }

	[Extension]
	public static NetworkSettings WithBaselibNetworkInterfaceParameters(ref NetworkSettings settings, int receiveQueueCapacity = 64, int sendQueueCapacity = 64, uint maximumPayloadSize = 2000) { }

}

