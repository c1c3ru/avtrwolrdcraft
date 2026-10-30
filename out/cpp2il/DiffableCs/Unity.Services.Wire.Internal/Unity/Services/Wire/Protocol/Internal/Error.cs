namespace Unity.Services.Wire.Protocol.Internal;

[JsonObject(ItemNullValueHandling = NullValueHandling::Ignore (1))]
internal class Error
{
	public CentrifugeErrorCode code; //Field offset: 0x10
	public string message; //Field offset: 0x18

	[Preserve]
	public Error() { }

}

