namespace Unity.Services.Relay.Models;

[DataContract(Name = "JoinResponseBody")]
[Preserve]
public class JoinResponseBody
{
	[CompilerGenerated]
	private readonly ResponseMeta <Meta>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly JoinData <Data>k__BackingField; //Field offset: 0x18

	[DataMember(Name = "data", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public JoinData Data
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
	public JoinResponseBody(ResponseMeta meta, JoinData data) { }

	[CompilerGenerated]
	public JoinData get_Data() { }

	[CompilerGenerated]
	public ResponseMeta get_Meta() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

