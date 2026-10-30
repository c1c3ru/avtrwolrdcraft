namespace Unity.Services.Authentication;

internal class UpdatePasswordRequest
{
	[JsonProperty("password")]
	public string Password; //Field offset: 0x10
	[JsonProperty("newPassword")]
	public string NewPassword; //Field offset: 0x18

	[Preserve]
	internal UpdatePasswordRequest() { }

}

