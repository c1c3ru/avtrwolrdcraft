namespace Unity.Services.Authentication;

internal class GenerateCodeResponse
{
	[JsonProperty("codeLinkSessionId")]
	public string CodeLinkSessionId; //Field offset: 0x10
	[JsonProperty("signInCode")]
	public string SignInCode; //Field offset: 0x18
	[JsonProperty("expiration")]
	public string Expiration; //Field offset: 0x20

	[Preserve]
	public GenerateCodeResponse() { }

}

