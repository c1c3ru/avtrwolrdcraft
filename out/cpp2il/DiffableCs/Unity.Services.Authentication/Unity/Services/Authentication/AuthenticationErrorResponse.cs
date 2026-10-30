namespace Unity.Services.Authentication;

internal class AuthenticationErrorResponse
{
	[JsonProperty("title")]
	public string Title; //Field offset: 0x10
	[JsonProperty("detail")]
	public string Detail; //Field offset: 0x18
	[JsonProperty("status")]
	public int Status; //Field offset: 0x20
	[JsonProperty("details")]
	public List<Object> Details; //Field offset: 0x28

	[Preserve]
	public AuthenticationErrorResponse() { }

}

