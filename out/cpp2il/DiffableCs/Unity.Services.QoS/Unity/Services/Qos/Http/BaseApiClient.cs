namespace Unity.Services.Qos.Http;

internal abstract class BaseApiClient
{
	protected readonly IHttpClient HttpClient; //Field offset: 0x10

	public BaseApiClient(IHttpClient httpClient) { }

}

