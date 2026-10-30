namespace System.IO;

public sealed class InvalidDataException : SystemException
{

	public InvalidDataException() { }

	public InvalidDataException(string message) { }

	public InvalidDataException(string message, Exception innerException) { }

	private InvalidDataException(SerializationInfo info, StreamingContext context) { }

}

