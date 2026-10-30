namespace Unity.Services.Lobbies.Models;

[DataContract(Name = "PlayerDataObject")]
[Preserve]
public class PlayerDataObject
{
	[JsonConverter(typeof(StringEnumConverter))]
	[Preserve]
	internal enum VisibilityOptions
	{
		Public = 1,
		Member = 2,
		Private = 3,
	}

	[CompilerGenerated]
	private string <Value>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private VisibilityOptions <Visibility>k__BackingField; //Field offset: 0x18

	[DataMember(Name = "value", EmitDefaultValue = False)]
	[Preserve]
	public string Value
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	[DataMember(Name = "visibility", IsRequired = True, EmitDefaultValue = True)]
	[JsonConverter(typeof(StringEnumConverter))]
	[Preserve]
	public internal VisibilityOptions Visibility
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	[Preserve]
	public PlayerDataObject(VisibilityOptions visibility, string value = null) { }

	[CompilerGenerated]
	public string get_Value() { }

	[CompilerGenerated]
	public VisibilityOptions get_Visibility() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

	[CompilerGenerated]
	public void set_Value(string value) { }

	[CompilerGenerated]
	internal void set_Visibility(VisibilityOptions value) { }

}

