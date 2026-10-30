namespace Unity.Services.Authentication;

internal class User
{
	[JsonProperty("id")]
	public string Id; //Field offset: 0x10
	[JsonProperty("createdAt")]
	public string CreatedAt; //Field offset: 0x18
	[JsonProperty("externalIds")]
	public List<ExternalIdentity> ExternalIds; //Field offset: 0x20
	[CanBeNull]
	[JsonProperty("username")]
	public string Username; //Field offset: 0x28
	[CanBeNull]
	[JsonProperty("UsernameInfo")]
	public UsernameInfo UsernameInfo; //Field offset: 0x30

	[Preserve]
	public User() { }

}

