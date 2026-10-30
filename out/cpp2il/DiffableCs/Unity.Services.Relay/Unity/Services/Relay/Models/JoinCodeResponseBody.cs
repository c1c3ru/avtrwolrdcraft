namespace Unity.Services.Relay.Models;

[DataContract(Name = "JoinCodeResponseBody")]
[Preserve]
public class JoinCodeResponseBody
{
	[CompilerGenerated]
	private readonly ResponseMeta <Meta>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly ResponseLinks <Links>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private readonly JoinCodeData <Data>k__BackingField; //Field offset: 0x20

	[DataMember(Name = "data", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public JoinCodeData Data
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "links", IsRequired = True, EmitDefaultValue = True)]
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
	public JoinCodeResponseBody(ResponseMeta meta, ResponseLinks links, JoinCodeData data) { }

	[CompilerGenerated]
	public JoinCodeData get_Data() { }

	[CompilerGenerated]
	public ResponseLinks get_Links() { }

	[CompilerGenerated]
	public ResponseMeta get_Meta() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

