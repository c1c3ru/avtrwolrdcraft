namespace Unity.Services.Lobbies.Models;

[DataContract(Name = "QuickJoinRequest")]
[Preserve]
public class QuickJoinRequest
{
	[CompilerGenerated]
	private readonly List<QueryFilter> <Filter>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly Player <Player>k__BackingField; //Field offset: 0x18

	[DataMember(Name = "filter", EmitDefaultValue = False)]
	[Preserve]
	public List<QueryFilter> Filter
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
	public QuickJoinRequest(List<QueryFilter> filter = null, Player player = null) { }

	[CompilerGenerated]
	public List<QueryFilter> get_Filter() { }

	[CompilerGenerated]
	public Player get_Player() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

