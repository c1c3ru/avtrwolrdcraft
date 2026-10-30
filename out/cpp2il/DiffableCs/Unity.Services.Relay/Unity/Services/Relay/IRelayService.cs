namespace Unity.Services.Relay;

public interface IRelayService
{

	public Task<Allocation> CreateAllocationAsync(int maxConnections, string region = null) { }

	public Task<String> GetJoinCodeAsync(Guid allocationId) { }

	public Task<JoinAllocation> JoinAllocationAsync(string joinCode) { }

	public Task<List`1<Region>> ListRegionsAsync() { }

}

