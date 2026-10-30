namespace Unity.Services.Authentication;

internal class GenerateSignInCodeRequest
{
	[JsonProperty("identifier")]
	public string Identifier; //Field offset: 0x10
	[JsonProperty("codeChallenge")]
	public string CodeChallenge; //Field offset: 0x18

	public GenerateSignInCodeRequest() { }

}

