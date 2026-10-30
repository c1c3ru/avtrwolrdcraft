namespace Unity.Services.Authentication.Generated;

[DataContract(Name = "UpdateNameRequest")]
[Preserve]
internal class UpdateNameRequest
{
	[CompilerGenerated]
	private string <Name>k__BackingField; //Field offset: 0x10

	[DataMember(Name = "name", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public string Name
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	[Preserve]
	public UpdateNameRequest(string name = null) { }

	[CompilerGenerated]
	public string get_Name() { }

	[CompilerGenerated]
	public void set_Name(string value) { }

}

