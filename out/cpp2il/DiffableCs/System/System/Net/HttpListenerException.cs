namespace System.Net;

public class HttpListenerException : Win32Exception
{

	public virtual int ErrorCode
	{
		 get { } //Length: 8
	}

	public HttpListenerException() { }

	public HttpListenerException(int errorCode, string message) { }

	protected HttpListenerException(SerializationInfo serializationInfo, StreamingContext streamingContext) { }

	public virtual int get_ErrorCode() { }

}

