namespace Unity.Services.Lobbies.Models;

[DataContract(Name = "QueryRequest")]
[Preserve]
public class QueryRequest
{
	[CompilerGenerated]
	private readonly Nullable<Int32> <Count>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly Nullable<Int32> <Skip>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private readonly bool <SampleResults>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private readonly List<QueryFilter> <Filter>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private readonly List<QueryOrder> <Order>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private readonly string <ContinuationToken>k__BackingField; //Field offset: 0x38

	[DataMember(Name = "continuationToken", EmitDefaultValue = False)]
	[Preserve]
	public string ContinuationToken
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "count", EmitDefaultValue = False)]
	[Preserve]
	public Nullable<Int32> Count
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "filter", EmitDefaultValue = False)]
	[Preserve]
	public List<QueryFilter> Filter
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "order", EmitDefaultValue = False)]
	[Preserve]
	public List<QueryOrder> Order
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "sampleResults", EmitDefaultValue = True)]
	[Preserve]
	public bool SampleResults
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "skip", EmitDefaultValue = False)]
	[Preserve]
	public Nullable<Int32> Skip
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public QueryRequest(Nullable<Int32> count = null, Nullable<Int32> skip = null, bool sampleResults = false, List<QueryFilter> filter = null, List<QueryOrder> order = null, string continuationToken = null) { }

	[CompilerGenerated]
	public string get_ContinuationToken() { }

	[CompilerGenerated]
	public Nullable<Int32> get_Count() { }

	[CompilerGenerated]
	public List<QueryFilter> get_Filter() { }

	[CompilerGenerated]
	public List<QueryOrder> get_Order() { }

	[CompilerGenerated]
	public bool get_SampleResults() { }

	[CompilerGenerated]
	public Nullable<Int32> get_Skip() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

