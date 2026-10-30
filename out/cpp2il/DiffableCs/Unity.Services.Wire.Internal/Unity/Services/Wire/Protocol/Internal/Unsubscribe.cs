namespace Unity.Services.Wire.Protocol.Internal;

[JsonObject(ItemNullValueHandling = NullValueHandling::Ignore (1))]
internal class Unsubscribe
{
	public uint code; //Field offset: 0x10
	public string reason; //Field offset: 0x18

	[Preserve]
	public Unsubscribe() { }

}

