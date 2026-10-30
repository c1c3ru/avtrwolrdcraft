namespace Unity.Services.Authentication;

internal class CodeLinkInfoResponse
{
	[JsonProperty("identifier")]
	public string Identifier; //Field offset: 0x10
	[JsonProperty("expiration")]
	public string Expiration; //Field offset: 0x18

	[Preserve]
	public CodeLinkInfoResponse() { }

}

