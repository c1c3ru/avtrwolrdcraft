namespace Unity.Services.Lobbies.Models;

[DataContract(Name = "QueryResponse")]
[Preserve]
public class QueryResponse
{
	[CompilerGenerated]
	private readonly List<Lobby> <Results>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly string <ContinuationToken>k__BackingField; //Field offset: 0x18

	[DataMember(Name = "continuationToken", EmitDefaultValue = False)]
	[Preserve]
	public string ContinuationToken
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "results", EmitDefaultValue = False)]
	[Preserve]
	public List<Lobby> Results
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public QueryResponse(List<Lobby> results = null, string continuationToken = null) { }

	[CompilerGenerated]
	public string get_ContinuationToken() { }

	[CompilerGenerated]
	public List<Lobby> get_Results() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

