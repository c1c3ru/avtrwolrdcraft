namespace Unity.Services.Authentication.PlayerAccounts;

internal class PlayerAccountsErrorResponse
{
	[JsonProperty("error")]
	public string Error; //Field offset: 0x10
	[JsonProperty("error_description")]
	public string Description; //Field offset: 0x18

	[Preserve]
	public PlayerAccountsErrorResponse() { }

}

