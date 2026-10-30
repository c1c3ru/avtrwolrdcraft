namespace Unity.Services.Relay.Http;

internal class DeserializationException : Exception
{

	public DeserializationException() { }

	public DeserializationException(string message) { }

	private DeserializationException(string message, Exception inner) { }

}

