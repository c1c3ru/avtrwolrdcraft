namespace Unity.Networking.Transport.Relay;

[Extension]
public static class RelayParameterExtensions
{

	[Extension]
	public static RelayNetworkParameter GetRelayParameters(ref NetworkSettings settings) { }

	[Extension]
	public static NetworkSettings WithRelayParameters(ref NetworkSettings settings, ref RelayServerData serverData, int relayConnectionTimeMS = 3000) { }

}

