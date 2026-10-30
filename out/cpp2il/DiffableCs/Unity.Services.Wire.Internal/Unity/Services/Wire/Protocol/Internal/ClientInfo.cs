namespace Unity.Services.Wire.Protocol.Internal;

[JsonObject(ItemNullValueHandling = NullValueHandling::Ignore (1))]
internal class ClientInfo
{
	public string user; //Field offset: 0x10
	public string client; //Field offset: 0x18
	public Byte[] conn_info; //Field offset: 0x20
	public Byte[] chan_info; //Field offset: 0x28

	[Preserve]
	public ClientInfo() { }

}

