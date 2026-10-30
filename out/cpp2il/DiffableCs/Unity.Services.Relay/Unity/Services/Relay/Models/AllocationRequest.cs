namespace Unity.Services.Relay.Models;

[DataContract(Name = "AllocationRequest")]
[Preserve]
public class AllocationRequest
{
	[CompilerGenerated]
	private readonly int <MaxConnections>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly string <Region>k__BackingField; //Field offset: 0x18

	[DataMember(Name = "maxConnections", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public int MaxConnections
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "region", EmitDefaultValue = False)]
	[Preserve]
	public string Region
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public AllocationRequest(int maxConnections, string region = null) { }

	[CompilerGenerated]
	public int get_MaxConnections() { }

	[CompilerGenerated]
	public string get_Region() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

