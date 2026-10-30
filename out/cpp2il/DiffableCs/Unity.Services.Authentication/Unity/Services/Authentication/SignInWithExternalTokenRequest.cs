namespace Unity.Services.Authentication;

internal class SignInWithExternalTokenRequest
{
	[JsonProperty("idProvider")]
	public string IdProvider; //Field offset: 0x10
	[JsonProperty("token")]
	public string Token; //Field offset: 0x18
	[JsonProperty("signInOnly")]
	public bool SignInOnly; //Field offset: 0x20

	[Preserve]
	internal SignInWithExternalTokenRequest() { }

}

