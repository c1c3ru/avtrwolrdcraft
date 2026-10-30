namespace Unity.Services.Qos.V2.Http;

internal class DeserializationException : Exception
{

	public DeserializationException() { }

	public DeserializationException(string message) { }

	private DeserializationException(string message, Exception inner) { }

}

