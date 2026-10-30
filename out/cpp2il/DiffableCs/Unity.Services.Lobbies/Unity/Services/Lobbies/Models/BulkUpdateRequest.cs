namespace Unity.Services.Lobbies.Models;

[DataContract(Name = "BulkUpdateRequest")]
[Preserve]
internal class BulkUpdateRequest
{
	[CompilerGenerated]
	private readonly UpdateRequest <LobbyUpdate>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly Dictionary<String, PlayerUpdateRequest> <PlayerUpdates>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private readonly List<Player> <PlayersToAdd>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private readonly List<String> <PlayersToRemove>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private readonly Nullable<Boolean> <IgnoreIneffectualUpdates>k__BackingField; //Field offset: 0x30

	[DataMember(Name = "ignoreIneffectualUpdates", EmitDefaultValue = True)]
	[Preserve]
	public Nullable<Boolean> IgnoreIneffectualUpdates
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "lobbyUpdate", EmitDefaultValue = False)]
	[JsonConverter(typeof(JsonObjectConverter))]
	[Preserve]
	public UpdateRequest LobbyUpdate
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "playersToAdd", EmitDefaultValue = False)]
	[Preserve]
	public List<Player> PlayersToAdd
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "playersToRemove", EmitDefaultValue = False)]
	[Preserve]
	public List<String> PlayersToRemove
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "playerUpdates", EmitDefaultValue = False)]
	[JsonConverter(typeof(JsonObjectCollectionConverter))]
	[Preserve]
	public Dictionary<String, PlayerUpdateRequest> PlayerUpdates
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public BulkUpdateRequest(UpdateRequest lobbyUpdate = null, Dictionary<String, PlayerUpdateRequest> playerUpdates = null, List<Player> playersToAdd = null, List<String> playersToRemove = null, Nullable<Boolean> ignoreIneffectualUpdates = null) { }

	[CompilerGenerated]
	public Nullable<Boolean> get_IgnoreIneffectualUpdates() { }

	[CompilerGenerated]
	public UpdateRequest get_LobbyUpdate() { }

	[CompilerGenerated]
	public List<Player> get_PlayersToAdd() { }

	[CompilerGenerated]
	public List<String> get_PlayersToRemove() { }

	[CompilerGenerated]
	public Dictionary<String, PlayerUpdateRequest> get_PlayerUpdates() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

