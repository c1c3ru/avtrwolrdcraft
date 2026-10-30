namespace Unity.Services.Authentication;

internal class SignInWithAppleGameCenterRequest : SignInWithExternalTokenRequest
{
	[JsonProperty("appleGameCenterConfig")]
	public AppleGameCenterConfig AppleGameCenterConfig; //Field offset: 0x28

	[Preserve]
	internal SignInWithAppleGameCenterRequest() { }

}

