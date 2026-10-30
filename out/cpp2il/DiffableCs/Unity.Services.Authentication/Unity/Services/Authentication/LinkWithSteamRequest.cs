namespace Unity.Services.Authentication;

internal class LinkWithSteamRequest : LinkWithExternalTokenRequest
{
	[JsonProperty("steamConfig")]
	public SteamConfig SteamConfig; //Field offset: 0x28

	[Preserve]
	internal LinkWithSteamRequest() { }

}

