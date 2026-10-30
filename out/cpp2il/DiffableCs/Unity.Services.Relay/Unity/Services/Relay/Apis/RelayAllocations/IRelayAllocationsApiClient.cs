namespace Unity.Services.Relay.Apis.RelayAllocations;

internal interface IRelayAllocationsApiClient
{

	public Task<Response`1<AllocateResponseBody>> CreateAllocationAsync(CreateAllocationRequest request, Configuration operationConfiguration = null) { }

	public Task<Response`1<JoinCodeResponseBody>> CreateJoincodeAsync(CreateJoincodeRequest request, Configuration operationConfiguration = null) { }

	public Task<Response`1<JoinResponseBody>> JoinRelayAsync(JoinRelayRequest request, Configuration operationConfiguration = null) { }

	public Task<Response`1<RegionsResponseBody>> ListRegionsAsync(ListRegionsRequest request, Configuration operationConfiguration = null) { }

}

