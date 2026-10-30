namespace System.Net.NetworkInformation;

public class NetworkInformationException : Win32Exception
{

	public virtual int ErrorCode
	{
		 get { } //Length: 8
	}

	public NetworkInformationException() { }

	protected NetworkInformationException(SerializationInfo serializationInfo, StreamingContext streamingContext) { }

	public virtual int get_ErrorCode() { }

}

