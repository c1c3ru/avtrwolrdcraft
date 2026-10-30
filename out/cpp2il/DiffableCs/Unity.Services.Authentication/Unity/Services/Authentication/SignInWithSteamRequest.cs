namespace Unity.Services.Authentication;

internal class SignInWithSteamRequest : SignInWithExternalTokenRequest
{
	[JsonProperty("steamConfig")]
	public SteamConfig SteamConfig; //Field offset: 0x28

	[Preserve]
	internal SignInWithSteamRequest() { }

}

