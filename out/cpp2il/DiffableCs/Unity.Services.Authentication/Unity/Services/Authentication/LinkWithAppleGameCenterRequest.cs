namespace Unity.Services.Authentication;

internal class LinkWithAppleGameCenterRequest : LinkWithExternalTokenRequest
{
	[JsonProperty("appleGameCenterConfig")]
	public AppleGameCenterConfig AppleGameCenterConfig; //Field offset: 0x28

	[Preserve]
	internal LinkWithAppleGameCenterRequest() { }

}

