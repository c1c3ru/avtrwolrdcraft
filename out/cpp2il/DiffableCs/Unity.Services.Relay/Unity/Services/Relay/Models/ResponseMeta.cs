namespace Unity.Services.Relay.Models;

[DataContract(Name = "ResponseMeta")]
[Preserve]
public class ResponseMeta
{
	[CompilerGenerated]
	private readonly string <RequestId>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly int <Status>k__BackingField; //Field offset: 0x18

	[DataMember(Name = "requestId", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public string RequestId
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "status", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public int Status
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public ResponseMeta(string requestId, int status) { }

	[CompilerGenerated]
	public string get_RequestId() { }

	[CompilerGenerated]
	public int get_Status() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

