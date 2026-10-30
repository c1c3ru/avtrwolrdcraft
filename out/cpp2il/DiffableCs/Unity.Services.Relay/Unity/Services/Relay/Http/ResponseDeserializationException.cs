namespace Unity.Services.Relay.Http;

internal class ResponseDeserializationException : Exception
{
	public HttpClientResponse response; //Field offset: 0x90

	public ResponseDeserializationException() { }

	public ResponseDeserializationException(string message) { }

	private ResponseDeserializationException(Exception inner, string message) { }

	public ResponseDeserializationException(HttpClientResponse httpClientResponse) { }

	public ResponseDeserializationException(HttpClientResponse httpClientResponse, string message) { }

	public ResponseDeserializationException(HttpClientResponse httpClientResponse, Exception inner, string message) { }

}

