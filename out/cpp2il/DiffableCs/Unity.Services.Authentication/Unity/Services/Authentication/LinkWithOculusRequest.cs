namespace Unity.Services.Authentication;

internal class LinkWithOculusRequest : LinkWithExternalTokenRequest
{
	[JsonProperty("oculusConfig")]
	public OculusConfig OculusConfig; //Field offset: 0x28

	[Preserve]
	internal LinkWithOculusRequest() { }

}

