namespace Unity.Services.Lobbies.Models;

[DataContract(Name = "QueryFilter")]
[Preserve]
public class QueryFilter
{
	[JsonConverter(typeof(StringEnumConverter))]
	[Preserve]
	internal enum FieldOptions
	{
		MaxPlayers = 1,
		AvailableSlots = 2,
		Name = 3,
		Created = 4,
		LastUpdated = 5,
		S1 = 6,
		S2 = 7,
		S3 = 8,
		S4 = 9,
		S5 = 10,
		N1 = 11,
		N2 = 12,
		N3 = 13,
		N4 = 14,
		N5 = 15,
		IsLocked = 16,
		HasPassword = 17,
	}

	[JsonConverter(typeof(StringEnumConverter))]
	[Preserve]
	internal enum OpOptions
	{
		CONTAINS = 1,
		EQ = 2,
		NE = 3,
		LT = 4,
		LE = 5,
		GT = 6,
		GE = 7,
	}

	[CompilerGenerated]
	private readonly FieldOptions <Field>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly string <Value>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private readonly OpOptions <Op>k__BackingField; //Field offset: 0x20

	[DataMember(Name = "field", IsRequired = True, EmitDefaultValue = True)]
	[JsonConverter(typeof(StringEnumConverter))]
	[Preserve]
	public FieldOptions Field
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "op", IsRequired = True, EmitDefaultValue = True)]
	[JsonConverter(typeof(StringEnumConverter))]
	[Preserve]
	public OpOptions Op
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
	public QueryFilter(FieldOptions field, string value, OpOptions op) { }

	[CompilerGenerated]
	public FieldOptions get_Field() { }

	[CompilerGenerated]
	public OpOptions get_Op() { }

	[CompilerGenerated]
	public string get_Value() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

