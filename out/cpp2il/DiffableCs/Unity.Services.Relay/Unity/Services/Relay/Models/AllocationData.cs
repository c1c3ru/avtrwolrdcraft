namespace Unity.Services.Relay.Models;

[DataContract(Name = "AllocationData")]
[Preserve]
public class AllocationData
{
	[CompilerGenerated]
	private readonly Allocation <Allocation>k__BackingField; //Field offset: 0x10

	[DataMember(Name = "allocation", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public Allocation Allocation
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public AllocationData(Allocation allocation) { }

	[CompilerGenerated]
	public Allocation get_Allocation() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

