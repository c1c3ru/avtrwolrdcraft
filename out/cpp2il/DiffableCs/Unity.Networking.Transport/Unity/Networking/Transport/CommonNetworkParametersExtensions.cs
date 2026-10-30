namespace Unity.Networking.Transport;

[Extension]
public static class CommonNetworkParametersExtensions
{

	[Extension]
	public static NetworkDataStreamParameter GetDataStreamParameters(ref NetworkSettings settings) { }

	[Extension]
	public static NetworkConfigParameter GetNetworkConfigParameters(ref NetworkSettings settings) { }

	[Extension]
	[Obsolete("In Unity Transport 2.0, the data stream size will always be dynamically-sized and this API will be removed.")]
	public static NetworkSettings WithDataStreamParameters(ref NetworkSettings settings, int size = 0) { }

	[Extension]
	public static NetworkSettings WithNetworkConfigParameters(ref NetworkSettings settings, int connectTimeoutMS = 1000, int maxConnectAttempts = 60, int disconnectTimeoutMS = 30000, int heartbeatTimeoutMS = 500, int maxFrameTimeMS = 0, int fixedFrameTimeMS = 0, int maxMessageSize = 1400) { }

	[Extension]
	public static NetworkSettings WithNetworkConfigParameters(ref NetworkSettings settings, int connectTimeoutMS, int maxConnectAttempts, int disconnectTimeoutMS, int heartbeatTimeoutMS, int maxFrameTimeMS, int fixedFrameTimeMS) { }

}

