namespace Unity.Services.Wire.Protocol.Internal;

[JsonObject(ItemNullValueHandling = NullValueHandling::Ignore (1))]
internal class ConnectResult
{
	public string client; //Field offset: 0x10
	public string version; //Field offset: 0x18
	public bool expires; //Field offset: 0x20
	public uint ttl; //Field offset: 0x24
	public string data; //Field offset: 0x28
	public uint ping; //Field offset: 0x30
	public bool pong; //Field offset: 0x34
	public Dictionary<String, SubscribeResult> subs; //Field offset: 0x38

	[Preserve]
	public ConnectResult() { }

}

