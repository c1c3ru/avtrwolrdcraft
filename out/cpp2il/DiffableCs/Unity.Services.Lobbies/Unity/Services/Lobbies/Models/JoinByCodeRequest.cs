namespace Unity.Services.Lobbies.Models;

[DataContract(Name = "JoinByCodeRequest")]
[Preserve]
public class JoinByCodeRequest
{
	[CompilerGenerated]
	private readonly string <LobbyCode>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly string <Password>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private readonly Player <Player>k__BackingField; //Field offset: 0x20

	[DataMember(Name = "lobbyCode", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public string LobbyCode
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
	public JoinByCodeRequest(string lobbyCode, Player player = null, string password = null) { }

	[CompilerGenerated]
	public string get_LobbyCode() { }

	[CompilerGenerated]
	public string get_Password() { }

	[CompilerGenerated]
	public Player get_Player() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

