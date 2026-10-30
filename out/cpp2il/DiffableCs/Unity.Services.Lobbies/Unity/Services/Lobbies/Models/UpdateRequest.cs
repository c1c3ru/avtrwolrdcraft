namespace Unity.Services.Lobbies.Models;

[DataContract(Name = "UpdateRequest")]
[Preserve]
public class UpdateRequest
{
	[CompilerGenerated]
	private readonly string <Name>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly Nullable<Int32> <MaxPlayers>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private readonly Nullable<Boolean> <IsPrivate>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private readonly Nullable<Boolean> <IsLocked>k__BackingField; //Field offset: 0x22
	[CompilerGenerated]
	private readonly string <Password>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private readonly JsonObject <Data>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private readonly string <HostId>k__BackingField; //Field offset: 0x38

	[DataMember(Name = "data", EmitDefaultValue = False)]
	[JsonConverter(typeof(JsonObjectCollectionConverter))]
	[Preserve]
	public JsonObject Data
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "hostId", EmitDefaultValue = False)]
	[Preserve]
	public string HostId
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "isLocked", EmitDefaultValue = True)]
	[Preserve]
	public Nullable<Boolean> IsLocked
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "isPrivate", EmitDefaultValue = True)]
	[Preserve]
	public Nullable<Boolean> IsPrivate
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "maxPlayers", EmitDefaultValue = False)]
	[Preserve]
	public Nullable<Int32> MaxPlayers
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "name", EmitDefaultValue = False)]
	[Preserve]
	public string Name
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "password", EmitDefaultValue = False)]
	[Preserve]
	public string Password
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public UpdateRequest(string name = null, Nullable<Int32> maxPlayers = null, Nullable<Boolean> isPrivate = null, Nullable<Boolean> isLocked = null, Dictionary<String, DataObject> data = null, string hostId = null, string password = null) { }

	[CompilerGenerated]
	public JsonObject get_Data() { }

	[CompilerGenerated]
	public string get_HostId() { }

	[CompilerGenerated]
	public Nullable<Boolean> get_IsLocked() { }

	[CompilerGenerated]
	public Nullable<Boolean> get_IsPrivate() { }

	[CompilerGenerated]
	public Nullable<Int32> get_MaxPlayers() { }

	[CompilerGenerated]
	public string get_Name() { }

	[CompilerGenerated]
	public string get_Password() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

