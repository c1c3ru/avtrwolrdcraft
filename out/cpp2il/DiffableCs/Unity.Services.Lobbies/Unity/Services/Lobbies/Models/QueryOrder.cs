namespace Unity.Services.Lobbies.Models;

[DataContract(Name = "QueryOrder")]
[Preserve]
public class QueryOrder
{
	[JsonConverter(typeof(StringEnumConverter))]
	[Preserve]
	internal enum FieldOptions
	{
		Name = 1,
		MaxPlayers = 2,
		AvailableSlots = 3,
		Created = 4,
		LastUpdated = 5,
		ID = 6,
		S1 = 7,
		S2 = 8,
		S3 = 9,
		S4 = 10,
		S5 = 11,
		N1 = 12,
		N2 = 13,
		N3 = 14,
		N4 = 15,
		N5 = 16,
	}

	[CompilerGenerated]
	private readonly bool <Asc>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly FieldOptions <Field>k__BackingField; //Field offset: 0x14

	[DataMember(Name = "asc", EmitDefaultValue = True)]
	[Preserve]
	public bool Asc
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "field", EmitDefaultValue = False)]
	[JsonConverter(typeof(StringEnumConverter))]
	[Preserve]
	public FieldOptions Field
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public QueryOrder(bool asc = false, FieldOptions field = 0) { }

	[CompilerGenerated]
	public bool get_Asc() { }

	[CompilerGenerated]
	public FieldOptions get_Field() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

