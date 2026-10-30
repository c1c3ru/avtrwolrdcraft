namespace Unity.Networking.Transport.Relay;

public struct RelayNetworkParameter : INetworkParameter
{
	internal const int k_DefaultConnectionTimeMS = 3000; //Field offset: 0x0
	public RelayServerData ServerData; //Field offset: 0x0
	public int RelayConnectionTimeMS; //Field offset: 0x28C

	public override bool Validate() { }

}

