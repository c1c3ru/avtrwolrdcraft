namespace Unity.Services.Authentication;

internal class LinkResponse
{
	[JsonProperty("user")]
	public User User; //Field offset: 0x10

	[Preserve]
	public LinkResponse() { }

}

