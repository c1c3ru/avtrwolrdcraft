namespace Unity.Services.Relay.RelayAllocations;

[Preserve]
internal class CreateAllocationRequest : RelayAllocationsApiBaseRequest
{
	[CompilerGenerated]
	private readonly AllocationRequest <AllocationRequest>k__BackingField; //Field offset: 0x10
	private string PathAndQueryParams; //Field offset: 0x18

	[Preserve]
	public AllocationRequest AllocationRequest
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public CreateAllocationRequest(AllocationRequest allocationRequest) { }

	public Byte[] ConstructBody() { }

	public Dictionary<String, String> ConstructHeaders(IAccessToken accessToken, Configuration operationConfiguration = null) { }

	public string ConstructUrl(string requestBasePath) { }

	[CompilerGenerated]
	public AllocationRequest get_AllocationRequest() { }

}

