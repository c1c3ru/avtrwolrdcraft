namespace Unity.Services.Authentication;

internal class UsernamePasswordRequest
{
	[JsonProperty("username")]
	public string Username; //Field offset: 0x10
	[JsonProperty("password")]
	public string Password; //Field offset: 0x18

	[Preserve]
	internal UsernamePasswordRequest() { }

}

