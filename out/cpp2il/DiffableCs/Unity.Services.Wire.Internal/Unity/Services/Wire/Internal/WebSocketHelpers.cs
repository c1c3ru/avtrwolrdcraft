namespace Unity.Services.Wire.Internal;

internal static class WebSocketHelpers
{
	internal enum WebSocketErrorCode
	{
		InstanceNotFound = -1,
		AlreadyConnecting = -2,
		NotConnected = -3,
		AlreadyClosing = -4,
		AlreadyClosed = -5,
		NotOpen = -6,
		InvalidCloseParameters = -7,
	}


	public static WebSocketException GetErrorMessageFromCode(WebSocketErrorCode errorCode, Exception inner) { }

	public static WebSocketCloseCode ParseCloseCodeEnum(int closeCode) { }

}

