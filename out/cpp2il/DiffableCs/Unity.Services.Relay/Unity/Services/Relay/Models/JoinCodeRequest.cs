namespace Unity.Services.Relay.Models;

[DataContract(Name = "JoinCodeRequest")]
[Preserve]
public class JoinCodeRequest
{
	[CompilerGenerated]
	private readonly Guid <AllocationId>k__BackingField; //Field offset: 0x10

	[DataMember(Name = "allocationId", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public Guid AllocationId
	{
		[CompilerGenerated]
		 get { } //Length: 12
	}

	[Preserve]
	public JoinCodeRequest(Guid allocationId) { }

	[CompilerGenerated]
	public Guid get_AllocationId() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

