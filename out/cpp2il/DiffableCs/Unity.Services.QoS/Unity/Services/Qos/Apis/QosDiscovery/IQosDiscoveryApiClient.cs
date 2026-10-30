namespace Unity.Services.Qos.Apis.QosDiscovery;

internal interface IQosDiscoveryApiClient
{

	public Task<Response`1<QosServersResponseBody>> GetServersAsync(GetServersRequest request, Configuration operationConfiguration = null) { }

	public Task<Response`1<QosServiceServersResponseBody>> GetServiceServersAsync(GetServiceServersRequest request, Configuration operationConfiguration = null) { }

}

