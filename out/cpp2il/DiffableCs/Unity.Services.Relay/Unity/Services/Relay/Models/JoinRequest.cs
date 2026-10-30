namespace Unity.Services.Relay.Models;

[DataContract(Name = "JoinRequest")]
[Preserve]
public class JoinRequest
{
	[CompilerGenerated]
	private readonly string <JoinCode>k__BackingField; //Field offset: 0x10

	[DataMember(Name = "joinCode", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public string JoinCode
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public JoinRequest(string joinCode) { }

	[CompilerGenerated]
	public string get_JoinCode() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

