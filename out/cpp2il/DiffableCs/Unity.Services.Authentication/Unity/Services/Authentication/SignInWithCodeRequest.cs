namespace Unity.Services.Authentication;

internal class SignInWithCodeRequest
{
	[JsonProperty("codeLinkSessionId")]
	public string CodeLinkSessionId; //Field offset: 0x10
	[JsonProperty("codeVerifier")]
	public string CodeVerifier; //Field offset: 0x18

	public SignInWithCodeRequest() { }

}

