namespace Unity.Services.Relay.Models;

[DataContract(Name = "ErrorResponseBody")]
[Preserve]
public class ErrorResponseBody
{
	[CompilerGenerated]
	private readonly int <Status>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly string <Detail>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private readonly string <Title>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private readonly List<KeyValuePair> <Details>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private readonly string <Type>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private readonly int <Code>k__BackingField; //Field offset: 0x38

	[DataMember(Name = "code", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public int Code
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "detail", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public string Detail
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "details", EmitDefaultValue = False)]
	[Preserve]
	public List<KeyValuePair> Details
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

	[DataMember(Name = "title", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public string Title
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "type", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public string Type
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public ErrorResponseBody(int status, string detail, string title, string type, int code, List<KeyValuePair> details = null) { }

	[CompilerGenerated]
	public int get_Code() { }

	[CompilerGenerated]
	public string get_Detail() { }

	[CompilerGenerated]
	public List<KeyValuePair> get_Details() { }

	[CompilerGenerated]
	public int get_Status() { }

	[CompilerGenerated]
	public string get_Title() { }

	[CompilerGenerated]
	public string get_Type() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

