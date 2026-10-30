namespace Unity.Services.Qos;

public interface IQosService
{

	public Task<IList`1<QosServer>> GetAllServersAsync() { }

	public Task<IList`1<ValueTuple`2<QosServer, IQosMeasurements>>> GetQosResultsAsync(IList<QosServer> servers) { }

	public Task<IList`1<IQosAnnotatedResult>> GetSortedMultiplayQosResultsAsync(IList<String> fleet) { }

	public Task<IList`1<IQosResult>> GetSortedQosResultsAsync(string service, IList<String> regions) { }

	public Task<IList`1<IQosAnnotatedResult>> GetSortedRelayQosResultsAsync(IList<String> regions) { }

}

