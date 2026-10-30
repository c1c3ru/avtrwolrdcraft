namespace WebSocketSharp.Net;

public class HttpListenerException : Win32Exception
{

	public virtual int ErrorCode
	{
		 get { } //Length: 8
	}

	protected HttpListenerException(SerializationInfo serializationInfo, StreamingContext streamingContext) { }

	public HttpListenerException() { }

	public HttpListenerException(int errorCode) { }

	public HttpListenerException(int errorCode, string message) { }

	public virtual int get_ErrorCode() { }

}

