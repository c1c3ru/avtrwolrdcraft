namespace System;

public class UnauthorizedAccessException : SystemException
{

	public UnauthorizedAccessException() { }

	public UnauthorizedAccessException(string message) { }

	public UnauthorizedAccessException(string message, Exception inner) { }

	protected UnauthorizedAccessException(SerializationInfo info, StreamingContext context) { }

}

