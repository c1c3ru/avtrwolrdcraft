namespace Unity.Services.Authentication;

internal class PlayerInfoResponse
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
	[JsonProperty("usernamepassword")]
	public UsernameInfo UsernamePassword; //Field offset: 0x30

	[Preserve]
	public PlayerInfoResponse() { }

}

