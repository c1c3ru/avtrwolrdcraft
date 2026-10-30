namespace Unity.Services.Lobbies.Http;

public class DeserializationException : Exception
{

	public DeserializationException() { }

	public DeserializationException(string message) { }

	private DeserializationException(string message, Exception inner) { }

}

