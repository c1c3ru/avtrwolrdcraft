namespace Unity.Services.Lobbies.Models;

[DataContract(Name = "PlayerUpdateRequest")]
[Preserve]
public class PlayerUpdateRequest
{
	[CompilerGenerated]
	private readonly string <ConnectionInfo>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly JsonObject <Data>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private readonly string <AllocationId>k__BackingField; //Field offset: 0x20

	[DataMember(Name = "allocationId", EmitDefaultValue = False)]
	[Preserve]
	public string AllocationId
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "connectionInfo", EmitDefaultValue = False)]
	[Preserve]
	public string ConnectionInfo
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "data", EmitDefaultValue = False)]
	[JsonConverter(typeof(JsonObjectCollectionConverter))]
	[Preserve]
	public JsonObject Data
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public PlayerUpdateRequest(string connectionInfo = null, Dictionary<String, PlayerDataObject> data = null, string allocationId = null) { }

	[CompilerGenerated]
	public string get_AllocationId() { }

	[CompilerGenerated]
	public string get_ConnectionInfo() { }

	[CompilerGenerated]
	public JsonObject get_Data() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

