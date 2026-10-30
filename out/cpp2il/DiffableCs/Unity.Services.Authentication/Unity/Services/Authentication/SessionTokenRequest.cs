namespace Unity.Services.Authentication;

internal class SessionTokenRequest
{
	[JsonProperty("sessionToken")]
	public string SessionToken; //Field offset: 0x10

	[Preserve]
	public SessionTokenRequest() { }

}

