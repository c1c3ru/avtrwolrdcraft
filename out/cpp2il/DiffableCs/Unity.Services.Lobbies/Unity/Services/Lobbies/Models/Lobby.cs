namespace Unity.Services.Lobbies.Models;

[DataContract(Name = "Lobby")]
[Preserve]
public class Lobby
{
	[CompilerGenerated]
	private string <Id>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private string <LobbyCode>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private string <Upid>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private string <EnvironmentId>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private string <Name>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private int <MaxPlayers>k__BackingField; //Field offset: 0x38
	[CompilerGenerated]
	private int <AvailableSlots>k__BackingField; //Field offset: 0x3C
	[CompilerGenerated]
	private bool <IsPrivate>k__BackingField; //Field offset: 0x40
	[CompilerGenerated]
	private bool <IsLocked>k__BackingField; //Field offset: 0x41
	[CompilerGenerated]
	private bool <HasPassword>k__BackingField; //Field offset: 0x42
	[CompilerGenerated]
	private List<Player> <Players>k__BackingField; //Field offset: 0x48
	[CompilerGenerated]
	private Dictionary<String, DataObject> <Data>k__BackingField; //Field offset: 0x50
	[CompilerGenerated]
	private string <HostId>k__BackingField; //Field offset: 0x58
	[CompilerGenerated]
	private DateTime <Created>k__BackingField; //Field offset: 0x60
	[CompilerGenerated]
	private DateTime <LastUpdated>k__BackingField; //Field offset: 0x68
	[CompilerGenerated]
	private int <Version>k__BackingField; //Field offset: 0x70

	[DataMember(Name = "availableSlots", EmitDefaultValue = False)]
	[Preserve]
	public internal int AvailableSlots
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	[DataMember(Name = "created", EmitDefaultValue = False)]
	[Preserve]
	public internal DateTime Created
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	[DataMember(Name = "data", EmitDefaultValue = False)]
	[Preserve]
	public internal Dictionary<String, DataObject> Data
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	[DataMember(Name = "environmentId", EmitDefaultValue = False)]
	[Preserve]
	public internal string EnvironmentId
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	[DataMember(Name = "hasPassword", EmitDefaultValue = True)]
	[Preserve]
	public internal bool HasPassword
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 12
	}

	[DataMember(Name = "hostId", EmitDefaultValue = False)]
	[Preserve]
	public internal string HostId
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
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

	[DataMember(Name = "isLocked", EmitDefaultValue = True)]
	[Preserve]
	public internal bool IsLocked
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 12
	}

	[DataMember(Name = "isPrivate", EmitDefaultValue = True)]
	[Preserve]
	public internal bool IsPrivate
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 12
	}

	[DataMember(Name = "lastUpdated", EmitDefaultValue = False)]
	[Preserve]
	public internal DateTime LastUpdated
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	[DataMember(Name = "lobbyCode", EmitDefaultValue = False)]
	[Preserve]
	public internal string LobbyCode
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	[DataMember(Name = "maxPlayers", EmitDefaultValue = False)]
	[Preserve]
	public internal int MaxPlayers
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	[DataMember(Name = "name", EmitDefaultValue = False)]
	[Preserve]
	public internal string Name
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	[DataMember(Name = "players", EmitDefaultValue = False)]
	[Preserve]
	public internal List<Player> Players
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	[DataMember(Name = "upid", EmitDefaultValue = False)]
	[Preserve]
	public internal string Upid
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	[DataMember(Name = "version", EmitDefaultValue = False)]
	[Preserve]
	public int Version
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	[Preserve]
	public Lobby(string id = null, string lobbyCode = null, string upid = null, string environmentId = null, string name = null, int maxPlayers = 0, int availableSlots = 0, bool isPrivate = false, bool isLocked = false, List<Player> players = null, Dictionary<String, DataObject> data = null, string hostId = null, DateTime created = null, DateTime lastUpdated = null, int version = 0, bool hasPassword = false) { }

	[CompilerGenerated]
	public int get_AvailableSlots() { }

	[CompilerGenerated]
	public DateTime get_Created() { }

	[CompilerGenerated]
	public Dictionary<String, DataObject> get_Data() { }

	[CompilerGenerated]
	public string get_EnvironmentId() { }

	[CompilerGenerated]
	public bool get_HasPassword() { }

	[CompilerGenerated]
	public string get_HostId() { }

	[CompilerGenerated]
	public string get_Id() { }

	[CompilerGenerated]
	public bool get_IsLocked() { }

	[CompilerGenerated]
	public bool get_IsPrivate() { }

	[CompilerGenerated]
	public DateTime get_LastUpdated() { }

	[CompilerGenerated]
	public string get_LobbyCode() { }

	[CompilerGenerated]
	public int get_MaxPlayers() { }

	[CompilerGenerated]
	public string get_Name() { }

	[CompilerGenerated]
	public List<Player> get_Players() { }

	[CompilerGenerated]
	public string get_Upid() { }

	[CompilerGenerated]
	public int get_Version() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

	[CompilerGenerated]
	internal void set_AvailableSlots(int value) { }

	[CompilerGenerated]
	internal void set_Created(DateTime value) { }

	[CompilerGenerated]
	internal void set_Data(Dictionary<String, DataObject> value) { }

	[CompilerGenerated]
	internal void set_EnvironmentId(string value) { }

	[CompilerGenerated]
	internal void set_HasPassword(bool value) { }

	[CompilerGenerated]
	internal void set_HostId(string value) { }

	[CompilerGenerated]
	internal void set_Id(string value) { }

	[CompilerGenerated]
	internal void set_IsLocked(bool value) { }

	[CompilerGenerated]
	internal void set_IsPrivate(bool value) { }

	[CompilerGenerated]
	internal void set_LastUpdated(DateTime value) { }

	[CompilerGenerated]
	internal void set_LobbyCode(string value) { }

	[CompilerGenerated]
	internal void set_MaxPlayers(int value) { }

	[CompilerGenerated]
	internal void set_Name(string value) { }

	[CompilerGenerated]
	internal void set_Players(List<Player> value) { }

	[CompilerGenerated]
	internal void set_Upid(string value) { }

	[CompilerGenerated]
	public void set_Version(int value) { }

}

