namespace Unity.Services.Relay.Models;

[DataContract(Name = "AllocateResponseBody")]
[Preserve]
public class AllocateResponseBody
{
	[CompilerGenerated]
	private readonly ResponseMeta <Meta>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly ResponseLinks <Links>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private readonly AllocationData <Data>k__BackingField; //Field offset: 0x20

	[DataMember(Name = "data", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public AllocationData Data
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "links", EmitDefaultValue = False)]
	[Preserve]
	public ResponseLinks Links
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "meta", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public ResponseMeta Meta
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public AllocateResponseBody(ResponseMeta meta, AllocationData data, ResponseLinks links = null) { }

	[CompilerGenerated]
	public AllocationData get_Data() { }

	[CompilerGenerated]
	public ResponseLinks get_Links() { }

	[CompilerGenerated]
	public ResponseMeta get_Meta() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

