namespace Unity.Services.Wire.Internal;

internal class WebSocketUnexpectedException : WebSocketException
{

	public WebSocketUnexpectedException() { }

	public WebSocketUnexpectedException(string message) { }

	public WebSocketUnexpectedException(string message, Exception inner) { }

}

