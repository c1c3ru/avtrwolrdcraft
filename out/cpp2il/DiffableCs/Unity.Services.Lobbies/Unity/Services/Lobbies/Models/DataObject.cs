namespace Unity.Services.Lobbies.Models;

[DataContract(Name = "DataObject")]
[Preserve]
public class DataObject
{
	[JsonConverter(typeof(StringEnumConverter))]
	[Preserve]
	internal enum IndexOptions
	{
		S1 = 1,
		S2 = 2,
		S3 = 3,
		S4 = 4,
		S5 = 5,
		N1 = 6,
		N2 = 7,
		N3 = 8,
		N4 = 9,
		N5 = 10,
	}

	[JsonConverter(typeof(StringEnumConverter))]
	[Preserve]
	internal enum VisibilityOptions
	{
		Public = 1,
		Member = 2,
		Private = 3,
	}

	[CompilerGenerated]
	private readonly string <Value>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly VisibilityOptions <Visibility>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private readonly IndexOptions <Index>k__BackingField; //Field offset: 0x1C

	[DataMember(Name = "index", EmitDefaultValue = False)]
	[JsonConverter(typeof(StringEnumConverter))]
	[Preserve]
	public IndexOptions Index
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "value", EmitDefaultValue = False)]
	[Preserve]
	public string Value
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "visibility", IsRequired = True, EmitDefaultValue = True)]
	[JsonConverter(typeof(StringEnumConverter))]
	[Preserve]
	public VisibilityOptions Visibility
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public DataObject(VisibilityOptions visibility, string value = null, IndexOptions index = 0) { }

	[CompilerGenerated]
	public IndexOptions get_Index() { }

	[CompilerGenerated]
	public string get_Value() { }

	[CompilerGenerated]
	public VisibilityOptions get_Visibility() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

