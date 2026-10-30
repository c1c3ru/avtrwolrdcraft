namespace UnityWebSocketSharp;

internal class WebSocketException : Exception
{
	private ushort _code; //Field offset: 0x8C

	public ushort Code
	{
		 get { } //Length: 8
	}

	private WebSocketException(ushort code, string message, Exception innerException) { }

	internal WebSocketException() { }

	internal WebSocketException(Exception innerException) { }

	internal WebSocketException(string message) { }

	internal WebSocketException(CloseStatusCode code) { }

	internal WebSocketException(string message, Exception innerException) { }

	internal WebSocketException(CloseStatusCode code, Exception innerException) { }

	internal WebSocketException(CloseStatusCode code, string message) { }

	internal WebSocketException(CloseStatusCode code, string message, Exception innerException) { }

	public ushort get_Code() { }

}

