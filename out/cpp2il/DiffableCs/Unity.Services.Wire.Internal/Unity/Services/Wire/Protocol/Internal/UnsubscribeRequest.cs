namespace Unity.Services.Wire.Protocol.Internal;

[JsonObject(ItemNullValueHandling = NullValueHandling::Ignore (1))]
internal class UnsubscribeRequest
{
	public string channel; //Field offset: 0x10

	[Preserve]
	public UnsubscribeRequest() { }

}

