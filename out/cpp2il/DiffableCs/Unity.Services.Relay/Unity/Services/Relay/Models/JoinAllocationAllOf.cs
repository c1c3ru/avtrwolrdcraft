namespace Unity.Services.Relay.Models;

[DataContract(Name = "JoinAllocation_allOf")]
[Preserve]
public class JoinAllocationAllOf
{
	[CompilerGenerated]
	private readonly Byte[] <HostConnectionData>k__BackingField; //Field offset: 0x10

	[DataMember(Name = "hostConnectionData", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public Byte[] HostConnectionData
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public JoinAllocationAllOf(Byte[] hostConnectionData) { }

	[CompilerGenerated]
	public Byte[] get_HostConnectionData() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

