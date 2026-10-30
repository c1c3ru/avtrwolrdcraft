namespace Unity.Services.Relay.Models;

[DataContract(Name = "ResponseLinks")]
[Preserve]
public class ResponseLinks
{
	[CompilerGenerated]
	private readonly string <Next>k__BackingField; //Field offset: 0x10

	[DataMember(Name = "next", EmitDefaultValue = False)]
	[Preserve]
	public string Next
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public ResponseLinks(string next = null) { }

	[CompilerGenerated]
	public string get_Next() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

