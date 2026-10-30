namespace Unity.Services.Relay.RelayAllocations;

[Preserve]
internal class ListRegionsRequest : RelayAllocationsApiBaseRequest
{
	private string PathAndQueryParams; //Field offset: 0x10

	[Preserve]
	public ListRegionsRequest() { }

	public Byte[] ConstructBody() { }

	public Dictionary<String, String> ConstructHeaders(IAccessToken accessToken, Configuration operationConfiguration = null) { }

	public string ConstructUrl(string requestBasePath) { }

}

