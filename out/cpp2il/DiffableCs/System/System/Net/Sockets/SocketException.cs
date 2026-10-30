namespace System.Net.Sockets;

public class SocketException : Win32Exception
{
	private EndPoint m_EndPoint; //Field offset: 0x90

	public virtual int ErrorCode
	{
		 get { } //Length: 8
	}

	public virtual string Message
	{
		 get { } //Length: 144
	}

	public SocketError SocketErrorCode
	{
		 get { } //Length: 8
	}

	public SocketException() { }

	internal SocketException(int error, string message) { }

	public SocketException(int errorCode) { }

	internal SocketException(SocketError socketError) { }

	protected SocketException(SerializationInfo serializationInfo, StreamingContext streamingContext) { }

	public virtual int get_ErrorCode() { }

	public virtual string get_Message() { }

	public SocketError get_SocketErrorCode() { }

	private static int WSAGetLastError_icall() { }

}

