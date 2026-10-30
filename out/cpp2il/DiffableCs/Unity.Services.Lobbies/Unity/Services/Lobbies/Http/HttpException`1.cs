namespace Unity.Services.Lobbies.Http;

[Preserve]
internal class HttpException : HttpException
{
	[Preserve]
	public T ActualError; //Field offset: 0x0

	[Preserve]
	public HttpException`1() { }

	[Preserve]
	public HttpException`1(string message) { }

	[Preserve]
	public HttpException`1(string message, Exception inner) { }

	[Preserve]
	public HttpException`1(HttpClientResponse response, T actualError) { }

}

