namespace Unity.Services.Authentication.Generated;

[DataContract(Name = "ErrorStatus")]
[Preserve]
internal class ErrorStatus
{
	[CompilerGenerated]
	private int <Status>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private string <Title>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private string <Detail>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private int <Code>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private List<Detail> <Details>k__BackingField; //Field offset: 0x30

	[DataMember(Name = "code", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public int Code
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	[DataMember(Name = "detail", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public string Detail
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	[DataMember(Name = "details", EmitDefaultValue = False)]
	[Preserve]
	public List<Detail> Details
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	[DataMember(Name = "status", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public int Status
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	[DataMember(Name = "title", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public string Title
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	[Preserve]
	public ErrorStatus(int status = 0, string title = null, string detail = null, int code = 0, List<Detail> details = null) { }

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
	public void set_Code(int value) { }

	[CompilerGenerated]
	public void set_Detail(string value) { }

	[CompilerGenerated]
	public void set_Details(List<Detail> value) { }

	[CompilerGenerated]
	public void set_Status(int value) { }

	[CompilerGenerated]
	public void set_Title(string value) { }

}

