namespace Unity.Services.Qos.V2.Http;

internal abstract class BaseApiClient
{
	protected readonly IHttpClient HttpClient; //Field offset: 0x10

	public BaseApiClient(IHttpClient httpClient) { }

}

