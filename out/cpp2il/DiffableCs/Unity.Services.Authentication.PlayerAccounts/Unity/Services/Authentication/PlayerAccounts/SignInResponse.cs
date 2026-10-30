namespace Unity.Services.Authentication.PlayerAccounts;

internal class SignInResponse
{
	[JsonProperty("passport")]
	public string PassportId; //Field offset: 0x10
	[JsonProperty("userId")]
	public string UserId; //Field offset: 0x18
	[JsonProperty("access_token")]
	public string AccessToken; //Field offset: 0x20
	[JsonProperty("id_token")]
	public string IdToken; //Field offset: 0x28
	[JsonProperty("token_type")]
	public string tokenType; //Field offset: 0x30
	[JsonProperty("expires_in")]
	public int ExpiresIn; //Field offset: 0x38
	[JsonProperty("refresh_token")]
	public string RefreshToken; //Field offset: 0x40

	[Preserve]
	public SignInResponse() { }

}

