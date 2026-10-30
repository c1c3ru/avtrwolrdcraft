namespace Unity.Services.Authentication;

internal class UnlinkRequest
{
	[JsonProperty("idProvider")]
	public string IdProvider; //Field offset: 0x10
	[JsonProperty("externalId")]
	public string ExternalId; //Field offset: 0x18

	[Preserve]
	internal UnlinkRequest() { }

}

