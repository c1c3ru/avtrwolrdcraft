namespace Unity.Services.Qos.Http;

internal interface IHttpClient
{

	public Task<HttpClientResponse> MakeRequestAsync(string method, string url, Byte[] body, Dictionary<String, String> headers, int requestTimeout) { }

	public Task<HttpClientResponse> MakeRequestAsync(string method, string url, List<IMultipartFormSection> body, Dictionary<String, String> headers, int requestTimeout, string boundary = null) { }

}

