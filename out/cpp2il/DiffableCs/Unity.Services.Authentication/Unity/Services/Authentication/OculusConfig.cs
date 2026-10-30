namespace Unity.Services.Authentication;

internal class OculusConfig
{
	[JsonProperty("userId")]
	public string UserId; //Field offset: 0x10

	[Preserve]
	internal OculusConfig() { }

}

