namespace Unity.Services.Qos.V2.Models;

[DataContract(Name = "ErrorResponseBody")]
[Preserve]
internal class ErrorResponseBody
{
	[CompilerGenerated]
	private readonly string <Type>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly string <Title>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private readonly int <Status>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private readonly int <Code>k__BackingField; //Field offset: 0x24
	[CompilerGenerated]
	private readonly string <Detail>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private readonly string <Instance>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private readonly List<IDeserializable> <Details>k__BackingField; //Field offset: 0x38

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
	public List<IDeserializable> Details
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "instance", EmitDefaultValue = False)]
	[Preserve]
	public string Instance
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
	public ErrorResponseBody(string type, string title, int status, int code, string detail, string instance = null, List<Object> details = null) { }

	[CompilerGenerated]
	public int get_Code() { }

	[CompilerGenerated]
	public string get_Detail() { }

	[CompilerGenerated]
	public List<IDeserializable> get_Details() { }

	[CompilerGenerated]
	public string get_Instance() { }

	[CompilerGenerated]
	public int get_Status() { }

	[CompilerGenerated]
	public string get_Title() { }

	[CompilerGenerated]
	public string get_Type() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

