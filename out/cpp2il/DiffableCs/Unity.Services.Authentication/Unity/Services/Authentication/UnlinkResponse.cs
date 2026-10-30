namespace Unity.Services.Authentication;

internal class UnlinkResponse
{
	[JsonProperty("user")]
	public User User; //Field offset: 0x10

	[Preserve]
	public UnlinkResponse() { }

}

