namespace Unity.Services.Lobbies.Models;

[DataContract(Name = "ErrorStatus")]
[Preserve]
public class ErrorStatus
{
	[CompilerGenerated]
	private readonly string <Type>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly int <Status>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private readonly string <Title>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private readonly string <Detail>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private readonly int <Code>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private readonly List<Detail> <Details>k__BackingField; //Field offset: 0x38

	[DataMember(Name = "code", EmitDefaultValue = False)]
	[Preserve]
	public int Code
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "detail", EmitDefaultValue = False)]
	[Preserve]
	public string Detail
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "details", EmitDefaultValue = False)]
	[Preserve]
	public List<Detail> Details
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "status", EmitDefaultValue = False)]
	[Preserve]
	public int Status
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "title", EmitDefaultValue = False)]
	[Preserve]
	public string Title
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "type", EmitDefaultValue = False)]
	[Preserve]
	public string Type
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public ErrorStatus(string type = null, int status = 0, string title = null, string detail = null, int code = 0, List<Detail> details = null) { }

	[CompilerGenerated]
	public int get_Code() { }

	[CompilerGenerated]
	public string get_Detail() { }

	[CompilerGenerated]
	public List<Detail> get_Details() { }

	[CompilerGenerated]
	public int get_Status() { }

	[CompilerGenerated]
	public string get_Title() { }

	[CompilerGenerated]
	public string get_Type() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

