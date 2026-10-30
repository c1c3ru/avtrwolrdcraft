namespace Unity.Services.Relay.Models;

[DataContract(Name = "Region")]
[Preserve]
public class Region
{
	[CompilerGenerated]
	private readonly string <Id>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly string <Description>k__BackingField; //Field offset: 0x18

	[DataMember(Name = "description", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public string Description
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "id", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public string Id
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public Region(string id, string description) { }

	[CompilerGenerated]
	public string get_Description() { }

	[CompilerGenerated]
	public string get_Id() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

