namespace Unity.Services.Authentication.Generated;

[DataContract(Name = "Detail")]
[Preserve]
internal class Detail
{
	[CompilerGenerated]
	private string <ErrorType>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private string <Message>k__BackingField; //Field offset: 0x18

	[DataMember(Name = "errorType", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public string ErrorType
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	[DataMember(Name = "message", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public string Message
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	[Preserve]
	public Detail(string errorType = null, string message = null) { }

	[CompilerGenerated]
	public string get_ErrorType() { }

	[CompilerGenerated]
	public string get_Message() { }

	[CompilerGenerated]
	public void set_ErrorType(string value) { }

	[CompilerGenerated]
	public void set_Message(string value) { }

}

