namespace Unity.Services.Lobbies.Models;

[DataContract(Name = "Player")]
[Preserve]
public class Player
{
	[CompilerGenerated]
	private string <Id>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private PlayerProfile <Profile>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private string <ConnectionInfo>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private Dictionary<String, PlayerDataObject> <Data>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private string <AllocationId>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private DateTime <Joined>k__BackingField; //Field offset: 0x38
	[CompilerGenerated]
	private DateTime <LastUpdated>k__BackingField; //Field offset: 0x40

	[DataMember(Name = "allocationId", EmitDefaultValue = False)]
	[Preserve]
	public internal string AllocationId
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	[DataMember(Name = "connectionInfo", EmitDefaultValue = False)]
	[Preserve]
	public internal string ConnectionInfo
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	[DataMember(Name = "data", EmitDefaultValue = False)]
	[Preserve]
	public Dictionary<String, PlayerDataObject> Data
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	[DataMember(Name = "id", EmitDefaultValue = False)]
	[Preserve]
	public internal string Id
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	[DataMember(Name = "joined", EmitDefaultValue = False)]
	[Preserve]
	public DateTime Joined
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	[DataMember(Name = "lastUpdated", EmitDefaultValue = False)]
	[Preserve]
	public DateTime LastUpdated
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	[DataMember(Name = "profile", EmitDefaultValue = False)]
	[Preserve]
	public PlayerProfile Profile
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	[Preserve]
	public Player(string id = null, string connectionInfo = null, Dictionary<String, PlayerDataObject> data = null, string allocationId = null, DateTime joined = null, DateTime lastUpdated = null, PlayerProfile profile = null) { }

	[CompilerGenerated]
	public string get_AllocationId() { }

	[CompilerGenerated]
	public string get_ConnectionInfo() { }

	[CompilerGenerated]
	public Dictionary<String, PlayerDataObject> get_Data() { }

	[CompilerGenerated]
	public string get_Id() { }

	[CompilerGenerated]
	public DateTime get_Joined() { }

	[CompilerGenerated]
	public DateTime get_LastUpdated() { }

	[CompilerGenerated]
	public PlayerProfile get_Profile() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

	[CompilerGenerated]
	internal void set_AllocationId(string value) { }

	[CompilerGenerated]
	internal void set_ConnectionInfo(string value) { }

	[CompilerGenerated]
	public void set_Data(Dictionary<String, PlayerDataObject> value) { }

	[CompilerGenerated]
	internal void set_Id(string value) { }

	[CompilerGenerated]
	public void set_Joined(DateTime value) { }

	[CompilerGenerated]
	public void set_LastUpdated(DateTime value) { }

	[CompilerGenerated]
	public void set_Profile(PlayerProfile value) { }

}

