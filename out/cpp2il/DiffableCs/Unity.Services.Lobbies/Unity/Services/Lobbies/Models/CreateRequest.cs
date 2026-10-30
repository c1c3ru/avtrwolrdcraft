namespace Unity.Services.Lobbies.Models;

[DataContract(Name = "CreateRequest")]
[Preserve]
public class CreateRequest
{
	[CompilerGenerated]
	private readonly string <Name>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly int <MaxPlayers>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private readonly Nullable<Boolean> <IsPrivate>k__BackingField; //Field offset: 0x1C
	[CompilerGenerated]
	private readonly Nullable<Boolean> <IsLocked>k__BackingField; //Field offset: 0x1E
	[CompilerGenerated]
	private readonly Player <Player>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private readonly string <Password>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private readonly Dictionary<String, DataObject> <Data>k__BackingField; //Field offset: 0x30

	[DataMember(Name = "data", EmitDefaultValue = False)]
	[Preserve]
	public Dictionary<String, DataObject> Data
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

	[DataMember(Name = "maxPlayers", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public int MaxPlayers
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "name", IsRequired = True, EmitDefaultValue = True)]
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

	[DataMember(Name = "player", EmitDefaultValue = False)]
	[Preserve]
	public Player Player
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public CreateRequest(string name, int maxPlayers, Nullable<Boolean> isPrivate = null, Nullable<Boolean> isLocked = null, Player player = null, Dictionary<String, DataObject> data = null, string password = null) { }

	[CompilerGenerated]
	public Dictionary<String, DataObject> get_Data() { }

	[CompilerGenerated]
	public Nullable<Boolean> get_IsLocked() { }

	[CompilerGenerated]
	public Nullable<Boolean> get_IsPrivate() { }

	[CompilerGenerated]
	public int get_MaxPlayers() { }

	[CompilerGenerated]
	public string get_Name() { }

	[CompilerGenerated]
	public string get_Password() { }

	[CompilerGenerated]
	public Player get_Player() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

