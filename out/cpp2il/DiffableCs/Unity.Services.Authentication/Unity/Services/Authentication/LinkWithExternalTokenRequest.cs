namespace Unity.Services.Authentication;

internal class LinkWithExternalTokenRequest
{
	[JsonProperty("idProvider")]
	public string IdProvider; //Field offset: 0x10
	[JsonProperty("token")]
	public string Token; //Field offset: 0x18
	[JsonProperty("forceLink")]
	public bool ForceLink; //Field offset: 0x20

	[Preserve]
	internal LinkWithExternalTokenRequest() { }

}

