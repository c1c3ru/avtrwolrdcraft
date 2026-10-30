namespace Unity.Services.Authentication;

internal class ExternalIdentity
{
	[JsonProperty("providerId")]
	public string ProviderId; //Field offset: 0x10
	[JsonProperty("externalId")]
	public string ExternalId; //Field offset: 0x18

	[Preserve]
	public ExternalIdentity() { }

}

