namespace Unity.Services.Authentication;

internal class AccessToken : BaseJwt
{
	[JsonProperty("aud")]
	public String[] Audience; //Field offset: 0x20
	[JsonProperty("client_id")]
	public string ClientId; //Field offset: 0x28
	[JsonProperty("ext")]
	public AccessTokenExtraClaims Extra; //Field offset: 0x30
	[JsonProperty("iat")]
	public long IssuedAt; //Field offset: 0x38
	[JsonProperty("iss")]
	public string Issuer; //Field offset: 0x40
	[JsonProperty("jti")]
	public string JwtId; //Field offset: 0x48
	[JsonProperty("project_id")]
	public string ProjectId; //Field offset: 0x50
	[JsonProperty("scp")]
	public String[] Scope; //Field offset: 0x58
	[JsonProperty("sub")]
	public string Subject; //Field offset: 0x60
	[JsonProperty("sign_in_provider")]
	public string SignInProvider; //Field offset: 0x68
	[JsonProperty("exp")]
	public long Expiration; //Field offset: 0x70

	[Preserve]
	public AccessToken() { }

}

