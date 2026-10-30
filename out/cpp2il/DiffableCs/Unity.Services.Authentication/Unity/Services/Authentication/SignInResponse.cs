namespace Unity.Services.Authentication;

internal class SignInResponse
{
	[JsonProperty("userId")]
	public string UserId; //Field offset: 0x10
	[JsonProperty("idToken")]
	public string IdToken; //Field offset: 0x18
	[JsonProperty("sessionToken")]
	public string SessionToken; //Field offset: 0x20
	[JsonProperty("expiresIn")]
	public int ExpiresIn; //Field offset: 0x28
	[JsonProperty("user")]
	public User User; //Field offset: 0x30
	[CanBeNull]
	[JsonProperty("lastNotificationDate")]
	public string LastNotificationDate; //Field offset: 0x38

	[Preserve]
	public SignInResponse() { }

}

