namespace Unity.Networking.Transport;

internal interface INetworkProtocol : IDisposable
{

	public int Bind(INetworkInterface networkInterface, ref NetworkInterfaceEndPoint localEndPoint) { }

	public int CreateConnectionAddress(INetworkInterface networkInterface, NetworkEndPoint endPoint, out NetworkInterfaceEndPoint address) { }

	public NetworkProtocol CreateProtocolInterface() { }

	public NetworkEndPoint GetRemoteEndPoint(INetworkInterface networkInterface, NetworkInterfaceEndPoint address) { }

	public void Initialize(NetworkSettings settings) { }

}

