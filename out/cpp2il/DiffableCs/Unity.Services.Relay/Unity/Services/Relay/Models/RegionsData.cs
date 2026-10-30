namespace Unity.Services.Relay.Models;

[DataContract(Name = "RegionsData")]
[Preserve]
public class RegionsData
{
	[CompilerGenerated]
	private readonly List<Region> <Regions>k__BackingField; //Field offset: 0x10

	[DataMember(Name = "regions", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public List<Region> Regions
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public RegionsData(List<Region> regions) { }

	[CompilerGenerated]
	public List<Region> get_Regions() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

