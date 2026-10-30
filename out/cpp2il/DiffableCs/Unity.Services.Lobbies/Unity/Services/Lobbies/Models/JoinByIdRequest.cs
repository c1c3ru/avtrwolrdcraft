namespace Unity.Services.Lobbies.Models;

[DataContract(Name = "JoinByIdRequest")]
[Preserve]
public class JoinByIdRequest
{
	[CompilerGenerated]
	private readonly string <Password>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly Player <Player>k__BackingField; //Field offset: 0x18

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
	public JoinByIdRequest(string password = null, Player player = null) { }

	[CompilerGenerated]
	public string get_Password() { }

	[CompilerGenerated]
	public Player get_Player() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

