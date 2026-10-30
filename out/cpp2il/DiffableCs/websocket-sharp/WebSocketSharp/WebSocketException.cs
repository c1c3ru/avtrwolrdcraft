namespace WebSocketSharp;

public class WebSocketException : Exception
{
	private CloseStatusCode _code; //Field offset: 0x8C

	public CloseStatusCode Code
	{
		 get { } //Length: 8
	}

	internal WebSocketException() { }

	internal WebSocketException(Exception innerException) { }

	internal WebSocketException(string message) { }

	internal WebSocketException(CloseStatusCode code) { }

	internal WebSocketException(string message, Exception innerException) { }

	internal WebSocketException(CloseStatusCode code, Exception innerException) { }

	internal WebSocketException(CloseStatusCode code, string message) { }

	internal WebSocketException(CloseStatusCode code, string message, Exception innerException) { }

	public CloseStatusCode get_Code() { }

}

