namespace Unity.Services.Relay.RelayAllocations;

[Preserve]
internal class JoinRelayRequest : RelayAllocationsApiBaseRequest
{
	[CompilerGenerated]
	private readonly JoinRequest <JoinRequest>k__BackingField; //Field offset: 0x10
	private string PathAndQueryParams; //Field offset: 0x18

	[Preserve]
	public JoinRequest JoinRequest
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public JoinRelayRequest(JoinRequest joinRequest) { }

	public Byte[] ConstructBody() { }

	public Dictionary<String, String> ConstructHeaders(IAccessToken accessToken, Configuration operationConfiguration = null) { }

	public string ConstructUrl(string requestBasePath) { }

	[CompilerGenerated]
	public JoinRequest get_JoinRequest() { }

}

