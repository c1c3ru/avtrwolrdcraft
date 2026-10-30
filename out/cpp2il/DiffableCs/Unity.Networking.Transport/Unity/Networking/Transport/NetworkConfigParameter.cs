namespace Unity.Networking.Transport;

public struct NetworkConfigParameter : INetworkParameter
{
	public int connectTimeoutMS; //Field offset: 0x0
	public int maxConnectAttempts; //Field offset: 0x4
	public int disconnectTimeoutMS; //Field offset: 0x8
	public int heartbeatTimeoutMS; //Field offset: 0xC
	public int maxFrameTimeMS; //Field offset: 0x10
	public int fixedFrameTimeMS; //Field offset: 0x14
	public int maxMessageSize; //Field offset: 0x18

	public override bool Validate() { }

}

