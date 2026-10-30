namespace Unity.Services.Lobbies.Models;

[DataContract(Name = "PlayerProfile")]
[Preserve]
public class PlayerProfile
{
	[CompilerGenerated]
	private readonly string <Name>k__BackingField; //Field offset: 0x10

	[DataMember(Name = "name", EmitDefaultValue = False)]
	[Preserve]
	public string Name
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public PlayerProfile(string name = null) { }

	[CompilerGenerated]
	public string get_Name() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

