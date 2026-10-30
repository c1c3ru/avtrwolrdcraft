namespace Unity.Services.Authentication;

internal class AppleGameCenterConfig
{
	[JsonProperty("teamPlayerId")]
	public string TeamPlayerId; //Field offset: 0x10
	[JsonProperty("publicKeyUrl")]
	public string PublicKeyURL; //Field offset: 0x18
	[JsonProperty("salt")]
	public string Salt; //Field offset: 0x20
	[JsonProperty("timestamp")]
	public ulong Timestamp; //Field offset: 0x28

	[Preserve]
	internal AppleGameCenterConfig() { }

}

