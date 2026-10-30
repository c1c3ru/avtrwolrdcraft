namespace Unity.Services.Authentication;

internal class NotificationResponse
{
	[JsonProperty("id")]
	public string Id; //Field offset: 0x10
	[JsonProperty("caseID")]
	public string CaseId; //Field offset: 0x18
	[JsonProperty("message")]
	public string Message; //Field offset: 0x20
	[JsonProperty("playerId")]
	public string PlayerId; //Field offset: 0x28
	[JsonProperty("projectId")]
	public string ProjectId; //Field offset: 0x30
	[JsonProperty("type")]
	public string Type; //Field offset: 0x38
	[JsonProperty("createdAt")]
	public string CreatedAt; //Field offset: 0x40

	[Preserve]
	public NotificationResponse() { }

}

