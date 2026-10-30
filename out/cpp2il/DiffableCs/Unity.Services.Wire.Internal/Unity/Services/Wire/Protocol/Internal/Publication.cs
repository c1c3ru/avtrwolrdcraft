namespace Unity.Services.Wire.Protocol.Internal;

[JsonObject(ItemNullValueHandling = NullValueHandling::Ignore (1))]
internal class Publication
{
	public WireMessage data; //Field offset: 0x10
	public ClientInfo info; //Field offset: 0x18
	public ulong offset; //Field offset: 0x20
	public Dictionary<String, String> tags; //Field offset: 0x28

	[Preserve]
	public Publication() { }

}

