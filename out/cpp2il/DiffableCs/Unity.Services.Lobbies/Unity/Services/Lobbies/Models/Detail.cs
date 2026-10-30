namespace Unity.Services.Lobbies.Models;

[DataContract(Name = "Detail")]
[Preserve]
public class Detail
{
	[CompilerGenerated]
	private readonly string <ErrorType>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly string <Message>k__BackingField; //Field offset: 0x18

	[DataMember(Name = "errorType", EmitDefaultValue = False)]
	[Preserve]
	public string ErrorType
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "message", EmitDefaultValue = False)]
	[Preserve]
	public string Message
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public Detail(string errorType = null, string message = null) { }

	[CompilerGenerated]
	public string get_ErrorType() { }

	[CompilerGenerated]
	public string get_Message() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

