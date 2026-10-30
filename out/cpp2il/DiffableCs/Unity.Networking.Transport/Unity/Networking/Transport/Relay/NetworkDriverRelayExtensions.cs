namespace Unity.Networking.Transport.Relay;

[Extension]
public static class NetworkDriverRelayExtensions
{

	[Extension]
	public static NetworkConnection Connect(NetworkDriver driver) { }

	[Extension]
	public static RelayConnectionStatus GetRelayConnectionStatus(NetworkDriver driver) { }

}

