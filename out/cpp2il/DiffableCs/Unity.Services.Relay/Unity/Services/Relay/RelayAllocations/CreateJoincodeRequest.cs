namespace Unity.Services.Relay.RelayAllocations;

[Preserve]
internal class CreateJoincodeRequest : RelayAllocationsApiBaseRequest
{
	[CompilerGenerated]
	private readonly JoinCodeRequest <JoinCodeRequest>k__BackingField; //Field offset: 0x10
	private string PathAndQueryParams; //Field offset: 0x18

	[Preserve]
	public JoinCodeRequest JoinCodeRequest
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public CreateJoincodeRequest(JoinCodeRequest joinCodeRequest) { }

	public Byte[] ConstructBody() { }

	public Dictionary<String, String> ConstructHeaders(IAccessToken accessToken, Configuration operationConfiguration = null) { }

	public string ConstructUrl(string requestBasePath) { }

	[CompilerGenerated]
	public JoinCodeRequest get_JoinCodeRequest() { }

}

