namespace Unity.Services.Relay.Models;

[DataContract(Name = "KeyValuePair")]
[Preserve]
public class KeyValuePair
{
	[CompilerGenerated]
	private readonly string <Key>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly string <Value>k__BackingField; //Field offset: 0x18

	[DataMember(Name = "key", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public string Key
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "value", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public string Value
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public KeyValuePair(string key, string value) { }

	[CompilerGenerated]
	public string get_Key() { }

	[CompilerGenerated]
	public string get_Value() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

