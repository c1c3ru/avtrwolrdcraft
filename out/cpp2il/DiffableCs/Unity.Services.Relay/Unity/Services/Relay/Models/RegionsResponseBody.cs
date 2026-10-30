namespace Unity.Services.Relay.Models;

[DataContract(Name = "RegionsResponseBody")]
[Preserve]
public class RegionsResponseBody
{
	[CompilerGenerated]
	private readonly RegionsData <Data>k__BackingField; //Field offset: 0x10

	[DataMember(Name = "data", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public RegionsData Data
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public RegionsResponseBody(RegionsData data) { }

	[CompilerGenerated]
	public RegionsData get_Data() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

