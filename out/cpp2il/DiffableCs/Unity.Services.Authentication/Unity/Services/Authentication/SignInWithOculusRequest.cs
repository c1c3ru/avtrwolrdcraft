namespace Unity.Services.Authentication;

internal class SignInWithOculusRequest : SignInWithExternalTokenRequest
{
	[JsonProperty("oculusConfig")]
	public OculusConfig OculusConfig; //Field offset: 0x28

	[Preserve]
	internal SignInWithOculusRequest() { }

}

