namespace Unity.Services.Wire.Internal;

internal class Configuration
{
	public IAccessToken token; //Field offset: 0x10
	public string address; //Field offset: 0x18
	public double CommandTimeoutInSeconds; //Field offset: 0x20
	public double RetrieveTokenTimeoutInSeconds; //Field offset: 0x28
	public IWebSocket WebSocket; //Field offset: 0x30
	public INetworkUtil NetworkUtil; //Field offset: 0x38
	public double MaxServerPingDelay; //Field offset: 0x40

	public Configuration() { }

}

