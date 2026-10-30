namespace Unity.Services.Relay.Models;

[DataContract(Name = "JoinData")]
[Preserve]
public class JoinData
{
	[CompilerGenerated]
	private readonly JoinAllocation <Allocation>k__BackingField; //Field offset: 0x10

	[DataMember(Name = "allocation", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public JoinAllocation Allocation
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public JoinData(JoinAllocation allocation) { }

	[CompilerGenerated]
	public JoinAllocation get_Allocation() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

