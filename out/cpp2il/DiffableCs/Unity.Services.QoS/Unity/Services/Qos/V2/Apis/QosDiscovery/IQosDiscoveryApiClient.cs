namespace Unity.Services.Qos.V2.Apis.QosDiscovery;

internal interface IQosDiscoveryApiClient
{

	public Task<Response`1<QosServersResponseBody>> GetAllServersAsync(GetAllServersRequest request, Configuration operationConfiguration = null) { }

}

