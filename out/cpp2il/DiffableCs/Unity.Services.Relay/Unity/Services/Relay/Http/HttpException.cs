namespace Unity.Services.Relay.Http;

[Preserve]
internal class HttpException : Exception
{
	[Preserve]
	public HttpClientResponse Response; //Field offset: 0x90

	[Preserve]
	public HttpException() { }

	[Preserve]
	public HttpException(string message) { }

	[Preserve]
	public HttpException(string message, Exception inner) { }

	[Preserve]
	public HttpException(HttpClientResponse response) { }

}

