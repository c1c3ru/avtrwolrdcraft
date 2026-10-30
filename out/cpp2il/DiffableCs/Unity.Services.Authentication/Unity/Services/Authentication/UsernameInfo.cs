namespace Unity.Services.Authentication;

internal class UsernameInfo
{
	[JsonProperty("username")]
	public string Username; //Field offset: 0x10
	[JsonProperty("createdAt")]
	public string CreatedAt; //Field offset: 0x18
	[JsonProperty("lastLoginAt")]
	public string LastLoginAt; //Field offset: 0x20
	[JsonProperty("passwordUpdatedAt")]
	public string PasswordUpdatedAt; //Field offset: 0x28

	[Preserve]
	public UsernameInfo() { }

}

