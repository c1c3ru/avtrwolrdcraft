namespace WebSocketSharp.Net;

public class CookieException : FormatException, ISerializable
{

	internal CookieException(string message) { }

	internal CookieException(string message, Exception innerException) { }

	protected CookieException(SerializationInfo serializationInfo, StreamingContext streamingContext) { }

	public CookieException() { }

	public virtual void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext) { }

	private override void System.Runtime.Serialization.ISerializable.GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext) { }

}

