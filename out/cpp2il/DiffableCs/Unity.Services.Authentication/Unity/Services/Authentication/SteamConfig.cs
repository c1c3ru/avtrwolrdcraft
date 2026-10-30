namespace Unity.Services.Authentication;

internal class SteamConfig
{
	[JsonProperty("identity")]
	public string identity; //Field offset: 0x10
	[CanBeNull]
	[JsonProperty("appId")]
	public string appId; //Field offset: 0x18

	[Preserve]
	internal SteamConfig() { }

}

